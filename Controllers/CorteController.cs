using Microsoft.AspNetCore.Mvc;

namespace ColegioWeb1.Controllers
{
    public class CorteController : Controller
    {

        [HttpGet]
        public IActionResult Corte() //este abre pagina
        {
            return View();
        }
    }
}
