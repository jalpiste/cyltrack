using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VentaService;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmConsultarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCedulaCliente.Focus();
            }
            else 
            {
                DivInfoVenta.Focus();
            }
        }
        
        protected void btnMenu_Click(object sender, EventArgs e)
        {
             //Response.Redirect("~/Default.aspx");
           
        }
        
        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
              Response.Redirect("~/Ventas/frmConsultarVenta.aspx");
        }

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {

            VentaServiceClient serVenta = new VentaServiceClient();
            VentaBE venta = new VentaBE();
           
            try 
            {
                DataTable table = new DataTable();
                ClienteBE cli = new ClienteBE();
                cli.Cedula= txtCedulaCliente.Text;
                venta.Cliente = cli;
                List<VentaBE> datosVenta = new List<VentaBE>(serVenta.ConsultarVenta(venta));
                
                table.Columns.Add("CodigosCil");
                table.Columns.Add("Tamano");
                table.Columns.Add("TipoCil");

                foreach (VentaBE info in datosVenta)
                {
                    txtFecha.Text = Convert.ToString(info.Fecha);
                    txtHora.Text = Convert.ToString(info.Fecha);
                    txtNumCedula.Text = info.Cliente.Cedula;
                    txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = info.Cliente.Apellido_1;
                    txtSegundoApellido.Text = info.Cliente.Apellido_2;
                    txtDireccion.Text = info.Cliente.Ubicacion.Direccion;
                    txtBarrio.Text = info.Cliente.Ubicacion.Barrio;
                    txtCiudad.Text = info.Cliente.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = info.Cliente.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = info.Cliente.Ubicacion.Telefono_1;
                    txtObservacion.Text = info.Observaciones;

                    //-------------------------------------

                    txtNombreConductor.Text = info.Vehiculo.Conductor.Nombres_Conductor;
                    txtApellidoConductor.Text = info.Vehiculo.Conductor.Apellido_1;
                    txtSegundoApellidoConductor.Text = info.Vehiculo.Conductor.Apellido_2;
                    txtPlaca.Text = info.Vehiculo.Placa;
                    txtRuta.Text = info.Vehiculo.Ruta.Nombre_Ruta;
                    table.Rows.Add(info.Detalle_Venta.Cod_Cil_Actual, info.Detalle_Venta.Tamano, info.Detalle_Venta.Tipo_Cilindro);
                    gvCargue.DataSource = table;
                    gvCargue.DataBind();

                    DivInfoVenta.Visible = true;
                    btnNuevaConsulta.Visible = true;
                }
            }
            catch (Exception ex) 
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                serVenta.Close();
            }
            
        }

        
     }
}