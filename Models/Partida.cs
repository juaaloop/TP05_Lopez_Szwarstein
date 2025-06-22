class Partida{
    public string nombreJugador {get;private set;}
    public Dictionary<int,Sala> salas{get;private set;}    
    public int cantPistasUsadas{get;private set;}
    public List<Sospechoso> listaSospechosos {get;private set;}

    public Partida(string NombreJugador){
        salas = new Dictionary<int, Sala>();
        cantPistasUsadas = 0;
        listaSospechosos=new List<Sospechoso>();
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

    }
}