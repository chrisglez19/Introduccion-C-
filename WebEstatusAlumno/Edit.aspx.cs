using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstatusAlumno
{
    public partial class Edit : System.Web.UI.Page
    {
        ADOEstatus crud = new ADOEstatus();
        Estatus estatu = new Estatus();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] ?? "1";
                int idEnt = int.Parse(id);
                estatu = crud.Consultar(idEnt);
                txtId.Text = id;
                txtNombre.Text = estatu.Nombre;
                txtClave.Text = estatu.Clave;
            }

        }

        protected void btnGuardarEdit_Click(object sender, EventArgs e)
        {
            string clave, nombre,id;
            int idEnt;
            id = txtId.Text;
            idEnt = int.Parse(id);
            nombre = txtNombre.Text;
            clave = txtClave.Text;
            crud.Actualizar(idEnt,clave, nombre);
        }
    }
}