using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VentaService;
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
                List<string> tiposCasos = Auxiliar.ConsultarTipoCaso();
                foreach (string datosCasos in tiposCasos)
                {
                    lstCaso.Items.Add(datosCasos);
                }
            }

            if (!IsPostBack)
            {
                VentaServiceClient serVenta = new VentaServiceClient();
                try
                {
                    List<CilindroBE> cargueVehiculo = new List<CilindroBE>(serVenta.ConsultarCarguePlaca());
                    foreach(CilindroBE datos in cargueVehiculo)
                    {
                        lstCilEntrega.Items.Add(datos.Codigo_Cilindro);
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }
                finally
                {
                    serVenta.Close();
                }
            }

        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            SetFocus(lstCaso);
            VentaServiceClient serVenta = new VentaServiceClient();
            VentaBE venta = new VentaBE();

            try
            {
                string consultaCedula = serVenta.ConsultarExistencia(txtCedulaCliente.Text);

                if (consultaCedula != "Ok")
                {
                    MessageBox.Show("El cliente digitado no tiene ventas asignadas", "Casos Especiales");
                }
                else
                {
                    VentaBE consultarVenta = serVenta.ConsultarVenta(txtCedulaCliente.Text);

                    txtFecha.Text = Convert.ToString(consultarVenta.Fecha);
                    txtHora.Text = Convert.ToString(consultarVenta.Fecha);
                    txtNumCedula.Text = consultarVenta.Cliente.Cedula;
                    txtNombreCliente.Text = consultarVenta.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = consultarVenta.Cliente.Apellido_1;
                    txtSegundoApellido.Text = consultarVenta.Cliente.Apellido_2;
                    foreach (string datos in consultarVenta.Cliente.Ubicacion.Direccion)
                    {
                        txtDireccion.Text = datos;
                    } 
                    txtBarrio.Text = consultarVenta.Cliente.Ubicacion.Barrio;
                    txtCiudad.Text = consultarVenta.Cliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = consultarVenta.Cliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = consultarVenta.Cliente.Ubicacion.Telefono_1;
                    txtObservacion.Text = consultarVenta.Observaciones;

                    DataTable table = new DataTable();
                    table.Columns.Add("CodigosCil");
                    table.Columns.Add("Tamano");
                    table.Columns.Add("TipoCil");

                    table.Rows.Add(consultarVenta.Detalle_Venta.Cod_Cil_Actual, consultarVenta.Detalle_Venta.Tamano, consultarVenta.Detalle_Venta.Tipo_Cilindro);
                    gvCargue.DataSource = table;
                    gvCargue.DataBind();

                    DivInfoVenta.Visible = true;
                    divVerifInfo.Visible = true;
                    btnGuardar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                serVenta.Close();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            VentaServiceClient serVenta = new VentaServiceClient();
            CasosBE casos = new CasosBE();
            string resp;
            try
            {
                VentaBE venta = new VentaBE();
                Detalle_VentaBE detVenta = new Detalle_VentaBE();
                venta.Detalle_Venta = detVenta;
                ClienteBE cli = new ClienteBE();
                cli.Cedula = txtCedulaCliente.Text;
                venta.Cliente = cli;
                Tipo_CasoBE tip = new Tipo_CasoBE();
                casos.Tipo_Caso = tip;
                casos.Tipo_Caso.Nombre_Caso = lstCaso.SelectedValue;
                casos.Observaciones = txtObserva.Text;

                if (lstCaso.SelectedIndex == 1)
                {
                    venta.Detalle_Venta.Cod_Cil_Nuevo = lstCilEntrega.SelectedValue;
                    venta.Detalle_Venta.Cod_Cil_Actual = lblMsn.Text;
                }
                if (lstCaso.SelectedIndex == 3)
                {
                    venta.Detalle_Venta.Cod_Cil_Nuevo = txtCodigoVerific.Text;
                    venta.Detalle_Venta.Cod_Cil_Actual = lblMsn.Text;
                }
                //falta adicionar al cargue del vehiculo el cilindro que devuelve en terminacion del contrato
                
                casos.Venta = venta;
              
                resp = serVenta.CasosEspeciales(casos);

                MessageBox.Show("El caso especial fue registrado con satisfacción", "Casos Especiales");

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

            divGrid.Visible = true;

            if (lstCaso.SelectedIndex == 1)
            {
                divEscape.Visible = true;
                SetFocus(lstCilEntrega);
            }
            if (lstCaso.SelectedIndex == 3)
            {
                divCodCorrecto.Visible = true;
                SetFocus(txtCodigoVerific);
            }
        }

        
        protected void Agregar_onClick(object sender, EventArgs e)
        {
            SetFocus(btnGuardar);
            
            DataTable tabla = new DataTable();

            try
            {
                string codigo = ((System.Web.UI.WebControls.RadioButton)sender).Attributes["value"].ToString();
                lblMsn.Text = "Se seleccionó el cilindro : " + codigo;
                ((System.Web.UI.WebControls.RadioButton)sender).Checked = false;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                lblMsn.Visible = true;                
            }
        } 
    }
}