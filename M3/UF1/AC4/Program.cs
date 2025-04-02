using System.Security.Cryptography.X509Certificates;

class Program {
    public static void Main(string[] args){

        /* Ejemplo 1 */

        // try{

        //     Console.Write("Elige un numero");
        //     int numero1 = Convert.ToInt32(Console.ReadLine());

        //     Console.Write("Elige un numero");
        //     int numero2 = Convert.ToInt32(Console.ReadLine());

        //     int resultado = numero1 / numero2;
        //     Console.Write("El resultado es:" + resultado);

        // }

        // catch(Exception error){
        //     Console.WriteLine("Mensaje error: " + error.Message);
        // }

        /* Ejemplo 2 */

        // try{
            
        //  negativeNumber(-1);
        
        // }
        
        // catch(Exception error){
        //     Console.WriteLine("Error: " + error.Message);
        // }

        /* Ejemplo 3 */

        //  Escribe un programa en C# que lea una ruta de archivo proporcionada por el usuario e intente abrir el archivo. 
        //  Maneja excepciones si el archivo no existe.

        // try{

        //     Console.WriteLine($"Escribe el archivo/ruta que quieras abrir");
        //     string ruta = Console.ReadLine();
        //     StreamReader fichero = new StreamReader(ruta);

        // }
        // catch(Exception e){
        //     Console.WriteLine("Error: " + e.Message);
            
        // }

        /* Ejemplo 4 */

        //  Escribe un programa en C# que solicite al usuario ingresar un número entero.
        //  Lanza una excepción si el número es menor que 0 o mayor que 1000.

        // try {
        //     int numero = 0;

        //     Console.WriteLine("Escribe un numero entre el 0 y 1000");
        //     numero = Convert.ToInt32(Console.ReadLine());

        //     if (numero < 0 || numero > 1000){

        //         throw new ArgumentOutOfRangeException("Debe ser entre 0 o 100");

        //     }

        //     else{

        //         Console.WriteLine("El numero que has elegido es: " + numero);

        //     }
            

        // }

        // catch(IndexOutOfRangeException ex){
            
        //     Console.WriteLine($"Error: {ex.Message}");
            
            
        // }

        /* Ejemplo 5 */

        // Escribe un programa en C# que implemente un método que reciba un arreglo de enteros como entrada y calcule el valor promedio. 
        // Maneja la excepción si el índice está fuera de rango

        int[] lista = [2, 3, 4];

        promedioNumber(lista);

    }

        public static void negativeNumber(int numero)
        {
            if(numero < 0){

                throw new Exception("El mensaje debe ser positivo");

            }

        }

        public static void promedioNumber(int[] numeros){

            int suma = 0;

            for(int i = 0; i < numeros.Length; i++){

                suma += numeros[i];

            }

            try{

                int elementoInvalido = numeros[numeros.Length];

            }

            catch(IndexOutOfRangeException ex){

                Console.WriteLine($"Error: {ex.Message}" );
                

            }     
        }
}


