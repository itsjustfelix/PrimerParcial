using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.IO;
namespace Datos
{
    public interface IDatos
    {
        string Capturar(Venta venta);
        List<Venta> Consultar();

        String eliminar(List<Venta> lista);

        Venta Mapeo(string linea);
    }
}
