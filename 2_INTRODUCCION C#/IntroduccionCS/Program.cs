using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string op;
            do
            {
                string ruta;
                Console.Clear();
                Console.WriteLine("1.-Hola Mundo\n2.-Arreglos de Cadenas\n3.-El numero Mayor\n4.-ConversionTipoOracion\n5.-Calculadora\n6.-Calculadora IMSS"+
                                    "\n7.-Poliza de Vida\n8.-Leer un archivo Txt\n9.-Leer un archivo csv\n10.-Escribir txt\n11.-Escribir xml\n12.-Calculadora ISR\nF.-Termina ");
                
                Console.WriteLine("Seleccione una opción");
                op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        OperacionesBasicas.HolaMundo();
                        Console.ReadKey();

                        break;
                    case "2":
                        OperacionesBasicas.ArreglosCadenas();
                        Console.ReadKey();

                        break;
                    case "3":
                        OperacionesBasicas.ArreglosEnteros();
                        Console.ReadKey();
                        break;
                    case "4":
                        OperacionesBasicas.ConvierteATipoOracion();
                        Console.ReadKey();
                        break;
                    case "5":
                        Calculadora.Presentacion();
                        Console.ReadKey();
                        break;
                    case "6":
                        CalculadoraIMMS.Presentacion();

                        Console.ReadKey();
                        break;
                    case "7":
                        OperacionesBasicas.PresentacionPolizaVida();
                        Console.ReadKey();
                        break;
                    case "8":
                        ArchivoTxt.PresentacionLeerArchivo();
                        Console.ReadKey();
                        break;
                    case "9":
                        Console.Clear();
                        
                        Console.WriteLine("***Bienvenido a Leer archivos csv por linea***\n");
                        Console.WriteLine("Ingresa la ruta del archivo a leer");
                        ruta = Console.ReadLine().Trim();
                        ArchivoTxt.MostrarCSV(ruta);
                        Console.ReadKey();
                        break;
                    case "10":
                        Console.Clear();
                        string codigo;
                        int isNew;
                        Console.WriteLine("Ingresa la ruta a escribir los registros\n");
                        ruta = Console.ReadLine().Trim();
                        Console.WriteLine("Ingresa el numero correspondiente\n");
                        Console.WriteLine("1.-Agregar registros\n2.-Ingresar registros desde 0\n");
                        isNew = int.Parse(Console.ReadLine().Trim());
                        Console.WriteLine("Ingresa el codigo que llevara el archivo(UTF8,UTF7,UTF32)\n");
                        codigo = Console.ReadLine().Trim();
                        ArchivoTxt.EscribirTxt(ruta, isNew, codigo);
                        break;
                    case "11":
                        Console.Clear();
                        Console.WriteLine("Ingresa la ruta a escribir los registros en XML\n");
                        ruta = Console.ReadLine().Trim();
                        ArchivoTxt.EscribirXML(ruta);
                        break;
                    case "12":
                        Console.Clear();
                        decimal sueldo;
                        Console.WriteLine("*******Bienvenido a Caluladora de ISR********\n");
                        Console.WriteLine("Ingresa el sueldo mensual\n");
                        sueldo = decimal.Parse(Console.ReadLine().Trim());
                        OperacionesBasicas.CalcularISR(sueldo);
                        break;
                    case "F":
                        
                        op = "F";
                        break;
                    default:
                        Console.WriteLine("***Debes seleccionar una opcion válida del menú****");
                        Console.ReadKey();
                        break;
                }
            } while (op != "F");

        }
    }
}
