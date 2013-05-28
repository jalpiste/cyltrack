using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VentaService;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmConsultarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
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

            VentaServiceClient serVenta = new VentaServiceClient();
            VentaBE venta = new VentaBE();
            VentaBE [] datosVenta = serVenta.ConsultarVenta(venta);
            
            var datos = from info in datosVenta
                         select info;

            foreach (VentaBE info in datos)
            {

                txtFecha.Text = Convert.ToString(info.Fecha);
                txtHora.Text = Convert.ToString(info.Fecha);
                txtNumCedula.Text = info.Id_Venta;
                //txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                //txtPrimerApellido.Text = info.Cliente.Apellido_1;
                //txtSegundoApellido.Text = info.Cliente.Apellido_2;
                //txtDireccion.Text = info.Ubicacion.Direccion;
                //txtBarrio.Text = info.Ubicacion.Barrio;
                //txtCiudad.Text = info.Ubicacion.Ciudad.Nombre_Ciudad;
                //txtDepartamento.Text = info.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                //txtTelefono.Text = info.Ubicacion.Telefono_1;
                //txtCilindro.Text = info.Cilindro.Codigo_Cilindro;
                //txtTamano.Text = info.Cilindro.NTamano.Id_Tamano;
                txtObservacion.Text = info.Observaciones;

                ////-------------------------------------

                //txtNombreConductor.Text = info.Vehiculo.Conductor_Vehiculo.Conductor.Nombres_Conductor;
                //txtApellidoConductor.Text = info.Vehiculo.Conductor_Vehiculo.Conductor.Apellido_1;
                //txtSegundoApellidoConductor.Text = info.Vehiculo.Conductor_Vehiculo.Conductor.Apellido_2;
                //txtPlaca.Text = info.Vehiculo.Conductor_Vehiculo.Vehiculo.Placa;
                //txtRuta.Text = info.Vehiculo.Ruta.Nombre_Ruta;


                DivInfoVenta.Visible = true;
                btnNuevaConsulta.Visible = true;

            }
        }

        
     }
}