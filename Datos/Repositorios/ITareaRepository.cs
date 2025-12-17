using IdentityDemo.Models;

namespace IdentityDemo.Datos.Repositorios
{
    public interface ITareaRepository
    {
        IEnumerable<Tarea> ObtenerPorUsuario(string userId);
        Tarea? ObtenerPorId(int id);

        void Crear(Tarea tarea);
        void Borrar(Tarea tarea);

        void Actualizar(Tarea tarea);
    }
}
