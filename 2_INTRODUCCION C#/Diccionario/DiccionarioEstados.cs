using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario
{
    class DiccionarioEstados
    {

        public static Dictionary<int, string> _Estados = new Dictionary<int, string>();

        public static void Agregar()
        {
            int id;
            string nombre;
            Console.WriteLine("Ingresa el id del estado a ingresar");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nombre del estado a ingresar");
            nombre = (Console.ReadLine());
            
            try 
            {
                _Estados.Add(id, nombre);
                Console.WriteLine("Dato agregado correctamente al diccionario");
            }
            catch (Exception e )
            {
                Console.WriteLine("No se pudo agregar el registro");
            }
        }

        public static void Actualizar()
        {
            int id;
            string nombre;
            Console.WriteLine("Ingresa el id del estado a Actualizar");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nuevo nombre del estado");
            nombre = (Console.ReadLine());
            try
            {
                _Estados[id] = nombre;
                Console.WriteLine("Dato actualizado correctamente al diccionario");
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo actualizar el registro");
            }
        }

        public static void Eliminar()
        {
            int id;
            string nombre;
            Console.WriteLine("Ingresa el id del estado a eliminar");
            id = int.Parse(Console.ReadLine());
            try
            {
                _Estados.Remove(id);
                Console.WriteLine("Dato eliminado correctamente al diccionario");
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo eliminar el registro o no existe");
            }
        }

        public static void Consultar()
        {
            int id;
            string nombre;
            Console.WriteLine("Ingresa el id del estado a consultar");
            id = int.Parse(Console.ReadLine());
            try
            {
                nombre = _Estados[id];
                Console.WriteLine(nombre);
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
                foreach (KeyValuePair<int, string> kvp in _Estados)
                {
                    Console.WriteLine("ID = {0} \n Estado = {1} ", kvp.Key, kvp.Value);
                }
            }
            catch (Exception)
            {

            }
            //_Estados.Add();
        }


    }
}
