using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VentaService;
using CYLTRACK_WebApp.ClienteService;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmVentaCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        VentaServiceClient serVenta = new VentaServiceClient();
        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
           
            //ventas.Cliente.Cedula = txtCedula.Text;
            

            ConsultaDatosCliente();

            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void TxtNumPedido_TextChanged(object sender, EventArgs e)
        {
            //valida en BD
            //ventas.Pedido.Id_Pedido = TxtNumPedido.Text;

           ConsultaDatosCliente();

            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            VentaBE ventas = new VentaBE();
            //ventas.Detalle_Venta.Cod_Cil_Actual = LstCodigos.SelectedValue;
            ventas.Observaciones = txtObservacion.Text;

           
            String infVenta;
            infVenta = serVenta.VentaCilindro(ventas);

            if (infVenta == "Ok")
            {
                Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
                divInfoCliente.Visible = false;
                btnGuardar.Visible = false;  
            }
            else
            {
                Response.Write("<script type='text/javascript'> alert('Error') </script>");
                divInfoCliente.Visible = false;
                btnGuardar.Visible = false;
            }
            
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        public void ConsultaDatosCliente()
        {
            
            VentaBE venta = new VentaBE();
            VentaBE [] consulta = serVenta.ConsultarVenta(venta);

            var datos = from info in consulta
                         select info;

            foreach (VentaBE info in datos)
            {
                txtNombreCliente.Text = info.Observaciones;
                txtPrimerApellido.Text = Convert.ToString(info.Fecha);
                txtSegundoApellido.Text = info.Id_Venta;
                //lstDireccion.Text = info.Ubicacion.Direccion;
                //txtBarrio.Text = info.Ubicacion.Barrio;
                //txtTelefono.Text = info.Ubicacion.Telefono_1;
                //txtCiudad.Text = info.Ubicacion.Ciudad.Nombre_Ciudad;
                //txtDepartamento.Text = info.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                //txtCilindro.Text = info.Cilindro.Codigo_Cilindro;
                //txtTamano.Text = info.Cilindro.NTamano.Tamano;
                ////cantidad
                //txtTipoCil.Text = info.Cilindro.Tipo_Cilindro;
            }
        }
    }
}