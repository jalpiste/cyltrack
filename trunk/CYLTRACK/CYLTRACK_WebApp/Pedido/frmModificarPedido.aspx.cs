using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido
{
    public partial class frmModificarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void TxtNumPedido_TextChanged(object sender, EventArgs e)
        {
            divInfoCliente.Visible = true;
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            //Response.Redirect("~/Pedido/frmModificarPedido.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidadCilindro.Text = " ";
            txtCedulaCliente.Text = " ";

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lstAgregar.Visible = true;
            lstAgregar.Items.Add(lstTamano.Text + " " + txtCantidadCilindro.Text);
            txtCantidadCilindro.Text = "";
        }
    }
}