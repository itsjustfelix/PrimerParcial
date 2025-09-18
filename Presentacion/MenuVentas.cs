using Entidades;
using System;
using Logica;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class MenuVentas : IPresentacion
    {
        ServicioVenta servicioventa = new ServicioVenta();
        public void capturar()
        {
            try
            {
                Venta venta = new Venta();
                Console.Clear();
                Console.WriteLine("Captura de Venta");


                Console.WriteLine("digite el id");
                venta.id = int.Parse(Console.ReadLine());

                Console.WriteLine("digite el nombre del cliente ");
                venta.cliente = Console.ReadLine();

                Console.WriteLine("digite el subtotal de la compra");
                venta.subtotal = double.Parse(Console.ReadLine());

                var resultado = servicioventa.Agregar(venta);
                Console.WriteLine($"su total es: {resultado.total}");
                Console.WriteLine("Presione cualquier tecla para salir al menu principal");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message}");
            }

            Console.ReadKey();
        }

        public void consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Consulta de Venta");

                Console.WriteLine("-----------------------------------------");
                foreach (var item in servicioventa.Consultar())
                {
                    Console.WriteLine(
                        $"id venta : {item.id}\n" +
                        $"nombre cliente : {item.cliente}\n" +
                        $"subtotal : {item.subtotal}\n" +
                        $"descuento : {item.descuento}\n" +
                        $"total : {item.total}"


                        );
                    Console.WriteLine("----------------------------------");
                }

                Console.WriteLine("Presione cualquier tecla para salir al menu principal");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.ReadKey();
        }

        public void consultaTotalIngresos()
        {
            Console.Clear();
            Console.WriteLine("Total de ingresos por ventas");
            Console.WriteLine($"El total de ingresos por venta es : {servicioventa.CalcularTotalVenta()}");
            Console.WriteLine("Presione cualquier tecla para salir al menu principal");
            Console.ReadKey();

        }

        public void eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("eliminar venta");
                Console.WriteLine("Estas son las ventas hasta el momento");
                Console.WriteLine("-----------------------------------------");
                foreach (var item in servicioventa.Consultar())
                {
                    Console.WriteLine(
                        $"id venta : {item.id}\n" +
                        $"nombre cliente : {item.cliente}\n" +
                        $"subtotal : {item.subtotal}\n" +
                        $"descuento : {item.descuento}\n" +
                        $"total : {item.total}"


                        );
                    Console.WriteLine("----------------------------------");
                }

                Console.WriteLine("ingrese le id de la venta a eliminar");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Esta seguro que desea eliminar esta venta? SI -> 1/ NO -> 0");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.WriteLine(servicioventa.Eliminar(id));
                    Console.Clear();
                    Console.WriteLine("Estas son las ventas Actualmente");
                    foreach (var item in servicioventa.Consultar())
                    {
                        Console.WriteLine(
                            $"id venta : {item.id}\n" +
                            $"nombre cliente : {item.cliente}\n" +
                            $"subtotal : {item.subtotal}\n" +
                            $"descuento : {item.descuento}\n" +
                            $"total : {item.total}"


                            );
                        Console.WriteLine("----------------------------------");
                    }
                }
                else Console.WriteLine("Operacion cancelada");
                Console.WriteLine("Presione cualquier tecla para salir al menu principal");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

        public void menu()
        {

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Tienda Escolar Mi Aula");
                Console.WriteLine("Gestion de ventas");
                Console.WriteLine("");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. consultar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Consultar el total de ventas");
                Console.WriteLine("0. Volver");
                Console.WriteLine("Made by: Felix buelvas y Sandra Gomez");
                Console.WriteLine("Presione cualquier tecla para salir al menu principal");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: capturar(); break;
                    case 2: consultar(); break;
                    case 3: eliminar(); break;
                    case 4: consultaTotalIngresos(); break;
                }
            } while (opcion != 0);
        }
    }
}
