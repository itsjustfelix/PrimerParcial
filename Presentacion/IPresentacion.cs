using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public interface IPresentacion
    {
        void capturar();
        void consultar();
        void consultaTotalIngresos();
        void eliminar();
        void menu();
    }
}
