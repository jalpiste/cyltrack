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
            ClienteServiceClient servCliente = new ClienteServiceClient();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();

            long respExisCliente;
            long respExisPedido;

            try
            {
                respExisCliente = servCliente.ConsultarExistenciasClientes(txtCedula.Text);

                if (respExisCliente == 0)
                {
                    MessageBox.Show("El cliente no ha solicitado pedido de cilindros", "Consultar Pedido");
                    divInfoCliente.Visible = false;
                    txtCedula.Text = "";
                    txtCedula.Focus();
                }

                else
                {
                    respExisPedido = servPedido.ConsultarExistenciaPedido(txtCedula.Text);

                if (respExisPedido == 0)
                {
                    MessageBox.Show("El cliente no tiene no se encuentra registrado en el sistema", "Consultar Pedido");
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

                    PedidoBE objPedido = servPedido.Consultar_Pedido(txtCedulaCliente.Text);
                    
                    table2.Columns.Add("TamanoCil");
                    table2.Columns.Add("CantidadPedido");
                    table2.Columns.Add("FechaPedido");
                    table2.Columns.Add("CodigoPedido");
                   
                    foreach(Detalle_PedidoBE datos in objPedido.List_Detalle_Ped)
                    {
                        table2.Rows.Add(datos.Tamano, datos.Cantidad, datos.Fecha, datos.Id_Pedido);                        
                    }
                    gvPedido.DataSource = table2;
                    gvPedido.DataBind();
                    gvDirecciones.Visible = true;
                    divInfoPedido.Visible = true;
                    divInfoCliente.Visible = true;
                    divDirCliente.Visible = true;
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
                txtCedula.Text = "";
                txtNumPedido.Text = "";
                btnNuevaConsulta.Visible = true;
                lblCodigoPedido.Visible = false;
                lblPedido.Visible = false;
                btnNuevaConsulta.Focus();
            }          
        }

        protected void NumPedidoTxt_TextChanged(object sender, EventArgs e)
        {
            btnNuevaConsulta.Focus();
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

                        PedidoBE objPedido = servPedido.Consultar_Pedido(txtNumPedido.Text);
                        table2.Columns.Add("TamanoCil");
                        table2.Columns.Add("CantidadPedido");
                        table2.Columns.Add("FechaPedido");
                        table2.Columns.Add("CodigoPedido");

                        if (objPedido.Estado == "2")
                        {
                            lblPedidoCancelado.Text = "PEDIDO CANCELADO POR EL CLIENTE";
                            lblPedidoCancelado.Visible = true;
                        }
                    
                        foreach (Detalle_PedidoBE datos in objPedido.List_Detalle_Ped)
                        {
                            table2.Rows.Add(datos.Tamano, datos.Cantidad, datos.Fecha, datos.Id_Pedido);
                            gvPedido.DataSource = table2;
                            gvPedido.DataBind();
                        }
                        divInfoPedido.Visible = true;                        
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
                btnNuevaConsulta.Visible = true;
                btnNuevaConsulta.Focus();
            }                       
        
        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pedido/frmConsultarPedido.aspx");
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

    }
}