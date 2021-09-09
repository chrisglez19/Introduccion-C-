using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Curp { get; set; }
        public decimal? Sueldo { get; set; }
        public int IdEstadoOrigen { get; set; }
        public int IdEstatus { get; set; }
    }
}
