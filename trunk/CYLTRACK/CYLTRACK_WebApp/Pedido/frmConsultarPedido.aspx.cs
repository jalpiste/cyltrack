using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.PedidoService;
using CYLTRACK_WebApp.ReporteService;
using CYLTRACK_WebApp.ClienteService;
using System.Windows.Forms;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido
{
    public partial class frmConsultarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            
            //long resp;
            //try
            //{
            ////    resp = servCliente.ConsultarExistenciasClientes(txtCedula.Text);
                
            //   if (resp == 0)
            //   {
            //       MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Registrar Pedido");
            //       divInfoCliente.Visible = false;
            //       txtCedula.Text = "";
            //       txtCedula.Focus();
            //   }

            //   else
            //   {
            //       ClienteBE objCliente = servCliente.Consultar_Cliente(txtCedula.Text);
                   
            //       txtCedulaCli.Text = objCliente.Cedula;
            //       txtNombreCliente.Text = objCliente.Nombres_Cliente;
            //       txtPrimerApellido.Text = objCliente.Apellido_1;
            //       txtSegundoApellido.Text = objCliente.Apellido_2;
            //       lstDireccion.Items.Add(objCliente.Ubicacion.Direccion);
            //       txtBarrio.Text = objCliente.Ubicacion.Barrio;
            //       txtCiudad.Text = objCliente.Ubicacion.Ciudad.Nombre_Ciudad;
            //       txtDepartamento.Text = objCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
            //       txtTelefono.Text = objCliente.Ubicacion.Telefono_1;

            //       divInfoCliente.Visible = true;
            //       btnGuardar.Visible = true;
            //       lstDireccion.Focus();

            //       lstPlaca.DataSource = servVeh.ConsultarVehiculo(string.Empty);
            //       lstPlaca.DataValueField = "Id_Vehiculo";
            //       lstPlaca.DataTextField = "Placa";
            //       lstPlaca.DataBind(); 
                   
            //   }
            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("~/About.aspx");
            //}
            //finally
            //{
            //    servCliente.Close();
            //    servPedido.Close();
            //    servVeh.Close();
            //    serRuta.Close();
            //    lblCodigoPedido.Visible = true;
            //    lblNumeroPedido.Visible = true;
                
            //}                       
        
        }

        protected void NumPedidoTxt_TextChanged(object sender, EventArgs e)
        {
            btnNuevaConsulta.Focus();
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ReporteServiceClient servReporte = new ReporteServiceClient(); 
            PedidoBE consultar_ped = new PedidoBE();
            long resp;

            try
            {
                resp = servReporte.consultadeExistenciaVarios(NumPedidoTxt.Text);

                if (resp == 0)
                {
                    MessageBox.Show("El Pedido no se encuentra registrado en el sistema", "Consultar Pedido");
                }
                else
                {

                    DataTable tabla = new DataTable();

                    tabla.Columns.Add("CantidadPedido");
                    tabla.Columns.Add("TamanoCil");

                    PedidoBE objPedido = new PedidoBE();
                    objPedido = servPedido.Consultar_Pedido(NumPedidoTxt.Text);

                    lblCodigoPedido.Text = objPedido.Id_Pedido;
                    txtCedulaCliente.Text = objPedido.Cliente.Cedula;
                    txtNombreCliente.Text = objPedido.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = objPedido.Cliente.Apellido_1;
                    txtSegundoApellido.Text = objPedido.Cliente.Apellido_2;
                    txtDireccion.Text = objPedido.Cliente.Ubicacion.Direccion;
                    txtBarrio.Text = objPedido.Cliente.Ubicacion.Barrio;
                    txtCiudad.Text = objPedido.Cliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = objPedido.Cliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = objPedido.Cliente.Ubicacion.Telefono_1;
                    txtPlaca.Text = objPedido.Vehiculo.Placa;
                    lblRutaAsignada.Text = objPedido.Ruta.Nombre_Ruta;
                    foreach (CilindroBE datos in objPedido.Cilindro)
                    {
                        tabla.Rows.Add(datos.Cantidad, datos.NTamano.Tamano);
                    }

                    gvPedido.DataSource = tabla;
                    gvPedido.DataBind();

                    lblFechaPedido.Text = Convert.ToString(objPedido.Fecha);
                    lblFechaEntregaCilindro.Text = Convert.ToString(objPedido.Fecha);
                    divInfoCliente.Visible = true;
                    btnNuevaConsulta.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servPedido.Close();
            }
        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pedido/frmConsultarPedido.aspx");
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

    }
}