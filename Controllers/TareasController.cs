using IdentityDemo.DTOs;
using IdentityDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace IdentityDemo.Controllers
{
    [Authorize]
    public class TareasController : Controller
    {
        private readonly ITareasService tareasService;
        private readonly UserManager<IdentityUser> userManager;


        public TareasController(
            ITareasService tareasService,
            UserManager<IdentityUser> userManager)
        {
            this.tareasService = tareasService;
            this.userManager = userManager;
        }


        public IActionResult Index()
        {
            var userId = userManager.GetUserId(User);


            var tareas = tareasService.ObtenerTareasUsuario(userId);


            return View(tareas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(TareaDto tareaDto)
        {
            if (!ModelState.IsValid)
                return View(tareaDto);


            var userId = userManager.GetUserId(User);


            tareasService.CrearTarea(tareaDto, userId);


            return RedirectToAction(nameof(Index));
        }

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var userId = userManager.GetUserId(User);

            var borrado = tareasService.BorrarTarea(id, userId);

            // si no se puede borrar, volvemos a la lista
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = userManager.GetUserId(User);

            var tarea = tareasService.ObtenerTareaPorId(id, userId);

            if (tarea == null)
                return NotFound();

            return View(tarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TareaDto tareaDto)
        {
            if (!ModelState.IsValid)
                return View(tareaDto);

            var userId = userManager.GetUserId(User);

            var editada = tareasService.EditarTarea(tareaDto, userId);

            if (!editada)
                return Forbid();

            return RedirectToAction(nameof(Index));
        }

        // tareas pendientes
        public IActionResult Pendientes()
        {
            var userId = userManager.GetUserId(User);

            var tareas = tareasService.ObtenerTareasPorEstado(userId, "Pendiente");

            return View("Index", tareas);
        }

        // tareas en proceso
        public IActionResult EnProceso()
        {
            var userId = userManager.GetUserId(User);

            var tareas = tareasService.ObtenerTareasPorEstado(userId, "EnProceso");

            return View("Index", tareas);
        }

        // tareas completadas
        public IActionResult Completadas()
        {
            var userId = userManager.GetUserId(User);

            var tareas = tareasService.ObtenerTareasPorEstado(userId, "Completada");

            return View("Index", tareas);
        }


    }

}


