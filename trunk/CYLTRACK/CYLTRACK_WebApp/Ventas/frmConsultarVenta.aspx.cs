using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VentaService;
using CYLTRACK_WebApp.ClienteService;
using System.Data;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmConsultarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCedulaCliente.Focus();
            }
            else
            {
                DivInfoVenta.Focus();
            }
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");

        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ventas/frmConsultarVenta.aspx");
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
                    txtObservacion.Text = datosVenta.Observaciones;

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
                    divInfoCilindro.Visible = true;
                    DivInfoVenta.Visible = true;
                    btnNuevaConsulta.Visible = true;
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

        protected void Seleccion_onClick(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            DataTable table = new DataTable();
            VentaBE venta = new VentaBE();
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
                btnNuevaConsulta.Focus();
                servCliente.Close();
            }
        }
    }
}