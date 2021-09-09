using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Estatus
    {
        D_Estatus consultasEstatus = new D_Estatus();
        E_Estatus estatus = new E_Estatus();
        List<E_Estatus> listaEstatus = new List<E_Estatus>();
        public List<E_Estatus> ConsultarTodos()
        {
            listaEstatus = consultasEstatus.Consultar();
            return listaEstatus;
        }

        public E_Estatus Consultar1(int id)
        {
            estatus =consultasEstatus.Consultar(id);
            return estatus;
        }
    }
}
