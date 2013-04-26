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
    public partial class frmRegistrarUsuario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUserButton_Click(object sender, EventArgs e)
        {
           
            //UsuarioBE registrar_usuario = new UsuarioBE();

            //registrar_usuario.Usuario = txtUserName.Text;
            //registrar_usuario.Contrasena_1 = txtPassword.Text;
            //registrar_usuario.Contrasena_2 = txtConfirmPassword.Text;
            //registrar_usuario.Correo = txtEmail.Text;

            //registrar_usuario.Cedula = txtCedula.Text;
            //registrar_usuario.Nombre = txtNombre.Text;
            //registrar_usuario.Apellido = txtApellidos.Text;
            //registrar_usuario.Direccion = txtDireccion.Text;
            //registrar_usuario.Telefono = txtTelefono.Text;
            //registrar_usuario.Genero = lstGenero.SelectedValue;
            //registrar_usuario.Fecha_Nacim = lstDia.SelectedValue; // selección de la fecha de nacimiento
            //registrar_usuario.Perfil.Perfil = lstCargo.SelectedValue;
            

            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            //Response.Redirect("~/Autenticacion/frmRegistrarUsuario.aspx");
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }


    }
}
