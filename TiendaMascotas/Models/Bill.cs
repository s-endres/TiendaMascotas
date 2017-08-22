using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int Code { get; set; }
        public DateTime Date { get; set; }
        public double GrossCost { get; set; }
        public double Discount { get; set; }
        public double NetCost { get; set; }
        public List<Product> Products { get; set; }
    }
}