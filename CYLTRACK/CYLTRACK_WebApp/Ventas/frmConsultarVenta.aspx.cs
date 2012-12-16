using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Ventas
{
    public partial class frmConsultarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            DivInfoVenta.Visible = true;
            btnNuevaConsulta.Visible = true;
            btnConsultar.Visible = false;
            txtCedulaCliente.Text = "";
        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            DivInfoVenta.Visible = false;
            btnNuevaConsulta.Visible = false;
            btnConsultar.Visible = true;
        }
    }
}