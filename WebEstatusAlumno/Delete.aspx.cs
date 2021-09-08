using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstatusAlumno
{
    public partial class Delete : System.Web.UI.Page
    {
        ADOEstatus crud = new ADOEstatus();
        Estatus estatu = new Estatus();
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (!IsPostBack)
            {
               
               
                estatu = crud.Consultar(int.Parse(id));
                txtId.Text = id;
                txtNombre.Text = estatu.Nombre;
                txtClave.Text = estatu.Clave;
            }
            
        }

        protected void btnGuardarDel_Click(object sender, EventArgs e)
        {
            string clave, nombre;
            
            nombre = txtNombre.Text;
            clave = txtClave.Text;
            crud.Eliminar(int.Parse(id));
        }
    }
}