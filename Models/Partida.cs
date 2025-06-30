class Partida
{
    public string nombreJugador { get; private set; }
    public Dictionary<int, Sala> salas { get; private set; }
    public Dictionary<int, bool> pistasRecolectadas { get; private set; }
    public List<Sospechoso> listaSospechosos { get; private set; }
    public bool partidaGanada { get; set; }
    public Sospechoso culpable { get; private set; }

    public Partida(string NombreJugador)
    {
        salas = [];
        partidaGanada = false;
        pistasRecolectadas = new Dictionary<int, bool>
        {
            { 2, false },
            { 3, false },
            { 4, false },
            { 5, false },
            { 6, false },
            { 7, false },
        };

        listaSospechosos = [];
        this.nombreJugador = NombreJugador;

        salas.Add(1, new Sala("Empezar", true, new List<int> { }));
        salas.Add(2, new Sala("desbloquear", false,  new List<int> { }));
        salas.Add(3, new Sala("JKCNM", false,  new List<int> { }));
        salas.Add(4, new Sala("Karamázov1900", false, new List<int> { 3 }));
        salas.Add(5, new Sala("53", false, new List<int> { 2, 4 }));
        salas.Add(6, new Sala("desbloquear", false, new List<int> { 5 }));
        salas.Add(7, new Sala("Los hermanos Karamazov", false, new List<int> { 6 }));
        salas.Add(8, new Sala("Empezar", false, new List<int> { 7 }));


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
        culpable = listaSospechosos[2];

    }

    public bool estanTodasPistas()
    {
        foreach (bool pista in pistasRecolectadas.Values)
        {
            if (pista == false)
            {
                return false;
            }
        }
        return true;
    }
    public bool puedeEntrar(int numSala)
    {
        Sala sala = salas[numSala];
        bool puedeEntrarAhora = true;

        if (sala.numSalaDependienteDe == null || sala.numSalaDependienteDe.Count < 1)
        {
            return true;
        }

        foreach (int dependencia in sala.numSalaDependienteDe)
        {
            if (!salas[dependencia].estaDesbloqueada)
            {
                puedeEntrarAhora = false;
                return puedeEntrarAhora;
            }
        }
        return puedeEntrarAhora;
    }
}