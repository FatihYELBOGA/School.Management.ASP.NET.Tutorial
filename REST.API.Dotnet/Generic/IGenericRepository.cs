using Microsoft.EntityFrameworkCore;

namespace School_Management.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Entity GetById(int id);
        List<Entity> GetAll();
        Entity Add(Entity entity);
        Entity Update(Entity entity);
        void DeleteById(int id);
        void DeleteByEntity(Entity entity);
            
    }
}
