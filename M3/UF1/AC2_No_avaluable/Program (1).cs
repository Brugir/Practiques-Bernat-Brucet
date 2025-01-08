class Programa
{
    static void Main(string[] args)
    {
        List<RobotBase> listaDeRobots = new List<RobotBase>
        {
            new DroideProtocolo("Bernat", 1, 80, "sordo-MAX-3000"),
            new DroideAstroMecanico("David", 2, 69, DateTime.Now),
            new DroideCombate("Judit", 3, 50, 10)
        };

        int opcionUsuario = MostrarMenu();

        switch (opcionUsuario)
        {
            case 1:
                string opcionRobot = MostrarMenuCategorias();
                AgregarRobot(listaDeRobots, opcionRobot);
                break;

            case 2:
                string opcionRobotMostrar = MostrarMenuCategorias();
                MostrarRobotPorCategoria(listaDeRobots, opcionRobotMostrar);
                break;
        }
    }

    public static int MostrarMenu()
    {
        int opcionUsuario;

        do
        {
            Console.WriteLine("Hola, bienvenido a los Robots Aleatorios");
            Console.WriteLine("1. Insertar Robot");
            Console.WriteLine("2. Mostrar robots por categoría");
            Console.Write("Inserte su opción: ");
            opcionUsuario = int.Parse(Console.ReadLine());

            if (opcionUsuario <= 0 || opcionUsuario > 2)
            {
                Console.WriteLine("¡Opción no válida!");
                Console.ReadKey();
            }

        } while (opcionUsuario < 1 || opcionUsuario > 2);

        return opcionUsuario;
    }

    public static string MostrarMenuCategorias()
    {
        int opcionRobot;
        string[] tiposDeRobots = { "DroideProtocolo", "DroideAstroMecanico", "DroideCombate" };

        do
        {

            Console.WriteLine("1. Droide Protocolo");
            Console.WriteLine("2. Droide Astromecánico");
            Console.WriteLine("3. Droide Combate");
            Console.Write("Inserte su opción: ");
            opcionRobot = int.Parse(Console.ReadLine());

            if (opcionRobot <= 0 || opcionRobot > 3)
            {
                Console.WriteLine("¡Opción no válida!");
                Console.ReadKey();
            }

        } while (opcionRobot < 1 || opcionRobot > 3);

        return tiposDeRobots[opcionRobot - 1];
    }

    public static void MostrarRobotPorCategoria(List<RobotBase> listaDeRobots, string tipoRobot)
    {
        foreach (RobotBase robot in listaDeRobots)
        {
            if (robot.GetType().Name == tipoRobot)
            {
                Console.WriteLine($"Tipo: {robot.GetType().Name}");
                Console.WriteLine($"Nombre: {robot.Nombre}");
                Console.WriteLine($"Batería: {robot.Bateria}");
                Console.WriteLine($"Unidad: {robot.Unidad}");
            }
        }
    }

    public static void AgregarRobot(List<RobotBase> listaDeRobots, string tipoRobot)
    {
        Console.Write("Inserte el Nombre: ");
        string nombre = Console.ReadLine();

        switch (tipoRobot)
        {
            case "DroideProtocolo":
                listaDeRobots.Add(new DroideProtocolo(nombre, listaDeRobots.Count + 1, 100, "mamahuevo"));
                break;

            case "DroideAstroMecanico":
                listaDeRobots.Add(new DroideAstroMecanico(nombre, listaDeRobots.Count + 1, 100, DateTime.Now));
                break;

            case "DroideCombate":
                listaDeRobots.Add(new DroideCombate(nombre, listaDeRobots.Count + 1, 100, 10));
                break;
        }
    }
}
