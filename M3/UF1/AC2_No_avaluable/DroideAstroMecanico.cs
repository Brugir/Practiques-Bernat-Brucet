class DroideAstroMecanico : RobotBase
{

    public int RepairedShips { get; }
    public DateTime LastRepaired { get; }


    public DroideAstroMecanico(string name, int unity, int battery, DateTime lastRepaired) : base(name, unity, battery)
    {
        LastRepaired = lastRepaired;
        RepairedShips = new Random().Next(0,100);
    }


    public void GetLastReparation(){ 
        
        Console.WriteLine($"La ultima reparacion fue {this.LastRepaired}");
    
    }
}