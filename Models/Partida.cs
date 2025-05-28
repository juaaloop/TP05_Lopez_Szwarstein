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
        salas.Add("patio", (new Sala("LLAVE")));
        salas.Add("cocina", (new Sala("Empezar")));
        salas.Add("sotano", (new Sala("Empezar")));
        salas.Add("baño", (new Sala("Empezar")));
        salas.Add("biblioteca", (new Sala("Empezar")));
        salas.Add("estudio", (new Sala("Empezar")));

        salasDesbloqueadas.Add("salaDeEstar",true);
        salasDesbloqueadas.Add("patio",false);
        salasDesbloqueadas.Add("cocina",false);
        salasDesbloqueadas.Add("sotano",false);
        salasDesbloqueadas.Add("baño",false);
        salasDesbloqueadas.Add("biblioteca",false);
        salasDesbloqueadas.Add("estudio",false); 

    }
}