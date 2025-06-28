using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalaDeEscape.Models;

namespace SalaDeEscape.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {

        return View();
    }

    public IActionResult inicio()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ingresarNombre(string nombre){
        Partida partidaNueva = new Partida(nombre);
        HttpContext.Session.SetString("partida", Objeto.ObjectToString(partidaNueva));

        return RedirectToAction("salaDeEstar");
    }

    public IActionResult salaDeEstar()
    {

        return View();
    }

    public IActionResult cocina()
    {
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        ViewBag.estaDesbloqueada = partidaNueva.salas[3].estaDesbloqueada;
        return View();
    }
    public IActionResult estanteria()
    {
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        ViewBag.estaDesbloqueada = partidaNueva.salas[3].estaDesbloqueada;
        ViewBag.salas = partidaNueva.salas;
        return View();
    }

    public IActionResult patio()
    {
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        ViewBag.estaDesbloqueada = partidaNueva.salas[2].estaDesbloqueada;
        ViewBag.nombre = partidaNueva.nombreJugador;
        return View();
    }
    public IActionResult sotano()
    {

        return View();
    }
    public IActionResult caja()
    {

        return View();
    }
    public IActionResult luz()
    {

        return View();
    }
    public IActionResult baño()
    {

        return View();
    }

    public IActionResult salaDeRetratos()
    {

        return View();
    }

    public IActionResult biblioteca()
    {

        return View();
    }
    public IActionResult estudio()
    {
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        ViewBag.estanLasPistas=partidaNueva.estanTodasPistas();
        ViewBag.ListaSospechosos = partidaNueva.listaSospechosos;
                ViewBag.acusado=partidaNueva.culpable.nombreSospechoso;

        return View();
    }
    public IActionResult manijas(int numeroActual1, int manija1, int manija2)
    {
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        ViewBag.estaDesbloqueada = partidaNueva.salas[5].estaDesbloqueada;
        ViewBag.numeroActual = numeroActual1;
        ViewBag.manija1 = manija1;
        ViewBag.manija2 = manija2;
        return View();
    }
    public IActionResult enviarValorManija(int valor, int manija, int numeroActual, int Manija1, int Manija2)
    {

        if (!(numeroActual == 0 && valor < 0))
        {
            numeroActual = numeroActual + valor;
            if (manija == 1)
            {
                if (valor == -1)
                {
                    Manija1 = Manija1 - 1;
                }
                else
                {
                    Manija1++;
                }
            }
            else if (valor == -3)
            {
                Manija2 = Manija2 - 1;
            }
            else
            {
                Manija2++;
            }


        }

        return RedirectToAction("manijas", new { numeroActual1 = numeroActual, manija1 = Manija1, manija2 = Manija2 });
    }
    public IActionResult desbloquearSala(string clave, int sala, string salaOriginal)
    {
        string partidaStr = HttpContext.Session.GetString("partida");
        if (!string.IsNullOrEmpty(partidaStr))
        {
            Partida partidaNueva = Objeto.StringToObject<Partida>(partidaStr);
            if (partidaNueva.salas[sala].clave == clave)
            {
                partidaNueva.salas[sala].estaDesbloqueada = true;
                partidaNueva.pistasRecolectadas[sala] = true;
            }
            HttpContext.Session.SetString("partida", Objeto.ObjectToString(partidaNueva));
        }

        return RedirectToAction(salaOriginal);
    }

    public IActionResult irASala(string sala, int numSala)
    {
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        if (partidaNueva.salas[numSala].puedeEntrar(partidaNueva.salas))
        {
            return RedirectToAction(sala);
        }
        else
        {
            return View();
        }
    }
    public IActionResult comprobarSospechoso(string sospechoso)
    {
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        if (partidaNueva.culpable.nombreSospechoso == sospechoso)
        {
            
            partidaNueva.partidaGanada = true;
        }
        HttpContext.Session.SetString("partida", Objeto.ObjectToString(partidaNueva));
        return RedirectToAction("final");
    }
    public IActionResult mapa()
    {
        return View();
    }
    public IActionResult final()
    {
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        if (partidaNueva.partidaGanada)
        {
            return RedirectToAction("finalBueno");
        }
        else
        {
            return RedirectToAction("finalMalo");
        }

    }
    public IActionResult finalBueno()
    {
        return View();
    }
    public IActionResult finalMalo()
    {
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        return View();
    }
}

