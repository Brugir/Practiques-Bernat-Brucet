using System;
using System.Collections.Generic;

public static class VideoGameManager
{
    private static LinkedList<VideoGame> games = new LinkedList<VideoGame>();

    public static void AddVideoGame()
    {
        Console.Write("Título: ");
        string title = Console.ReadLine();
        Console.Write("Año de lanzamiento: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Género: ");
        string genre = Console.ReadLine();
        Console.Write("Estudio: ");
        string studio = Console.ReadLine();

        games.AddLast(new VideoGame(title, year, genre, studio));
        Console.WriteLine("Videojuego añadido con éxito.");
    }

    public static void RemoveVideoGame()
    {
        Console.Write("Título del videojuego a eliminar: ");
        string title = Console.ReadLine();

        VideoGame gameToRemove = null;
        foreach (var game in games)
        {
            if (game.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                gameToRemove = game;
                break;
            }
        }

        if (gameToRemove != null)
        {
            games.Remove(gameToRemove);
            Console.WriteLine("Videojuego eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Videojuego no encontrado.");
        }
    }

    public static void ListAvailableGames()
    {
        Console.WriteLine("Videojuegos disponibles:");
        foreach (var game in games)
        {
            if (!game.IsRented)
            {
                Console.WriteLine(game);
            }
        }
    }

    public static void ListRentedGames()
    {
        Console.WriteLine("Videojuegos alquilados:");
        foreach (var game in games)
        {
            if (game.IsRented)
            {
                Console.WriteLine(game);
            }
        }
    }
}
