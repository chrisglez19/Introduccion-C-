using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    class ArchivoTxt
    {
        public static void PresentacionLeerArchivo()
        {
            Console.Clear();
            string ruta;
            Console.WriteLine("***Bienvenido a Leer archivos Txt***\n");
            Console.WriteLine("Ingresa la ruta del archivo a leer");
            ruta = Console.ReadLine().Trim();
            Mostrar(ruta);
        }

        public static void Mostrar(String rutaArchivo)
        {
            string archivoTemp;
            StreamReader archivo = new StreamReader(rutaArchivo);
            do
            {
                archivoTemp = archivo.ReadLine();
                Console.WriteLine(archivoTemp);
            } while (archivoTemp != null);

               

        }

        public static void MostrarCSV(String rutaArchivo)
        {
            string archivoTemp,lineaArchivo=null;
            StreamReader archivo = new StreamReader(rutaArchivo);
            do
            {
                archivoTemp = archivo.ReadLine();
                lineaArchivo = lineaArchivo + archivoTemp;
            } while (archivoTemp != null);

            string[] archivoArreglo = lineaArchivo.Split(',');
            foreach (var elemen in archivoArreglo)
            {
                Console.WriteLine(elemen);
            }
            //Console.WriteLine(lineaArchivo);


        }


        public static void EscribirTxt(String rutaArchivo, int esNuevo, string codigo)
        {
            bool isNew;
            string repetir;
            string nombre, apellido1, apellido2, estado;
            int edad;
            codigo = codigo.ToUpper();
            if (esNuevo == 1)
            {
                isNew = true;
            }
            else 
                {
                isNew = false;
                }

            if(!File.Exists(rutaArchivo))
            {
                Console.WriteLine($"El archivo {rutaArchivo} creado");
            }

            StreamWriter archivo;
            switch (codigo)
            {
                case "UTF8":
                    archivo = new StreamWriter(rutaArchivo, isNew, Encoding.UTF8);
                    break;
                case "UTF7":
                    archivo = new StreamWriter(rutaArchivo, isNew, Encoding.UTF7);
                    break;
                case "UNICODE":
                    archivo = new StreamWriter(rutaArchivo, isNew, Encoding.Unicode);
                    break;
                case "UTF32":
                    archivo = new StreamWriter(rutaArchivo, isNew, Encoding.UTF32);
                    break;
                case "ASCII":
                    archivo = new StreamWriter(rutaArchivo, isNew, Encoding.ASCII);
                    break;
                default:
                    archivo = new StreamWriter(rutaArchivo, isNew, Encoding.UTF8);
                    break;
            }
            do
            {
                Console.WriteLine("Ingresa el nombre del Alumno\n");
                nombre = Console.ReadLine().Trim();
                Console.WriteLine("Ingresa el primer Apellido\n");
                apellido1 = Console.ReadLine().Trim();
                Console.WriteLine("Ingresa el segundo Apellido\n");
                apellido2 = Console.ReadLine().Trim();
                Console.WriteLine("Ingresa la edad\n");
                edad = int.Parse(Console.ReadLine().Trim());
                Console.WriteLine("Ingresa el estado del Alumno\n");
                estado = Console.ReadLine().Trim();
               
                
                archivo.WriteLine($"{nombre},{apellido1},{apellido2},{edad},{estado}");
                Console.WriteLine("Alumno Agregado, desea agregar otro Alumno? SI/NO");
                repetir = Console.ReadLine();
                isNew = true;
            } while (repetir == "SI");

            archivo.Close();
        }

        public static void EscribirXML(String rutaArchivo)
        {
            
            string repetir;
            string nombre, apellido1, apellido2, estado;
            int edad;
            
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine($"El archivo {rutaArchivo} ya existe");
            }

            StreamWriter archivo = new StreamWriter(rutaArchivo, false,Encoding.UTF8);
            archivo.WriteLine("<?xml version=\"1.0\"encoding= \"UTF-8\">");
            archivo.WriteLine("<Alumnos>");
            do
            {
                Console.WriteLine("Ingresa el nombre del Alumno\n");
                nombre = Console.ReadLine().Trim();
                Console.WriteLine("Ingresa el primer Apellido\n");
                apellido1 = Console.ReadLine().Trim();
                Console.WriteLine("Ingresa el segundo Apellido\n");
                apellido2 = Console.ReadLine().Trim();
                Console.WriteLine("Ingresa la edad\n");
                edad = int.Parse(Console.ReadLine().Trim());
                Console.WriteLine("Ingresa el estado del Alumno\n");
                estado = Console.ReadLine().Trim();

                archivo.WriteLine("<alumno>");
                archivo.WriteLine($"	<nombre>{nombre}</nombre>");
                archivo.WriteLine($"	<primerApellido>{apellido1}</primerApellido>");
                archivo.WriteLine($"	<segundoApellido>{apellido2}</segundoApellido>");
                archivo.WriteLine($"	<edad>{edad}</edad>");
                archivo.WriteLine($"	<estado>{estado}</estado>");
                archivo.WriteLine("</alumno>");
                Console.WriteLine("Alumno Agregado, desea agregar otro Alumno? SI/NO");
                repetir = Console.ReadLine();
                
            } while (repetir == "SI");
            archivo.WriteLine("<Alumnos>");
            archivo.Close();
        }
    }
}
