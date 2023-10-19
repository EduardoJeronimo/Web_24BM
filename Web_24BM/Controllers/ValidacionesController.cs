using Microsoft.AspNetCore.Mvc;
using Web_24BM.Models;

namespace Web_24BM.Controllers
{
    public class ValidacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Curriculum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarFormulario(Curriculum model)
        {
            string mensaje = " ";
            if (ModelState.IsValid)
            {
                mensaje = "Datos Validos";
                TempData["msj"] = mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                mensaje = "Datos Incorrectos";
                return View("Index",model) ;
            }
            
        }
    }
}

