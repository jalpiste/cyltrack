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

           UsuarioBE usuario = new UsuarioBE();
        protected void btnCreateUserButton_Click(object sender, EventArgs e)
        {
            // usuario.Usuario = txtUserName.Text;
            // usuario.Contrasena_1 = txtPassword.Text;
            // usuario.Contrasena_2 = txtConfirmPassword.Text; // no si asi se compara
            // usuario.Correo = txtEmail.Text;
            // usuario.Cedula = txtCedula.Text;
            // usuario.Nombre = txtNombre.Text;
            // usuario.Apellido = txtApellidos.Text;
            // usuario.Direccion = txtDireccion.Text;
            // usuario.Telefono = txtTelefono.Text;
            // usuario.Genero = lstGenero.SelectedValue;
            // usuario.Fecha_Nacim = lstDia.SelectedValue +","+ lstMes.SelectedValue+","+lstAno.SelectedValue;
            //usuario.cargo// el cargo 


            Response.Write("<script type='text/javascript'> alert('') </script>");
            //Response.Redirect("~/Autenticacion/frmRegistrarUsuario.aspx");
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}
