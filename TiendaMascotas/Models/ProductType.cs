using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public bool IsDeleted { get; set; }
    }
}