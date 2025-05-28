class Partida{
    public string nombreJugador {get;private set;}
    public Dictionary<string,Sala> salas{get;private set;}
    public Dictionary<string, bool> salasDesbloqueadas{get;private set;}
    
    public int cantPistasUsadas{get;private set;}
    public List<Sospechoso> listaSospechosos {get;private set;}

    public Partida(){
        nombreJugador ="";
        salas = new Dictionary<string, Sala>();
        salasDesbloqueadas = new Dictionary<string, bool>();
        cantPistasUsadas = 0;
        listaSospechosos=new List<Sospechoso>();
    }
    public void iniciarPartida(string NombreJugador){
        nombreJugador = NombreJugador;
        salas.Add("salaDeEstar", (new Sala("Empezar")));
    }
}