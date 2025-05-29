class Sala{
    public string clave{get;private set;}
    public List<string> pistas{get;private set;}
    public bool estaDesbloqueada{get; set;}
    public List<Sala> salaDependienteDe {get; private set;}


    public Sala(string Clave,bool EstaDesbloqueada, List<Sala> SalaDependienteDe){
        clave = Clave;
        pistas = new List<string>();
        estaDesbloqueada=EstaDesbloqueada;
        salaDependienteDe = SalaDependienteDe;
    }

    public bool puedeEntrar(){
        bool puede = true;
        foreach(Sala salaDependiente in salaDependienteDe){
            if(salaDependiente.estaDesbloqueada = false){
                puede = false;
            }
        }
        return puede;
    }
}