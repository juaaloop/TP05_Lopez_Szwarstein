class Partida{
    public string nombreJugador {get;private set;}
    public Dictionary<int,Sala> salas{get;private set;}    
    public Dictionary<int,bool>  pistasRecolectadas{get;private set;}
    public List<Sospechoso> listaSospechosos {get;private set;}
    public bool partidaGanada{get; set;}
    public Sospechoso culpable{get;private set;}

    public Partida(string NombreJugador){
        salas = new Dictionary<int, Sala>();
        partidaGanada=false;
        pistasRecolectadas = new Dictionary<int, bool>();
        pistasRecolectadas.Add(2, true);
        pistasRecolectadas.Add(3, true);
        pistasRecolectadas.Add(4, true);
        pistasRecolectadas.Add(5, true);
        pistasRecolectadas.Add(6, true);
        pistasRecolectadas.Add(7, true);
        pistasRecolectadas.Add(8, true);

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


      Sospechoso abuelo = new Sospechoso();
abuelo.crearSospechoso("Abuelo Iván", "abuelo.png");
listaSospechosos.Add(abuelo);

Sospechoso tio = new Sospechoso();
tio.crearSospechoso("Dmitri", "tio.png");
listaSospechosos.Add(tio);

Sospechoso hermana = new Sospechoso();
hermana.crearSospechoso("Elena", "hermana.png");
listaSospechosos.Add(hermana);

Sospechoso primo = new Sospechoso();
primo.crearSospechoso("Andrei", "primo.png");
listaSospechosos.Add(primo);

Sospechoso mayordomo = new Sospechoso();
mayordomo.crearSospechoso("Nikolai", "mayordomo.png");
listaSospechosos.Add(mayordomo);

Sospechoso olga = new Sospechoso();
olga.crearSospechoso("Olga", "cocinera.png");
listaSospechosos.Add(olga);

Sospechoso viktor = new Sospechoso();
viktor.crearSospechoso("Viktor", "viktor.png");
listaSospechosos.Add(viktor);
        culpable=listaSospechosos[2];

    }

    public bool estanTodasPistas() {
        foreach (bool pista in pistasRecolectadas.Values) {
            if (pista == false) {
                return false;
            }
        }
        return true;
    }
}