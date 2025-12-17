using IdentityDemo.Datos.Repositorios;
using IdentityDemo.DTOs;
using IdentityDemo.Models;

namespace IdentityDemo.Services
{
    public class TareasService : ITareasService
    {
        private readonly ITareaRepository tareaRepository;

        public TareasService(ITareaRepository tareaRepository)
        {
            this.tareaRepository = tareaRepository;
        }

        public IEnumerable<TareaDto> ObtenerTareasUsuario(string userId)
        {
            var tareas = tareaRepository.ObtenerPorUsuario(userId);

            return tareas.Select(t => new TareaDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                Estado = t.Estado,
                FechaCreacion = t.FechaCreacion,
                FechaCompletada = t.FechaCompletada
            });
        }

        public void CrearTarea(TareaDto tareaDto, string userId)
        {
            var tarea = new Tarea
            {
                Titulo = tareaDto.Titulo,
                Descripcion = tareaDto.Descripcion,
                Estado = tareaDto.Estado,
                FechaCreacion = DateTime.Now,
                FechaCompletada = tareaDto.Estado == "Completada"
                    ? DateTime.Now
                    : null,
                UserId = userId
            };

            tareaRepository.Crear(tarea);
        }

        public bool BorrarTarea(int tareaId, string userId)
        {
            var tarea = tareaRepository.ObtenerPorId(tareaId);

            if (tarea == null || tarea.UserId != userId)
                return false;

            tareaRepository.Borrar(tarea);
            return true;
        }

        // obtiene la tarea para cargar el formulario de edición
        public TareaDto? ObtenerTareaPorId(int tareaId, string userId)
        {
            var tarea = tareaRepository.ObtenerPorId(tareaId);

            if (tarea == null || tarea.UserId != userId)
                return null;

            return new TareaDto
            {
                Id = tarea.Id,
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                Estado = tarea.Estado,
                FechaCreacion = tarea.FechaCreacion,
                FechaCompletada = tarea.FechaCompletada
            };
        }

        // guarda los cambios de la tarea editada
        public bool EditarTarea(TareaDto tareaDto, string userId)
        {
            var tarea = tareaRepository.ObtenerPorId(tareaDto.Id);

            if (tarea == null || tarea.UserId != userId)
                return false;

            tarea.Titulo = tareaDto.Titulo;
            tarea.Descripcion = tareaDto.Descripcion;
            tarea.Estado = tareaDto.Estado;
            tarea.FechaCompletada = tareaDto.Estado == "Completada"
                ? DateTime.Now
                : null;

            tareaRepository.Actualizar(tarea);
            return true;
        }

        public IEnumerable<TareaDto> ObtenerTareasPorEstado(string userId, string estado)
        {
            var tareas = tareaRepository.ObtenerPorUsuario(userId)
                                        .Where(t => t.Estado == estado);

            return tareas.Select(t => new TareaDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                Estado = t.Estado,
                FechaCreacion = t.FechaCreacion,
                FechaCompletada = t.FechaCompletada
            });
        }

    }
}
