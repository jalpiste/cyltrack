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
            else 
            {
                SetFocus(btnGuardar);
            }
            
            if(!IsPostBack)
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
                VentaBE venta = new VentaBE();

                try 
                {
                    List<VentaBE> lstVenta = new List<VentaBE>(serVenta.ConsultarVenta(venta)); 
                    foreach(VentaBE datosCodigos in lstVenta)
                    {
                        lstCilEntrega.Items.Add(datosCodigos.Detalle_Venta.Cod_Cil_Actual);
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

        VentaBE codaCorregir;
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void txtCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            //SetFocus(lstCaso);
            VentaServiceClient serVenta = new VentaServiceClient();
            VentaBE venta = new VentaBE();

            try
            {
                ClienteBE cli = new ClienteBE();
                cli.Cedula = txtCedulaCliente.Text;
                venta.Cliente = cli;
                List<VentaBE> datosVenta = new List<VentaBE>(serVenta.ConsultarVenta(venta));
                DataTable table = new DataTable();
                table.Columns.Add("CodigosCil");
                table.Columns.Add("Tamano");
                table.Columns.Add("TipoCil");

                foreach (VentaBE info in datosVenta)
                {
                    txtFecha.Text = Convert.ToString(info.Fecha);
                    txtHora.Text = Convert.ToString(info.Fecha);
                    txtNumCedula.Text = info.Cliente.Cedula;
                    txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = info.Cliente.Apellido_1;
                    txtSegundoApellido.Text = info.Cliente.Apellido_2;
                    txtDireccion.Text = info.Cliente.Ubicacion.Direccion;
                    txtBarrio.Text = info.Cliente.Ubicacion.Barrio;
                    txtCiudad.Text = info.Cliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = info.Cliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    txtTelefono.Text = info.Cliente.Ubicacion.Telefono_1;
                    txtObservacion.Text = info.Observaciones;

                    table.Rows.Add(info.Detalle_Venta.Cod_Cil_Actual, info.Detalle_Venta.Tamano, info.Detalle_Venta.Tipo_Cilindro);
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
                venta.Detalle_Venta= detVenta;
                ClienteBE cli = new ClienteBE();
                cli.Cedula = txtCedulaCliente.Text;
                venta.Cliente = cli;
                Tipo_CasoBE tip = new Tipo_CasoBE();
                casos.Tipo_Caso = tip;
                casos.Tipo_Caso.Nombre_Caso = lstCaso.SelectedValue;
                casos.Observaciones = txtObserva.Text;

                if (lstCaso.SelectedIndex == 1) 
                {
                   venta.Detalle_Venta.Cod_Cil_Nuevo= lstCilEntrega.SelectedValue;
                }
                if (lstCaso.SelectedIndex == 3)
                {
                    venta.Detalle_Venta.Cod_Cil_Nuevo = txtCodigoVerific.Text;
                }

                casos.Venta = venta;
                //venta.Detalle_Venta.Cod_Cil_Actual = codaCorregir.Cilindro.Codigo_Cilindro;
                resp = serVenta.CasosEspeciales(casos);

                MessageBox.Show("El caso especial fue registrado con satisfacción","Casos Especiales");

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
                
            }
            if (lstCaso.SelectedIndex == 3) 
            {
                divCodCorrecto.Visible = true;
               
            }
        }

        String resp;
       protected void Agregar_onClick(object sender, EventArgs e)
        {
            SetFocus(btnGuardar);
            VentaServiceClient serVenta = new VentaServiceClient();
            CasosBE casos = new CasosBE();
            DataTable tabla = new DataTable();
            
            try
            {
                VentaBE venta = new VentaBE();
                string codigo = ((System.Web.UI.WebControls.RadioButton)sender).Attributes["value"].ToString();
                Detalle_VentaBE detVenta = new Detalle_VentaBE();
                detVenta.Cod_Cil_Actual = codigo;
                venta.Detalle_Venta = detVenta;
                casos.Venta = venta;
                resp = serVenta.CasosEspeciales(casos);
                codaCorregir=venta;
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