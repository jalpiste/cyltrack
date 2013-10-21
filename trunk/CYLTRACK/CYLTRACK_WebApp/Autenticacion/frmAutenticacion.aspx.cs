using CYLTRACK_WebApp.UsuarioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion
{
    public partial class frmAutenticacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNombreUsuario.Focus();
            }            
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            UsuarioServiceClient servUsuario = new UsuarioServiceClient();
            UsuarioBE usuario = new UsuarioBE();
            try
            {
                bool autentic;
                usuario.Usuario = txtNombreUsuario.Text;
                usuario.Contrasena_1 = txtContrasena.Text;

                autentic = servUsuario.Autenticacion(usuario);

                if (autentic)
                {
                    divAutentica.Visible = false;
                    divPrimeraVez.Visible = true;
                    btnIniciarSesion.Visible = false;
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
             {
                Response.Redirect("~/About.aspx");
             }

            finally
            {
                servUsuario.Close();
            }
 
           }
       
        protected void btnPrimeraVez_Click(object sender, EventArgs e)
        {

            UsuarioServiceClient serUser = new UsuarioServiceClient();
            UsuarioBE user = new UsuarioBE();
            try
            {
                if (txtNuevaContrasena.Text == txtConfirmarContrasena.Text)
                {
                    bool primeraContrasena;
                    user.Contrasena_1 = txtConfirmarContrasena.Text;
                    primeraContrasena = serUser.Autenticacion(user);
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }

            finally
            {
                serUser.Close();
                Response.Redirect("~/Default.aspx");
            }
       

        }

    }
}