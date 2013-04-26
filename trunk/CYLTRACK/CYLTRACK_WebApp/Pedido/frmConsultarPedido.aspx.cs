using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account.Pedido
{
    public partial class frmConsultarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            
            //PedidoBE consultar_ped = new PedidoBE();

            //lblCodigoPedido.Text = consultar_ped.Id_Pedido;
            //txtCedulaCliente.Text = consultar_ped.Cliente.Cedula;
            //txtNombreCliente.Text = consultar_ped.Cliente.Nombres;
            //txtPrimerApellido.Text = consultar_ped.Cliente.Apellido_1;
            //txtSegundoApellido.Text = consultar_ped.Cliente.Apellido_2;
            //txtDireccion.Text = consultar_ped.Ubicacion.Direccion;
            //txtBarrio.Text = consultar_ped.Ubicacion.Barrio;
            //txtCiudad.Text = consultar_ped.Ciudad.Nombre_Ciudad;
            //txtDepartamento.Text = consultar_ped.Ciudad.Departamento.Nombre_Departamento;
            //txtTelefono.Text = consultar_ped.Ubicacion.Telefono_1;
            //txtCilindro.Text = consultar_ped.Cilindro.Codigo_Cilindro;
            //txtTamano.Text = consultar_ped.Cilindro.Tamano;

            //txtPlaca.Text = consultar_ped.Vehiculo.Placa;
            //lblRutaAsignada.Text = consultar_ped.Ruta.Nombre;
            //lstAgregar.Text = consultar_ped.Detalle_Ped.Tamaño; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
            //lstAgregar.Text = consultar_ped.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
            //lblFechaPedido.Text = consultar_ped.Fecha;
            //lblFechaEntregaCilindro.Text = consultar_ped.Venta.Fecha;

            divInfoCliente.Visible = true;
            btnNuevaConsulta.Visible = true;
        }

        protected void NumPedidoTxt_TextChanged(object sender, EventArgs e)
        {
            divInfoCliente.Visible = true;
        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pedido/frmConsultarPedido.aspx");
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

    }
}