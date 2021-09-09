using System;
using Negocio;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Presentacion
{
    public partial class Edit : System.Web.UI.Page
    {
        string id;
        string nombre, priApp, segApp, curp, correo, telefono;
        decimal? sueldo;
        DateTime fechaNacimiento;
        int idEdo, idEst;
        N_Alumno alumnoNegocio = new N_Alumno();
        N_Estado estadoNegocio = new N_Estado();

        protected void validaCurpFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
           
                string fechaN = txtNacimiento.Text;
                string fechaNac, fechaCurp, fechaC;
                fechaNac = fechaN.Substring(2, 2) + fechaN.Substring(5, 2) + fechaN.Substring(8, 2);
                fechaC = args.Value;
                fechaCurp = fechaC.Substring(4, 2) + fechaC.Substring(6, 2) + fechaC.Substring(8, 2);
                if (fechaNac == fechaCurp)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
        }

        N_Estatus estatusNegocio = new N_Estatus();
        E_Alumno alumno = new E_Alumno();
        List<E_Estado> listaEstados = new List<E_Estado>();
        List<E_Estatus> listaEstatus = new List<E_Estatus>();

        protected void btnGuardarEdit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                txtId.Text = id;
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
                alumnoNegocio.Actualizar(int.Parse(id), nombre, priApp, segApp, correo, telefono, fechaNacimiento, curp, sueldo, idEdo, idEst);
                Response.Redirect("Index.aspx", true);
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"] ?? "1";


            alumno = alumnoNegocio.Consultar1(int.Parse(id));


            idEdo = alumno.IdEstadoOrigen;

            idEst = alumno.IdEstatus;
            listaEstados = estadoNegocio.ConsultarTodos();
            listaEstatus = estatusNegocio.ConsultarTodos();
            var estadoSelected = listaEstados.Find(x => x.Id == idEdo);
            var estatusSelected = listaEstatus.Find(x => x.Id == idEst);

            if (!IsPostBack)
            {

                
                ddlEstados.DataSource = listaEstados;
                ddlEstados.DataTextField = "nombre";
                ddlEstados.DataValueField = "id";
                ddlEstados.DataBind();

                ddlStatus.DataSource = listaEstatus;
                ddlStatus.DataTextField = "nombre";
                ddlStatus.DataValueField = "id";
                ddlStatus.DataBind();

               
              
                txtId.Text = alumno.Id.ToString();
                txtNombre.Text = alumno.Nombre.ToString();
                txtpApp.Text = alumno.PrimerApellido.ToString();
                txtsApp.Text = alumno.SegundoApellido.ToString();
                txtNacimiento.Text = alumno.FechaNacimiento.ToString("yyyy-MM-dd");
                txtCurp.Text = alumno.Curp;
                txtCorreo.Text = alumno.Correo;
                txtTel.Text = alumno.Telefono;
                txtSueldo.Text = alumno.Sueldo.ToString();
                ddlEstados.SelectedValue = estadoSelected.Id.ToString();
                ddlStatus.SelectedValue = estatusSelected.Id.ToString();
            }
        }
    }
}