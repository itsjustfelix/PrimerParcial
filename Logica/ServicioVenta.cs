using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Logica
{
    public class ServicioVenta : IService
    {
        DatosVenta datosVenta = new DatosVenta();

        public string Agregar(Venta venta)
        {
            if(venta == null) throw new ArgumentNullException("La venta no puede ser nula");
            
            return datosVenta.Capturar(venta);
        }

        public List<Venta> Consultar()
        {
           return datosVenta.Consultar();
        }

        public string Eliminar(int id)
        {
            try
            {
                if (id == null) throw new ArgumentNullException("El id de la compra a eliminar no puede estar vacio");
                var lista = Consultar();
                var index = lista.FindIndex(v => v.id.Equals(id));
                lista.RemoveAt(index);
                return datosVenta.eliminar(lista);
            }
            catch (Exception e)
            {
                return $"error -> {e.Message}";
            }
        }
    }
}
