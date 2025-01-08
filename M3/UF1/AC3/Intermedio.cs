class Intermedio : ShipBase{

    public int Escudos { get; set; }

    public Intermedio(int capacidadCarga, int velocidadMaxima, int escudos) : base(capacidadCarga, velocidadMaxima){
        Escudos = escudos;
    }

    public override void MostrarInfo(){
        Console.WriteLine($"La nave intermedia tiene {Escudos} escudos para colocar");
            
    }

    public override void ActivarNave(){
        Console.WriteLine($"Activando nave intermedio");
        
    }

    public override void MisionNave(){
        Console.WriteLine($"La nave intermedia está colocando escudos en ciertas zonas del planeta");
        
    }
}