using IdentityDemo.Models;

namespace IdentityDemo.Datos.Repositorios
{
    public class TareaRepository : ITareaRepository
    {
        private readonly ApplicationDbContext context;

        public TareaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tarea> ObtenerPorUsuario(string userId)
        {
            return context.Tareas
                          .Where(t => t.UserId == userId)
                          .ToList();
        }

        public Tarea? ObtenerPorId(int id)
        {
            return context.Tareas.FirstOrDefault(t => t.Id == id);
        }

        public void Crear(Tarea tarea)
        {
            context.Tareas.Add(tarea);
            context.SaveChanges();
        }

        public void Borrar(Tarea tarea)
        {
            context.Tareas.Remove(tarea);
            context.SaveChanges();
        }

        public void Actualizar(Tarea tarea)
        {
            context.Tareas.Update(tarea);
            context.SaveChanges();
        }
    }
}
