using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    class ItemDescuento : ItemBase
    {
        public decimal Descuento { get; set; }
        public decimal impDescuento { get; set; }


        public ItemDescuento(Articulo articulo, int cant, decimal descuento) : base (articulo, cant)
        {
            Descuento = descuento;
        }
        
       
       
        public override decimal Total()
        {
            decimal total = Subtotal()-(Subtotal() * Descuento / 100);
            return total;
        }

        public override void Imprimir()
        {
            Console.WriteLine($"{Id} {Nombre}: {Precio} cantidad: {Cantidad} subtotal: {Subtotal()}");
            Console.WriteLine($"Descuento: {Subtotal()- Total()}({Descuento})\nTotal: {Total()}");
        }


    }
}
