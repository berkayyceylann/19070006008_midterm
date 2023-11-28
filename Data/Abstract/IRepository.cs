using System.Threading.Tasks;

namespace _19070006008_midterm.Data.Abstract
{
    public interface IRepository<Entity> where Entity : class
    {
        Task<Entity> Create(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
        Task<Entity> Get(int id);
    }
}
