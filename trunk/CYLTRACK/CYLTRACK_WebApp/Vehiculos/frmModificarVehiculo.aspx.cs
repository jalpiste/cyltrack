using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

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
            //VehiculoBE consultar_vehiculo = new VehiculoBE();

            //txtIdVehiculo.Text = consultar_vehiculo.Placa;
            //txtMarca.Text = consultar_vehiculo.Marca;
            //txtCilindraje.Text = consultar_vehiculo.Cilindraje;
            //txtModelo.Text = consultar_vehiculo.Modelo;
            //txtMotor.Text = consultar_vehiculo.Motor;
            //txtChasis.Text = consultar_vehiculo.Chasis;

            //txtCedula.Text = consultar_vehiculo.Ced_Prop;
            //txtNombre.Text = consultar_vehiculo.Nombres_Prop;
            //txtPrimerApellido.Text = consultar_vehiculo.Apellido_1_Prop;
            //txtSegundoApellido.Text = consultar_vehiculo.Apellido_2_Prop;
            //txtRuta.Text = consultar_vehiculo.Ruta.Nombre;

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

            //VehiculoBE modificar_vehiculo = new VehiculoBE();

            //modificar_vehiculo.Id_Vehiculo = txtIdVehiculo.Text;
            //modificar_vehiculo.Marca = txtMarca.Text;
            //modificar_vehiculo.Cilindraje = txtCilindraje.Text;
            //modificar_vehiculo.Modelo = txtModelo.Text;
            //modificar_vehiculo.Motor = txtMotor.Text;
            //modificar_vehiculo.Chasis = txtChasis.Text;
            //modificar_vehiculo.Ced_Prop = txtCedula.Text;
            //modificar_vehiculo.Nombres_Prop = txtNombre.Text;
            //modificar_vehiculo.Apellido_1_Prop = txtPrimerApellido.Text;
            //modificar_vehiculo.Apellido_2_Prop = txtSegundoApellido.Text;
            //modificar_vehiculo.Conductor_Vehiculo.Nombre_Cond = txtNombreCond.Text;
            //modificar_vehiculo.Conductor_Vehiculo.Apellido_1_Cond = txtPrimerApellidoCond.Text;
            //modificar_vehiculo.Conductor_Vehiculo.Apellido_2_Cond = txtSegundoApellidoCond.Text;
            //modificar_vehiculo.Ruta.Nombre = txtRuta.Text; // donde asignarle el valor de la ruta seleccionada. en que tabla o que campo

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

        protected void txtCedulaCond_TextChanged(object sender, EventArgs e)
        {
            //ConductorBE consultar_conductor = new ConductorBE();

            //txtNombreCond.Text = consultar_conductor.Nombres;
            //txtPrimerApellidoCond.Text = consultar_conductor.Apellido_1;
            //txtSegundoApellidoCond.Text = consultar_conductor.Apellido_2;

        }
    }
}