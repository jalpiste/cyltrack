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
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            DataTable table = new DataTable();

            long respExisCliente;
            long respExisPedido;

            try
            {
                respExisCliente = servCliente.ConsultarExistenciasClientes(txtCedula.Text);

                if (respExisCliente == 0)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consultar Pedido");
                    divInfoCliente.Visible = false;
                    txtCedula.Text = "";
                    txtCedula.Focus();
                }

                else
                {
                    respExisPedido = servPedido.ConsultarExistenciaPedido(txtCedula.Text);

                    if (respExisPedido == 0)
                    {
                        MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Consultar Pedido");
                        divInfoCliente.Visible = false;
                        txtCedula.Text = "";
                        txtNumPedido.Text = "";
                        txtCedula.Focus();
                    }
                    else
                    {
                        ClienteBE objCliente = servCliente.Consultar_Cliente(txtCedula.Text);

                        txtCedulaCliente.Text = objCliente.Cedula;
                        txtNombreCliente.Text = objCliente.Nombres_Cliente;
                        txtPrimerApellido.Text = objCliente.Apellido_1;
                        txtSegundoApellido.Text = objCliente.Apellido_2;
                        txtDireccion.Text = objCliente.Ubicacion.Direccion;
                        txtBarrio.Text = objCliente.Ubicacion.Barrio;
                        txtCiudad.Text = objCliente.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = objCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = objCliente.Ubicacion.Telefono_1;
                        divInfoCliente.Visible = true;

                        PedidoBE objPedido = servPedido.Consultar_Pedido(txtCedulaCliente.Text);

                        table.Columns.Add("TamanoCil");
                        table.Columns.Add("CantidadPedido");
                        table.Columns.Add("FechaPedido");
                        lblCodigoPedido.Text = objPedido.Id_Pedido;
                        foreach (Detalle_PedidoBE datos in objPedido.List_Detalle_Ped)
                        {
                            table.Rows.Add(datos.Tamano, datos.Cantidad, datos.Fecha);
                        }
                        gvPedido.DataSource = table;
                        gvPedido.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
                servPedido.Close();
                lblCodigoPedido.Visible = true;
                lblPedido.Visible = true;
                txtCedula.Text = "";
                txtNumPedido.Text = "";
                btnGuardar.Visible = true;
            }                       
        
        }

        protected void txtNumPedido_TextChanged(object sender, EventArgs e)
        {
            txtMotivoCancelacion.Focus();
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            DataTable table = new DataTable();

            long respExisPedido;

            try
            {
                respExisPedido = servPedido.ConsultarExistenciaPedido(txtNumPedido.Text);

                if (respExisPedido == 0)
                {
                    MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Consultar Pedido");
                    divInfoCliente.Visible = false;
                    txtCedula.Text = "";
                    txtNumPedido.Text = "";
                    txtCedula.Focus();
                }
                else
                {
                    ClienteBE objCliente = servCliente.Consultar_Cliente(Convert.ToString(respExisPedido));

                    txtCedulaCliente.Text = objCliente.Cedula;
                    txtNombreCliente.Text = objCliente.Nombres_Cliente;
                    txtPrimerApellido.Text = objCliente.Apellido_1;
                    txtSegundoApellido.Text = objCliente.Apellido_2;
                    txtDireccion.Text = objCliente.Ubicacion.Direccion;
                    txtBarrio.Text = objCliente.Ubicacion.Barrio;
                    txtCiudad.Text = objCliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = objCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = objCliente.Ubicacion.Telefono_1;
                    divInfoCliente.Visible = true;

                    PedidoBE objPedido = servPedido.Consultar_Pedido(txtNumPedido.Text);

                    table.Columns.Add("TamanoCil");
                    table.Columns.Add("CantidadPedido");
                    table.Columns.Add("FechaPedido");

                    foreach (Detalle_PedidoBE datos in objPedido.List_Detalle_Ped)
                    {
                        table.Rows.Add(datos.Tamano, datos.Cantidad, datos.Fecha);
                    }
                    lblCodigoPedido.Text = txtNumPedido.Text;
                    gvPedido.DataSource = table;
                    gvPedido.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
                servPedido.Close();
                lblCodigoPedido.Visible = true;
                lblPedido.Visible = true;
                txtCedula.Text = "";
                txtNumPedido.Text = "";
                btnGuardar.Visible = true;
            }
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            long resp;
            PedidoBE cancelar_ped = new PedidoBE();

            try
            {
                cancelar_ped.Motivo_Cancel = txtMotivoCancelacion.Text;
                cancelar_ped.Id_Pedido = lblCodigoPedido.Text;
                
                resp = servPedido.Cancelar_Pedido(cancelar_ped);

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