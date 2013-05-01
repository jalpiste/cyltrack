using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmVentaCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        VentaBE ventas = new VentaBE();
        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            //validar en BD
            //ventas.Cliente.Cedula = txtCedula.Text;

            //ConsultaDatosCliente();

            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void TxtNumPedido_TextChanged(object sender, EventArgs e)
        {
            //valida en BD
            //ventas.Pedido.Id_Pedido = TxtNumPedido.Text;

            //ConsultaDatosCliente();

            divInfoCliente.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            //ventas.Detalle_Venta.Cod_Cil_Actual = LstCodigos.SelectedValue;
            //ventas.//observaciones

            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            divInfoCliente.Visible = false;
            btnGuardar.Visible = false;
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        public void ConsultaDatosCliente()
        {
            txtNombreCliente.Text = ventas.Cliente.Nombres_Cliente;
            txtPrimerApellido.Text = ventas.Cliente.Apellido_1;
            txtSegundoApellido.Text = ventas.Cliente.Apellido_2;
            lstDireccion.Text = ventas.Ubicacion.Direccion;
            txtBarrio.Text = ventas.Ubicacion.Barrio;
            txtTelefono.Text = ventas.Ubicacion.Telefono_1;
            txtCiudad.Text = ventas.Ubicacion.Ciudad.Nombre_Ciudad;
            txtDepartamento.Text = ventas.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
            txtCilindro.Text = ventas.Cilindro.Codigo_Cilindro;
            txtTamano.Text = ventas.Cilindro.NTamano.Tamano;
            //cantidad
            txtTipoCil.Text = ventas.Cilindro.Tipo_Cilindro;

        }
    }
}