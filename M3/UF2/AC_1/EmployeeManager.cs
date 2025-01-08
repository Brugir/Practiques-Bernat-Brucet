using System;
using System.Collections.Generic;

public static class EmployeeManager
{
    private static LinkedList<Employee> employees = new LinkedList<Employee>();

    public static void AddEmployee()
    {
        Console.WriteLine("\n--- Alta de Empleado ---");
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
        Console.Write("Categoría: ");
        string category = Console.ReadLine();
        Console.Write("Salario: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        employees.AddLast(new Employee(name, lastName, age, address, phone, category, salary));
        Console.WriteLine("Empleado añadido con éxito.\n");
    }

    public static void RemoveEmployee()
    {
        Console.WriteLine("\n--- Baja de Empleado ---");
        Console.Write("Ingrese el nombre del empleado a eliminar: ");
        string name = Console.ReadLine();

        Employee employeeToRemove = null;
        foreach (var employee in employees)
        {
            if (employee.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                employeeToRemove = employee;
                break;
            }
        }

        if (employeeToRemove != null)
        {
            employees.Remove(employeeToRemove);
            Console.WriteLine("Empleado eliminado con éxito.\n");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.\n");
        }
    }

    public static void ListEmployees()
    {
        Console.WriteLine("\n--- Listado de Empleados ---");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}
