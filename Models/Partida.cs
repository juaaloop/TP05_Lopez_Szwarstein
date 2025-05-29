class Partida{
    public string nombreJugador {get;private set;}
    public Dictionary<string,Sala> salas{get;private set;}    
    public int cantPistasUsadas{get;private set;}
    public List<Sospechoso> listaSospechosos {get;private set;}

    public Partida(){
        nombreJugador ="";
        salas = new Dictionary<string, Sala>();
        cantPistasUsadas = 0;
        listaSospechosos=new List<Sospechoso>();
    }
    public void iniciarPartida(string NombreJugador){
        nombreJugador = NombreJugador;
        salas.Add("salaDeEstar", (new Sala("Empezar",true,new List<Sala>())));
        salas.Add("patio", (new Sala("LLAVE",true,new List<Sala>())));
        salas.Add("cocina", (new Sala("Empezar",false,new List<Sala>())));
        salas.Add("sotano", (new Sala("Empezar",false,new List<Sala>())));
        List<Sala> listaDependencias = new List<Sala>();
        listaDependencias.Add(salas["patio"]);
        listaDependencias.Add(salas["cocina"]);
        listaDependencias.Add(salas["sotano"]);
        salas.Add("baño", (new Sala("Empezar",false, listaDependencias)));
        listaDependencias.Clear();
        listaDependencias.Add(salas["baño"]);
        salas.Add("biblioteca", (new Sala("Empezar",false,listaDependencias)));
        listaDependencias.Clear();
        listaDependencias.Add(salas["biblioteca"]);
        salas.Add("estudio", (new Sala("Empezar",false,listaDependencias)));

    }
}