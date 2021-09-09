using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Alumno
    {
        D_Alumno consultasAlumno = new D_Alumno();
        List<E_Alumno> list_Alumno = new List<E_Alumno>();
        E_Alumno alumno = new E_Alumno();

        public List<E_Alumno> ConsultarTodos()
        {
            
            list_Alumno = consultasAlumno.Consultar();
            return list_Alumno;
        }

        public E_Alumno Consultar1(int id)
        {
            alumno = consultasAlumno.Consultar(id);
            return alumno;
        }

        public void Agregar(string nombre, string primerApellido, string segundoApellido, string correo, string telefono, DateTime fechaNacimiento, string curp, decimal? sueldo, int idEstado, int idEstatus)
        {
            consultasAlumno.Agregar( nombre,  primerApellido,  segundoApellido,  correo,  telefono,  fechaNacimiento,  curp,  sueldo,  idEstado,  idEstatus);
        }

        public void Actualizar(int id, string nombre, string primerApellido, string segundoApellido, string correo, string telefono, DateTime fechaNacimiento, string curp, decimal? sueldo, int idEstado, int idEstatus)
        {
            consultasAlumno.Actualizar(id, nombre, primerApellido, segundoApellido, correo, telefono, fechaNacimiento, curp, sueldo, idEstado, idEstatus);
        }

        public void Eliminar(int id)
        {
            consultasAlumno.Eliminar(id);
        }

    }
}
