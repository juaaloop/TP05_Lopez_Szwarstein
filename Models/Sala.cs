class Sala{
    public string nombre{get;private set;}
    public string clave{get;private set;}

    public List<Pista> Pistas{get;private set;}
    public Sala(string Nombre,string Clave){
        nombre = Nombre;
        clave = Nombre;
        Pistas = new List<Pista>();
    }
}