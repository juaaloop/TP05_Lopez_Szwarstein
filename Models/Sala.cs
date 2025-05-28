class Sala{
    public string clave{get;private set;}

    public List<Pista> Pistas{get;private set;}
    public Sala(string Clave){
        clave = Clave;
        Pistas = new List<Pista>();
    }
}