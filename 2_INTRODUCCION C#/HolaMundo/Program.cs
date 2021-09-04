using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Como te llamas");
            string nombre = Console.ReadLine();
            Console.WriteLine("Hola " + nombre);
            Console.ReadKey();
        }
    }
}
