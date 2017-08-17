using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Models
{
    public class Discount
    {
        public int Id { get; set; }

        public int IdBill { get; set; }

        public int DiscountType { get; set; }

    }
}