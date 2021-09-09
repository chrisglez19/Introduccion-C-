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
    public partial class Create : System.Web.UI.Page
    {
        string nombre, priApp, segApp, curp, correo, telefono;
        decimal? sueldo;
        DateTime fechaNacimiento;
        int idEdo, idEst;
        N_Alumno alumnoNegocio = new N_Alumno();
        N_Estado estadoNegocio = new N_Estado();

     

        N_Estatus estatusNegocio = new N_Estatus();
        E_Alumno alumno = new E_Alumno();
        List<E_Estado> listaEstados = new List<E_Estado>();
        List<E_Estatus> listaEstatus = new List<E_Estatus>();

        protected void btnGuardarAg_Click(object sender, EventArgs e)
        {
            
            nombre = txtNombre.Text;
            priApp = txtpApp.Text;
            segApp = txtsApp.Text;
            fechaNacimiento = Convert.ToDateTime(txtNacimiento.Text);
            curp = txtCurp.Text;
            correo = txtCorreo.Text;
            telefono = txtTel.Text;
            if (txtSueldo.Text == "")
                sueldo = null;
            else
                sueldo = Convert.ToDecimal(txtSueldo.Text);
            idEdo = int.Parse(ddlEstados.SelectedValue);
            idEst = int.Parse(ddlStatus.SelectedValue);
            alumnoNegocio.Agregar(nombre, priApp, segApp, correo, telefono, fechaNacimiento, curp, sueldo, idEdo, idEst);
            Response.Redirect("Index.aspx",true);
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //id = Request.QueryString["id"] ?? "1";

            
            
            idEst = alumno.IdEstatus;
            var estadoSelected = listaEstados.Find(x => x.Id == idEdo);
            var estatusSelected = listaEstatus.Find(x => x.Id == idEst);



            if (!IsPostBack)
            {

                listaEstados = estadoNegocio.ConsultarTodos();
                listaEstatus = estatusNegocio.ConsultarTodos();
                ddlEstados.DataSource = listaEstados;
                ddlEstados.DataTextField = "nombre";
                ddlEstados.DataValueField = "id";
                ddlEstados.DataBind();

                ddlStatus.DataSource = listaEstatus;
                ddlStatus.DataTextField = "nombre";
                ddlStatus.DataValueField = "id";
                ddlStatus.DataBind();

            }
            

        }
    }
}