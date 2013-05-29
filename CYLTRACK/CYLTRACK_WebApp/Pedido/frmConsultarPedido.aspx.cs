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
            prueba[] pps = new prueba[2];
            prueba pp = new prueba();
            pp.Prueba1 = "Hola";
            pp.Prueba2 = "Tooo";
            prueba pp1 = new prueba();
            pp1.Prueba1 = "Hola 1";
            pp1.Prueba2 = "Tooo 1";

            pps[0] = pp;
            pps[1] = pp1;
            gvPedido.DataSource = pps;
            gvPedido.DataBind();

        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {

            //PedidoBE consultar_ped = new PedidoBE();

            //lblCodigoPedido.Text = consultar_ped.Id_Pedido;
            //txtCedulaCliente.Text = consultar_ped.Cliente.Cedula;
            //txtNombreCliente.Text = consultar_ped.Cliente.Nombres_Cliente;
            //txtPrimerApellido.Text = consultar_ped.Cliente.Apellido_1;
            //txtSegundoApellido.Text = consultar_ped.Cliente.Apellido_2;
            //txtDireccion.Text = consultar_ped.Ubicacion.Direccion;
            //txtBarrio.Text = consultar_ped.Ubicacion.Barrio;
            //txtCiudad.Text = consultar_ped.Ciudad.Nombre_Ciudad;
            //txtDepartamento.Text = consultar_ped.Ciudad.Departamento.Nombre_Departamento;
            //txtTelefono.Text = consultar_ped.Ubicacion.Telefono_1;
            
            //txtPlaca.Text = consultar_ped.Vehiculo.Placa;
            //lblRutaAsignada.Text = consultar_ped.Ruta.Nombre_Ruta;
            //lstAgregar.Text = consultar_ped.Detalle_Ped.Tamano.Tamano; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
            //lstAgregar.Text = consultar_ped.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
            //lblFechaPedido.Text = consultar_ped.Fecha;
            //lblFechaEntregaCilindro.Text = Convert.ToString(consultar_ped.Venta.Fecha);

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


        public class prueba
        {
            private string prueba1;

            public string Prueba1
            {
                get { return prueba1; }
                set { prueba1 = value; }
            }
            private string prueba2;

            public string Prueba2
            {
                get { return prueba2; }
                set { prueba2 = value; }
            }
        }
    }
}