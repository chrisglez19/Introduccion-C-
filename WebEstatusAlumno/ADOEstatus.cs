using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace WebEstatusAlumno
{
    class ADOEstatus 
    {
        string StrngDeConexn = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
        string query;
        SqlCommand comando;
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
            foreach(DataRow fila in _1Estatus.Rows)
            {
                consultaStatus.Id = Convert.ToInt32(fila["id"]);
                consultaStatus.Clave = fila["clave"].ToString();
                consultaStatus.Nombre = fila["nombre"].ToString();
            }
            
            return consultaStatus;
        }


        public int Agregar(string clave, string nombre)
        {
            
            //SqlCommand comando;
            query = $"Insert into EstatusAlumnos(id, Clave, Nombre) values((select max(id)+1 From EstatusAlumnos),@clave,@nombre)";
            int idd;
            using (SqlConnection conect = new SqlConnection(StrngDeConexn))
            {

                comando = new SqlCommand(query, conect);
                comando.CommandType = CommandType.Text;
                conect.Open();
                try
                {
                    comando.Parameters.AddWithValue("nombre", nombre);
                    comando.Parameters.AddWithValue("clave", clave);
                    //MessageBox.Show("Registro agregado con exito");
                    idd = Convert.ToInt32(comando.ExecuteScalar());

                }
               catch (Exception e)
                {
                    //MessageBox.Show("No se pudo agregar el registro, debido al sig, error:" + e.ToString());
                }
                finally
                {
                    idd = 0;
                }
                conect.Close();
                return idd;
            }
        }

        public void Actualizar(int id,string clave, string nombre)
        {
          
            query = $"update EstatusAlumnos set Nombre='{nombre}', Clave='{clave}' where id={id}";
            SqlCommand comando;
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
                //MessageBox.Show("Registro actualizado con exito");
            }
            catch (Exception e)
            {
                //MessageBox.Show("No se pudo actualizar el registro, debido al sig, error:" + e.ToString());
            }

        }

        public void Eliminar(int id)
        {
           
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
                //MessageBox.Show("Registro eliminado con exito");
            }
            catch (Exception e)
            {
                //MessageBox.Show("No se pudo eliminar el registro, debido al sig, error:" + e.ToString());
            }
        }
    }
}
