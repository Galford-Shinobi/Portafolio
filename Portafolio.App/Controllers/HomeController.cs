using Microsoft.AspNetCore.Mvc;
using Portafolio.App.Models;
using Portafolio.Common.ViewModels;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos _repositorioProyectos;
        private readonly IServicioEmail _servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, IServicioEmail servicioEmail)
        {
            _logger = logger;
            _repositorioProyectos = repositorioProyectos;
            _servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("este es un mensaje de LogInformation!");
            _logger.LogCritical("este es un mensaje de Critical!");
            _logger.LogWarning("este es un mensaje de Warning!");
            _logger.LogError("este es un mensaje de Error!");

            var proyectos = _repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            ViewBag.Name = "Daniel Hernández Corona";

            ViewBag.Age = 10000;

            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos
            };
            return View(modelo);
        }

        public IActionResult Proyectos()
        {
            var proyectos = _repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {

            if (!ModelState.IsValid) { return View(contactoViewModel); }

            await _servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}