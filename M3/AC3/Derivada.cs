class Derivada : Intermedio{

    public int PotenciaAtaque {get; set; }

    public Derivada(int capacidadCarga, int velocidadMaxima, int escudos, int potenciaAtaque) : base(capacidadCarga, velocidadMaxima, escudos){

        PotenciaAtaque = potenciaAtaque;

    }

    public override void MostrarInfo(){
        Console.WriteLine($"Esta nave tiene torretas, su potencia de fuego es {PotenciaAtaque}.");
        
    }

    public override void ActivarNave(){
        Console.WriteLine($"Activando motores y las torretas de la nave derivada");
        
    }

    public override void MisionNave(){

        Console.WriteLine($"La nave derivada esta atacando a los aliens con una potencia de fuego de {PotenciaAtaque}");
        Console.WriteLine($"LA nave derivada esta cargando una cantidad de {CapacidadCarga}kg");
        
        
    }



}