using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.PedidoService;
using CYLTRACK_WebApp.VehiculoService;
using CYLTRACK_WebApp.RutaService;
using CYLTRACK_WebApp.ReporteService;
using System.Windows.Forms;
using System.Data;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido
{
    public partial class frmRegistroPedido : System.Web.UI.Page
    {
        List<Detalle_PedidoBE> lstDetail = new List<Detalle_PedidoBE>();
        DataTable objdtLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();

            if (!Page.IsPostBack)
            {
                PedidoServiceClient servPed = new PedidoServiceClient();

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

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            ReporteServiceClient servReporte = new ReporteServiceClient();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            VehiculoServiceClient serVeh = new VehiculoServiceClient();
            RutaServicesClient serRuta = new RutaServicesClient();
            PedidoServiceClient servPedido = new PedidoServiceClient();
            
            long resp;
            try
            {
               resp = servReporte.consultadeExistencia(txtCedula.Text);
                
               if (resp == 0)
               {
                   MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Registrar Pedido");
               }

               else
               {
                   ClienteBE objCliente = servCliente.Consultar_Cliente(txtCedula.Text);
                   
                   txtCedulaCli.Text = objCliente.Cedula;
                   txtNombreCliente.Text = objCliente.Nombres_Cliente;
                   txtPrimerApellido.Text = objCliente.Apellido_1;
                   txtSegundoApellido.Text = objCliente.Apellido_2;
                   lstDireccion.Items.Add(objCliente.Ubicacion.Direccion);
                   txtBarrio.Text = objCliente.Ubicacion.Barrio;
                   txtCiudad.Text = objCliente.Ubicacion.Ciudad.Nombre_Ciudad;
                   txtDepartamento.Text = objCliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                   txtTelefono.Text = objCliente.Ubicacion.Telefono_1;

                   divInfoCliente.Visible = true;
                   btnGuardar.Visible = true;
                   lstDireccion.Focus();

                   List<VehiculoBE> listaPlacas = new List<VehiculoBE>(serVeh.ConsultarVehiculo(string.Empty));
                   foreach (VehiculoBE datosVehiculo in listaPlacas)
                   {
                       lstPlaca.Items.Add(datosVehiculo.Placa);
                   }
                   
                   RutaBE ruta = new RutaBE();
                  // ruta = serRuta.ConsultarRuta(objCliente.Ubicacion.Ciudad.Nombre_Ciudad);
                   // se tiene que consultar la ruta que tiene cada placa seleccionada...
                   //PedidoBE ped = servPedido.Consultar_Pedido(txtCedula.Text);
                   //lblNumeroPedido.Text = ped.Id_Pedido;
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
                serVeh.Close();
                servReporte.Close();
                serRuta.Close();
                lblCodigoPedido.Visible = true;
                lblNumeroPedido.Visible = true;
                
            }                       
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //txtNombreCliente.Text = " ";
            //txtPrimerApellido.Text = " ";
            //txtSegundoApellido.Text = " ";
            //txtBarrio.Text = " ";
            //txtCiudad.Text = " ";
            //txtDepartamento.Text = " ";
            //txtTelefono.Text = " ";
            //txtCantidadCilindro.Text = " ";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE registrar_ped = new PedidoBE();
            String resp;
            txtCedula.Text = "";
            

            try
            {
                ClienteBE idcliente = new ClienteBE();
                idcliente.Cedula = txtCedulaCli.Text;
                registrar_ped.Cliente = idcliente;

                UbicacionBE ubicli = new UbicacionBE();
                ubicli.Direccion = lstDireccion.SelectedValue;
                registrar_ped.Ubicacion = ubicli;

                VehiculoBE veh = new VehiculoBE();
                veh.Placa = lstPlaca.SelectedValue;
                registrar_ped.Vehiculo = veh;

                RutaBE ruta = new RutaBE();
                ruta.Nombre_Ruta = lblRutaAsignada.Text;
                registrar_ped.Ruta = ruta;

                PedidoBE pedido = new PedidoBE();
                pedido.Detalle = txtObservaciones.Text;

                foreach (DataRow row in objdtTabla.Rows)
                {
                    Detalle_PedidoBE det = new Detalle_PedidoBE();
                    TamanoBE tamanito = new TamanoBE();
                    det.Tamano = tamanito;
                    det.Tamano.Tamano = (Convert.ToString(row["TamanoCil"]));
                    det.Cantidad = (Convert.ToString(row["CantidadPedido"]));
                    lstDetail.Add(det);
                }
                                
                registrar_ped.Detalle_Ped = lstDetail;

                resp = servPedido.Registrar_Pedido(registrar_ped);

               MessageBox.Show("El pedido fue registrado satisfactoriamente", "Registrar Pedido");
                  
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servPedido.Close();
                Response.Redirect("~/Pedido/frmRegistroPedido.aspx");
            }

        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

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
                        info.RowState.ToString().Remove(0,1);
                        //lstDetail.Add(detail);
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
                txtCantidadCilindro.Text = "";
                btnGuardar.Focus();
            }

        }
        protected void lstDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPlaca.Focus();
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