using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface IRepository
    {
        Product GetProduct(int id);
        List<Product> GetAllProduct();
        List<Product> GetFilterProduct(string category, decimal? price, bool includeRelatedData);

        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
