class Partida{
    public string nombreJugador {get;private set;}
    public Dictionary<string, bool> salasDesbloqueadas{get;private set;}
    public Dictionary<string,Sala> salas{get;private set;}
    public int cantPistas{get;private set;}
    public List<Sospechoso> listaSospechosos {get;private set;}
}