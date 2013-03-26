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
            
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
        
        }
    }
}