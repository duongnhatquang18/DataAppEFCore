using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public enum Color
    {
        Red, Green, Blue
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Color Color { get; set; }
        public bool InStock { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
