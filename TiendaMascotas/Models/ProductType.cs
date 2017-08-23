using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int IdCategory { get; set; }
    }
}