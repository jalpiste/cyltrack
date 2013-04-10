using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp
{
    public partial class frmRecuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'> alert('La contraseña ha sido enviada a su correo electrónico') </script>");
            
        }

       
        
    }
}