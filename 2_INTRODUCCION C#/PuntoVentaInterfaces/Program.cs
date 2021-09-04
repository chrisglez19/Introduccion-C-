using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVentaInterfaces
{
    class Program
    {
        public static Venta venta = new Venta();
        public static void Main(string[] args)
        {
            venta.Menu();
        }
    }
}
