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
    public partial class frmModificarPedido : System.Web.UI.Page
    {
        List<Detalle_PedidoBE> lstDetail = new List<Detalle_PedidoBE>();
        DataTable objdtLista;
        string aux;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();

            if (!Page.IsPostBack)
            {
                objdtLista = new DataTable();
                CrearTabla();
            }
            if (!IsPostBack)
            {
                List<string> tamanos = Auxiliar.ConsultarTamanos();
                foreach (string datosTamanos in tamanos)
                {
                    lstTamano.Items.Add((datosTamanos).Substring(3));
                }
            }
        }
        //      ------------------------- inicio de tabla acumulada y asignación de valor
        protected DataTable objdtTabla
        {
            get
            {
                if (ViewState["objdtTabla"] != null)
                {
                    return (DataTable)ViewState["objdtTabla"];
                }
                else
                {
                    return objdtLista;
                }
            }
            set
            {
                ViewState["objdtTabla"] = value;
            }
        }
        //        ------------------------- fin de tabla acumulada y asignación de valor
        private void CrearTabla()
        {
            objdtLista.Columns.Add("TamanoCil");
            objdtLista.Columns.Add("CantidadPedido");
            objdtTabla = objdtLista;
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            txtCedulaCliente.Focus();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            PedidoServiceClient servPedido = new PedidoServiceClient();
            
            PedidoBE consultar_ped = new PedidoBE();
            String resp;

            try
            {
                resp = servCliente.Consultar_Existencia(txtCedula.Text);
                aux = txtCedula.Text;

                if (resp == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Modificar Pedido");
                }
                else
                    {
                        ClienteBE objCliente = servCliente.Consultar_Cliente(txtCedula.Text);

                        txtCedulaCliente.Text = objCliente.Cedula;
                        txtNombreCliente.Text = objCliente.Nombres_Cliente;
                        txtPrimerApellido.Text = objCliente.Apellido_1;
                        txtSegundoApellido.Text = objCliente.Apellido_2;
                        lstDireccion.Items.Add(objCliente.Ubicacion.Direccion);// como llamar todas las direcciones disponibles para el cliente???
                        txtBarrio.Text = objCliente.Ubicacion.Barrio;
                        txtCiudad.Text = objCliente.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = objCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = objCliente.Ubicacion.Telefono_1;
                       // lblFechaPedido.Text = Convert.ToString(objCliente.Detalle_Venta.Venta.Fecha);
                        
                        foreach (DataRow row in objdtTabla.Rows)
                        {
                            Detalle_PedidoBE det = new Detalle_PedidoBE();
                            TamanoBE tamanito = new TamanoBE();
                            det.Tamano = tamanito;
                            det.Tamano.Tamano = (Convert.ToString(row["TamanoCil"]));
                            det.Cantidad = (Convert.ToString(row["CantidadPedido"]));
                            lstDetail.Add(det);
                        }

                        Detalle_PedidoBE detalle = new Detalle_PedidoBE();
                        TamanoBE tam = new TamanoBE();
                        detalle.Tamano = tam;

                        foreach (Detalle_PedidoBE datos in lstDetail)
                        {
                            detalle.Tamano.Tamano = datos.Tamano.Tamano;
                            detalle.Cantidad = datos.Cantidad;
                        } 
                  
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
                servCliente.Close();
                servPedido.Close();
            }
        }

        protected void TxtNumPedido_TextChanged(object sender, EventArgs e)
        {
            txtCedulaCliente.Focus();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            PedidoServiceClient servPedido = new PedidoServiceClient();

            PedidoBE consultar_ped = new PedidoBE();
            String resp;

            try
            {
                resp = servPedido.Consultar_Existencia(TxtNumPedido.Text);

                if (resp == null)
                {
                    MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Modificar Pedido");
                }
                else
                {
                    ClienteBE objCliente = servCliente.Consultar_Cliente(txtCedulaCliente.Text);

                    txtCedulaCliente.Text = objCliente.Cedula;
                    txtNombreCliente.Text = objCliente.Nombres_Cliente;
                    txtPrimerApellido.Text = objCliente.Apellido_1;
                    txtSegundoApellido.Text = objCliente.Apellido_2;
                    lstDireccion.Items.Add(objCliente.Ubicacion.Direccion);// como llamar todas las direcciones disponibles para el cliente???
                    txtBarrio.Text = objCliente.Ubicacion.Barrio;
                    txtCiudad.Text = objCliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = objCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = objCliente.Ubicacion.Telefono_1;
                    //lblFechaPedido.Text = Convert.ToString(objCliente.Detalle_Venta.Venta.Fecha);
                    
                    foreach (DataRow row in objdtTabla.Rows)
                    {
                        Detalle_PedidoBE det = new Detalle_PedidoBE();
                        TamanoBE tamanito = new TamanoBE();
                        det.Tamano = tamanito;
                        det.Tamano.Tamano = (Convert.ToString(row["TamanoCil"]));
                        det.Cantidad = (Convert.ToString(row["CantidadPedido"]));
                        lstDetail.Add(det);
                    }

                    Detalle_PedidoBE detalle = new Detalle_PedidoBE();
                    TamanoBE tam = new TamanoBE();
                    detalle.Tamano = tam;

                    foreach (Detalle_PedidoBE datos in lstDetail)
                    {
                        detalle.Tamano.Tamano = datos.Tamano.Tamano;
                        detalle.Cantidad = datos.Cantidad;
                    }
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
                servCliente.Close();
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
            txtCedula.Text = "";

            try
            {
                ClienteBE idcliente = new ClienteBE();
                idcliente.Cedula = txtCedula.Text;
                modificar_ped.Cliente = idcliente;

                UbicacionBE ubicli = new UbicacionBE();
                ubicli.Direccion = lstDireccion.Text;
                modificar_ped.Ubicacion = ubicli;

                VehiculoBE veh = new VehiculoBE();
                veh.Placa = lstPlaca.SelectedValue;
                modificar_ped.Vehiculo = veh;

                RutaBE ruta = new RutaBE();
                ruta.Nombre_Ruta = lblRutaAsignada.Text;
                modificar_ped.Ruta = ruta;

                foreach (DataRow row in objdtTabla.Rows)
                {
                    Detalle_PedidoBE det = new Detalle_PedidoBE();
                    TamanoBE tamanito = new TamanoBE();
                    det.Tamano = tamanito;
                    det.Tamano.Tamano = (Convert.ToString(row["TamanoCil"]));
                    det.Cantidad = (Convert.ToString(row["CantidadPedido"]));
                    lstDetail.Add(det);
                }

                Detalle_PedidoBE detalle = new Detalle_PedidoBE();
                TamanoBE tam = new TamanoBE();
                detalle.Tamano = tam;

                foreach (Detalle_PedidoBE datos in lstDetail)
                {
                    detalle.Tamano.Tamano = datos.Tamano.Tamano;
                    detalle.Cantidad = datos.Cantidad;
                }
                modificar_ped.Detalle_Ped = detalle;
             
                resp = servPedido.Modificar_Pedido(Convert.ToString(modificar_ped));

                if (resp == "Ok")
                {
                   if (lstDetail.Count == 0)
                   {
                      MessageBox.Show("No se percibió cambio en la orden de pedido de cilindros", "Modificar Pedido");
                   }
                   else
                   {
                      MessageBox.Show("El pedido fue modificado satisfactoriamente", "Modificar Pedido");
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
                        detail.Cantidad += det.Tamano.Tamano;
                        lstDetail.Remove(det);
                    }
                }
                lstDetail.Add(detail);
                
                foreach (Detalle_PedidoBE info in lstDetail)
                {
                    objdtTabla.Rows.Add(info.Tamano.Tamano, info.Cantidad);

                    gvPedido.DataSource = objdtTabla;
                    gvPedido.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }

            finally
            {
                gvPedido.Visible = true;
                servPedido.Close();
                btnGuardar.Focus();
            }
        }

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            lstDireccion.Focus();

            ClienteServiceClient servCliente = new ClienteServiceClient();
            PedidoBE consultar_cli = new PedidoBE();
            String resp;

            try
            {
                ClienteBE cliente = new ClienteBE();
                cliente.Cedula = txtCedulaCliente.Text;
                consultar_cli.Cliente = cliente;

                resp = servCliente.Consultar_Existencia(txtCedula.Text);

                if (resp == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Modificar Pedido");
                }
                  else
                    {
                        ClienteBE objCliente = servCliente.Consultar_Cliente(txtCedulaCliente.Text);

                        txtNombreCliente.Text = objCliente.Nombres_Cliente;
                        txtPrimerApellido.Text = objCliente.Apellido_1;
                        txtSegundoApellido.Text = objCliente.Apellido_2;
                        lstDireccion.Items.Add(objCliente.Ubicacion.Direccion);
                        txtBarrio.Text = objCliente.Ubicacion.Barrio;
                        txtCiudad.Text = objCliente.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = objCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = objCliente.Ubicacion.Telefono_1;
                    }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
            }
        }

        protected void lstDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstDireccion.Focus();
        }

        protected void gvPedido_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            objdtTabla.Rows.RemoveAt(e.RowIndex);
            gvPedido.DataSource = objdtTabla;
            gvPedido.DataBind();
            btnGuardar.Focus();
        }
    }
}