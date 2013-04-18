using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Vehiculos
{
    public partial class frmModificarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            DivDatosVehiculo.Visible = true;
            DivPropietario.Visible = true;
            DivAsigRuta.Visible = true;
            DivConductor.Visible = true;
            DivConductorAsignado.Visible = true;
            divDatosRuta.Visible = true;
            btnGuardar.Visible = true;

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            txtIdVehiculo.Enabled = true;
            txtMarca.Enabled = true;
            txtCilindraje.Enabled = true;
            txtModelo.Enabled = true;
            txtMotor.Enabled = true;
            txtChasis.Enabled = true;
            txtCedula.Enabled = true;
            txtRuta.Visible = false;
            lblNota.Visible = true;
            lstRuta.Visible = true;
            lblPost.Text = "Asignación de Ruta";
            lblPoster2.Text = "Asignación de Conductor";
            txtNombre.Enabled = true;
            txtPrimerApellido.Enabled = true;
            txtSegundoApellido.Enabled = true;
            txtCedulaCond.Enabled = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            //Response.Redirect("~/Vehiculos/frmModificarVehiculo.aspx");
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