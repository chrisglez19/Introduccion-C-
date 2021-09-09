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
    public class D_Estatus
    {
        string StrngDeConexn = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
        string query;
        SqlCommand comando;

        public List<E_Estatus> Consultar()
        {
            List<E_Estatus> todosEstatus = new List<E_Estatus>();
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
            DataTable dtbleEstatus = new DataTable();
            string query;
            SqlCommand comando;
            query = "select id, clave,nombre from EstatusAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dtbleEstatus);
                con.Close();
            }

            foreach (DataRow fila in dtbleEstatus.Rows)
            {
                E_Estatus status = new E_Estatus();
                status.Id = Convert.ToInt32(fila["id"]);
                status.Clave = fila["clave"].ToString();
                status.Nombre = fila["nombre"].ToString();
                todosEstatus.Add(status);

            }
            return todosEstatus;


        }

        public E_Estatus Consultar(int id)
        {
            E_Estatus consultaStatus = new E_Estatus();
            DataTable _1Estatus = new DataTable();
            query = $"select * from EstatusAlumnos where id={id}";
            using (SqlConnection conect = new SqlConnection(StrngDeConexn))
            {
                comando = new SqlCommand(query, conect);
                comando.CommandType = CommandType.Text;
                conect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(_1Estatus);
                conect.Close();
            }
            foreach (DataRow fila in _1Estatus.Rows)
            {
                consultaStatus.Id = Convert.ToInt32(fila["id"]);
                consultaStatus.Clave = fila["clave"].ToString();
                consultaStatus.Nombre = fila["nombre"].ToString();
            }

            return consultaStatus;
        }

    }
}
