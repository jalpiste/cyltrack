using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmConsultarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        VentaBE ventas = new VentaBE();
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }
        
        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            DivInfoVenta.Visible = false;
            btnNuevaConsulta.Visible = false;
        }

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            //ventas.Cliente.Cedula = txtCedulaCliente.Text;
        
            //txtFecha.Text = Convert.ToString(ventas.Fecha);
            //txtHora.Text = Convert.ToString(ventas.Fecha);
            //txtNumCedula.Text = ventas.Cliente.Cedula;
            //txtNombreCliente.Text = ventas.Cliente.Nombres_Cliente;
            //txtPrimerApellido.Text = ventas.Cliente.Apellido_1;
            //txtSegundoApellido.Text = ventas.Cliente.Apellido_2;
            //txtDireccion.Text = ventas.Ubicacion.Direccion;
            //txtBarrio.Text = ventas.Ubicacion.Barrio;
            //txtCiudad.Text = ventas.Ubicacion.Ciudad.Nombre_Ciudad;
            //txtDepartamento.Text = ventas.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
            //txtTelefono.Text = ventas.Ubicacion.Telefono_1;
            //txtCilindro.Text = ventas.Cilindro.Codigo_Cilindro;
            //txtTamano.Text = ventas.Cilindro.NTamano.Id_Tamano;
            //txtObservacion.Text = ventas.Observaciones;

            ////-------------------------------------

            //txtNombreConductor.Text = ventas.Vehiculo.Conductor_Vehiculo.Conductor.Nombres_Conductor;
            //txtApellidoConductor.Text = ventas.Vehiculo.Conductor_Vehiculo.Conductor.Apellido_1;
            //txtSegundoApellidoConductor.Text = ventas.Vehiculo.Conductor_Vehiculo.Conductor.Apellido_2;
            //txtPlaca.Text = ventas.Vehiculo.Conductor_Vehiculo.Vehiculo.Placa;
            //txtRuta.Text = ventas.Vehiculo.Ruta.Nombre_Ruta;


            DivInfoVenta.Visible = true;
            btnNuevaConsulta.Visible = true;
        }

        
     }
}