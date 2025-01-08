class ShipBase {

    public int CapacidadCarga {get; set;}
    public int VelocidadMaxima {get; set;}

    public ShipBase (int capacidadCarga, int velocidadMaxima){
        CapacidadCarga = capacidadCarga;
        VelocidadMaxima = velocidadMaxima;
    } 

    public virtual void MostrarInfo(){
        Console.WriteLine($"Esta es una nave basica, su capacidad de carga es {CapacidadCarga} kg y su maxima velocidad es {VelocidadMaxima}");
        
    }

    public virtual void ActivarNave(){
        Console.WriteLine($"Activando motores de la nave basica");
        
    }

    public virtual void MisionNave(){
        Console.WriteLine($"La nave basica esta explorando planetas");
        
    }

}