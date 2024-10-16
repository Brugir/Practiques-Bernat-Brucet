class RobotBase
{
    public string Nombre { get; set; }
    public int Unidad { get; set; }
    public int Bateria { get; set; }

    public RobotBase(string nombre, int unidad, int bateria)
    {
        Nombre = nombre;
        Unidad = unidad;
        Bateria = bateria;
    }
}

