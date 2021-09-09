using System;
using Negocio;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void cargarGrid()
        {
            N_Alumno datosAlumnos = new N_Alumno();
            N_Estado datosEstados = new N_Estado();
            N_Estatus datosEstatus = new N_Estatus();
            List<E_Alumno> lstAlumnos;
            List<E_Estado> lstEstados;
            List<E_Estatus> lstEstatus;
            lstAlumnos = datosAlumnos.ConsultarTodos();
            lstEstados = datosEstados.ConsultarTodos();
            lstEstatus = datosEstatus.ConsultarTodos();
            var lstFinal =
                from alus in lstAlumnos
                join edos in lstEstados on alus.IdEstadoOrigen equals edos.Id
                join status in lstEstatus on alus.IdEstatus equals status.Id
                orderby alus.Id
                select new { Id = alus.Id, Nombre = alus.Nombre, PrimerAPellido = alus.PrimerApellido, SegundoApellido = alus.SegundoApellido, Correo = alus.Correo, Telefono= alus.Telefono, Estado= edos.Nombre, Estatus = status.Nombre  };



            gvAlumnos.DataSource = lstFinal.ToList();
            gvAlumnos.DataBind();
        }

        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }
            int idx = Convert.ToInt32(e.CommandArgument);  //Convirtiendo indice de fila a entero

            GridViewRow filaSeleccionada = gvAlumnos.Rows[idx];
            TableCell idAlumno = filaSeleccionada.Cells[0];
            string id = idAlumno.Text;

            switch (e.CommandName)
            {
                case "Consultar":
                    Response.Redirect($"Detail.aspx?id={id}",false);
                    break;
                case "Actualizar":
                    Response.Redirect($"Edit.aspx?id={id}", false);
                    break;
                case "Eliminar":
                    Response.Redirect($"Delete.aspx?id={id}", false);
                    break;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Create.aspx", false);
        }

        protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvAlumnos.PageIndex = e.NewPageIndex;
                cargarGrid();
            }
            catch(Exception exep)
            {
                throw exep;
            }
        }
    }
}