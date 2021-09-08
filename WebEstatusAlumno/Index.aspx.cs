using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstatusAlumno
{
    public partial class Index : System.Web.UI.Page
    {
        ADOEstatus crud = new ADOEstatus();
        List<Estatus> estatuses = new List<Estatus>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                estatuses = crud.Consultar();
                ddlStatus.DataSource = estatuses;
                ddlStatus.DataTextField = "nombre";
                ddlStatus.DataValueField = "id";
                ddlStatus.DataBind();
            }
            
            //Carga();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            string id= ddlStatus.SelectedValue;
            string url = $"Create.aspx";
            Response.Redirect(url, true);
            

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string id = ddlStatus.SelectedValue;
            string url = $"Edit.aspx?id={id}";
            Response.Redirect(url, true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            string id = ddlStatus.SelectedValue;
            string url = $"Delete.aspx?id={id}";
            Response.Redirect(url, true);

        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            string id = ddlStatus.SelectedValue;
            string url = $"Details.aspx?id={id}";
            Response.Redirect(url, true);
        }
        //public void Carga()
        //{


        //}

    }
}