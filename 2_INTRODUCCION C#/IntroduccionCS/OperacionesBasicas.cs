using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    class OperacionesBasicas
    {
        public static void HolaMundo() 
        {
            Console.Clear();
            Console.WriteLine("***Bienvenido a Hola Mundo***\n");
            Console.WriteLine("Proporciona tu nombre");
            string nombre = (Console.ReadLine()).Trim();
            Console.WriteLine("Proporciona tu primer Apellido");
            string primerApellido= (Console.ReadLine()).Trim();
            Console.WriteLine("Proporciona tu segundo Apellido");
            string segundoApellido = (Console.ReadLine()).Trim();
            Console.WriteLine("Proporciona tu edad");
            int edad = (int.Parse((Console.ReadLine()).Trim()));
            Console.WriteLine("Hola " + nombre+ " " + primerApellido+" " + segundoApellido);
            Console.WriteLine("{0} {1} {2} tiene {3} años", nombre,primerApellido,segundoApellido,edad);
            Console.WriteLine($"Gusto en conocerte {(nombre.ToUpper())} {primerApellido.ToUpper()} {segundoApellido.ToUpper()}!!!");
            Console.WriteLine($"El archivo fue almacenado en C:\\Documentos\\IntroduccionCS\\{nombre}{primerApellido}{segundoApellido}.docx");
            
        }
        public static void ArreglosCadenas()
        {
            int i=0;
            string temporal;
            Console.Clear();
            Console.WriteLine("***Bienvenido a Arreglo de Cadenas***\n");
            Console.WriteLine("Proporciona tu nombre completo");
            string nombre = Console.ReadLine();
            temporal = "\n";
            Console.WriteLine("Hola");
            while (i<nombre.Length)
            {
                if (nombre.Substring(i, 1) != " ") 
                {
                    temporal = temporal + nombre.Substring(i, 1);
                    i++;

                }
                else
                {
                    Console.WriteLine(temporal);
                    temporal = "\n";
                    i++;
                }
            }
            Console.WriteLine(temporal); 

        }
        public static void ArreglosEnteros()
        {
            int[] numeros = new int[5];
            Console.Clear();
            Console.WriteLine("****Bienvenido al numero mayor****\n");
            Console.WriteLine("Ingresa el numero 1");
            numeros[0] = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el numero 2");
            numeros[1]  = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el numero 3");
            numeros[2]  = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el numero 4");
            numeros[3]  = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el numero 5");
            numeros[4]  = int.Parse(Console.ReadLine());
            int max=numeros[0];
            for (int i=0; i < 5; i++)
            {
                if (numeros[i] > max)
                    max = numeros[i];
                else
                    max = max;
            }
            Console.WriteLine($"El numero mas grande es {max}");

             
                        
        }

        public static void ConvierteATipoOracion()
        {
            int i = 0;
            string temporal;
            Console.Clear();
            Console.WriteLine("***Bienvenido a Arreglo de Cadenas***\n");
            Console.WriteLine("Proporciona tu nombre completo");
            string cadena = Console.ReadLine();
            temporal = "\n";
            temporal = temporal + (cadena.Substring(i, 1)).ToUpper();
            i++;
            while (i < cadena.Length)
            {
                if (cadena.Substring(i, 1) == " ")
                {
                    i++;
                    temporal = temporal + " "+(cadena.Substring(i, 1)).ToUpper();
                    i++;
                }
                else
                {
                    temporal = temporal + (cadena.Substring(i, 1));
                    i++;
                }
            }
            Console.WriteLine(cadena);
            Console.WriteLine(temporal);

        }
        public static void PolizaVida(DateTime fechaIni, string periodo, decimal SumAsegurada, DateTime fechaNaci, string genero)
        {
            decimal factor=0;
            string[] extraerPeriodo = new string[2];
            extraerPeriodo = periodo.Split(' ');
            decimal cantPeriodo = decimal.Parse(extraerPeriodo[0]);
            int cantPeriodoInt = int.Parse(extraerPeriodo[0]);
            string tipoPeriodo = extraerPeriodo[1];
            decimal prima;
            string[,] tablaFactor = new string[,] { { "0", "21","Femenino","0.05" }, { "21", "30", "Femenino", "0.1" }, { "31", "40", "Femenino", "0.4" }, { "50", "60", "Femenino", "0.65" },
                                                         { "60", "100","Femenino","0.85" }, { "0", "21","Masculino","0.05" }, { "21", "30", "Masculino", "0.1" }, { "31", "40", "Masculino", "0.4" }, 
                                                         { "50", "60", "Masculino", "0.7" }, { "60", "100","Masculino","0.9" }};
            int edad;
            TimeSpan dif_fecha = (DateTime.Now).Subtract(fechaNaci);
            edad = (dif_fecha.Days / 365);
           
            int i=0;
            while (i<tablaFactor.GetUpperBound(0))
            {
                if (int.Parse(tablaFactor[i, 0]) <= edad & int.Parse(tablaFactor[i, 1]) >= edad & tablaFactor[i,2]==genero)
                {
                    factor = decimal.Parse(tablaFactor[i, 3]);
                    break;
                }
                i++;
            }


        switch(tipoPeriodo)
            {
                case "dias":
                case  "dia":
                    prima = (SumAsegurada * factor * (cantPeriodo / 360));
                    Console.WriteLine($"\nLa fecha de vencimiento es:{fechaIni.AddDays(cantPeriodoInt)}");
                    Console.WriteLine($"La prima a pagar es de {prima} pesos");
                    break;
                case "años":
                case "año":
                    prima = (SumAsegurada * factor * ((cantPeriodo*365) / 360));
                    Console.WriteLine($"\nLa fecha de vencimiento es:{fechaIni.AddYears(cantPeriodoInt)}");
                    Console.WriteLine($"La prima a pagar es de {prima} pesos");
                    break;
                case "meses":
                case "mes":
                    prima = (SumAsegurada * factor * ((cantPeriodo * 30) / 360));
                    Console.WriteLine($"\nLa fecha de vencimiento es:{fechaIni.AddMonths(cantPeriodoInt)}");
                    Console.WriteLine($"La prima a pagar es de { (SumAsegurada * factor * ((cantPeriodo * 30) / 360))} pesos");
                    break;
            }
        }

        public static void PresentacionPolizaVida ()
        {

            Console.Clear();
            Console.WriteLine("***Bienvenido a Cotizacion de Poliza***\n");
            DateTime fechaInicio, fechaNacimiento;
            String periodo, genero;
            decimal sumaAsegurada;
            Console.WriteLine("Ingresa la fecha de inicio de Vigencia");
            fechaInicio = DateTime.Parse((Console.ReadLine()).Trim());
            Console.WriteLine("Ingresa para cuanto tiempo quieres la poliza(ejemplo: 2 años)");
            periodo = (Console.ReadLine()).Trim();
            Console.WriteLine("Ingresa la suma asegurada");
            sumaAsegurada = int.Parse((Console.ReadLine()).Trim());
            Console.WriteLine("Ingresa la fecha de nacimiento del asegurado");
            fechaNacimiento = DateTime.Parse((Console.ReadLine()).Trim());
            Console.WriteLine("Ingresa el genero del asegurado");
            genero = (Console.ReadLine()).Trim();
            PolizaVida(fechaInicio, periodo, sumaAsegurada, fechaNacimiento, genero);

        }

        public static void CalcularISR(decimal sueldoMens)
        {
            string rutaArchivo;
            decimal impuestoTotal = 0, limiteInf=0, limiteSup=0,cuotaFija=0,excedente=0,subsidio=0,res1=0;
            //decimal prueba;
            rutaArchivo = @"C:\Users\DOTNET6\Documents\DESARROLLO .NET\2_INTRODUCCION C#\TablaISR_V2.csv";
            decimal sueldoQuin = (sueldoMens / 2);
            string archivoTemp;
            string[] archivoFilas = new string[5];
            string[,] tablaISR = new string[21,5];
            int j=0, i = 0,l=0;
            StreamReader archivo = new StreamReader(rutaArchivo);
            do
            {
                archivoTemp = archivo.ReadLine();
                if (archivoTemp != null)
                {
                    archivoFilas = archivoTemp.Split(',');
                    for (j = 0; j < 5; j++)
                        tablaISR[i, j] = archivoFilas[j];
                }
                 i++;
            } while (archivoTemp != null);

            while (l < 21)
            {
                if (decimal.Parse(tablaISR[l, 0]) <= sueldoQuin & decimal.Parse(tablaISR[l, 1]) >= sueldoQuin)
                {
                    limiteInf = (decimal.Parse(tablaISR[l, 0]));
                    limiteSup = (decimal.Parse(tablaISR[l, 1]));
                    cuotaFija = decimal.Parse(tablaISR[l, 2]);
                    excedente = decimal.Parse(tablaISR[l, 3]);
                    subsidio = decimal.Parse(tablaISR[l, 4]);
                    res1 = ((sueldoQuin - limiteInf) * excedente / 100);
                    impuestoTotal = res1 + cuotaFija - subsidio;
                    break;
                }
                l++;
            }
            Console.WriteLine($"Sueldo: ${sueldoMens} mensual\nSueldo Quincenal = {sueldoMens}/2 = {sueldoQuin}");
            Console.WriteLine($"En la tabla:\nLimite inferior = {limiteInf}\nLimite Superior = {limiteSup}\nCuota fija = {cuotaFija}\nExcedente Limite Inferior = {excedente}%");
            Console.WriteLine($"Subsidio para el empleo = {subsidio}");
            Console.WriteLine($"Resultado = ({sueldoQuin} - {limiteInf}) * {excedente/100}\nResultado = {res1}");
            Console.WriteLine($"Impuesto = {res1} + {cuotaFija} - {subsidio}\nImpuesto = {impuestoTotal}");

            //Console.WriteLine($"2,0: {tablaISR[2, 0]}\n 2,1: {tablaISR[2, 1]}");
            //for (int m = 0; m < tablaISR.Length; m++)
            //{
            //    for (int n = 0; n < tablaISR.GetUpperBound(1); n++)
            //    {
            //        Console.Write(" {0}", tablaISR[m, n]);
            //    }
            //    Console.WriteLine();
            //}

            Console.ReadKey();
            

        }

    }
}
