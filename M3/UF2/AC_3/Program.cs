using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        /* Valida una dirección de correo electrónico (ej. usuario@dominio.com). */

        // string correo = "usuario@dominio.com";
        // string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // if (Regex.IsMatch(correo, patron))
        // {
        //     Console.WriteLine("La dirección de correo es válida.");
        // }
        // else
        // {
        //     Console.WriteLine("La dirección de correo no es válida.");
        // }


        // /* Valida un número de teléfono con formato de 10 dígitos (ej. 123-456-7890). */

        // string numero = "123-456-7890";
        // string patron2 = @"^\d{3}-\d{3}-\d{4}$";

        // if (Regex.IsMatch(numero, patron2))
        // {
        //     Console.WriteLine("Patrón valido.");
        // }
        // else
        // {
        //     Console.WriteLine("Patrón inválido");
        // }

        // /* Valida una fecha en formato día/mes/año ej. 29/02/2024). */

        // string fecha = "29/02/2024";
        // string patron3 = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";

        // if (Regex.IsMatch(fecha, patron3))
        // {
        //     Console.WriteLine("Patrón valido.");
        // }
        // else
        // {
        //     Console.WriteLine("Patrón inválido");
        // }

        // /* Valida una dirección IP en formato IPv4 (ej. 192.168.1.1). */

        // string ip = "192.168.1.1";
        // string patron4 = @"^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])$";

        // if (Regex.IsMatch(ip, patron4))
        // {
        //     Console.WriteLine("Patrón valido.");
        // }
        // else
        // {
        //     Console.WriteLine("Patrón inválido");
        // }

        // /* Valida un código postal de 5 dígitos (ej. 12345). */ 

        // string postal = "08360";
        // string patron5 = @"^\d{5}";

        // if (Regex.IsMatch(postal, patron5))
        // {
        //     Console.WriteLine("Patrón valido.");
        // }
        // else
        // {
        //     Console.WriteLine("Patrón inválido");
        // }

        // /* Valida una palabra que contenga solo letras, sin números ni caracteres especiales (ej. "Hola"). */ 

        // string mensaje = "hola";
        // string patron6 = @"^[A-Za-z]+$";

        // if (Regex.IsMatch(mensaje, patron6))
        // {
        //     Console.WriteLine("Patrón valido.");
        // }
        // else
        // {
        //     Console.WriteLine("Patrón inválido");
        // }

        // /* Valida un número entero positivo, que puede tener más de un dígito (ej. 123). */

        // string numero2 = "123";
        // string patron7 = @"^[1-9]\d*$";

        // if (Regex.IsMatch(numero2, patron7))
        // {
        //     Console.WriteLine("Patrón valido.");
        // }
        // else
        // {
        //     Console.WriteLine("Patrón inválido");
        // }

        // /* Valida una URL (ej. http://www.ejemplo.com/). */

        // string url = "http://www.ejemplo.com/";
        // string patron8 = @"^https?:\/\/([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}(\/[a-zA-Z0-9%_./-]*)?$";

        // if (Regex.IsMatch(url, patron8))
        // {
        //     Console.WriteLine("Patrón valido.");
        // }
        // else
        // {
        //     Console.WriteLine("Patrón inválido");
        // }

        // /* Valida un código de color hexadecimal (ej. #A3C1D7). */

        // string color = "#A3C1D7";
        // string patron9 = @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";

        // if (Regex.IsMatch(color, patron9))
        // {
        //     Console.WriteLine("Patrón valido.");
        // }
        // else
        // {
        //     Console.WriteLine("Patrón inválido");
        // }

        // /* Valida un número decimal con punto (ej. 12.23) */

        // string numeroPunto = "12.34";
        // string patron10 = @"^[0-9]+\.[0-9]+$";

        // if (Regex.IsMatch(numeroPunto, patron10))
        // {
        //     Console.WriteLine("Patrón valido.");
        // }
        // else
        // {
        //     Console.WriteLine("Patrón inválido");
        // }

        string prueba = "http://www.putoAlvaro.com";


        

        string patron11 = @"^[http|https]+\://w{3}\.\w+$";

        if (Regex.IsMatch(prueba, patron11)){

            Console.WriteLine("Patron normal valido");

        }

        else{
            Console.WriteLine($"Patron normal invalido");
            
        }

    }
}
