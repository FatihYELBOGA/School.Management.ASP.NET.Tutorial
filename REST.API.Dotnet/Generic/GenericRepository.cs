using Microsoft.EntityFrameworkCore;
using School_Management.DatabaseConfig;

namespace School_Management.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        private DataContext _dataContext;
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Entity GetById(int id)
        {
            return _dataContext.Set<Entity>().Find(id);
        }

        public List<Entity> GetAll()
        {
            return _dataContext.Set<Entity>().ToList();
        }

        public Entity Add(Entity entity)
        {
            Entity addedEntity =  _dataContext.Add<Entity>(entity).Entity;
            _dataContext.SaveChanges();
            return addedEntity;
        }

        public Entity Update(Entity entity)
        {
            Entity updatedEntity = _dataContext.Update<Entity>(entity).Entity;
            _dataContext.SaveChanges();
            return updatedEntity;
        }

        public void DeleteById(int id)
        {
            _dataContext.Remove<Entity>(GetById(id));
            _dataContext.SaveChanges();
        }

        public void DeleteByEntity(Entity entity)
        {
            _dataContext.Remove<Entity>(entity);
            _dataContext.SaveChanges();
        }
    }
}
