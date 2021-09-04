using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class ADOEstatus : ICRUDEstatus
    {
         public List<Estatus> Consultar()
        {
            List<Estatus> todosEstatus = new List<Estatus>();
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
                Estatus status = new Estatus();
                status.Id = Convert.ToInt32(fila["id"]);
                status.Clave = fila["clave"].ToString();
                status.Nombre = fila["nombre"].ToString();
                todosEstatus.Add(status);
                
            }
            return todosEstatus;


        }

        public Estatus Consultar(int id)
        {
            Estatus consultaStatus = new Estatus();
            string StrngDeConexn = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
            DataTable _1Estatus = new DataTable();
            string query;
            SqlCommand comando;
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
            foreach(DataRow fila in _1Estatus.Rows)
            {
                consultaStatus.Id = Convert.ToInt32(fila["id"]);
                consultaStatus.Clave = fila["clave"].ToString();
                consultaStatus.Nombre = fila["nombre"].ToString();
            }
            
            return consultaStatus;
        }

//        INSERT INTO table_name
//VALUES(value1, value2, value3, ...);
        public int Agregar(string clave, string nombreE)
        {
            string StrngDeConexn = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
            string query;
            //SqlCommand comando;
            query = $"Agregar Estatus";
            using (SqlConnection con = new SqlConnection(StrngDeConexn))
            {
                

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "nombre";
                parametro.SqlDbType = SqlDbType.NVarChar;
                parametro.Direction = ParameterDirection.Input;
                parametro.Value = nombreE;
                SqlParameter parametro2 = new SqlParameter();
                parametro2.ParameterName = "clave";
                parametro2.SqlDbType = SqlDbType.NVarChar;
                parametro2.Direction = ParameterDirection.Input;
                parametro2.Value = clave;

               
                con.Close();
                return 1;
            }
        }

        public void Actualizar(int id,string clave, string nombre)
        {
            string StrngDeConexn = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
            string query = $"update EstatusAlumnos set Nombre='{nombre}', Clave='{clave}' where id={id}";
            SqlCommand comando;
            using (SqlConnection con = new SqlConnection(StrngDeConexn))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }

        }

        public void Eliminar(int id)
        {
            string StrngDeConexn = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
            string query;
            SqlCommand comando;
            query = $"delete EstatusAlumnos where id={id}";
            try
            {
                using (SqlConnection con = new SqlConnection(StrngDeConexn))
                {
                    comando = new SqlCommand(query, con);
                    comando.CommandType = CommandType.Text;
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                }
                Console.WriteLine("\nEliminado con exito\n"); 
                 
            }
            catch(Exception)
            {
                Console.WriteLine("El registro no se puede eliminar debido a que es usado por otra tabla");
            }


        }
    }
}
