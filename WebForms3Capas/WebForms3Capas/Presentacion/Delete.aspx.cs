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
    public partial class Delete : System.Web.UI.Page
    {
        string id;
        int idEdo, idEst;
        N_Alumno alumnoNegocio = new N_Alumno();
        N_Estado estadoNegocio = new N_Estado();
        N_Estatus estatusNegocio = new N_Estatus();
        E_Alumno alumno = new E_Alumno();
        List<E_Estado> listaEstados = new List<E_Estado>();
        List<E_Estatus> listaEstatus = new List<E_Estatus>();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"] ?? "10";

            alumno = alumnoNegocio.Consultar1(int.Parse(id));
            listaEstados = estadoNegocio.ConsultarTodos();
            idEdo = alumno.IdEstadoOrigen;
            listaEstatus = estatusNegocio.ConsultarTodos();
            idEst = alumno.IdEstatus;
            var estadoSelected = listaEstados.Find(x => x.Id == idEdo);
            var estatusSelected = listaEstatus.Find(x => x.Id == idEst);



            if (!IsPostBack)
            {

                int idEnt = int.Parse(id);
                lblIdV.Text = id;
                lblNomV.Text = alumno.Nombre;
                lblprimerApellidoV.Text = alumno.PrimerApellido;
                lblsegundoApellidoV.Text = alumno.SegundoApellido;
                lblNacimientoV.Text = alumno.FechaNacimiento.ToString();
                lblCurpV.Text = alumno.Curp;
                lblCorreoV.Text = alumno.Correo;
                lblTelV.Text = alumno.Telefono;
                lblSueldoV.Text = alumno.Sueldo is null ? "Sin sueldo" : alumno.Sueldo.ToString();
                lblEstadoV.Text = estadoSelected.Nombre;
                lblEstatusV.Text = estatusSelected.Nombre;

            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            alumnoNegocio.Eliminar(int.Parse(id));
            Response.Redirect("Index.aspx", true);    
        }
    }
}