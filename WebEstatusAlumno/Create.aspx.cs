using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstatusAlumno
{
    public partial class Create : System.Web.UI.Page
    {
        ADOEstatus crud = new ADOEstatus();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
            //regresarAg = Response.Redirect("Index.aspx",true);
        }
         
        protected void btnGuardarAg_Click(object sender, EventArgs e)
        {
            string clave, nombre;
            nombre = txtNombre.Text;
            clave = txtClave.Text;
            crud.Agregar(clave, nombre);
        }
    }
}