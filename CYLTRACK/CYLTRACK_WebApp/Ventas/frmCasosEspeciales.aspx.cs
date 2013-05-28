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
    public partial class frmCasosEspeciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //[System.Runtime.InteropServices.DllImport("Kernel32")]
        //public static extern bool AllocConsole();
        //[System.Runtime.InteropServices.DllImport("Kernel32")]
        //public static extern bool FreeConsole();
        VentaServiceClient serVenta = new VentaServiceClient();
        VentaBE ventas = new VentaBE();
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            //ventas.Cliente.Cedula = txtCedulaCliente.Text;
            VentaBE[] consulta = serVenta.ConsultarVenta(ventas);
            var datos = from info in consulta
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
                //lstCaso.Text = info.Casos_Especiales.Tipo_Caso.Nombre_Caso;
 
            }
                       
            DivInfoVenta.Visible = true;
            divVerifInfo.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String infoVenta;
            ventas.Observaciones = lstCaso.SelectedValue;
            //ventas.Casos_Especiales.Tipo_Caso.Nombre_Caso = lstCaso.SelectedValue;
            //ventas.Detalle_Venta.Cod_Cil_Nuevo = lstCilEntrega.SelectedValue;
            //ventas.Detalle_Venta.Cod_Cil_Nuevo = txtCodigoVerific.Text;
           
            infoVenta = serVenta.CasosEspeciales(ventas);
            //AllocConsole();
            //Console.WriteLine("prueba"+infoVenta);
            //Console.Read();
            //FreeConsole();

            if (infoVenta == "Ok")
            {
                Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
                DivInfoVenta.Visible = false;
                divVerifInfo.Visible = false;
                btnGuardar.Visible = false;
            }
            else
            {
                Response.Write("<script type='text/javascript'> alert('Error') </script>");
                DivInfoVenta.Visible = false;
                divVerifInfo.Visible = false;
                btnGuardar.Visible = false;
            }
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

        
        

    }
}