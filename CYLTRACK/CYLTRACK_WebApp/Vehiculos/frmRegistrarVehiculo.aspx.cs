using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Rutas
{
    public partial class frmRegistrarVehículo : System.Web.UI.Page
    {

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void txtPlaca1_TextChanged(object sender, EventArgs e)
        {
            DivVehiculo.Visible = true;
            DivPropietario.Visible = true;
            DivSelRuta.Visible = true;
            DivAsignacionConductor.Visible = true;
            lblCedula1.Visible = true;
            txtCedula1.Visible = true;
        }
        
        protected void txtCedula1_TextChanged(object sender, EventArgs e)
        {
            lblImprimirCedula.Text = txtCedula1.Text;
            txtCedula1.Text = "";
            DatosConductor.Visible = true;
            btnGuardar.Visible = true;
        }

        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'> alert('Los datos fueron enviados satisfactoriamente') </script>");
            //Response.Redirect("~/Vehiculos/frmRegistrarVehiculo.aspx");
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