using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
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
