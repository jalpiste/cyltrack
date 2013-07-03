using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.PedidoService;
using System.Windows.Forms;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido
{
    public partial class frmModificarPedido : System.Web.UI.Page
    {
        List<Detalle_PedidoBE> lstDetail = new List<Detalle_PedidoBE>();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
        }


        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            txtCedulaCliente.Focus();
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

                        txtCedulaCliente.Text = info.Cliente.Cedula;
                        txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                        txtPrimerApellido.Text = info.Cliente.Apellido_1;
                        txtSegundoApellido.Text = info.Cliente.Apellido_2;
                        lstDireccion.Items.Add(info.Ubicacion.Direccion);
                        txtBarrio.Text = info.Ubicacion.Barrio;
                        txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = info.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = info.Ubicacion.Telefono_1;

                        lstPlaca.Items.Add(info.Vehiculo.Placa);
                        lblRutaAsignada.Text = info.Ruta.Nombre_Ruta;
                        //GRIDVIEW lstAgregar.Text = info.Detalle_Ped.Tamano.Tamano; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
                        //GRIDVIEW lstAgregar.Text = info.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
                        lblFechaPedido.Text = Convert.ToString(info.Fecha);

                        divInfoCliente.Visible = true;
                        btnGuardar.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Modificar Pedido");
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

        protected void TxtNumPedido_TextChanged(object sender, EventArgs e)
        {
            txtCedulaCliente.Focus();
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

                        txtCedulaCliente.Text = info.Cliente.Cedula;
                        txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                        txtPrimerApellido.Text = info.Cliente.Apellido_1;
                        txtSegundoApellido.Text = info.Cliente.Apellido_2;
                        lstDireccion.Items.Add(info.Ubicacion.Direccion);
                        txtBarrio.Text = info.Ubicacion.Barrio;
                        txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = info.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = info.Ubicacion.Telefono_1;

                        lstPlaca.Items.Add(info.Vehiculo.Placa);
                        lblRutaAsignada.Text = info.Ruta.Nombre_Ruta;
                        //GRIDVIEW lstAgregar.Text = info.Detalle_Ped.Tamano.Tamano; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
                        //GRIDVIEW lstAgregar.Text = info.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
                        lblFechaPedido.Text = Convert.ToString(info.Fecha);

                        divInfoCliente.Visible = true;
                        btnGuardar.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Modificar Pedido");
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

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            String resp;

            PedidoBE modificar_ped = new PedidoBE();

            try
            {

                UbicacionBE ubicli = new UbicacionBE();
                ubicli.Direccion = lstDireccion.Text;
                modificar_ped.Ubicacion = ubicli;

                VehiculoBE veh = new VehiculoBE();
                veh.Placa = lstPlaca.Text;
                modificar_ped.Vehiculo = veh;

                Detalle_PedidoBE detalle = new Detalle_PedidoBE();
                //detalle.Cantidad = GRIDVIEW lstAgregar.SelectedValue; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
                modificar_ped.Detalle_Ped = detalle;

                TamanoBE tam = new TamanoBE();
                //tam.Tamano = GRIDVIEW lstAgregar.Text; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
                detalle.Tamano = tam;

                divInfoCliente.Visible = false;
                btnGuardar.Visible = false;

                resp = servPedido.Modificar_Pedido(modificar_ped);

                if (resp == "Ok")
                {
                    MessageBox.Show("El pedido fue modificado satisfactoriamente", "Modificar Pedido");
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servPedido.Close();
                Response.Redirect("~/Pedido/frmModificarPedido.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //txtCantidadCilindro.Text = " ";
            //txtCedulaCliente.Text = " ";
            //TxtNumPedido.Text = " ";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            Detalle_PedidoBE detail = new Detalle_PedidoBE();
            DataTable tabla = new DataTable();

            try
            {

                detail.Cantidad = txtCantidadCilindro.Text;

                TamanoBE tamanocil = new TamanoBE();
                tamanocil.Tamano = lstTamano.SelectedValue;
                detail.Tamano = tamanocil;

                foreach (Detalle_PedidoBE det in lstDetail)
                {
                    if (det.Tamano.Tamano == detail.Tamano.Tamano)
                    {
                        lstDetail.Remove(det);
                    }

                }
                lstDetail.Add(detail);

                tabla.Columns.Add("TamanoCil");
                tabla.Columns.Add("CantidadPedido");


                foreach (Detalle_PedidoBE info in lstDetail)
                {
                    tabla.Rows.Add(info.Tamano.Tamano, info.Cantidad);

                    gvPedido.DataSource = tabla;
                    gvPedido.DataBind();
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

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            lstDireccion.Focus();

            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE consultar_cli = new PedidoBE();

            try
            {
                ClienteBE cliente = new ClienteBE();
                cliente.Cedula = txtCedulaCliente.Text;
                consultar_cli.Cliente = cliente;

                consultar_cli.Cliente.Cedula = txtCedulaCliente.Text;
                PedidoBE[] consulta = servPedido.Consultar_Pedido(consultar_cli);

                foreach (PedidoBE info in consulta)
                {
                    if (info.Cliente.Cedula != txtCedulaCliente.Text)
                    {

                
                        txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                        txtPrimerApellido.Text = info.Cliente.Apellido_1;
                        txtSegundoApellido.Text = info.Cliente.Apellido_2;
                        lstDireccion.Items.Add(info.Ubicacion.Direccion);
                        txtBarrio.Text = info.Ubicacion.Barrio;
                        txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = info.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = info.Ubicacion.Telefono_1;
                    }
                    else
                    {
                        MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Modificar Pedido");
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

        protected void lstDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstDireccion.Focus();
        }
    }
}
    
        