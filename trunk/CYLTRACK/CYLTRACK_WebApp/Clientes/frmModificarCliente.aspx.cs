using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account.Clientes
{
    public partial class frmModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hprNuevaUbicacion.NavigateUrl = "frmNuevaUbicacion.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }


        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {

            //ClienteBE consultar_cli = new ClienteBE();

            //txtNombreCliente.Text = consultar_cli.Nombres_Cliente;
            //txtPrimerApellido.Text = consultar_cli.Apellido_1;
            //txtSegundoApellido.Text = consultar_cli.Apellido_2;
            //txtDireccion.Text = consultar_cli.Ubicacion.Direccion;
            //txtBarrio.Text = consultar_cli.Ubicacion.Barrio;
            //lstDepartamento.Text = consultar_cli.Ciudad.Departamento.Nombre_Departamento;
            //lstCiudad.Text = consultar_cli.Ciudad.Nombre_Ciudad;
            //txtTelefono.Text = consultar_cli.Ubicacion.Telefono_1;

            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {



            //ClienteBE modificar_cli = new ClienteBE();

            //modificar_cli.Nombres_Cliente = txtNombreCliente.Text;
            //modificar_cli.Apellido_1 = txtPrimerApellido.Text;
            //modificar_cli.Apellido_2 = txtSegundoApellido.Text;
            //modificar_cli.Ubicacion.Direccion = txtDireccion.Text;
            //modificar_cli.Ubicacion.Barrio = txtBarrio.Text;
            //modificar_cli.Ciudad.Departamento.Nombre_Departamento = lstDepartamento.Text;
            //modificar_cli.Ciudad.Nombre_Ciudad = lstCiudad.Text;
            //modificar_cli.Ubicacion.Telefono_1 = txtTelefono.Text; 
            

            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            //Response.Redirect("~/Cliente/frmModificarCliente.aspx");
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

    }
}