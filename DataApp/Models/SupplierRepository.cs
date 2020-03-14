using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface ISupplierRepository
    {
        Supplier Get(long id);
        List<Supplier> GetAll();
        void Create(Supplier newDataObject);
        void Update(Supplier changedDataObject);
        void Delete(long id);
    }

    public class SupplierRepository : ISupplierRepository
    {
        private EFDBContext context;
        public SupplierRepository(EFDBContext ctx) => context = ctx;
        public Supplier Get(long id)
        {
            return context.Suppliers.Find(id);
        }
        public List<Supplier> GetAll()
        {
            return context.Suppliers.ToList();
        }
        public void Create(Supplier newDataObject)
        {
            context.Add(newDataObject);
            context.SaveChanges();
        }
        public void Update(Supplier changedDataObject)
        {
            context.Update(changedDataObject);
            context.SaveChanges();
        }
        public void Delete(long id)
        {
            context.Remove(Get(id));
            context.SaveChanges();
        }
    }
}
