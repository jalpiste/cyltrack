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
                ReporteServiceClient servReporte = new ReporteServiceClient();
                try
                {
                    lstTamano.DataSource = servReporte.ConsultaTamanoCilindro();
                    lstTamano.DataTextField = "Tamano";
                    lstTamano.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }
                finally
                {
                    servReporte.Close();
                }
            }
        }
        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            VehiculoServiceClient servVeh = new VehiculoServiceClient();
            
            long resp;
            try
            {
                resp = servCliente.ConsultarExistenciasClientes(txtCedula.Text);
                
               if (resp == 0)
               {
                   MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Registrar Pedido");
                   divInfoCliente.Visible = false;
                   txtCedula.Text = "";
                   txtCedula.Focus();
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

                   lstPlaca.DataSource = servVeh.ConsultarVehiculo(string.Empty);
                   lstPlaca.DataValueField = "Id_Vehiculo";
                   lstPlaca.DataTextField = "Placa";
                   lstPlaca.DataBind(); 
                   
               }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
                servVeh.Close();                
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
            long resp;
            txtCedula.Text = "";            

            try
            {
                ClienteBE idcliente = new ClienteBE();
                idcliente.Cedula = txtCedulaCli.Text;
                UbicacionBE ubicli = new UbicacionBE();
                ubicli.Direccion = lstDireccion.SelectedValue;
                idcliente.Ubicacion = ubicli;
                registrar_ped.Cliente = idcliente;

                
                VehiculoBE veh = new VehiculoBE();
                veh.Id_Vehiculo = lstPlaca.SelectedValue;
                registrar_ped.Vehiculo = veh;

                RutaBE ruta = new RutaBE();
                ruta.Nombre_Ruta = lblRutaAsignada.Text;
                registrar_ped.Ruta = ruta;

                PedidoBE pedido = new PedidoBE();
                pedido.Detalle = txtObservaciones.Text;
                
                Detalle_PedidoBE det = new Detalle_PedidoBE();
                TamanoBE tamanito = new TamanoBE();
                det.Tamano = tamanito;
                foreach (DataRow row in objdtTabla.Rows)
                {
                    det.Tamano.Tamano += Convert.ToString(row["TamanoCil"])+",";
                    det.Cantidad += Convert.ToString(row["CantidadPedido"])+",";                        
                }

                int varCant = det.Cantidad.Length;
                det.Cantidad = det.Cantidad.Substring(0, varCant - 1);

                int varTam = det.Tamano.Tamano.Length;
                det.Tamano.Tamano = det.Tamano.Tamano.Substring(0, varTam - 1);
                registrar_ped.Detalle_Ped = det;

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

        protected void lstPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            try 
            {
                Ruta_VehiculoBE rutaVehiculo = new Ruta_VehiculoBE() ;
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = txtCiudad.Text;
                rutaVehiculo.Ciudad = ciu;
                                
                VehiculoBE veh = new VehiculoBE();
                veh.Id_Vehiculo = lstPlaca.SelectedValue;
                rutaVehiculo.Vehiculo = veh;

                RutaBE objRuta_Vehiculo = servRuta.ConsultarRutaPorPlaca(rutaVehiculo);
                lblRutaAsignada.Text = objRuta_Vehiculo.Nombre_Ruta;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servRuta.Close();
                btnGuardar.Focus();
            }


        }

        
    }
}