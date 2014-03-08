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
    public partial class frmModificarPedido : System.Web.UI.Page
    {
        List<Detalle_PedidoBE> lstDetail = new List<Detalle_PedidoBE>();
        DataTable objdtLista;
        
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
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ReporteServiceClient servReporte = new ReporteServiceClient();
            PedidoBE consultar_ped = new PedidoBE();
            long resp;

            try
            {
                resp = servReporte.consultadeExistenciaVarios(txtCedula.Text);
                
                if (resp == 0)
                {
                    MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Modificar Pedido");
                }
                else
                    {                       
                        consultar_ped = servPedido.Consultar_Pedido(txtCedula.Text);
                        DataTable tabla = new DataTable();

                        tabla.Columns.Add("CantidadPedido");
                        tabla.Columns.Add("TamanoCil");

                        txtCedulaCliente.Text = consultar_ped.Cliente.Cedula;
                        txtNombreCliente.Text = consultar_ped.Cliente.Nombres_Cliente;
                        txtPrimerApellido.Text = consultar_ped.Cliente.Apellido_1;
                        txtSegundoApellido.Text = consultar_ped.Cliente.Apellido_2;
                        lstDireccion.Items.Add(consultar_ped.Ubicacion.Direccion);
                        txtBarrio.Text = consultar_ped.Ubicacion.Barrio;
                        txtCiudad.Text = consultar_ped.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = consultar_ped.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = consultar_ped.Ubicacion.Telefono_1;
                        lblFechaPedido.Text = Convert.ToString(consultar_ped.Fecha);
                        lblCodigoPedido.Text = consultar_ped.Id_Pedido;
                        lstPlaca.Items.Add(consultar_ped.Vehiculo.Placa);
                        lblRutaAsignada.Text = consultar_ped.Ruta.Nombre_Ruta;
                        foreach(CilindroBE datos in consultar_ped.Cilindro)
                        {
                            objdtTabla.Rows.Add(datos.NTamano.Tamano, datos.Cantidad);
                            gvPedido.DataSource = objdtTabla;
                            gvPedido.DataBind();
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
               servPedido.Close();
            }
        }

        protected void TxtNumPedido_TextChanged(object sender, EventArgs e)
        {
            txtCedulaCliente.Focus();
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ReporteServiceClient servReporte = new ReporteServiceClient();
            PedidoBE consultar_ped = new PedidoBE();
            long resp;

            try
            {
                resp = servReporte.consultadeExistencia(TxtNumPedido.Text);

                if (resp == 0)
                {
                    MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Modificar Pedido");
                }
                else
                {
                    consultar_ped = servPedido.Consultar_Pedido(TxtNumPedido.Text);
                    DataTable tabla = new DataTable();

                    tabla.Columns.Add("CantidadPedido");
                    tabla.Columns.Add("TamanoCil");

                    txtCedulaCliente.Text = consultar_ped.Cliente.Cedula;
                    txtNombreCliente.Text = consultar_ped.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = consultar_ped.Cliente.Apellido_1;
                    txtSegundoApellido.Text = consultar_ped.Cliente.Apellido_2;
                    lstDireccion.Items.Add(consultar_ped.Ubicacion.Direccion);
                    txtBarrio.Text = consultar_ped.Ubicacion.Barrio;
                    txtCiudad.Text = consultar_ped.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = consultar_ped.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = consultar_ped.Ubicacion.Telefono_1;
                    lblFechaPedido.Text = Convert.ToString(consultar_ped.Fecha);
                    lblCodigoPedido.Text = consultar_ped.Id_Pedido;
                    lstPlaca.Items.Add(consultar_ped.Vehiculo.Placa);
                    lblRutaAsignada.Text = consultar_ped.Ruta.Nombre_Ruta;
                    foreach (CilindroBE datos in consultar_ped.Cilindro)
                    {
                        objdtTabla.Rows.Add(datos.NTamano.Tamano, datos.Cantidad);
                        gvPedido.DataSource = objdtTabla;
                        gvPedido.DataBind();
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
              servPedido.Close();
              servReporte.Close();
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
                idcliente.Cedula = txtCedulaCliente.Text;
                modificar_ped.Cliente = idcliente;

                UbicacionBE ubicli = new UbicacionBE();
                ubicli.Direccion = lstDireccion.SelectedValue;
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

                
                modificar_ped.Detalle_Ped = lstDetail;
             
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

                foreach (DataRow info in objdtTabla.Rows)
                {
                    if (tamanocil.Tamano == (Convert.ToString(info["TamanoCil"])))
                    {
                        detail.Cantidad += (Convert.ToString(info["CantidadPedido"]));
                    }
                    lstDetail.Add(detail);
                }


                foreach (Detalle_PedidoBE info in lstDetail)
                {
                    objdtTabla.Rows.Add(info.Tamano.Tamano, info.Cantidad);
                    gvPedido.DataSource = objdtTabla;
                    gvPedido.DataBind();
                }
                //foreach (Detalle_PedidoBE info in lstDetail)
                //{
                //    if (info.Tamano.Tamano == objdtTabla.Rows.ToString())
                //    {
                //        detail.Cantidad += info.Tamano.Tamano;
                //        lstDetail.Remove(info);
                //    }
                //    objdtTabla.Rows.Add(info.Tamano.Tamano, info.Cantidad);

                //    gvPedido.DataSource = objdtTabla;
                //    gvPedido.DataBind();
                //}
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
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ReporteServiceClient servReporte = new ReporteServiceClient();
            PedidoBE consultar_ped = new PedidoBE();
            long resp;

            try
            {
                resp = servReporte.consultadeExistencia(txtCedulaCliente.Text);

                if (resp == 0)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Modificar Pedido");
                }
                
                else
                {
                    consultar_ped = servPedido.Consultar_Pedido(txtCedulaCliente.Text);

                    DataTable tabla = new DataTable();

                    tabla.Columns.Add("CantidadPedido");
                    tabla.Columns.Add("TamanoCil");

                    txtCedulaCliente.Text = consultar_ped.Cliente.Cedula;
                    txtNombreCliente.Text = consultar_ped.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = consultar_ped.Cliente.Apellido_1;
                    txtSegundoApellido.Text = consultar_ped.Cliente.Apellido_2;
                    lstDireccion.Items.Add(consultar_ped.Ubicacion.Direccion);
                    txtBarrio.Text = consultar_ped.Ubicacion.Barrio;
                    txtCiudad.Text = consultar_ped.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = consultar_ped.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = consultar_ped.Ubicacion.Telefono_1;
                    lblFechaPedido.Text = Convert.ToString(consultar_ped.Fecha);
                    lblCodigoPedido.Text = consultar_ped.Id_Pedido;
                    lstPlaca.Items.Add(consultar_ped.Vehiculo.Placa);
                    lblRutaAsignada.Text = consultar_ped.Ruta.Nombre_Ruta;
                    foreach (CilindroBE datos in consultar_ped.Cilindro)
                    {
                        objdtTabla.Rows.Add(datos.NTamano.Tamano, datos.Cantidad);
                        gvPedido.DataSource = objdtTabla;
                        gvPedido.DataBind();
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
                servPedido.Close();
                servReporte.Close();
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