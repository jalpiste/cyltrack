using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE; 

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account
{
    public partial class frmcrearcliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
         // validar en la base de datos
            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //ClienteBE registrar_cli = new ClienteBE();

            //registrar_cli.Cedula = Convert.ToString(txtCedula.Text);
            //registrar_cli.Nombres_Cliente = Convert.ToString(txtNombreCliente.Text);
            //registrar_cli.Apellido_1 = Convert.ToString(txtPrimerApellido.Text);
            //registrar_cli.Apellido_2 = Convert.ToString(txtSegundoApellido.Text);
            //registrar_cli.Ubicacion.Direccion = Convert.ToString(txtDireccion.Text);
            //registrar_cli.Ubicacion.Barrio = Convert.ToString(txtBarrio.Text);
            //registrar_cli.Ciudad.Departamento.Nombre_Departamento = Convert.ToString(lstDepartamento.SelectedValue);
            //registrar_cli.Ciudad.Nombre_Ciudad = Convert.ToString(lstCiudad.SelectedValue);
            //registrar_cli.Ubicacion.Telefono_1 = Convert.ToString(txtTelefono.Text);

            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            //Response.Redirect("~/Cliente/frmRegistrarCliente.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}