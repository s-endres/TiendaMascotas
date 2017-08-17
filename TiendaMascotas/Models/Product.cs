using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int IdProductType { get; set; }

        public bool isSold { get; set; }

        public double Price { get; set; }
    }
}