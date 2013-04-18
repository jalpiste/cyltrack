using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmConsultarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }



        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            DivInfoVenta.Visible = false;
            btnNuevaConsulta.Visible = false;
        }

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            DivInfoVenta.Visible = true;
            btnNuevaConsulta.Visible = true;
        }

        protected void chckCasoEspecial_CheckedChanged(object sender, EventArgs e)
        {
            divCilCorrecto.Visible = true;
        }

    }
}