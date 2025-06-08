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

    public IActionResult ingresarNombre(string nombre){
        Partida partidaNueva = new Partida(nombre);
        HttpContext.Session.SetString("partida", Objeto.ObjectToString(partidaNueva));
        
       
        return View("salaDeEstar");
    }

    public IActionResult salaDeEstar(){

        return View();
    }

    public IActionResult patio(){
        Partida partidaNueva= Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        ViewBag.estaDesbloqueada = partidaNueva.salas[2].estaDesbloqueada;
        ViewBag.nombre = partidaNueva.nombreJugador;
        return View();
    }

    public IActionResult desbloquearSala(string clave, int sala, string salaOriginal){
        if (Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida")) != null)
        {
            Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
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
         if (partidaNueva.salas[numSala].puedeEntrar()){
            return RedirectToAction(sala);
         }else{
            return View();
         }
    }
    public IActionResult mapa(){
        return View();
    }
}
