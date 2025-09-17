using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        int id { get; set; }
        string cliente { get; set; }
        double subtotal { get; set; }
        double descuento { get; set; }
        double total { get; set; }

    }
}
