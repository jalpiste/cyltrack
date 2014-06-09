using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.PedidoService;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.ReporteService;
using System.Windows.Forms;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido
{
    public partial class frmCancelarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            txtMotivoCancelacion.Focus();
            //txtCedula.Text = "";

            PedidoServiceClient servPedido = new PedidoServiceClient();
            ReporteServiceClient servReporte = new ReporteServiceClient();
            PedidoBE objPed = new PedidoBE();
            long resp;

            try
            {
                resp = servReporte.consultadeExistencia(txtCedula.Text);
                
                if (resp == 0)
                {
                    MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Cancelar Pedido");
                }
                    else
                    {
                        objPed = servPedido.Consultar_Pedido(txtCedula.Text);

                        lblCodigoPedido.Text = objPed.Id_Pedido;
                        txtCedulaCliente.Text = objPed.Cliente.Cedula;
                        txtNombreCliente.Text = objPed.Cliente.Nombres_Cliente;
                        txtPrimerApellido.Text = objPed.Cliente.Apellido_1;
                        txtSegundoApellido.Text = objPed.Cliente.Apellido_2;
                        txtDireccion.Text = objPed.Cliente.Ubicacion.Direccion;
                        txtBarrio.Text = objPed.Cliente.Ubicacion.Barrio;
                        txtCiudad.Text = objPed.Cliente.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = objPed.Cliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = objPed.Cliente.Ubicacion.Telefono_1;
                        //----------------------------------------------------------
                        txtZona.Text = objPed.Vehiculo.Placa;
                        lblRutaAsignada.Text = objPed.Ruta.Nombre_Ruta;
                        DataTable tabla = new DataTable();

                        tabla.Columns.Add("CantidadPedido");
                        tabla.Columns.Add("TamanoCil");
                        foreach (CilindroBE datos in objPed.Cilindro)
                        {
                            tabla.Rows.Add(datos.Cantidad, datos.NTamano.Tamano);
                        }
                        gvPedido.DataSource = tabla;
                        gvPedido.DataBind();
                    
                        lblFechaPedido.Text = Convert.ToString(objPed.Fecha);

                        divInfoCliente.Visible = true;
                        btnGuardar.Visible = true;
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

        protected void txtNumPedido_TextChanged(object sender, EventArgs e)
        {
            txtMotivoCancelacion.Focus();
            
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ReporteServiceClient servReporte = new ReporteServiceClient();
            PedidoBE objPed = new PedidoBE();
            long resp;

            try
            {
                resp = servReporte.consultadeExistenciaVarios(txtNumPedido.Text);

                if (resp == 0)
                {
                    MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Cancelar Pedido");
                }
                else
                {
                    objPed = servPedido.Consultar_Pedido(txtNumPedido.Text);

                    lblCodigoPedido.Text = objPed.Id_Pedido;
                    txtCedulaCliente.Text = objPed.Cliente.Cedula;
                    txtNombreCliente.Text = objPed.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = objPed.Cliente.Apellido_1;
                    txtSegundoApellido.Text = objPed.Cliente.Apellido_2;
                    txtDireccion.Text = objPed.Cliente.Ubicacion.Direccion;
                    txtBarrio.Text = objPed.Cliente.Ubicacion.Barrio;
                    txtCiudad.Text = objPed.Cliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = objPed.Cliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = objPed.Cliente.Ubicacion.Telefono_1;
                    //----------------------------------------------------------
                    txtZona.Text = objPed.Vehiculo.Placa;
                    lblRutaAsignada.Text = objPed.Ruta.Nombre_Ruta;
                    DataTable tabla = new DataTable();

                    tabla.Columns.Add("CantidadPedido");
                    tabla.Columns.Add("TamanoCil");
                    foreach (CilindroBE datos in objPed.Cilindro)
                    {
                        tabla.Rows.Add(datos.Cantidad, datos.NTamano.Tamano);
                    }
                    gvPedido.DataSource = tabla;
                    gvPedido.DataBind();

                    lblFechaPedido.Text = Convert.ToString(objPed.Fecha);

                    divInfoCliente.Visible = true;
                    btnGuardar.Visible = true;
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

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            String resp;
            PedidoBE cancelar_ped = new PedidoBE();

            try
            {
                cancelar_ped.Motivo_Cancel = txtMotivoCancelacion.Text;

                divInfoCliente.Visible = false;
                btnGuardar.Visible = false;
                txtMotivoCancelacion.Text = "";

                resp = servPedido.Cancelar_Pedido(Convert.ToString(cancelar_ped));

                MessageBox.Show("El pedido fue cancelado satisfactoriamente", "Cancelar Pedido");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servPedido.Close();
                Response.Redirect("~/Pedido/frmCancelarPedido.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

    }
}