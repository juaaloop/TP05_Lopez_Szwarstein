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

    public IActionResult inicio(){
        return View();
    }
[HttpPost]
    public IActionResult ingresarNombre(string nombre){
        Partida partidaNueva = new Partida(nombre);
        HttpContext.Session.SetString("partida", Objeto.ObjectToString(partidaNueva));

        return View("salaDeEstar");
    }

    public IActionResult salaDeEstar(){

        return View();
    }

    public IActionResult cocina(){
        Partida partidaNueva= Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        ViewBag.estaDesbloqueada = partidaNueva.salas[3].estaDesbloqueada;
        return View();
    }
      public IActionResult estanteria(){
        Partida partidaNueva= Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        ViewBag.estaDesbloqueada = partidaNueva.salas[3].estaDesbloqueada;
        ViewBag.salas = partidaNueva.salas;
        return View();
    }

    public IActionResult patio(){
        Partida partidaNueva= Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        ViewBag.estaDesbloqueada = partidaNueva.salas[2].estaDesbloqueada;
        ViewBag.nombre = partidaNueva.nombreJugador;
        return View();
    }
    public IActionResult sotano(){

        return View();
    }
    public IActionResult luz(){

        return View();
    }
    public IActionResult baño(){

        return View();
    }
     public IActionResult manijas(int numeroActual, int manija1, int manija2){
        ViewBag.numeroActual=numeroActual;
        ViewBag.manija1 = manija1;
        ViewBag.manija2 = manija2;
        return View();
    }
    public IActionResult enviarValorManija(int valor, int manija, int numeroActual, int manija1, int manija2)
    {
        numeroActual += valor;
        if (manija == 1)
             {
                 manija1++;
             }
        else
             {
                 manija2++;
             }

        return RedirectToAction("manijas", new { numeroActual = numeroActual, manija1 = manija1, manija2 = manija2 });
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
            }       
                 HttpContext.Session.SetString("partida", Objeto.ObjectToString(partidaNueva));
        }

        return RedirectToAction(salaOriginal);
    }

    public IActionResult irASala(string sala, int numSala){
         Partida partidaNueva= Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
         if (partidaNueva.salas[numSala].puedeEntrar(partidaNueva.salas)){
            return RedirectToAction(sala);
         }else{
            return View();
         }
    }
    public IActionResult mapa(){
        return View();
    }
}
