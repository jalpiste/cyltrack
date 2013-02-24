using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Pedido
{
    public partial class frmCancelarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            divInfoCliente.Visible = true;
        }

        protected void NumPedidoTxt_TextChanged(object sender, EventArgs e)
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
            //Response.Redirect("~/Pedido/frmCancelarPedido.aspx");
        }
    }
}