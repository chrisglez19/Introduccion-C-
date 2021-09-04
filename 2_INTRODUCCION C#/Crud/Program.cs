using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string op;
            do
            {
                Console.Clear();
                Console.WriteLine("1.-Consultar Todos\n2.-Consultar Solo Uno\n3.-Agregar\n4.-Actualizar\n5.-Eliminar\n6.-Termina ");

                Console.WriteLine("Seleccione una opción");
                op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        ADOEstatus crud = new ADOEstatus();
                        List<Estatus> estatuses = new List<Estatus>();
                        estatuses = crud.Consultar();
                        Console.WriteLine("Id Clave       Estatus\n");
                        foreach (var elemento in estatuses)
                        {
                            Console.WriteLine($"{elemento.Id}- {elemento.Clave}- {elemento.Nombre}");
                        }
                        Console.ReadKey();

                        break;
                    case "2":
                        ADOEstatus consulta2 = new ADOEstatus();
                        int id;
                        Console.WriteLine("Ingresa el Id estatus");
                        id = int.Parse(Console.ReadLine());
                        Estatus estatus = new Estatus();
                        estatus = consulta2.Consultar(id);
                        Console.WriteLine("\nId Clave       Estatus\n");
                        Console.WriteLine($"{estatus.Id}-  {estatus.Clave}-{estatus.Nombre}");

                        Console.ReadKey();
                        break;
                    case "3":
                        ADOEstatus consulta3 = new ADOEstatus();
                        int id3;
                        string clave, nombreE;
                        Console.WriteLine("Ingresa la clave de Estatus");
                        clave = Console.ReadLine();
                        Console.WriteLine("Ingresa el nombre del Estatus");
                        nombreE = Console.ReadLine();
                        id3 = consulta3.Agregar(clave,nombreE);
                        Console.WriteLine("\nId Clave       Estatus\n");
                        Console.WriteLine($"{id3} {clave}-{nombreE}");
                        Console.ReadKey();
                        break;
                    case "4":
                        ADOEstatus consulta4 = new ADOEstatus();
                        int id4;
                        string clave2, nombreE2;
                        Console.WriteLine("Ingresa el Id del Estatus a actualizar");
                        id4 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingresa la clave de Estatus");
                        clave2 = Console.ReadLine();
                        Console.WriteLine("Ingresa el nombre del Estatus");
                        nombreE2 = Console.ReadLine();
                        consulta4.Actualizar(id4,clave2, nombreE2);
                        Console.WriteLine("\nEl estado actualizado es\nId Clave       Estatus\n");
                        Console.WriteLine($"{id4} {clave2}-{nombreE2}");
                        Console.ReadKey();
                        break;
                    case "5":
                        ADOEstatus consulta5 = new ADOEstatus();
                        int id5;
                        Console.WriteLine("Ingresa el Id del estatus a eliminar");
                        id5 = int.Parse(Console.ReadLine());
                        consulta5.Eliminar(id5);                        
                        Console.ReadKey();
                        break;

                }
            } while (op != "6");
        
            
        }
    }
}
