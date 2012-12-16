using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Ventas
{
    public partial class frmDevolucionCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            DivDatosCilindro.Visible = true;
            DivDatosCliente.Visible = true;
            DivObservaciones.Visible = true;
        }

        protected void lstMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMotivo.SelectedIndex == 1)
            {
                DivCambio.Visible = true;
            }
            if (lstMotivo.SelectedIndex == 2)
            {
                DivCambio.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}