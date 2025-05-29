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

    Partida partidaNueva = new Partida();
    public IActionResult Index()
    {
        Partida partidaNuevaa = new Partida();   
        return View();
    }

    public IActionResult ingresarNombre(string nombre){
        partidaNueva.iniciarPartida(nombre);
        return View("salaDeEstar");
    }

    public IActionResult salaDeEstar(){

        return View();
    }

    public IActionResult patio(){
        return View();
    }

    public IActionResult desbloquearSala(string clave, string sala){
        if(partidaNueva.salas[sala].clave == clave){
            partidaNueva.salas[sala].estaDesbloqueada = true;
        }
        return View(sala);
    }
}
