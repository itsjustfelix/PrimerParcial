using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public int id { get; set; }
        public string cliente { get; set; }
        public double subtotal { get; set; }
        public double descuento { get; set; }
        public double total { get; set; }

        public void CalcularTotal()
        {
            total = subtotal - descuento;
        }

    }
}
