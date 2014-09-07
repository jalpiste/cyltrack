using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.Windows.Forms;
using CYLTRACK_WebApp.UsuarioService;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion
{
    public partial class frmOlvidoContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnvíoInformación_Click(object sender, EventArgs e)
        {
            UsuarioServiceClient servUsuario = new UsuarioServiceClient ();
            long registrar;
            

            try
            {
                long consultaUsuario = servUsuario.ConsultarExistencia(txtUserName.Text);

                if (consultaUsuario != 0)
                {
                    MessageBox.Show("El usuario digitado ya se encuentra registrado en el sistema", "Registrar Usuario");
                }

                else
                {
                    registrar = servUsuario.RecuperarContrasena(txtUserName.Text);

                    MessageBox.Show("El usuario ha sido creado satisfactoriamente", "Registrar Usuario");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servUsuario.Close();
                Response.Redirect("~/Autenticacion/frmRegistrarUsuario.aspx");
            }

            //usuario.Usuario = txtUserName.Text;// 
            //Response.Write("<script type='text/javascript'> alert('La contraseña ha sido enviada a su correo electrónico') </script>");
        }

    }
}