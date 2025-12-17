using IdentityDemo.DTOs;

namespace IdentityDemo.Services
{
    public interface ITareasService
    {
        IEnumerable<TareaDto> ObtenerTareasUsuario(string userId);
        void CrearTarea(TareaDto tareaDto, string userId);
        bool BorrarTarea(int tareaId, string userId);

        // obtener una tarea para editar
        TareaDto? ObtenerTareaPorId(int tareaId, string userId);

        // guardar los cambios de la tarea editada
        bool EditarTarea(TareaDto tareaDto, string userId);
        // obtener tareas filtradas por estado
        IEnumerable<TareaDto> ObtenerTareasPorEstado(string userId, string estado);

    }
}
