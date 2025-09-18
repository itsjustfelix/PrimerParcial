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

        public Venta Agregar(Venta venta)
        {
            if (venta == null) throw new ArgumentNullException("La venta no puede ser nula");
            if (IdExistente(venta.id)) throw new ArgumentException("El id de la venta ya existe");
            var descuento = CalcularDescuento(venta.subtotal);
            venta.descuento = descuento;
            venta.CalcularTotal();
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

        private bool IdExistente(int id)
        {
            foreach (var venta in Consultar())
            {
                if (venta.id == id) return true;
            }
            return false;
        }

        public double CalcularDescuento(double subtotal)
        {
            if (subtotal < 30000)return 0; // 0%
            if (subtotal <= 70000)return subtotal * 0.05; // 5%
            return subtotal * 0.08; // 8%
        }
    }
}
