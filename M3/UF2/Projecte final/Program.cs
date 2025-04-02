using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

class Program
{
    static void Main()
    {
        SlotMachine game = new SlotMachine();
        game.StartGame();
    }
}

class SlotMachine
{
    private List<Order> orders = new List<Order>();
    private List<string> history = new List<string>();
    private int totalPoints = 0; // Los puntos se reinician a 0 por cada partida
    private int jackpotCount = 0; // Para contar cuántos Jackpots obtuvo el jugador
    private static readonly Random random = new Random();
    private static readonly string[] models = { "R2D2", "C3PO", "BB8" };
    private string playerName;

    public void StartGame()
    {
        Console.Write("Ingrese su nombre: ");
        playerName = Console.ReadLine();
        StartMenu();
    }

    public void StartMenu()
    {
        bool playing = true;
        while (playing)
        {
            Console.Clear();

            Console.WriteLine(@"
🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖
🤖  _____   ____              _____          __  __ ____  _      _____ _   _  _____  🤖
🤖 |  __ \ / __ \            / ____|   /\   |  \/  |  _ \| |    |_   _| \ | |/ ____| 🤖
🤖 | |__) | |  | |  ______  | |  __   /  \  | \  / | |_) | |      | | |  \| | |  __  🤖
🤖 |  _  /| |  | | |______| | | |_ | / /\ \ | |\/| |  _ <| |      | | | . ` | | |_ | 🤖
🤖 | | \ \| |__| |          | |__| |/ ____ \| |  | | |_) | |____ _| |_| |\  | |__| | 🤖
🤖 |_|  \_\\____/            \_____/_/    \_\_|  |_|____/|______|_____|_| \_|\_____| 🤖
🤖                                                                                   🤖
🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖🤖                                                                           

            ");
            Console.WriteLine("1 - Tirar (10 veces)");
            Console.WriteLine("2 - Ver ranking");
            Console.WriteLine("3 - Ver historial");
            Console.WriteLine("4 - Cambiar de jugador");
            Console.WriteLine("5 - Salir");
            Console.Write("Seleccione una opción: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": Play(); break;
                case "2": ShowRanking(); break;
                case "3": ShowHistory(); break;
                case "4": StartGame(); break;
                case "5": playing = false; break;
                default: Console.WriteLine("Opción inválida, intente nuevamente."); break;
            }
        }
    }

    public void Play()
    {
        totalPoints = 0;  // Reinicia los puntos al inicio de cada partida.
        jackpotCount = 0; // Reinicia el contador de Jackpots al inicio de cada partida.
        Console.Clear();
        for (int i = 0; i < 10; i++)
        {
            List<string> roll = Spin();
            EvaluateRoll(roll);
            Thread.Sleep(500);
        }
        SaveResults();
    }

    private List<string> Spin()
    {
        List<string> result = new List<string>
        {
            models[random.Next(models.Length)],
            models[random.Next(models.Length)],
            models[random.Next(models.Length)]
        };

        string rollResult = $"[ {result[0]} ] [ {result[1]} ] [ {result[2]} ]";
        Console.WriteLine(rollResult);
        history.Add(rollResult);
        return result;
    }

    private void EvaluateRoll(List<string> roll)
{
    var grouped = roll.GroupBy(x => x).ToList();
    int points = grouped.Max(g => g.Count()) switch
    {
        3 => 10,
        2 => 5,
        _ => 0
    };

    if (grouped.Any(g => g.Count() == 3))
    {
        ShowJackpot(jackpotCount); // Muestra Jackpot
        jackpotCount++; // Incrementa el contador de Jackpots
    }
    else if (grouped.Any(g => g.Count() == 2))
    {
        ShowDouble(); // Muestra "Double!"
    }

    totalPoints += points;
    GenerateOrder(roll);
}

private void ShowDouble()
{
    string doubleMessage = "🎉🎉 DOUBLE! 🎉🎉";

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{doubleMessage}");
    

    Console.ResetColor();
}

    private void ShowJackpot(int jackpotCount)
    {
        string jackpotMessage = string.Empty;
        
        // Seleccionamos el mensaje dependiendo de la cantidad de Jackpots
        switch (jackpotCount)
        {
            case 0:
                jackpotMessage = @"
                💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰 
          _____   ______    ______   __    __  _______    ______   ________  __  __  __       
         /     | /      \  /      \ /  |  /  |/       \  /      \ /        |/  |/  |/  |      
         $$$$$ |/$$$$$$  |/$$$$$$  |$$ | /$$/ $$$$$$$  |/$$$$$$  |$$$$$$$$/ $$ |$$ |$$ |      
            $$ |$$ |__$$ |$$ |  $$/ $$ |/$$/  $$ |__$$ |$$ |  $$ |   $$ |   $$ |$$ |$$ |      
       __   $$ |$$    $$ |$$ |      $$  $$<   $$    $$/ $$ |  $$ |   $$ |   $$ |$$ |$$ |      
      /  |  $$ |$$$$$$$$ |$$ |   __ $$$$$  \  $$$$$$$/  $$ |  $$ |   $$ |   $$/ $$/ $$/       
      $$ \__$$ |$$ |  $$ |$$ \__/  |$$ |$$  \ $$ |      $$ \__$$ |   $$ |    __  __  __       
      $$    $$/ $$ |  $$ |$$    $$/ $$ | $$  |$$ |      $$    $$/    $$ |   /  |/  |/  |      
       $$$$$$/  $$/   $$/  $$$$$$/  $$/   $$/ $$/        $$$$$$/     $$/    $$/ $$/ $$/       

                💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰 ";
                break;
            case 1:
                jackpotMessage = @"
💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰  
 _______    ______   __    __  _______   __        ________                             
/       \  /      \ /  |  /  |/       \ /  |      /        |                            
$$$$$$$  |/$$$$$$  |$$ |  $$ |$$$$$$$  |$$ |      $$$$$$$$/                             
$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |__$$ |$$ |      $$ |__                                
$$ |  $$ |$$ |  $$ |$$ |  $$ |$$    $$< $$ |      $$    |                               
$$ |  $$ |$$ |  $$ |$$ |  $$ |$$$$$$$  |$$ |      $$$$$/                                
$$ |__$$ |$$ \__$$ |$$ \__$$ |$$ |__$$ |$$ |_____ $$ |_____                             
$$    $$/ $$    $$/ $$    $$/ $$    $$/ $$       |$$       |                            
$$$$$$$/   $$$$$$/   $$$$$$/  $$$$$$$/  $$$$$$$$/ $$$$$$$$/                             
                                                                                                                                                                                                                                                                    
    _____   ______    ______   __    __  _______    ______   ________  __  __  __       
   /     | /      \  /      \ /  |  /  |/       \  /      \ /        |/  |/  |/  |      
   $$$$$ |/$$$$$$  |/$$$$$$  |$$ | /$$/ $$$$$$$  |/$$$$$$  |$$$$$$$$/ $$ |$$ |$$ |      
      $$ |$$ |__$$ |$$ |  $$/ $$ |/$$/  $$ |__$$ |$$ |  $$ |   $$ |   $$ |$$ |$$ |      
 __   $$ |$$    $$ |$$ |      $$  $$<   $$    $$/ $$ |  $$ |   $$ |   $$ |$$ |$$ |      
/  |  $$ |$$$$$$$$ |$$ |   __ $$$$$  \  $$$$$$$/  $$ |  $$ |   $$ |   $$/ $$/ $$/       
$$ \__$$ |$$ |  $$ |$$ \__/  |$$ |$$  \ $$ |      $$ \__$$ |   $$ |    __  __  __       
$$    $$/ $$ |  $$ |$$    $$/ $$ | $$  |$$ |      $$    $$/    $$ |   /  |/  |/  |      
 $$$$$$/  $$/   $$/  $$$$$$/  $$/   $$/ $$/        $$$$$$/     $$/    $$/ $$/ $$/       
                                                                                        
💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰";
                break;
            case 2:
                jackpotMessage = @"
💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰                    
 ________  _______   ______  _______   __        ________                               
/        |/       \ /      |/       \ /  |      /        |                              
$$$$$$$$/ $$$$$$$  |$$$$$$/ $$$$$$$  |$$ |      $$$$$$$$/                               
   $$ |   $$ |__$$ |  $$ |  $$ |__$$ |$$ |      $$ |__                                  
   $$ |   $$    $$<   $$ |  $$    $$/ $$ |      $$    |                                 
   $$ |   $$$$$$$  |  $$ |  $$$$$$$/  $$ |      $$$$$/                                  
   $$ |   $$ |  $$ | _$$ |_ $$ |      $$ |_____ $$ |_____                               
   $$ |   $$ |  $$ |/ $$   |$$ |      $$       |$$       |                              
   $$/    $$/   $$/ $$$$$$/ $$/       $$$$$$$$/ $$$$$$$$/                               
                                                                                                                                                                                                                                                                   
    _____   ______    ______   __    __  _______    ______   ________  __  __  __       
   /     | /      \  /      \ /  |  /  |/       \  /      \ /        |/  |/  |/  |      
   $$$$$ |/$$$$$$  |/$$$$$$  |$$ | /$$/ $$$$$$$  |/$$$$$$  |$$$$$$$$/ $$ |$$ |$$ |      
      $$ |$$ |__$$ |$$ |  $$/ $$ |/$$/  $$ |__$$ |$$ |  $$ |   $$ |   $$ |$$ |$$ |      
 __   $$ |$$    $$ |$$ |      $$  $$<   $$    $$/ $$ |  $$ |   $$ |   $$ |$$ |$$ |      
/  |  $$ |$$$$$$$$ |$$ |   __ $$$$$  \  $$$$$$$/  $$ |  $$ |   $$ |   $$/ $$/ $$/       
$$ \__$$ |$$ |  $$ |$$ \__/  |$$ |$$  \ $$ |      $$ \__$$ |   $$ |    __  __  __       
$$    $$/ $$ |  $$ |$$    $$/ $$ | $$  |$$ |      $$    $$/    $$ |   /  |/  |/  |      
 $$$$$$/  $$/   $$/  $$$$$$/  $$/   $$/ $$/        $$$$$$/     $$/    $$/ $$/ $$/       
                                                                                        
💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰";
                break;
            case 3:
                jackpotMessage = @"
💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰              
 _______   ______   ______         __       __  ______  __    __                        
/       \ /      | /      \       /  |  _  /  |/      |/  \  /  |                       
$$$$$$$  |$$$$$$/ /$$$$$$  |      $$ | / \ $$ |$$$$$$/ $$  \ $$ |                       
$$ |__$$ |  $$ |  $$ | _$$/       $$ |/$  \$$ |  $$ |  $$$  \$$ |                       
$$    $$<   $$ |  $$ |/    |      $$ /$$$  $$ |  $$ |  $$$$  $$ |                       
$$$$$$$  |  $$ |  $$ |$$$$ |      $$ $$/$$ $$ |  $$ |  $$ $$ $$ |                       
$$ |__$$ | _$$ |_ $$ \__$$ |      $$$$/  $$$$ | _$$ |_ $$ |$$$$ |                       
$$    $$/ / $$   |$$    $$/       $$$/    $$$ |/ $$   |$$ | $$$ |                       
$$$$$$$/  $$$$$$/  $$$$$$/        $$/      $$/ $$$$$$/ $$/   $$/                        
                                                                                                                                                                         
    _____   ______    ______   __    __  _______    ______   ________  __  __  __       
   /     | /      \  /      \ /  |  /  |/       \  /      \ /        |/  |/  |/  |      
   $$$$$ |/$$$$$$  |/$$$$$$  |$$ | /$$/ $$$$$$$  |/$$$$$$  |$$$$$$$$/ $$ |$$ |$$ |      
      $$ |$$ |__$$ |$$ |  $$/ $$ |/$$/  $$ |__$$ |$$ |  $$ |   $$ |   $$ |$$ |$$ |      
 __   $$ |$$    $$ |$$ |      $$  $$<   $$    $$/ $$ |  $$ |   $$ |   $$ |$$ |$$ |      
/  |  $$ |$$$$$$$$ |$$ |   __ $$$$$  \  $$$$$$$/  $$ |  $$ |   $$ |   $$/ $$/ $$/       
$$ \__$$ |$$ |  $$ |$$ \__/  |$$ |$$  \ $$ |      $$ \__$$ |   $$ |    __  __  __       
$$    $$/ $$ |  $$ |$$    $$/ $$ | $$  |$$ |      $$    $$/    $$ |   /  |/  |/  |      
 $$$$$$/  $$/   $$/  $$$$$$/  $$/   $$/ $$/        $$$$$$/     $$/    $$/ $$/ $$/       

💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰";
                break;
            case 4:
                jackpotMessage = @"
💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰          
 __    __  __    __   ______   ________           _____   ______    ______   __    __  _______    ______   ________  __  __  __       
/  |  /  |/  |  /  | /      \ /        |         /     | /      \  /      \ /  |  /  |/       \  /      \ /        |/  |/  |/  |      
$$ |  $$ |$$ |  $$ |/$$$$$$  |$$$$$$$$/          $$$$$ |/$$$$$$  |/$$$$$$  |$$ | /$$/ $$$$$$$  |/$$$$$$  |$$$$$$$$/ $$ |$$ |$$ |      
$$ |__$$ |$$ |  $$ |$$ | _$$/ $$ |__                $$ |$$ |__$$ |$$ |  $$/ $$ |/$$/  $$ |__$$ |$$ |  $$ |   $$ |   $$ |$$ |$$ |      
$$    $$ |$$ |  $$ |$$ |/    |$$    |          __   $$ |$$    $$ |$$ |      $$  $$<   $$    $$/ $$ |  $$ |   $$ |   $$ |$$ |$$ |      
$$$$$$$$ |$$ |  $$ |$$ |$$$$ |$$$$$/          /  |  $$ |$$$$$$$$ |$$ |   __ $$$$$  \  $$$$$$$/  $$ |  $$ |   $$ |   $$/ $$/ $$/       
$$ |  $$ |$$ \__$$ |$$ \__$$ |$$ |_____       $$ \__$$ |$$ |  $$ |$$ \__/  |$$ |$$  \ $$ |      $$ \__$$ |   $$ |    __  __  __       
$$ |  $$ |$$    $$/ $$    $$/ $$       |      $$    $$/ $$ |  $$ |$$    $$/ $$ | $$  |$$ |      $$    $$/    $$ |   /  |/  |/  |      
$$/   $$/  $$$$$$/   $$$$$$/  $$$$$$$$/        $$$$$$/  $$/   $$/  $$$$$$/  $$/   $$/ $$/        $$$$$$/     $$/    $$/ $$/ $$/       
                                                                                                                                 
💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰";
                break;
            case >=5:
                jackpotMessage = @"
💰💰💰 💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰
 _______    ______   ______  __    __           _____   ______    ______   __    __  _______    ______   ________  __  __  __       
/       \  /      \ /      |/  \  /  |         /     | /      \  /      \ /  |  /  |/       \  /      \ /        |/  |/  |/  |      
$$$$$$$  |/$$$$$$  |$$$$$$/ $$  \ $$ |         $$$$$ |/$$$$$$  |/$$$$$$  |$$ | /$$/ $$$$$$$  |/$$$$$$  |$$$$$$$$/ $$ |$$ |$$ |      
$$ |__$$ |$$ |__$$ |  $$ |  $$$  \$$ |            $$ |$$ |__$$ |$$ |  $$/ $$ |/$$/  $$ |__$$ |$$ |  $$ |   $$ |   $$ |$$ |$$ |      
$$    $$< $$    $$ |  $$ |  $$$$  $$ |       __   $$ |$$    $$ |$$ |      $$  $$<   $$    $$/ $$ |  $$ |   $$ |   $$ |$$ |$$ |      
$$$$$$$  |$$$$$$$$ |  $$ |  $$ $$ $$ |      /  |  $$ |$$$$$$$$ |$$ |   __ $$$$$  \  $$$$$$$/  $$ |  $$ |   $$ |   $$/ $$/ $$/       
$$ |  $$ |$$ |  $$ | _$$ |_ $$ |$$$$ |      $$ \__$$ |$$ |  $$ |$$ \__/  |$$ |$$  \ $$ |      $$ \__$$ |   $$ |    __  __  __       
$$ |  $$ |$$ |  $$ |/ $$   |$$ | $$$ |      $$    $$/ $$ |  $$ |$$    $$/ $$ | $$  |$$ |      $$    $$/    $$ |   /  |/  |/  |      
$$/   $$/ $$/   $$/ $$$$$$/ $$/   $$/        $$$$$$/  $$/   $$/  $$$$$$/  $$/   $$/ $$/        $$$$$$/     $$/    $$/ $$/ $$/       

💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰💰";
                break;
        }

        // Mostrar el mensaje de Jackpot con cambio de colores
        ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Magenta };
        for (int i = 0; i < 6; i++)
        {
            Console.ForegroundColor = colors[i % colors.Length];
            Console.WriteLine(jackpotMessage);
            Thread.Sleep(500);
            Console.Clear();
        }

        // Reseteamos el color
        Console.ResetColor();
    }

    private void GenerateOrder(List<string> roll)
    {
        Order order = new Order();
        foreach (var model in roll)
        {
            order.AddRobot(model);
        }
        orders.Add(order);
    }

    private void ShowHistory()
    {
        Console.Clear();
        Console.WriteLine("\nHistorial de tiros:");
        foreach (var entry in history)
        {
            Console.WriteLine(entry);
        }
        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
        Console.ReadKey();
    }

    private void SaveResults()
    {
        string filePath = "results.txt";
        // Guarda el nombre del jugador, los puntos y la cantidad de Jackpots obtenidos
        File.AppendAllLines(filePath, new List<string> { $"{playerName}: {totalPoints} puntos, {jackpotCount} Jackpots" });
    }

    private void ShowRanking()
    {
        Console.Clear();
        Console.WriteLine("\nRanking de jugadores:");

        // Verificamos si el archivo existe, si no, creamos una lista vacía.
        var ranking = File.Exists("results.txt") ? File.ReadAllLines("results.txt").ToList() : new List<string>();

        // Creamos una lista de jugadores con sus puntos y Jackpots
        var parsedRanking = ranking.Select(r =>
        {
            var parts = r.Split(':');
            var playerName = parts[0].Trim();
            var stats = parts[1].Split(',').Select(p => p.Trim()).ToArray();

            int points = 0;
            int jackpots = 0;

            // Extraemos los puntos y Jackpots de la cadena de estadísticas
            foreach (var stat in stats)
            {
                if (stat.Contains("puntos"))
                {
                    points = int.Parse(stat.Replace("puntos", "").Trim());
                }
                else if (stat.Contains("Jackpots"))
                {
                    jackpots = int.Parse(stat.Replace("Jackpots", "").Trim());
                }
            }

            return new { PlayerName = playerName, Points = points, Jackpots = jackpots };
        }).OrderByDescending(p => p.Points)
          .ThenByDescending(p => p.Jackpots)
          .Take(3)
          .ToList();

        // Imprimimos el ranking
        for (int i = 0; i < parsedRanking.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {parsedRanking[i].PlayerName}: {parsedRanking[i].Points} puntos, {parsedRanking[i].Jackpots} Jackpots");
        }

        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
        Console.ReadKey();
    }
}

class Order
{
    private List<Robot> robots = new List<Robot>();

    public void AddRobot(string model)
    {
        robots.Add(model switch
        {
            "R2D2" => new R2D2(),
            "C3PO" => new C3PO(),
            "BB8" => new BB8(),
            _ => throw new ArgumentException("Modelo inválido")
        });
    }
}

abstract class Robot
{
    private static int counter = 1;
    public int Id { get; } = counter++;
    public abstract string Model { get; }
    public DateTime CreationDate { get; } = DateTime.Now;
}

class R2D2 : Robot
{
    public override string Model => "R2D2";
    public int Version { get; } = new Random().Next(1, 10);
}

class C3PO : Robot
{
    public override string Model => "C3PO";
}

class BB8 : Robot
{
    public override string Model => "BB8";
    public float Version { get; } = (float)new Random().NextDouble() * 10;
}
