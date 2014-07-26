using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VentaService;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.VehiculoService;
using CYLTRACK_WebApp.ReporteService;
using System.Data;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmCasosEspeciales : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCedulaCliente.Focus();
            }          

            if (!IsPostBack)
            {
                ReporteServiceClient servReporte = new ReporteServiceClient();
                try
                {
                    List<Tipo_CasoBE> lstTipCasos = new List<Tipo_CasoBE>(servReporte.ConsultaTiposCasos());

                    lstCaso.DataSource = servReporte.ConsultaTiposCasos();
                    lstCaso.DataValueField = "Id_Tipo_Caso";
                    lstCaso.DataTextField = "Nombre_Caso";
                    lstCaso.DataBind();   
                                 
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

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            VentaServiceClient serVenta = new VentaServiceClient();
            ClienteServiceClient serCliente = new ClienteServiceClient();

            try
            {
                DataTable table = new DataTable();
                long consultarExistencia = serVenta.ConsultarExistenciaVenta(txtCedulaCliente.Text);

                if (consultarExistencia == 0)
                {
                    MessageBox.Show("El cliente no tiene asignado ninguna venta reciente", "Consultar Venta");
                }
                else
                {
                    VentaBE datosVenta = serVenta.ConsultarVenta(txtCedulaCliente.Text);

                    txtFecha.Text = Convert.ToString(datosVenta.Fecha);
                    txtHora.Text = Convert.ToString(datosVenta.Fecha.TimeOfDay);
                    
                    ClienteBE cliente = serCliente.Consultar_Cliente(txtCedulaCliente.Text);

                    txtCedula2.Text = cliente.Cedula;
                    lblIdCliente.Text = cliente.Id_Cliente;
                    txtNombreCliente.Text = cliente.Nombres_Cliente + " " + cliente.Apellido_1 + " " + cliente.Apellido_2;

                    table.Columns.Add("IdUbicacion");
                    table.Columns.Add("Direccion");
                    table.Columns.Add("Barrio");
                    table.Columns.Add("Telefono");
                    table.Columns.Add("Ciudad");

                    foreach (UbicacionBE datos in cliente.ListaDirecciones)
                    {
                        table.Rows.Add(datos.Id_Ubicacion, datos.Direccion, datos.Barrio, datos.Telefono_1, datos.Ciudad.Nombre_Ciudad);
                    }
                    gvDirecciones.DataSource = table;
                    gvDirecciones.DataBind();
                    divDirCliente.Visible = true;
                    DivInfoVenta.Visible = true;                    
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                serVenta.Close();
                txtCedulaCliente.Text = "";
                txtCodVenta.Text = "";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            VentaServiceClient serVenta = new VentaServiceClient();
            CasosBE casos = new CasosBE();
            long resp;
            try
            {
                //casos.Id_Cliente = lblIdCliente.Text;
                //casos.
                //casos.Tipo_Caso.Nombre_Caso = lstCaso.SelectedValue;
                //casos.Observaciones = txtObserva.Text;

                //if (lstCaso.SelectedIndex == 1)
                //{
                //    venta.Lista_Detalle_Venta.Cod_Cil_Nuevo = lstCilEntrega.SelectedValue;
                //    venta.Lista_Detalle_Venta.Cod_Cil_Actual = lblMsn.Text;
                //}
                //if (lstCaso.SelectedIndex == 3)
                //{
                //    venta.Lista_Detalle_Venta.Cod_Cil_Nuevo = txtCodigoVerific.Text;
                //    venta.Lista_Detalle_Venta.Cod_Cil_Actual = lblMsn.Text;
                //}
                ////falta adicionar al cargue del vehiculo el cilindro que devuelve en terminacion del contrato

                //casos.Id_Detalle_Venta = venta;

                //resp = serVenta.CasosEspeciales(casos);

                //MessageBox.Show("El caso especial fue registrado con satisfacción", "Casos Especiales");

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                serVenta.Close();
                Response.Redirect("~/Ventas/frmCasosEspeciales.aspx");
            }

        }

        protected void lstCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            DataTable table = new DataTable();

            try
            {
                if (lstCaso.SelectedItem.Text == Tipo_Casos.ESCAPE.ToString())
                {
                    divEscape.Visible = true;
                    SetFocus(lstCilEntrega);
                    List<Ubicacion_CilindroBE> lstCilVehiculos = new List<Ubicacion_CilindroBE>(servVehiculo.ConsultarCilPorVehiculo("1"));

                    foreach (Ubicacion_CilindroBE datos in lstCilVehiculos)
                    {
                        lstCilEntrega.Items.Add(datos.Cilindro.Codigo_Cilindro);
                    }
                }
                else
                {
                    divEscape.Visible = false;
                }

                if (lstCaso.SelectedItem.Text == Tipo_Casos.CODIGO.ToString() + " " + Tipo_Casos.ERRADO.ToString())
                {
                    divCodCorrecto.Visible = true;
                    SetFocus(txtCodigoVerific);
                }
                else 
                {
                    divCodCorrecto.Visible = false;
                }    
             }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }
                finally
                {
                    servVehiculo.Close();
                    divGrid.Visible = true;
                    btnGuardar.Visible = true;
                }
       }

        protected void Seleccion_onClick(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            DataTable table = new DataTable();
            
            try
            {
                string idUbica = ((System.Web.UI.WebControls.RadioButton)sender).Attributes["value"].ToString();
                lblIdUbica.Text = idUbica;
                ((System.Web.UI.WebControls.RadioButton)sender).Checked = false;
                List<Ubicacion_CilindroBE> lstCilCliente = new List<Ubicacion_CilindroBE>(servCliente.ConsultarCilPorCliente(lblIdUbica.Text));
                table.Columns.Add("CodigosCil");
                table.Columns.Add("Tamano");
                table.Columns.Add("TipoCil");

                foreach (Ubicacion_CilindroBE info in lstCilCliente)
                {
                    table.Rows.Add(info.Cilindro.Codigo_Cilindro, info.Cilindro.NTamano.Tamano, info.Cilindro.Tipo_Cilindro);
                }

                gvCargue.DataSource = table;
                gvCargue.DataBind();   
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                btnGuardar.Focus();
                divVerifInfo.Visible = true;
            }
        }

    }
}