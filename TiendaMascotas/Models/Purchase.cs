using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdBill { get; set; }
    }
}