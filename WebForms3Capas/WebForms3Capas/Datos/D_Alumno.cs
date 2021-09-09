using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Datos
{
    public class D_Alumno
    {
        string StrngDeConexn = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
        string query;
        SqlCommand comando;

        public List<E_Alumno> Consultar()
        {
            List<E_Alumno> todosAlumnos = new List<E_Alumno>();
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
            DataTable dtbleAlumnos = new DataTable();
            string query;
            SqlCommand comando;
            query = "select * from Alumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dtbleAlumnos);
                con.Close();
            }

            foreach (DataRow fila in dtbleAlumnos.Rows)
            {
                E_Alumno alumno = new E_Alumno();
                alumno.Id = Convert.ToInt32(fila["id"]);
                alumno.Nombre = fila["nombre"].ToString();
                alumno.PrimerApellido = fila["primerApellido"].ToString();
                alumno.SegundoApellido = fila["segundoApellido"].ToString();
                alumno.Correo = fila["correo"].ToString();
                alumno.Telefono = fila["telefono"].ToString();
                alumno.FechaNacimiento = new DateTime(1996,06,19);// DateTime.ParseExact(fila["fechaNacimiento"].ToString(), "yyyy/MM/dd", null);
                alumno.Curp = fila["curp"].ToString();
                alumno.Sueldo = 0.0m; //decimal.Parse(fila["sueldo"].ToString());
                alumno.IdEstadoOrigen = int.Parse(fila["idEstadoOrigen"].ToString());
                alumno.IdEstatus = int.Parse(fila["idEstatus"].ToString());

                todosAlumnos.Add(alumno);

            }
            return todosAlumnos;


        }

        public E_Alumno Consultar(int id)
        {
            E_Alumno consultaAlumno = new E_Alumno();
            DataTable _1Alumno = new DataTable();
            query = $"select * from Alumnos where id={id}";
            using (SqlConnection conect = new SqlConnection(StrngDeConexn))
            {
                comando = new SqlCommand(query, conect);
                comando.CommandType = CommandType.Text;
                conect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(_1Alumno);
                conect.Close();
            }
            foreach (DataRow fila in _1Alumno.Rows)
            {
                consultaAlumno.Id = Convert.ToInt32(fila["id"]);
                consultaAlumno.Nombre = fila["nombre"].ToString();
                consultaAlumno.PrimerApellido = fila["primerApellido"].ToString();
                consultaAlumno.SegundoApellido = fila["segundoApellido"].ToString();
                consultaAlumno.Correo = fila["correo"].ToString();
                consultaAlumno.Telefono = fila["telefono"].ToString();
                consultaAlumno.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"].ToString());
                consultaAlumno.Curp = fila["curp"].ToString();
                if (DBNull.Value.Equals(fila["sueldo"]))
                {
                    consultaAlumno.Sueldo = null;
                }
                else
                {
                    consultaAlumno.Sueldo = Convert.ToDecimal(fila["sueldo"]);
                }
                //consultaAlumno.Sueldo = null; //DBNull.Value.Equals(fila["sueldo"]) ? 0 : Convert.ToDecimal(fila["sueldo"]);
                consultaAlumno.IdEstadoOrigen = int.Parse(fila["idEstadoOrigen"].ToString());
                consultaAlumno.IdEstatus = int.Parse(fila["idEstatus"].ToString());
            }

            return consultaAlumno;
        }

        public int Agregar(string nombre, string primerApellido, string segundoApellido, string correo, string telefono, DateTime fechaNacimiento, string curp, decimal? sueldo, int idEstado, int idEstatus)
        {

            //SqlCommand comando;
            query = $"Insert into Alumnos(nombre, primerApellido, segundoApellido, correo, telefono, fechaNacimiento,curp,sueldo,idEstadoOrigen,idEstatus) values(@nombre, @primerApellido, @segundoApellido, @correo, @telefono, @fechaNacimiento,@curp,@sueldo,@idEstado,@idEstatus)";
            int idd;
            using (SqlConnection conect = new SqlConnection(StrngDeConexn))
            {

                comando = new SqlCommand(query, conect);
                comando.CommandType = CommandType.Text;
                conect.Open();
                try
                {
                    comando.Parameters.AddWithValue("nombre", nombre);
                    comando.Parameters.AddWithValue("primerApellido", primerApellido);
                    comando.Parameters.AddWithValue("segundoApellido", segundoApellido);
                    comando.Parameters.AddWithValue("correo", correo);
                    comando.Parameters.AddWithValue("telefono", telefono);
                    comando.Parameters.AddWithValue("fechaNacimiento", fechaNacimiento);
                    comando.Parameters.AddWithValue("curp", curp);
                    if (sueldo != null)
                    comando.Parameters.Add(new SqlParameter("sueldo",sueldo));
                    else
                    comando.Parameters.Add(new SqlParameter("sueldo", DBNull.Value));

                    //comando.Parameters.AddWithValue("sueldo", null
                    comando.Parameters.AddWithValue("idEstado", idEstado);
                    comando.Parameters.AddWithValue("idEstatus", idEstatus);
                    MessageBox.Show("Registro agregado con exito");
                    idd = Convert.ToInt32(comando.ExecuteScalar());

                }
                catch (Exception e)
                {
                    MessageBox.Show("No se pudo agregar el registro, debido al sig, error:" + e.ToString());
                }
                finally
                {
                    idd = 0;
                }
                conect.Close();
                return idd;
            }
        }


        public void Actualizar(int id, string nombre, string primerApellido, string segundoApellido, string correo, string telefono, DateTime fechaNacimiento, string curp, decimal? sueldo, int idEstado, int idEstatus)
        {
            string fecha= fechaNacimiento.ToString("yyyy-MM-dd");
            if (sueldo == null)
            {
                query = $"update Alumnos set Nombre='{nombre}', primerApellido='{primerApellido}', segundoApellido='{segundoApellido}', correo='{correo}', telefono='{telefono}' , fechaNacimiento='{fecha}', curp='{curp}', sueldo=null, idEstadoOrigen='{idEstado}', idEstatus='{idEstatus}' where id={id}";
            }
            else
            {
                query = $"update Alumnos set Nombre='{nombre}', primerApellido='{primerApellido}', segundoApellido='{segundoApellido}', correo='{correo}', telefono='{telefono}' , fechaNacimiento='{fecha}', curp='{curp}', sueldo='{sueldo}', idEstadoOrigen='{idEstado}', idEstatus='{idEstatus}' where id={id}";

            }
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
                MessageBox.Show("Registro actualizado con exito");
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo actualizar el registro, debido al sig, error:" + e.ToString());
            }

        }

        public void Eliminar(int id)
        {

            query = $"delete Alumnos where id={id}";
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
                MessageBox.Show("Registro eliminado con exito");
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo eliminar el registro, debido al sig, error:" + e.ToString());
            }
        }

    }
}
