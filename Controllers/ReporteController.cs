using Microsoft.AspNetCore.Mvc;

namespace ColegioWeb1.Controllers
{
    public class ReporteController : Controller
    {
        [HttpGet]
        public IActionResult ReporteA() //este abre pagina
        {
            return View();
        }
    }
}
