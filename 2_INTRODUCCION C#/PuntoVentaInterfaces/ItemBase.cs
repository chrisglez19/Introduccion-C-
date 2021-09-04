using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVentaInterfaces
{
    public class ItemBase : IItemBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public ItemBase(Articulo articulo, int cantidad)
        {
            Id = articulo.Id;
            Cantidad = cantidad;
            Nombre = articulo.Nombre;
            Precio = articulo.Precio;
        }


        public decimal Subtotal()
        {
            decimal Subtotal = Precio * Cantidad;
            return Subtotal;
        }

        public virtual decimal Total()
        {
            decimal total = Precio * Cantidad;
            return total;
        }

        public virtual void Imprimir()
        { }
    }
}
