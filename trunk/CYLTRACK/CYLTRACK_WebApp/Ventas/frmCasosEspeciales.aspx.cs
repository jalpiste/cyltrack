using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmCasosEspeciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            DivInfoVenta.Visible = true;
            divVerifInfo.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
        }

        protected void lstCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCaso.SelectedIndex == 1) 
            {
                divEscape.Visible = true;
            }
            if (lstCaso.SelectedIndex == 3) 
            {
                divCodCorrecto.Visible = true;
            }
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
        }

        

    }
}