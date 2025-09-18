using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Logica
{
    public interface IService
    {
        Venta Agregar(Venta venta);
        List<Venta> Consultar();
        string Eliminar (int id);
        double CalcularTotalVenta();

    }
}
