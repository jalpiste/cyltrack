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
            txtNumPedido.Focus();
        }

        protected void txtNumPedido_TextChanged(object sender, EventArgs e)
        {
            txtMotivoCancelacion.Focus();
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();

            long respExisPedido;

            try
            {
                respExisPedido = servPedido.ConsultarExistenciaPedido(txtNumPedido.Text);

                if (respExisPedido == 0)
                {
                    MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Cancelar Pedido");
                    divInfoCliente.Visible = false;                    
                    txtNumPedido.Text = "";
                    txtNumPedido.Focus();
                }
                else
                {
                    PedidoBE objPedido = servPedido.Consultar_Pedido(txtNumPedido.Text);

                    if (objPedido.Estado != "2")
                    {
                        table2.Columns.Add("TamanoCil");
                        table2.Columns.Add("CantidadPedido");
                        table2.Columns.Add("FechaPedido");

                        foreach (Detalle_PedidoBE datos in objPedido.List_Detalle_Ped)
                        {
                            table2.Rows.Add(datos.Tamano, datos.Cantidad, datos.Fecha);
                            gvPedido.DataSource = table2;
                            gvPedido.DataBind();
                        }
                        divInfoPedido.Visible = true;

                        ClienteBE objCliente = servCliente.Consultar_Cliente(Convert.ToString(respExisPedido));

                        txtCedulaCliente.Text = objCliente.Cedula;
                        txtNombreCliente.Text = objCliente.Nombres_Cliente;
                        txtPrimerApellido.Text = objCliente.Apellido_1;
                        txtSegundoApellido.Text = objCliente.Apellido_2;
                        lblCodigoPedido.Text = txtNumPedido.Text;
                        table1.Columns.Add("IdUbicacion");
                        table1.Columns.Add("Direccion");
                        table1.Columns.Add("Barrio");
                        table1.Columns.Add("Telefono");
                        table1.Columns.Add("Ciudad");

                        foreach (UbicacionBE datos in objCliente.ListaDirecciones)
                        {
                            table1.Rows.Add(datos.Id_Ubicacion, datos.Direccion, datos.Barrio, datos.Telefono_1, datos.Ciudad.Nombre_Ciudad);
                            gvDirecciones.DataSource = table1;
                            gvDirecciones.DataBind();
                        }

                        divInfoCliente.Visible = true;
                        divDirCliente.Visible = true;
                        btnGuardar.Visible = true;
                    }
                    else {
                        MessageBox.Show("El pedido ya se encuentra cancelado en el sistema", "Cancelar Pedido");
                        divInfoCliente.Visible = false;
                        txtNumPedido.Text = "";
                        txtNumPedido.Focus();
                        btnMenuPrincipal.Visible = true;
                        
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
                txtNumPedido.Text = "";                
            }                       
        
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Redirect("~/Default.aspx");
            }
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

        protected void txtMotivoCancelacion_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            btnGuardar.Focus();
        }
       
    }
}