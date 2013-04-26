using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

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
            //VehiculoBE consultar_conductor = new VehiculoBE();

            //lblImprimirCedula.Text = consultar_conductor.Ced_Prop;
            //txtNombreCond.Text = consultar_conductor.Nombres_Prop;
            //txtPrimerApellidoCond.Text = consultar_conductor.Apellido_1_Prop;
            //txtSegundoApellidoCond.Text = consultar_conductor.Apellido_2_Prop;


            lblImprimirCedula.Text = txtCedula1.Text;
            txtCedula1.Text = "";
            DatosConductor.Visible = true;
            btnGuardar.Visible = true;
        }

        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //VehiculoBE registrar_vehiculo = new VehiculoBE();

            //registrar_vehiculo.Placa = txtPlaca.Text;
            //registrar_vehiculo.Marca = txtMarca.Text;
            //registrar_vehiculo.Cilindraje = txtCilindraje.Text;
            //registrar_vehiculo.Modelo = txtModelo.Text;
            //registrar_vehiculo.Motor = txtMotor.Text;
            //registrar_vehiculo.Chasis = txtChasis.Text;
            //registrar_vehiculo.Ced_Prop = txtCedula.Text;
            //registrar_vehiculo.Nombres_Prop = txtNombre.Text;
            //registrar_vehiculo.Apellido_1_Prop = txtPrimerApellido.Text;
            //registrar_vehiculo.Apellido_2_Prop = txtSegundoApellido.Text;
            //registrar_vehiculo.Ruta.Nombre = lstRuta.SelectedValue; // donde asignarle el valor de la ruta seleccionada. en que tabla o que campo
            //registrar_vehiculo.Conductor_Vehiculo.Nombre_Cond = txtNombreCond.Text;
            //registrar_vehiculo.Conductor_Vehiculo.Apellido_1_Cond = txtPrimerApellidoCond.Text;
            //registrar_vehiculo.Conductor_Vehiculo.Apellido_2_Cond = txtSegundoApellidoCond.Text;


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