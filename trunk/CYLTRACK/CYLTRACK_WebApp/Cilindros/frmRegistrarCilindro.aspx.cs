using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account
{
    public partial class frmcrearcil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void TxtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            DivDatosCilindro.Visible = true;
            BtnGuardar.Visible = true;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            DivDatosCilindro.Visible = false;
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {


        }




    }
}