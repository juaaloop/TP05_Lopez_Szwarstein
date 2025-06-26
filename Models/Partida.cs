class Partida{
    public string nombreJugador {get;private set;}
    public Dictionary<int,Sala> salas{get;private set;}    
    public Dictionary<int,bool>  pistasRecolectadas{get;private set;}
    public List<Sospechoso> listaSospechosos {get;private set;}
    public bool partidaGanada{get;set;}
    public Sospechoso culpable{get;private set;}
    public List<int> idPistas{get;private set;}

    public Partida(string NombreJugador){
        salas = new Dictionary<int, Sala>();
        partidaGanada=false;
        pistasRecolectadas = new Dictionary<int, bool>();
        pistasRecolectadas.Add(2, false);
        pistasRecolectadas.Add(3, false);
        pistasRecolectadas.Add(4, false);
        pistasRecolectadas.Add(5, false);
        pistasRecolectadas.Add(6, false);
        pistasRecolectadas.Add(7, false);
        pistasRecolectadas.Add(8, false);

        listaSospechosos =new List<Sospechoso>();
        this.nombreJugador = NombreJugador;
    
        salas.Add(1, (new Sala("Empezar",true,null)));
        salas.Add(2, (new Sala("desbloquear",false,null)));
        salas.Add(3, (new Sala("JKCNM",false,null)));
        List<int> listaDependencias0 = new List<int>();
        listaDependencias0.Add(3);
        salas.Add(4, (new Sala("Karamázov1900",false, listaDependencias0)));
        List<int> listaDependencias = new List<int>();
        listaDependencias.Add(2);
        listaDependencias.Add(4);
        salas.Add(5, (new Sala("53",false, listaDependencias)));
        List<int> listaDependencias2 = new List<int>();
        listaDependencias2.Add(5);
        salas.Add(6, (new Sala("Empezar",false,listaDependencias2)));
        List<int> listaDependencias3 = new List<int>();
        listaDependencias3.Add(6);
        salas.Add(7, (new Sala("Empezar",false,listaDependencias3)));
        List<int> listaDependencias4 = new List<int>();
        listaDependencias4.Add(7);
        salas.Add(8, (new Sala("Empezar",false,listaDependencias4)));


        listaSospechosos.Add(new("Abuelo Iván","abuelo.png"));
        listaSospechosos.Add(new("Dmitri","tio.png"));
        listaSospechosos.Add(new("Elena","hermana.png"));
        listaSospechosos.Add(new("Andrei","primo.png"));
        listaSospechosos.Add(new("Nikolai","mayordomo.png"));
        listaSospechosos.Add(new("Olga","cocinera.png"));
        listaSospechosos.Add(new("Viktor","jardinera.png"));

        culpable=listaSospechosos[3];
        idPistas.Add(2);
        idPistas.Add(3);
        idPistas.Add(5);
        idPistas.Add(7);
        idPistas.Add(8);

    }
}