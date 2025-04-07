using System;
using System.Data.SQLite;

namespace CRUDSQLite
{
    class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }

    class Program
    {
        static string connectionString = "Data Source=productos.db;Version=3;";

        static void Main(string[] args)
        {
            CrearBaseDeDatos();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Menú de Productos =====");
                Console.WriteLine("1. Crear Producto");
                Console.WriteLine("2. Listar Productos");
                Console.WriteLine("3. Buscar Producto por Nombre");
                Console.WriteLine("4. Actualizar Producto");
                Console.WriteLine("5. Eliminar Producto");
                Console.WriteLine("6. Salir");
                Console.Write("Selecciona una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": CrearProducto(); break;
                    case "2": ListarProductos(); break;
                    case "3": BuscarProducto(); break;
                    case "4": ActualizarProducto(); break;
                    case "5": EliminarProducto(); break;
                    case "6": return;
                    default: Console.WriteLine("Opción no válida."); break;
                }

                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void CrearBaseDeDatos()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS productos (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Nombre TEXT NOT NULL,
                                Precio REAL NOT NULL,
                                Cantidad INTEGER NOT NULL)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        static void CrearProducto()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio: ");
            double precio = Convert.ToDouble(Console.ReadLine());
            Console.Write("Cantidad: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO productos (Nombre, Precio, Cantidad) VALUES (@nombre, @precio, @cantidad)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Producto creado con éxito.");
        }

        static void ListarProductos()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM productos";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nLista de Productos:");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Nombre: {reader["Nombre"]}, Precio: {reader["Precio"]}, Cantidad: {reader["Cantidad"]}");
                }
            }
        }

        static void BuscarProducto()
        {
            Console.Write("Ingrese el nombre del producto a buscar: ");
            string nombre = Console.ReadLine();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM productos WHERE Nombre LIKE @nombre";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", $"%{nombre}%");
                SQLiteDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nResultados de la búsqueda:");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Nombre: {reader["Nombre"]}, Precio: {reader["Precio"]}, Cantidad: {reader["Cantidad"]}");
                }
            }
        }

        static void ActualizarProducto()
        {
            Console.Write("Ingrese el ID del producto a actualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nuevo precio: ");
            double precio = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nueva cantidad: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE productos SET Nombre = @nombre, Precio = @precio, Cantidad = @cantidad WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Producto actualizado correctamente.");
                else
                    Console.WriteLine("Producto no encontrado.");
            }
        }

        static void EliminarProducto()
        {
            Console.Write("Ingrese el ID del producto a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM productos WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Producto eliminado correctamente.");
                else
                    Console.WriteLine("Producto no encontrado.");
            }
        }
    }
}
