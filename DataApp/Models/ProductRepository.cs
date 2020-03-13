using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class ProductRepository : IRepository
    {
        private EFDBContext _context;

        public ProductRepository(EFDBContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            _context.Remove(new Product { Id = id });
            _context.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
            return _context.Products.Include(p => p.Category).ToList<Product>();
        }

        public List<Product> GetFilterProduct(string category, decimal? minPrice, bool includeRelatedData)
        {
            IQueryable<Product> products = _context.Products;

            if(category != null)
            {
               products = products.Where(p => p.Category == category);
            }

            if (minPrice != null)
            {
               products = products.Where(p => p.Price >= minPrice);
            }

            if(includeRelatedData == true)
            {
                products = products.Include(p => p.Supplier);
            }

            return products.ToList<Product>();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Include(p => p.Category).First(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
