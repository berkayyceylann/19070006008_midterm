using _19070006008_midterm.Data.EntityFramework;
using System;
using System.Threading.Tasks;

namespace _19070006008_midterm.Data.Abstract
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public async Task<T> Create(T entity)
        {
            using (var context = new DataContext())
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public void Delete(T entity)
        {
            using (var context = new DataContext())
            {
                try
                {
                    context.Set<T>().Remove(entity);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public T Get(int id)
        {
            using (var context = new DataContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public void Update(T entity)
        {
            using (var context = new DataContext())
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
