using Microsoft.AspNetCore.Mvc;
using BibliotecaColegio.DataLayer;
using BibliotecaColegio.Entities;
using BibliotecaColegio.Bussines;
//hola

namespace ColegioWeb1.Controllers
{
    public class AccesoController : Controller
    {
        private readonly string _cadenasql;

        public AccesoController(IConfiguration config)
        {
            _cadenasql = config.GetConnectionString("Conexion Colegio ") ?? "";
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Log(Administrador ADMLog)
        {
            AdminBAL ABAL = new AdminBAL();
            bool Acessopermitido = ABAL.ValidaADM(ADMLog, _cadenasql);
            if (Acessopermitido)
            {
                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                ViewBag.Error = "Usuario no autorizado ";
                return View("Index");
            }

        }

    }
}
