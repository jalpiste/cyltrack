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
    public partial class frmVentaCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCedula.Focus();
            }
            else
            {
                gvCargue.Focus();
            }
        }

        List<VentaBE> lstCodigos = new List<VentaBE>();
        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ConsultaDatosCliente();

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                divInfoCliente.Visible = true;
                btnGuardar.Visible = true;
            }

        }

        protected void TxtNumPedido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ConsultaDatosCliente();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                divInfoCliente.Visible = true;
                btnGuardar.Visible = true;
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            VentaServiceClient serVenta = new VentaServiceClient();
            VentaBE ventas = new VentaBE();

            try
            {
                ClienteBE cli = new ClienteBE();
                cli.Cedula = txtCedula.Text;
                ventas.Cliente = cli;
                PedidoBE ped = new PedidoBE();
                ped.Id_Pedido= TxtNumPedido.Text;
                ventas.Pedido = ped;
                UbicacionBE ubi = new UbicacionBE();
                ubi.Direccion = lstDireccion.SelectedValue;
                ventas.Ubicacion = ubi;
                foreach (VentaBE datos in lstCodigos)
                {
                    ventas.Cilindro.Codigo_Cilindro = datos.Cilindro.Codigo_Cilindro;
                }
                ventas.Observaciones = txtObservacion.Text;

                String regVenta = serVenta.VentaCilindro(ventas);
                //Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
                MessageBox.Show("La venta ha sido registrada satisfactoriamente","Venta de Cilindro");

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                serVenta.Close();
                Response.Redirect("~/Ventas/frmVentaCilindro.aspx");
            }


        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        public void ConsultaDatosCliente()
        {
            VentaServiceClient serVenta = new VentaServiceClient();
            VentaBE ventas = new VentaBE();
            DataTable table = new DataTable();

            try
            {
                ClienteBE cli = new ClienteBE();
                cli.Cedula = txtCedula.Text;
                ventas.Cliente = cli;
                List<VentaBE> datosVenta = new List<VentaBE>(serVenta.ConsultarVenta(ventas));

                table.Columns.Add("CodigosCil");
                table.Columns.Add("Tamano");
                table.Columns.Add("TipoCil");

                foreach (VentaBE info in datosVenta)
                {
                    txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = info.Cliente.Apellido_1;
                    txtSegundoApellido.Text = info.Cliente.Apellido_2;
                    lstDireccion.Items.Add(info.Ubicacion.Direccion);
                    txtBarrio.Text = info.Ubicacion.Barrio;
                    txtTelefono.Text = info.Ubicacion.Telefono_1;
                    txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = info.Ciudad.Departamento.Nombre_Departamento;
                    txtCilindro.Text = info.Cilindro.Codigo_Cilindro;
                    txtTamano.Text = info.Cilindro.NTamano.Tamano;
                    //cantidad
                    txtTipoCil.Text = info.Cilindro.Tipo_Cilindro;
                    table.Rows.Add(info.Cilindro.Codigo_Cilindro, info.Cilindro.NTamano.Tamano, info.Cilindro.Tipo_Cilindro);
                    gvCargue.DataSource = table;
                    gvCargue.DataBind();
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

        protected void Agregar_onClick(object sender, EventArgs e)
        {

            CilindroBE cil = new CilindroBE();
            DataTable tabla = new DataTable();

            try
            {
                string registro = ((System.Web.UI.WebControls.Button)sender).Attributes["value"].ToString();
                cil.Codigo_Cilindro = registro;
                foreach (VentaBE detalle in lstCodigos)
                {
                    if (detalle.Cilindro.Codigo_Cilindro == cil.Codigo_Cilindro)
                    {
                        cil.Codigo_Cilindro += detalle.Cilindro.Codigo_Cilindro;
                        lstCodigos.Remove(detalle);
                    }

                }
                VentaBE venta = new VentaBE();
                venta.Cilindro = cil;
                lstCodigos.Add(venta);

                tabla.Columns.Add("CodigosAdd");

                foreach (VentaBE info in lstCodigos)
                {
                    tabla.Rows.Add(info.Cilindro.Codigo_Cilindro);
                }

                gdAdd.DataSource = tabla;
                gdAdd.DataBind();

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                gdAdd.Visible = true;
            }

        }

    }
}