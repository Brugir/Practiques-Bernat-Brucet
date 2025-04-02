using System;
using System.Collections.Generic;

public class Persona{

    public string Nombre {get; set;}
    public int Edad {get; set;}

    public Persona (string nombre, int edad){
        Nombre = nombre;
        Edad = edad;
    }

}
public class Program{

    static void Main(string[] args){


        List<Persona> personas = new List<Persona>{
            new("Juan", 30),
            new("Pedro", 31),
            new("Miguel", 25),
            new("Luís", 36),
            new("José", 25),
        };

        // Sin LAMBDA

        // Encuentra el nombre de la persona más joven en la lista person
        var personaJoven = (
            from p in personas
            orderby p.Edad ascending
            select p).FirstOrDefault();
      
        Console.WriteLine($"La persona mas joven es: {personaJoven.Nombre}");



        // Calcula la edad promedio de todas las personas en la lista personas.
        var edadPromedio = (
            from p in personas
            select p.Edad
            ).Average();

        Console.WriteLine($"La edad promedio es: {edadPromedio}");


        // Encuentra todas las personas mayores de 25 años en la lista personas y ordénalas
        // alfabéticamente por nombre.

        var mayor25 = 
            from p in personas
            where p.Edad > 25
            select p;

        Console.WriteLine($"Las personas mayores de 25 son:");
        foreach (var persona in mayor25){
            Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");
        };
        
        // Encuentra todas las personas cuyo nombre comienza con la letra "M" en la lista personas y
        // ordénalas por edad de forma descendente.

        var inicialM =
            from p in personas
            where p.Nombre.StartsWith("M")
            select p;

        Console.WriteLine($"Perosnas con la inical M:");
        
        foreach (var persona in inicialM){
            Console.WriteLine($"{persona.Nombre}");
            
        }

        // Verifica si todas las personas en la lista personas son mayores de 18 años.
        
       bool mayor18 = personas.All( p => p.Edad > 18);

        Console.WriteLine(mayor18);


        // Encuentra la persona más joven en la lista personas que tenga un nombre que contenga la letra "a".

        var jovenA = 
        (from p in personas
        where p.Nombre.Contains("a")
        orderby p.Edad ascending
        select p).FirstOrDefault();

        Console.WriteLine($"Persona mas joven con la inical 'a': {jovenA.Nombre}");

        // Agrupa las personas en la lista personas por su primera letra de nombre y muestra cuántas
        // personas hay en cada grupo.

        var grupos = personas
                    .GroupBy(p => p.Nombre[0])
                    .OrderBy(g => g.Key);
        
        foreach (var grupo in grupos){
            Console.WriteLine($"Grupo de la letra '{grupo.Key}': {grupo.Count()} personas");
            
        }
                

        // Con LAMBDA

                    

        

        
    
        

    }

}