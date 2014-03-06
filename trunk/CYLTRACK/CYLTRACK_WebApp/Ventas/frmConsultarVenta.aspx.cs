using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VentaService;
using System.Data;
using System.Windows.Forms;

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
                string consultarExistencia = serVenta.ConsultarExistencia(txtCedulaCliente.Text);

                if (consultarExistencia != "Ok")
                {
                    MessageBox.Show("El cliente no tiene asignado ninguna venta reciente", "Consultar Venta");
                }
                else
                {
                    VentaBE datosVenta = new VentaBE();
                    datosVenta = serVenta.ConsultarVenta(txtCedulaCliente.Text);

                    table.Columns.Add("CodigosCil");
                    table.Columns.Add("Tamano");
                    table.Columns.Add("TipoCil");

                    txtFecha.Text = Convert.ToString(datosVenta.Fecha);
                    txtHora.Text = Convert.ToString(datosVenta.Fecha);
                    txtNumCedula.Text = datosVenta.Cliente.Cedula;
                    txtNombreCliente.Text = datosVenta.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = datosVenta.Cliente.Apellido_1;
                    txtSegundoApellido.Text = datosVenta.Cliente.Apellido_2;
                    txtDireccion.Text = datosVenta.Cliente.Ubicacion.Direccion;
                    txtBarrio.Text = datosVenta.Cliente.Ubicacion.Barrio;
                    txtCiudad.Text = datosVenta.Cliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = datosVenta.Cliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = datosVenta.Cliente.Ubicacion.Telefono_1;
                    txtObservacion.Text = datosVenta.Observaciones;

                    //-------------------------------------

                    txtNombreConductor.Text = datosVenta.Vehiculo.Conductor.Nombres_Conductor;
                    txtApellidoConductor.Text = datosVenta.Vehiculo.Conductor.Apellido_1;
                    txtSegundoApellidoConductor.Text = datosVenta.Vehiculo.Conductor.Apellido_2;
                    txtPlaca.Text = datosVenta.Vehiculo.Placa;
                    txtRuta.Text = datosVenta.Vehiculo.Ruta.Nombre_Ruta;
                    table.Rows.Add(datosVenta.Detalle_Venta.Cod_Cil_Actual, datosVenta.Detalle_Venta.Tamano, datosVenta.Detalle_Venta.Tipo_Cilindro);
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