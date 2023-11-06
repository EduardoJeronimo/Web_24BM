using Microsoft.AspNetCore.Mvc;
using web_24BM.Services;
using Web_24BM.Models;
using Microsoft.AspNetCore.Hosting;


namespace Web_24BM.Controllers
{
    public class CurriculumController : Controller
    {
        private readonly ICurriculum _curriculumService;
        private readonly IWebHostEnvironment _environment;

        public CurriculumController(ICurriculum curriculumService, IWebHostEnvironment environment)
        {
            _curriculumService = curriculumService;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _curriculumService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Curriculum model, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto != null && Foto.Length > 0)
                {
                    // Directorio de destino (utiliza "img" en lugar de "uploads")
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "img");

                    // Asegúrate de que el directorio exista, o créalo si no existe
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Genera un nombre de archivo único (puedes personalizar esta lógica)
                    string fileName = Guid.NewGuid() + "_" + Foto.FileName;
                    string filePath = Path.Combine(uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Foto.CopyToAsync(stream);
                    }

                    model.NombreFoto = fileName;
                }

                var response = await _curriculumService.Create(model);

                if (response.Success)
                {
                    TempData["MenssageSuccess"] = response.Message;
                    return RedirectToAction("Index", "Curriculum");
                }
                else
                {
                    TempData["ErrorMessage"] = response.Message;
                    return View(model);
                }
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int idCurriculum)
        {
            var curriculum = await _curriculumService.GetById(idCurriculum);

            return View(curriculum);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Curriculum model, IFormFile NuevoFoto)
        {
            // Obtener el curriculum existente
            var curriculumExistente = await _curriculumService.GetById(model.Id);

            // Verificar si se cargó una nueva foto
            if (NuevoFoto != null)
            {
                // Procesar y guardar la nueva foto
                var fileName = Path.GetFileName(NuevoFoto.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await NuevoFoto.CopyToAsync(stream);
                }

                // Actualizar el nombre de la foto en el modelo
                model.NombreFoto = fileName;
            }
            else
            {
                // Si no se cargó una nueva foto, mantener la foto existente sin cambios
                model.NombreFoto = curriculumExistente.NombreFoto;
            }

            // Actualizar el curriculum
            var response = await _curriculumService.Update(model);

            if (response.Success)
            {
                TempData["MenssageSuccess"] = response.Message;
                return RedirectToAction("Index", "Curriculum");
            }
            else
            {
                TempData["ErrorMessage"] = response.Message;

                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int idCurriculum)
        {
            var response = await _curriculumService.Delete(idCurriculum);
            if (response.Success)
            {
                TempData["MenssageSuccess"] = response.Message;
                return RedirectToAction("Index", "Curriculum");
            }
            else
            {
                TempData["ErrorMessage"] = response.Message;

                return RedirectToAction("Index", "Curriculum");
            }
        }

        [HttpGet]
        public async Task<IActionResult> View(int idCurriculum)
        {
            var curriculum = await _curriculumService.GetById(idCurriculum);

            if (curriculum == null)
            {
                return NotFound(); // Puedes personalizar esta respuesta
            }

            return View(curriculum);
        }


    }
}
