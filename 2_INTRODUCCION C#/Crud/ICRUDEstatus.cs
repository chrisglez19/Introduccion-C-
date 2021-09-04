using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    interface ICRUDEstatus
    {
        List<Estatus> Consultar();
        Estatus Consultar(int id);
        int Agregar(string clave, string nombre);
        void Actualizar(int id, string clave, string nombre);
        void Eliminar(int id);
    }
}
