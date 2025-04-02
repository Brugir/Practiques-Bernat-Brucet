using System;
using System.Collections.Generic;

public static class UserManager
{
    private static LinkedList<User> users = new LinkedList<User>();

    public static void AddUser()
    {
        Console.Write("Nombre: ");
        string name = Console.ReadLine();
        Console.Write("Apellido: ");
        string lastName = Console.ReadLine();
        Console.Write("Edad: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Dirección: ");
        string address = Console.ReadLine();
        Console.Write("Teléfono: ");
        string phone = Console.ReadLine();

        users.AddLast(new User(name, lastName, age, address, phone));
        Console.WriteLine("Usuario añadido con éxito.");
    }

    public static void RemoveUser()
    {
        Console.Write("Nombre del usuario a eliminar: ");
        string name = Console.ReadLine();

        User userToRemove = null;
        foreach (var user in users)
        {
            if (user.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                userToRemove = user;
                break;
            }
        }

        if (userToRemove != null)
        {
            users.Remove(userToRemove);
            Console.WriteLine("Usuario eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado.");
        }
    }

    public static void ListUserGames()
    {
        Console.Write("Nombre del usuario: ");
        string name = Console.ReadLine();

        foreach (var user in users)
        {
            if (user.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Juegos alquilados por {user.Name}:");
                foreach (var game in user.RentedGames)
                {
                    Console.WriteLine(game);
                }
                return;
            }
        }

        Console.WriteLine("Usuario no encontrado.");
    }

    public static void ListUsersWithRentedGames()
    {
        Console.WriteLine("Usuarios con juegos alquilados:");
        foreach (var user in users)
        {
            if (user.RentedGames.Count > 0)
            {
                Console.WriteLine(user);
            }
        }
    }
}
