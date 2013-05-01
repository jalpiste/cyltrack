using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion
{
    public partial class frmAutenticacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        UsuarioBE usuario = new UsuarioBE();


        protected void btnLoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
            //usuario.Usuario = txtUserName.Text;
            //usuario.Contrasena_1 = txtPassword.Text;
            //usuario.Contrasena_2 = txtNuevaContraseña.Text;
            //usuario.Contrasena_2 = txtConfirmPassword.Text;// no se en dato se coloca la confirmacion

        }




    }
}