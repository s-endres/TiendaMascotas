using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public int BillId { get; set; }
    }
}