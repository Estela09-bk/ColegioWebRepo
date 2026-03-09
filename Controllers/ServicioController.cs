using Microsoft.AspNetCore.Mvc;


namespace ColegioWeb1.Controllers
{
    public class ServicioController : Controller

    {
        [HttpGet]
        public IActionResult ServicioA() //este abre pagina
        {
            return View();
        }
        [HttpGet]
        public IActionResult CrearServicioA()
        {
            return View();
        }
    }
}
