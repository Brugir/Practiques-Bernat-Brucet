class DroideProtocolo : RobotBase
{
    public string TipoProtocolo { get; set; }

    public DroideProtocolo(string nombre, int unidad, int bateria, string tipoProtocolo) : base(nombre, unidad, bateria)
    {
        TipoProtocolo = tipoProtocolo;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Unidad: {Unidad}, Batería: {Bateria}");
    }
}
