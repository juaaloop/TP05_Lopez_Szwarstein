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
        salas.Add(3, (new Sala("Empezar",false,null)));
        salas.Add(4, (new Sala("Empezar",false, null)));
        List<Sala> listaDependencias = new List<Sala>();
        listaDependencias.Add(salas[2]);
        listaDependencias.Add(salas[3]);
        listaDependencias.Add(salas[4]);
        salas.Add(5, (new Sala("Empezar",false, listaDependencias)));
        List<Sala> listaDependencias2 = new List<Sala>();
        listaDependencias2.Add(salas[5]);
        salas.Add(6, (new Sala("Empezar",false,listaDependencias2)));
        List<Sala> listaDependencias3 = new List<Sala>();
        listaDependencias3.Add(salas[6]);
        salas.Add(7, (new Sala("Empezar",false,listaDependencias3)));
        List<Sala> listaDependencias4 = new List<Sala>();
        listaDependencias4.Add(salas[7]);
        salas.Add(8, (new Sala("Empezar",false,listaDependencias4)));

    }
}