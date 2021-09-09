using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Estado
    {
        D_Estado consultasEstados = new D_Estado();
        List<E_Estado> listaEstados = new List<E_Estado>();
        E_Estado estado = new E_Estado();
        public List<E_Estado> ConsultarTodos()
        {
            listaEstados= consultasEstados.Consultar();
            return listaEstados;
        }

        public E_Estado Consultar1(int id)
        {
            estado = consultasEstados.Consultar(id);
            return estado;
        }
    }
}
