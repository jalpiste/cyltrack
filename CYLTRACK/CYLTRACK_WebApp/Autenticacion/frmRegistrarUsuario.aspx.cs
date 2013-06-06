using CYLTRACK_WebApp.UsuarioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion
{
    public partial class frmRegistrarUsuario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string mes = Meses.Abril.ToString();
            int mesi = (int)Meses.Abril;
            List<string> meses = Auxiliar.ConsultarMeses();

            //UsuarioServiceClient servUsuario = new UsuarioServiceClient();
            //UsuarioBE usuario = new UsuarioBE();
            //UsuarioBE[] datosVenta = servUsuario.RegistrarUsuario(usuario);

            //lstCargo.Items.Add(servUsuario.RegistrarUsuario(usuario));
            txtNombreUsuario.Focus();
           
        }

       
        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            UsuarioServiceClient servUsuario = new UsuarioServiceClient();
            UsuarioBE usuario = new UsuarioBE();
            String registrar;
            
            try
            {
                
                usuario.Usuario = txtNombreUsuario.Text;
                usuario.Contrasena_1 = txtContrasena.Text;
                usuario.Correo = txtEmail.Text;
                usuario.Cedula = txtCedula.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellidos.Text;
                usuario.Direccion = txtDireccion.Text;
                usuario.Telefono = txtTelefono.Text;
                usuario.Genero = lstGenero.SelectedValue;
                usuario.Fecha_Nacim = lstDia.SelectedValue + "," + lstMes.SelectedValue + "," + lstAno.SelectedValue;
                PerfilBE pp = new PerfilBE();
                pp.Perfil = lstCargo.SelectedValue;
                usuario.Perfil = pp;

                registrar = servUsuario.RegistrarUsuario(usuario);

                MessageBox.Show("El usuario ha sido creado satisfactoriamente", "Registrar Usuario");
               
            }
            catch(Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servUsuario.Close();
                Response.Redirect("~/Autenticacion/frmRegistrarUsuario.aspx");
            }

        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}
