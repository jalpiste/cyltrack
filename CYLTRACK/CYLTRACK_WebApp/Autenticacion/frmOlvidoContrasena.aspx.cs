using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion
{
    public partial class frmOlvidoContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnvíoInformación_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'> alert('La contraseña ha sido enviada a su correo electrónico') </script>");
        }




    }
}