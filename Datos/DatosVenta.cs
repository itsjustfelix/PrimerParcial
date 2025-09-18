using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DatosVenta : IDatos
    {
        string path = "Ventas";
        public Venta Capturar(Venta venta)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine($"{venta.id};{venta.cliente};{venta.subtotal};{venta.descuento};{venta.total}");
                sw.Close();
                return venta;
            }
            catch (Exception ex)
            {
               throw new Exception($"hubo un error -> {ex.Message}");
            }
        }

        public List<Venta> Consultar()
        {
            try
            {
                List<Venta> lista = new List<Venta>();
                StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    lista.Add(Mapeo(sr.ReadLine()));
                }
                sr.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"hubo un error -> {ex.Message}");
            }
        }

        public string eliminar(List<Venta> lista)
        {
            string rutaTemporal = "temp.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(rutaTemporal, false))
                {
                    foreach (var venta in lista)
                    {
                        sw.WriteLine($"{venta.id};{venta.cliente};{venta.subtotal};{venta.descuento};{venta.total}");
                    }
                }

                File.Delete(path);
                File.Move(rutaTemporal, path);
                return $"Venta eliminada correctamente";
            }
            catch (Exception e)
            {
                return $"hubo un error -> {e.Message}";
            }
        }

        public Venta Mapeo(string linea)
        {
           Venta venta = new Venta();
            try
            {
                string[] datos = linea.Split(';');
                venta.id = int.Parse(datos[0]);
                venta.cliente = datos[1];
                venta.subtotal = double.Parse(datos[2]);
                venta.descuento = double.Parse(datos[3]);
                venta.total = double.Parse(datos[4]);
                return venta;
            }
            catch (Exception ex)
            {
                throw new Exception($" hubo un error -> {ex.Message}");
            }
        }
    }
}
