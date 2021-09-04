using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstatusAlumnos
{
    class ListaEstatus
    {
        private static List<EstatusAlumnos> estatusAlumnosList= new List<EstatusAlumnos>();

        public static void Agregar()
        {
            int id1;
            string nombre1;
            
            Console.WriteLine("Ingresa el id del estatus a capturar");
            id1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nombre del estatus a capturar");
            nombre1 = (Console.ReadLine());
            try
            {
                EstatusAlumnos est = estatusAlumnosList.Find(x => x.id == id1);
                    Console.WriteLine("No se pudo agregar el registro");
                    EstatusAlumnos est2 = new EstatusAlumnos { id = id1, nombre = nombre1 };
                    estatusAlumnosList.Add(est2);
                
                Console.WriteLine("Dato agregado correctamente a la lista");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo agregar el registro");
            }
        }

        public static void Actualizar()
        {
            int id1;
            string nombre1;
            Console.WriteLine("Ingresa el id del estatus a Actualizar");
            id1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nuevo nombre del estatus");
            nombre1 = (Console.ReadLine());
            try
            {

                EstatusAlumnos est = estatusAlumnosList.Find(x => x.id == id1);
                est.nombre = nombre1;
                Console.WriteLine("Dato actualizado correctamente a la lista Estatus Alumnos");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo actualizar el registro");
            }
        }

        public static void Eliminar()
        {
            int id;
            Console.WriteLine("Ingresa el id del estatus a eliminar");
            id = int.Parse(Console.ReadLine());
            try
            {
                estatusAlumnosList.RemoveAll(x=> x.id ==id);
                Console.WriteLine("Dato eliminado correctamente de los Estatus");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo eliminar el registro o no existe");
            }
        }

        public static void Consultar()
        {
            int id;
            Console.WriteLine("Ingresa el id del estatus a consultar");
            id = int.Parse(Console.ReadLine());
            try
            {
                EstatusAlumnos est = estatusAlumnosList.Find(x => x.id == id);
                Console.WriteLine(est.nombre);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("No se pudo encontrar el registro");
            }

        }
        public static void ConsultarTodos()
        {
            try
            {
                foreach (var estatus in estatusAlumnosList)
                {
                    Console.WriteLine("Id = {0} \nEstatus = {1} ", estatus.id, estatus.nombre);
                }
            }
            catch (Exception)
            {

            }
            //_Estados.Add();
        }

    }
}
