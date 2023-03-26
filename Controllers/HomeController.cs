using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;

namespace Portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos _repo;
    private readonly IServicioEmail servicioEmail;

    public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repo, IServicioEmail servicioEmail)
    {
        _logger = logger;
        _repo = repo;
        this.servicioEmail = servicioEmail;
    }

    public IActionResult Index()
    {
        var model = new HomeIndexViewModel();
        var proyectos = _repo.GetProyectos();

        model.Proyectos = proyectos;

        return View(model);
    }



    public IActionResult Proyectos()
    {
        var model = new HomeIndexViewModel();
        var proyectos = _repo.GetProyectos();

        model.Proyectos = proyectos;

        return View(proyectos);
    }


    public IActionResult Contacto()
    {
        return View();
    }

    [HttpPost] // atributo: indica que este evento responde a un http post. (por defecto todos son Get si no se especifica)
    public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
    {
        /*
         * Patron POST-Redireccion-GET:
         * Redireccionamos a otra web, para evitar duplicados en las transacciones http al pulsar 'F5'
         * de esta manera podriamos evitar compras dobles.
         */

        await servicioEmail.Enviar(contactoViewModel);

        return RedirectToAction("Gracias"); 
    }

    public IActionResult Gracias() // redireccion http de contacto ---> gracias
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
