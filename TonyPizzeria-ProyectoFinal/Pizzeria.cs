class Pizzeria
{
    string _idPizzeria;
    string _nombre;
    string _direccion;
    string _telefono;

    public Pizzeria(string idPizzeria, string nombre, string direccion, string telefono)
    {
        _idPizzeria = idPizzeria;
        _nombre = nombre;
        _direccion = direccion;
        _telefono = telefono;
    }
    public string IdPizzeria { get => _idPizzeria; set => _idPizzeria = value; }
    public string Nombre { get => _nombre; set => _nombre = value; }
    public string Direccion { get => _direccion; set => _direccion = value; }
    public string Telefono { get => _telefono; set => _telefono = value; }

    public override string ToString()
    {
        return $"Sucursal:{IdPizzeria} \n{Nombre} \nDirección: {Direccion}\nTeléfono: {Telefono}\n";
    }
}