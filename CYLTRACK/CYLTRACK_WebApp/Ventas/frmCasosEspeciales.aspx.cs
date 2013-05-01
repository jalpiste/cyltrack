using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmCasosEspeciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        VentaBE ventas = new VentaBE();
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
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
            //lstCaso.Text = ventas.Casos_Especiales.Tipo_Caso.Nombre_Caso;

            DivInfoVenta.Visible = true;
            divVerifInfo.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //ventas.Casos_Especiales.Tipo_Caso.Nombre_Caso= lstCaso.SelectedValue;
            //ventas.Detalle_Venta.Cod_Cil_Nuevo = lstCilEntrega.SelectedValue;
            //ventas.Detalle_Venta.Cod_Cil_Nuevo = txtCodigoVerific.Text;

            //Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
        }

        protected void lstCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCaso.SelectedIndex == 1) 
            {
                //lstCilEntrega.Text = ventas.Cilindro.Codigo_Cilindro;
                divEscape.Visible = true;
            }
            if (lstCaso.SelectedIndex == 3) 
            {
                divCodCorrecto.Visible = true;
            }
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
        }

        

    }
}