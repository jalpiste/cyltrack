using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.PedidoService;
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
            btnNuevaConsulta.Focus();
            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE consultar_ped = new PedidoBE();
            string resp;

            try
            {
                resp = servPedido.Consultar_Existencia(txtCedula.Text);

                if (resp == null)
                {
                    MessageBox.Show("El Pedido no se encuentra registrado en el sistema", "Consultar Pedido");
                }
                
                    else
                    {

                       DataTable tabla = new DataTable();

                       tabla.Columns.Add("CantidadPedido");
                       tabla.Columns.Add("TamanoCil");
                    
                       PedidoBE objPedido = new PedidoBE();
                       objPedido = servPedido.Consultar_Pedido(txtCedula.Text);

                        lblCodigoPedido.Text = objPedido.Id_Pedido;
                        txtCedulaCliente.Text = objPedido.Cliente.Cedula;
                        txtNombreCliente.Text = objPedido.Cliente.Nombres_Cliente;
                        txtPrimerApellido.Text = objPedido.Cliente.Apellido_1;
                        txtSegundoApellido.Text = objPedido.Cliente.Apellido_2;
                        foreach (string datos in objPedido.Ubicacion.Direccion)
                        {
                            txtDireccion.Text = datos;
                        } 
                        txtBarrio.Text = objPedido.Ubicacion.Barrio;
                        txtCiudad.Text = objPedido.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = objPedido.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = objPedido.Ubicacion.Telefono_1;
                        txtPlaca.Text = objPedido.Vehiculo.Placa;
                        lblRutaAsignada.Text = objPedido.Ruta.Nombre_Ruta;
                        foreach (CilindroBE datos in objPedido.Cilindro)
                        {
                            tabla.Rows.Add(datos.Cantidad, datos.NTamano.Tamano); 
                        }                                               
                   
                        gvPedido.DataSource = tabla;
                        gvPedido.DataBind();
                    
                        lblFechaPedido.Text = Convert.ToString(objPedido.Fecha);
                        lblFechaEntregaCilindro.Text=  Convert.ToString(objPedido.Fecha);
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

        protected void NumPedidoTxt_TextChanged(object sender, EventArgs e)
        {
            btnNuevaConsulta.Focus();
            PedidoServiceClient servPedido = new PedidoServiceClient();
             
            PedidoBE consultar_ped = new PedidoBE();
            String resp;

            try
            {
                resp = servPedido.Consultar_Existencia(NumPedidoTxt.Text);

                if (resp == null)
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
                    foreach (string datos in objPedido.Ubicacion.Direccion)
                    {
                        txtDireccion.Text=(datos);
                    } 
                    txtBarrio.Text = objPedido.Ubicacion.Barrio;
                    txtCiudad.Text = objPedido.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = objPedido.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = objPedido.Ubicacion.Telefono_1;
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