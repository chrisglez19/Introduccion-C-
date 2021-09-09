using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Estado
    {
        string StrngDeConexn = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
        string query;
        SqlCommand comando;

        public List<E_Estado> Consultar()
        {
            List<E_Estado> todosEstados = new List<E_Estado>();
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
            DataTable dtbleEstados = new DataTable();
            string query;
            SqlCommand comando;
            query = "select id, nombre from Estados";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dtbleEstados);
                con.Close();
            }

            foreach (DataRow fila in dtbleEstados.Rows)
            {
                E_Estado estado = new E_Estado();
                estado.Id = Convert.ToInt32(fila["id"]);
                estado.Nombre = fila["nombre"].ToString();
                todosEstados.Add(estado);

            }
            return todosEstados;


        }

        public E_Estado Consultar(int id)
        {
            E_Estado consultaEstado = new E_Estado();
            DataTable _1Estado = new DataTable();
            query = $"select * from Estados where id={id}";
            using (SqlConnection conect = new SqlConnection(StrngDeConexn))
            {
                comando = new SqlCommand(query, conect);
                comando.CommandType = CommandType.Text;
                conect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(_1Estado);
                conect.Close();
            }
            foreach (DataRow fila in _1Estado.Rows)
            {
                consultaEstado.Id = Convert.ToInt32(fila["id"]);
                consultaEstado.Nombre = fila["nombre"].ToString();
            }

            return consultaEstado;
        }
    }
}
