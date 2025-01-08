class DroideCombate : RobotBase
{
    public int PuntosDeFuego { get; set; }
    public int NumeroDeLuchas { get { return new Random().Next(0, 100); } }

    public DroideCombate(string nombre, int unidad, int bateria, int puntosDeFuego) : base(nombre, unidad, bateria)
    {
        PuntosDeFuego = puntosDeFuego;
    }

    public int ObtenerNumeroDeLuchas(){
         
        return PuntosDeFuego; 
    }
}
