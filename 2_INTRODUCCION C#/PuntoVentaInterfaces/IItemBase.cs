using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVentaInterfaces
{
    interface IItemBase
    {

        int Id { get; set; }
        string Nombre { get; set; }
        decimal Precio { get; set; }
        int Cantidad { get; set; }



        decimal Subtotal();

        decimal Total();

        void Imprimir();
    }
}
