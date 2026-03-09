using ColegioWeb1;
using BibliotecaColegio.DataLayer;
using BibliotecaColegio.Entities;
using BibliotecaColegio.Bussines;
using Microsoft.AspNetCore.Mvc;

namespace ColegioWeb1.Controllers
{
    public class AlumnosController : Controller //llama a la carpeta
    {


        [HttpGet]
        public IActionResult NuevoAlumno()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AlumnoA()
        {
            AlumnosDAL dal = new AlumnosDAL();
            var lista = dal.TraerListaalumnos();
            return View(lista);

        }

        [HttpPost]
        public JsonResult GuardarAlumnos([FromBody] ReinscripcionModel model)
        {
            try
            {
                AlumnoBAL bal = new AlumnoBAL();
                bool resultado = bal.ActualizarStatusAlumno(model.IdAlumno, model.Status);

                if (resultado)
                {
                    return Json(new
                    {
                        success = true,
                        mensaje = "Reinscripción guardada correctamente"
                    });
                }
                else
                {
                    return Json(new { success = false, mensaje = "No se pudo actualizar el status" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult GuardarAlumno(Alumnosinfo alumno)
        {
            try
            {
                AlumnoBAL bal = new AlumnoBAL();
                int idGenerado = bal.GuardarAlumno(alumno);

                if (idGenerado > 0)
                {
                    return RedirectToAction("AlumnoA");
                }

                return View("NuevoAlumno");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("NuevoAlumno");
            }
        }


        /* [HttpGet]
           public IActionResult Status()
           {
               AlumnosDAL dal = new AlumnosDAL();
               var lista = dal.Filtrador();
               return View(lista);
           }*/
    }
}



   

