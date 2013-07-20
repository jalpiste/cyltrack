using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.PedidoService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account.Pedido
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

            try
            {
                ClienteBE cliente = new ClienteBE();
                cliente.Cedula = txtCedula.Text;
                consultar_ped.Cliente = cliente;

                consultar_ped.Cliente.Cedula = txtCedula.Text;
                PedidoBE[] consulta = servPedido.Consultar_Pedido(consultar_ped);

                foreach (PedidoBE info in consulta)
                {
                    if (info.Cliente.Cedula != txtCedula.Text)
                    {

                        lblCodigoPedido.Text = info.Id_Pedido;
                        txtCedulaCliente.Text = info.Cliente.Cedula;
                        txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                        txtPrimerApellido.Text = info.Cliente.Apellido_1;
                        txtSegundoApellido.Text = info.Cliente.Apellido_2;
                        txtDireccion.Text = info.Ubicacion.Direccion;
                        txtBarrio.Text = info.Ubicacion.Barrio;
                        txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = info.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = info.Ubicacion.Telefono_1;

                        txtPlaca.Text = info.Vehiculo.Placa;
                        lblRutaAsignada.Text = info.Ruta.Nombre_Ruta;
                        //GRIDVIEW lstAgregar.Text = info.Detalle_Ped.Tamano.Tamano; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
                        //GRIDWIEW lstAgregar.Text = info.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
                        lblFechaPedido.Text = Convert.ToString(info.Fecha);

                        divInfoCliente.Visible = true;
                        btnNuevaConsulta.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consultar Pedido");
                    }
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

            try
            {
                ClienteBE cliente = new ClienteBE();
                cliente.Cedula = txtCedula.Text;
                consultar_ped.Cliente = cliente;

                consultar_ped.Cliente.Cedula = txtCedula.Text;
                PedidoBE[] consulta = servPedido.Consultar_Pedido(consultar_ped);

                foreach (PedidoBE info in consulta)
                {
                    if (info.Cliente.Cedula != txtCedula.Text)
                    {

                        lblCodigoPedido.Text = info.Id_Pedido;
                        txtCedulaCliente.Text = info.Cliente.Cedula;
                        txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                        txtPrimerApellido.Text = info.Cliente.Apellido_1;
                        txtSegundoApellido.Text = info.Cliente.Apellido_2;
                        txtDireccion.Text = info.Ubicacion.Direccion;
                        txtBarrio.Text = info.Ubicacion.Barrio;
                        txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = info.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = info.Ubicacion.Telefono_1;

                        txtPlaca.Text = info.Vehiculo.Placa;
                        lblRutaAsignada.Text = info.Ruta.Nombre_Ruta;
                        //GRIDVIEW lstAgregar.Text = info.Detalle_Ped.Tamano.Tamano; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
                        //GRIDWIEW lstAgregar.Text = info.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
                        lblFechaPedido.Text = Convert.ToString(info.Fecha);

                        divInfoCliente.Visible = true;
                        btnNuevaConsulta.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Consultar Pedido");
                    }
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