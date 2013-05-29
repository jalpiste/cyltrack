using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account.Pedido
{
    public partial class frmRegistroPedido : System.Web.UI.Page
    {
        List<Detalle_PedidoBE> lstDetail = new List<Detalle_PedidoBE>();
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

            //txtNombreCliente.Text = consultar_ped.Cliente.Nombres_Cliente;
            //txtPrimerApellido.Text = consultar_ped.Cliente.Apellido_1;
            //txtSegundoApellido.Text = consultar_ped.Cliente.Apellido_2;
            //lstDireccion.Text = consultar_ped.Ubicacion.Direccion; // como llamar todas las direcciones disponibles para el cliente???
            //txtBarrio.Text = consultar_ped.Ubicacion.Barrio;
            //txtCiudad.Text = consultar_ped.Ciudad.Nombre_Ciudad;
            //txtDepartamento.Text = consultar_ped.Ciudad.Departamento.Nombre_Departamento;
            //txtTelefono.Text = consultar_ped.Ubicacion.Telefono_1;

            //txtCilindro.Text = consultar_ped.Cilindro.Codigo_Cilindro;
            //txtTamano.Text = consultar_ped.Cilindro.NTamano.Tamano;
            

            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreCliente.Text = " ";
            txtPrimerApellido.Text = " ";
            txtSegundoApellido.Text = " ";
            txtBarrio.Text = " ";
            txtCiudad.Text = " ";
            txtDepartamento.Text = " ";
            txtTelefono.Text = " ";
            txtCilindro.Text = " ";
            txtTamano.Text = " ";
            txtCantidadCilindro.Text = " ";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //PedidoBE registrar_ped = new PedidoBE();

            //registrar_ped.Vehiculo.Placa = lstPlaca.SelectedValue;
            //registrar_ped.Ruta.Nombre_Ruta = lblRutaAsignada.Text;
            //registrar_ped.Detalle_Ped.Tamano.Tamano = lstAgregar.Text; // como asignarle a la base de datos la información del pedido que está en la lista (tam_cant)
            //registrar_ped.Detalle_Ped.Cantidad = lstAgregar.SelectedValue;

            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            //Response.Redirect("~/Pedido/frmRegistrarPedido.aspx");
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Detalle_PedidoBE detail = new Detalle_PedidoBE();
            detail.Cantidad = txtCantidadCilindro.Text;
            detail.Tamano.Tamano = lstTamano.SelectedValue;
            foreach (Detalle_PedidoBE det in lstDetail)
            {
                if (det.Tamano == detail.Tamano)
                {
                    detail.Cantidad += det.Cantidad;
                    lstDetail.Remove(det);
                }
                
            }
            lstDetail.Add(detail);
        }

    }
}