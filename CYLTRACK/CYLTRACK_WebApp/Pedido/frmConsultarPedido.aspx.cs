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
            ClienteServiceClient servCliente = new ClienteServiceClient();
            
            PedidoBE consultar_ped = new PedidoBE();
            String resp;

            try
            {
                resp = servCliente.Consultar_Existencia(txtCedula.Text);

                if (resp == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consultar Pedido");
                }
                
                    else
                    {
                        ClienteBE objCliente = servCliente.Consultar_Cliente(txtCedula.Text);

                        //lblCodigoPedido.Text = objPed.Id_Pedido;
                        txtCedulaCliente.Text = objCliente.Cedula;
                        txtNombreCliente.Text = objCliente.Nombres_Cliente;
                        txtPrimerApellido.Text = objCliente.Apellido_1;
                        txtSegundoApellido.Text = objCliente.Apellido_2;
                        txtDireccion.Text = objCliente.Ubicacion.Direccion;
                        txtBarrio.Text = objCliente.Ubicacion.Barrio;
                        txtCiudad.Text = objCliente.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = objCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = objCliente.Ubicacion.Telefono_1;

                        //txtPlaca.Text = objPed.Vehiculo.Placa;
                        //lblRutaAsignada.Text = objPed.Ruta.Nombre_Ruta;
                        //GRIDVIEW lstAgregar.Text = info.Detalle_Ped.Tamano.Tamano; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
                        //GRIDWIEW lstAgregar.Text = info.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
                        //lblFechaPedido.Text = Convert.ToString(objPed.Fecha);

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
                servCliente.Close();
            }
        }

        protected void NumPedidoTxt_TextChanged(object sender, EventArgs e)
        {
            btnNuevaConsulta.Focus();
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            
            PedidoBE consultar_ped = new PedidoBE();
            String resp;

            try
            {
                resp = servPedido.Consultar_Existencia(NumPedidoTxt.Text);

                if (resp == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consultar Pedido");
                }
                    else
                    {
                        ClienteBE objCliente = servCliente.Consultar_Cliente(txtCedula.Text);

                        //lblCodigoPedido.Text = objPed.Id_Pedido;
                        txtCedulaCliente.Text = objCliente.Cedula;
                        txtNombreCliente.Text = objCliente.Nombres_Cliente;
                        txtPrimerApellido.Text = objCliente.Apellido_1;
                        txtSegundoApellido.Text = objCliente.Apellido_2;
                        txtDireccion.Text = objCliente.Ubicacion.Direccion;
                        txtBarrio.Text = objCliente.Ubicacion.Barrio;
                        txtCiudad.Text = objCliente.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = objCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = objCliente.Ubicacion.Telefono_1;

                        //txtPlaca.Text = objPed.Vehiculo.Placa;
                        //lblRutaAsignada.Text = objPed.Ruta.Nombre_Ruta;
                        //GRIDVIEW lstAgregar.Text = info.Detalle_Ped.Tamano.Tamano; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
                        //GRIDWIEW lstAgregar.Text = info.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
                        //lblFechaPedido.Text = Convert.ToString(objPed.Fecha);

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
                servCliente.Close();
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