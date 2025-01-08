using System;

public static class Menu
{
    public static void Start()
    {
        int option;
        do
        {
            Console.WriteLine("\n--- SISTEMA DE ALQUILER DE VIDEOJUEGOS ---");
            Console.WriteLine("1. Alta de usuarios");
            Console.WriteLine("2. Baja de usuarios");
            Console.WriteLine("3. Alta de empleados");
            Console.WriteLine("4. Baja de empleados");
            Console.WriteLine("5. Alta de videojuegos");
            Console.WriteLine("6. Baja de videojuegos");
            Console.WriteLine("7. Listar videojuegos disponibles");
            Console.WriteLine("8. Listar videojuegos alquilados");
            Console.WriteLine("9. Listar videojuegos por usuario");
            Console.WriteLine("10. Listar usuarios con juegos prestados");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: UserManager.AddUser(); break;
                case 2: UserManager.RemoveUser(); break;
                case 3: EmployeeManager.AddEmployee(); break;
                case 4: EmployeeManager.RemoveEmployee(); break;
                case 5: VideoGameManager.AddVideoGame(); break;
                case 6: VideoGameManager.RemoveVideoGame(); break;
                case 7: VideoGameManager.ListAvailableGames(); break;
                case 8: VideoGameManager.ListRentedGames(); break;
                case 9: UserManager.ListUserGames(); break;
                case 10: UserManager.ListUsersWithRentedGames(); break;
                case 0: Console.WriteLine("¡Hasta luego!"); break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        } while (option != 0);
    }
}
