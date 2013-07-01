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

        
        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            VentaServiceClient serVentas = new VentaServiceClient();
            VentaBE ventas = new VentaBE();
            DataTable tabla = new DataTable();

            try
            {
                ConsultaDatosCliente();
                List<VentaBE> lstCargue = new List<VentaBE>(serVentas.ConsultarVenta(ventas));

                tabla.Columns.Add("CodigosCil");
                tabla.Columns.Add("Tamano");
                tabla.Columns.Add("TipoCil");

                foreach(VentaBE datos in lstCargue)
                {
                    tabla.Rows.Add(datos.Detalle_Venta.Cod_Cil_Actual, datos.Detalle_Venta.Tamano, datos.Detalle_Venta.Tipo_Cilindro );
                    gvCargue.DataSource = tabla;
                    gvCargue.DataBind();                
                }
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
            VentaServiceClient serVentas = new VentaServiceClient();
            VentaBE ventas = new VentaBE();
            DataTable tabla = new DataTable();

            try
            {
                ConsultaDatosCliente();
                List<VentaBE> lstCargue = new List<VentaBE>(serVentas.ConsultarVenta(ventas));

                tabla.Columns.Add("CodigosCil");
                tabla.Columns.Add("Tamano");
                tabla.Columns.Add("TipoCil");

                foreach (VentaBE datos in lstCargue)
                {
                    tabla.Rows.Add(datos.Detalle_Venta.Cod_Cil_Actual, datos.Detalle_Venta.Tamano, datos.Detalle_Venta.Tipo_Cilindro);
                    gvCargue.DataSource = tabla;
                    gvCargue.DataBind();
                }
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
        List<VentaBE> lstCodigos = new List<VentaBE>();
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            VentaServiceClient serVenta = new VentaServiceClient();
            VentaBE ventas = new VentaBE();            

            try
            {
                Detalle_VentaBE detVenta = new Detalle_VentaBE();
                ventas.Detalle_Venta = detVenta;
                ClienteBE cli = new ClienteBE();
                cli.Cedula = txtCedula.Text;
                ventas.Cliente = cli;
                PedidoBE ped = new PedidoBE();
                ped.Id_Pedido= TxtNumPedido.Text;
                cli.Pedido = ped;
                UbicacionBE ubi = new UbicacionBE();
                ubi.Direccion = lstDireccion.SelectedValue;
                cli.Ubicacion = ubi;
                foreach (VentaBE datos in lstCodigos)
                {
                    detVenta.Cod_Cil_Nuevo = datos.Detalle_Venta.Cod_Cil_Nuevo;
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
            ClienteServiceClient serCliente = new ClienteServiceClient();
            DataTable table = new DataTable();

            try
            {
                ClienteBE cliente = new ClienteBE();
                cliente.Cedula = txtCedula.Text;
                List<ClienteBE> datosCliente = new List<ClienteBE>(serCliente.Consultar_Cliente(cliente));

                table.Columns.Add("CodigosCil");
                table.Columns.Add("Tamano");
                table.Columns.Add("TipoCil");

                foreach (ClienteBE info in datosCliente)
                {
                    txtCedulaCliente.Text = info.Cedula;
                    txtNombreCliente.Text = info.Nombres_Cliente;
                    txtPrimerApellido.Text = info.Apellido_1;
                    txtSegundoApellido.Text = info.Apellido_2;
                    lstDireccion.Items.Add(info.Ubicacion.Direccion);
                    txtBarrio.Text = info.Ubicacion.Barrio;
                    txtTelefono.Text = info.Ubicacion.Telefono_1;
                    txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = info.Ciudad.Departamento.Nombre_Departamento;
                    table.Rows.Add(info.Cilindro.Codigo_Cilindro, info.Cilindro.NTamano.Tamano, info.Cilindro.Tipo_Cilindro);
                    gdCilindrosCli.DataSource = table;
                    gdCilindrosCli.DataBind();
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                serCliente.Close();
            }
        }

        protected void Agregar_onClick(object sender, EventArgs e)
        {
            SetFocus(btnGuardar);
            VentaBE venta = new VentaBE();
            Detalle_VentaBE detventa = new Detalle_VentaBE();
            DataTable tabla = new DataTable();

            try
            {
                string registro = ((System.Web.UI.WebControls.Button)sender).Attributes["value"].ToString();
                detventa.Cod_Cil_Nuevo = registro;
                foreach (VentaBE detalle in lstCodigos)
                {
                    if (detalle.Detalle_Venta.Cod_Cil_Nuevo == detventa.Cod_Cil_Nuevo)
                    {
                        detventa.Cod_Cil_Nuevo += detalle.Detalle_Venta.Cod_Cil_Nuevo;
                        lstCodigos.Remove(detalle);
                    }
                }               
                venta.Detalle_Venta= detventa;                 
                lstCodigos.Add(venta);

                tabla.Columns.Add("CodigosAdd");

                foreach (VentaBE info in lstCodigos)
                {
                    tabla.Rows.Add(info.Detalle_Venta.Cod_Cil_Nuevo);
                    gdAdd.DataSource = tabla;
                    gdAdd.DataBind();
                }                           

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