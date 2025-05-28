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
        Partida partidaNueva = new Partida();
        HttpContext.Session.SetString("partida", Objeto.ObjectToString(partidaNueva));
       
        return View();
    }

    public IActionResult ingresarNombre(string nombre){
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        partidaNueva.iniciarPartida(nombre);
        HttpContext.Session.SetString("partida", Objeto.ObjectToString(partidaNueva));

        return View("Index");
    }


    public IActionResult desbloquearSala(string clave,string sala){
        Partida partidaNueva = Objeto.StringToObject<Partida>(HttpContext.Session.GetString("partida"));
        if(partidaNueva.salas[sala].clave == clave){
            partidaNueva.salasDesbloqueadas[sala] = true;
        }
        HttpContext.Session.SetString("partida", Objeto.ObjectToString(partidaNueva));
        return View("sala");
    }

}
