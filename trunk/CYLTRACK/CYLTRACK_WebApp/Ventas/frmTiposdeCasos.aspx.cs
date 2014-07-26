using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYLTRACK_WebApp.VentaService;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmTiposdeCasos : System.Web.UI.Page
    {
        CasosBE id_Caso;
        protected void Page_Load(object sender, EventArgs e)
        {
            VentaServiceClient serVenta = new VentaServiceClient();
            try 
            {
                var dato = Server.UrlDecode(Request.QueryString["Data"]);
                List<CasosBE> lstCasos = new List<CasosBE>(serVenta.RevisionCasosEspeciales(dato));
                foreach(CasosBE consulta in lstCasos)
                {
                    //txtNumCedula.Text = consulta.Venta.IdCliente.Cedula; 
                    //txtNombreCliente.Text=consulta.Venta.IdCliente.Nombres_Cliente;
                    //txtPrimerApellido.Text = consulta.Venta.IdCliente.Apellido_1;
                    //txtSegundoApellido.Text = consulta.Venta.IdCliente.Apellido_2;
                    ////foreach (string datos in consulta.Venta.Cliente.ListaDirecciones)
                    ////{
                    ////    txtDireccion.Text= datos;
                    ////} 
                    //txtBarrio.Text = consulta.Venta.IdCliente.Ubicacion.Barrio;
                    //txtCiudad.Text = consulta.Venta.IdCliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    //txtDepartamento.Text = consulta.Venta.IdCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    //txtTelefono.Text = consulta.Venta.IdCliente.Ubicacion.Telefono_1;
                   // txtObservacion.Text = consulta.Id_Detalle_Venta.Observaciones;
                    txtCasoEspecial.Text = consulta.Tipo_Caso.Nombre_Caso;
                    
                    if (txtCasoEspecial.Text == "Escape")
                    {
                        divEscape.Visible = true;
                       // txtCilAnterior.Text = consulta.Venta.Detalle_Venta.Cod_Cil_Actual;
                      //  txtCilaCambio.Text = consulta.Venta.Detalle_Venta.Cod_Cil_Nuevo;
                    }
                    if (txtCasoEspecial.Text == "Codigo_Errado") 
                    {
                        divCodErroneo.Visible = true;
                        //txtCodigoErroneo.Text = consulta.Venta.Detalle_Venta.Cod_Cil_Actual;
                        //txtCodigoCorrecto.Text = consulta.Venta.Detalle_Venta.Cod_Cil_Nuevo;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                serVenta.Close();
                DivInfoVenta.Visible = true;
            }            

        }
        
        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            String respuesta;
            VentaServiceClient serventa = new VentaServiceClient();
            try
            {
                respuesta = serventa.CasosEspeciales(id_Caso);
                MessageBox.Show("El caso fue registrado satisfactoriamente", "Revision de Casos Especiales");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                serventa.Close();
                Response.Redirect("~/Ventas/frmRevisionCasosEspeciales.aspx");
            }
            
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El caso registrado será rechazado en el sistema","Revision de Casos Especiales");
            Response.Redirect("~/Ventas/frmRevisionCasosEspeciales.aspx");
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ventas/frmRevisionCasosEspeciales.aspx");
        }

           }
}