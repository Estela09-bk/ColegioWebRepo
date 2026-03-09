using BibliotecaColegio.Bussines;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ColegioWeb1.Controllers
{
    public class ReinscripcionController : Controller
    {
        [HttpGet]
        public IActionResult ReinscripcionA()
        {
            return View();
        }

        [HttpGet]
        public JsonResult BuscarAlumno(string nombre, string apellido)
        {
            try
            {
                AlumnoBAL bal = new AlumnoBAL();
                var alumno = bal.ObtenerAlumnoCompleto(nombre, apellido);

                if (alumno == null)
                {
                    return Json(new
                    {
                        encontrado = false,
                        mensaje = "Alumno no encontrado en la base de datos"
                    });
                }

                return Json(new
                {
                    encontrado = true,
                    idAlumno = alumno.Idalumno,
                    nombre = alumno.nombre ?? "",
                    apellido = alumno.apellido ?? "",
                    status = alumno.status_alumno ?? "Activo",
                    telefono = alumno.telefono ?? "",
                    correo = alumno.correo ?? ""
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    encontrado = false,
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public JsonResult GuardarReinscripcion([FromBody] ReinscripcionModel model)
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
    }

    public class ReinscripcionModel
    {
        public int IdAlumno { get; set; }
        public string Status { get; set; } = "";
        public string TipoServicio { get; set; } = "";
        public string Lapso { get; set; } = "";
        public string MetodoPago { get; set; } = "";
    }
}