class Program{

    static void Main(string[] args){

        ShipBase shipBase = new ShipBase(50, 20);

        Intermedio shipIntermedio = new Intermedio(70, 35, 10);

        Derivada shipDerivada = new Derivada(100, 70, 50, 80);

        shipBase.ActivarNave();
        shipBase.MisionNave();
        shipBase.MostrarInfo();
        Console.WriteLine($"------------------------------------------");
        shipIntermedio.ActivarNave();
        shipIntermedio.MisionNave();
        shipIntermedio.MostrarInfo();
        Console.WriteLine($"-------------------------------------------");
        shipDerivada.ActivarNave();
        shipDerivada.MisionNave();
        shipDerivada.MostrarInfo();
        
        


    }

}