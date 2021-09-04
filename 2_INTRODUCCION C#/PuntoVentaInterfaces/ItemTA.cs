using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVentaInterfaces
{
    class ItemTA : ItemBase
    {

        public string Telefono { get; set; }
        public string Compañia { get; set; }
        public decimal Comision { get; set; }

        public ItemTA(Articulo articulo, int cant, string telefono, string compañia, decimal comision) : base(articulo, cant)
        {
            Telefono = telefono;
            Compañia = compañia;
            Comision = comision;

        }

        public override decimal Total()
        {
            decimal total = Subtotal() + Comision;
            return total;
        }

        public override void Imprimir()
        {

            Console.WriteLine($"{Id} {Nombre}: {Precio} cantidad: {Cantidad} subtotal: {Subtotal()}");
            Console.WriteLine($"Telefono: {Telefono} Compañia: ({Compañia}) Comision: {Comision}\nTotal: {Total()}");
        }

    }

}
