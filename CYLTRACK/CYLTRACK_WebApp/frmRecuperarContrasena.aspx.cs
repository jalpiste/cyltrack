using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.UsuarioService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp
{
    public partial class frmRecuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Focus();
        }


        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            UsuarioServiceClient servUsuario = new UsuarioServiceClient();
            UsuarioBE usuario = new UsuarioBE();
            String datosUsuario;

            try
            {
                usuario.Usuario = txtNombreUsuario.Text;

                datosUsuario = servUsuario.RecuperarContrasena(usuario);
                MessageBox.Show("La contraseña ha sido enviada a su correo electronico", "Olvido Contraseña");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servUsuario.Close();
                Response.Redirect("~/Default.aspx");
            }



        }



    }
}