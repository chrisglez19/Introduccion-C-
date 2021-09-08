using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstatusAlumno
{
    public partial class Details : System.Web.UI.Page
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
                lblIdV.Text = id;
                lblNomV.Text = estatu.Nombre;
                lblClveV.Text = estatu.Clave;
            }
        }


    }
}