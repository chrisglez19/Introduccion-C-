using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    class Item : ItemBase
    {
        
        
        public Item(Articulo articulo, int cantidad) : base (articulo, cantidad)
        {

        }
        public override void Imprimir()
        {
            Console.WriteLine($"{Id} {Nombre}: {Precio} cantidad: {Cantidad} subtotal:  {Subtotal()}\nTotal:  {Total()}");
        }
    }
}
