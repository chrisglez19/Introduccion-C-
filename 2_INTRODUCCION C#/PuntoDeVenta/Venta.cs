using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    class Venta
    {
        
        public List<Articulo> articulos;
        public void Menu()
        {
            
            Serializar();
            string arranque, repetir = "1", nombre,compañia, telefono;
            int idArticulo, cantidad, tipo, i=0;
            decimal precio, descuento, comision, totalTod=0;

            do
            {
                decimal total1;
                Console.Clear();
                List<ItemBase> ticket = new List<ItemBase>();
                do
                {
                    
                    Console.WriteLine("Ingresa id articulo");
                    idArticulo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingresa la cantidad");
                    cantidad = int.Parse(Console.ReadLine());

                    Articulo art = articulos.Where(x => x.Id == idArticulo).FirstOrDefault();
                    precio = art.Precio;
                    nombre = art.Nombre;
                    tipo = art.Tipo;
                    switch (tipo)
                    {
                        case 1:
                            Item item = new Item(art, cantidad);
                            ticket.Add(item);
                            //totalTod = totalTod + (item.Precio * cantidad);
                            break;
                        case 2:
                            Console.WriteLine("Ingresa el descuento");
                            descuento = int.Parse(Console.ReadLine());
                            ItemDescuento itemDesc = new ItemDescuento(art, cantidad, descuento);
                            ticket.Add(itemDesc);
                            decimal totaldes = (itemDesc.Precio*cantidad);
                            break;
                        case 3:
                            Console.WriteLine("Ingresa telefono");
                            telefono = Console.ReadLine();
                            Console.WriteLine("Ingresa compañia");
                            compañia = Console.ReadLine();
                            Console.WriteLine("Ingresa comision correspondiente");
                            comision = int.Parse(Console.ReadLine());
                            ItemTA itemTA = new ItemTA(art, cantidad, telefono, compañia, comision);
                            ticket.Add(itemTA);
                            break;
                    }

                    Console.WriteLine("Continuar Vente (CV)\nTerminar Venta(TV)");
                    repetir = Console.ReadLine().ToUpper();
                } while (repetir != "TV");
                Console.WriteLine("Empresa TICH");
                foreach (var elem in ticket)
                { 
                    elem.Imprimir();
                }
                total1 = ticket.Sum(x => x.Total());
                Console.WriteLine($"Total: {total1}");
                //Console.WriteLine($"Total: {totalTod}\n\n");

                Console.WriteLine("Iniciar una nueva venta (V) terminar (T)");
                arranque = Console.ReadLine().ToUpper();
                i++;
                 totalTod = totalTod + total1;
                if (arranque != "V")
                {
                    Console.WriteLine($"La venta del dia fueron {i} clientes con un total de {totalTod}");
                    Console.ReadKey();
                }
            } while (arranque == "V");
            
        }

        public void Serializar()
        {
            string rutaArticulos = @"C:\Users\DOTNET6\Documents\DESARROLLO .NET\2_INTRODUCCION C#\Articulos.json";

            StreamReader jsonArticuloStr = new StreamReader(rutaArticulos);
            var jsonArticulo = jsonArticuloStr.ReadToEnd();
            jsonArticuloStr.Close();
            articulos = JsonConvert.DeserializeObject<List<Articulo>>(jsonArticulo);


        }
    }
}
