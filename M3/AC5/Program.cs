class Program{

    public static void Main(string[] args){

        /* 
        Ejemplo 1:
        
        Escribe un programa que lea una cadena del usuario y la convierta en un entero. 
        Maneja la excepción si la entrada no se puede  analizar como un entero. 
        */

        // try {

        //     Console.WriteLine($"Escribe un numero: ");
        //     string stringUser = Console.ReadLine();

        //     int numUSer = Convert.ToInt32(stringUser);
        //     Console.WriteLine(numUSer);
            

        // } catch(Exception error){
        //     Console.WriteLine($"Mensaje error: {error.Message}");
        // }

        /* 
        Ejemplo 2

        Escribe un programa que lea una lista de números enteros del usuario. 
        Maneja la excepción que ocurre si el usuario ingresa un valor fuera del rango de Int32.
        */

        // try{

        //     List<int> lista = new List<int>();

        //     for (int i = 0; i < 3; i++){

        //         Console.WriteLine($"Escribe un numero para añadir: ");
        //         int number = Convert.ToInt32(Console.ReadLine());

        //         lista.Add(number);
                
        //     }

        //     for (int i = 0; i < 3; i++){
        //         Console.WriteLine(lista[i]);
        //     }

        // } catch (Exception error){
        //     Console.WriteLine($"Mensaje de error: {error.Message}");
        // }

        /*
        Ejemplo 3

        Escribe un programa que implemente un método que divida dos números. 
        Controla la excepción DivideByZeroException que se produce si el denominador es 0.
        */

        // try {

        //     int resultado = Division(8, 0);

        //     Console.WriteLine($"Resultado de la división: {resultado}");
            

        // } catch(DivideByZeroException error){
        //     Console.WriteLine($"Mensaje de error: {error.Message}");
        // }

        /* Ejemplo 4

        Escribe un programa que lea un número del usuario y calcule su raíz cuadrada. 
        Maneja la excepción si el número es negativo.
        */

        // try{

        //     Console.WriteLine("Escribe un numero: ");
        //     int num1 = Convert.ToInt32(Console.ReadLine());

        //     double raizCuadrada = Math.Sqrt(num1);

        //     if (num1 <= 0){
                
        //         throw new Exception("No puede ser un numero negativo");

        //     }   else{

        //         Console.WriteLine($"La raiz cuadrada de {num1} es {raizCuadrada}");
        //     }

        // } catch (Exception error){
        //     Console.WriteLine($"Mensaje de error: {error.Message}");
        // }

        /* Ejemplo 5

        Escribe un programa que cree un método que tome una cadena como entrada y la convierta a mayúsculas. 
        Controla la excepción NullReferenceException que se produce si la cadena de entrada es nula.
        */

        try{

            Console.WriteLine("Escribe cualquier cosa: "); 
            string mensajeUser = Console.ReadLine();
           
            Console.WriteLine(Mayusculas(mensajeUser));

        } catch (NullReferenceException error){
            Console.WriteLine($"Mensaje de error: {error.Message}");
            
        }
        
    }

    static int Division(int a, int b){
        
        return a/b;

    }

    static string Mayusculas(string a){

        if (a == null){
                throw new NullReferenceException("No puede ser nulo");
            }
        
        if (a == ""){
            throw new NullReferenceException("No puede ser nulo");
        }

        return a.ToUpper();
    }

}