using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Account.Clientes
{
    public partial class frmModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hprNuevaUbicacion.NavigateUrl = "frmCambioUbicacion.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }


        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            divInfoCliente.Visible = true;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            //Response.Redirect("~/Clientes/frmModificarCliente.aspx");
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreCliente.Text = " ";
            txtPrimerApellido.Text = " ";
            txtSegundoApellido.Text = " ";
            txtDireccion.Text = " ";
            txtBarrio.Text = " ";
            txtTelefono.Text = " ";
        }



    }
}