using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido
{
    public partial class frmModificarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            PedidoBE consultar_ped = new PedidoBE ();

            //txtCedulaCliente.Text = consultar_ped.Cliente.Cedula;
            //txtNombreCliente.Text = consultar_ped.Cliente.Nombres;
            //txtPrimerApellido.Text = consultar_ped.Cliente.Apellido_1;
            //txtSegundoApellido.Text = consultar_ped.Cliente.Apellido_2;
            //lstDireccion.Text = consultar_ped.Ubicacion.Direccion;
            //txtBarrio.Text = consultar_ped.Ubicacion.Barrio;
            //txtCiudad.Text = consultar_ped.Ciudad.Nombre_Ciudad;
            //txtDepartamento.Text = consultar_ped.Ciudad.Departamento.Nombre_Departamento;
            //txtTelefono.Text = consultar_ped.Ubicacion.Telefono_1;
            //txtCilindro.Text = consultar_ped.Cilindro.Codigo_Cilindro;
            //txtTamano.Text = consultar_ped.Cilindro.Tamano;
            //lstPlaca.Text = consultar_ped.Vehiculo.Placa;
            //lblRutaAsignada.Text = consultar_ped.Ruta.Nombre;
            //lstAgregar.Text = consultar_ped.Detalle_Ped.Tamaño; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
            //lstAgregar.Text = consultar_ped.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
            //lblFechaPedido.Text = consultar_ped.Fecha;

            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void TxtNumPedido_TextChanged(object sender, EventArgs e)
        {
            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //PedidoBE modificar_ped = new PedidoBE();

            //modificar_ped.Ubicacion.Direccion = lstDireccion.Text;
            //modificar_ped.Vehiculo.Placa = lstPlaca.Text;
            //modificar_ped.Detalle_Ped.Tamaño = lstAgregar.Text; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
            //modificar_ped.Detalle_Ped.Cantidad = lstAgregar.Text; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista

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