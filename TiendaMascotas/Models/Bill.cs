using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public double BaseTotal { get; set; }
        public double NetTotal { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int DiscountId { get; set; }
    }
}