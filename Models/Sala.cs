class Sala{
    public string clave{get;private set;}
    public List<string> pistas{get;private set;}
    public bool estaDesbloqueada{get; set;}
    public List<int> numSalaDependienteDe {get; private set;}


    public Sala(string Clave,bool EstaDesbloqueada, List<int> SalaDependienteDe){
        clave = Clave;
        pistas = new List<string>();
        estaDesbloqueada=EstaDesbloqueada;
        numSalaDependienteDe = SalaDependienteDe;
    }

public bool puedeEntrar(Dictionary<int, Sala> salas)
{

    return false; 
}

}