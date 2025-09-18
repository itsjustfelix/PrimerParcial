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
            Venta venta = new Venta();
            Console.Clear();
            Console.WriteLine("Captura de Venta");


            Console.WriteLine("digite el id");
            venta.id = int.Parse(Console.ReadLine());

            Console.WriteLine("digite el nombre del cliente ");
            venta.cliente = Console.ReadLine();

            Console.WriteLine("digite el subtotal de la compra");
            venta.subtotal = double.Parse(Console.ReadLine());

            Console.WriteLine("su subtotal es:");

            Console.ReadKey();


        }

        public void consultar()
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
            Console.ReadKey();
        }

        public void eliminar()
        {
            Console.Clear();
            Console.WriteLine("eliminar venta");

            Console.WriteLine("ingrese le id de la venta a eliminar");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(servicioventa.Eliminar(id));

            Console.WriteLine("Presione cualquier tecla para salir al menu principal");
            Console.ReadKey();
        }

        public void menu()
        {
            Console.Clear();
            int opcion;
            do
            {
                Console.WriteLine("Gestion de ventas");

                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. consultar");
                Console.WriteLine("3. Eliminar");
               
                Console.WriteLine("0. Volver");

                Console.WriteLine("Presione cualquier tecla para salir al menu principal");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: capturar(); break;
                    case 2: consultar(); break;
                    case 3: eliminar(); break;
                    
                }
            } while (opcion != 0);
        }
    }
}
