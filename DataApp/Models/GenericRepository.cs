using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(long id);
        List<T> GetAll();
        void Create(T newDataObject);
        void Update(T changedDataObject);
        void Delete(long id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected EFDBContext context;
        public GenericRepository(EFDBContext ctx) => context = ctx;
        public virtual T Get(long id)
        {
            return context.Set<T>().Find(id);
        }
        public virtual List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual void Create(T newDataObject)
        {
            context.Add<T>(newDataObject);
            context.SaveChanges();
        }
        public virtual void Delete(long id)
        {
            context.Remove<T>(Get(id));
            context.SaveChanges();
        }
        public virtual void Update(T changedDataObject)
        {
            context.Update<T>(changedDataObject);
            context.SaveChanges();
        }
    }
}