using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VentaService;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.PedidoService;
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
            try
            { 
                ConsultaDatosCliente(txtCedula.Text);
                ConsultaDatosPlaca();

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
                ConsultaDatosPedido(TxtNumPedido.Text);
                ConsultaDatosPlaca();                
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
                ped.Id_Pedido = TxtNumPedido.Text;
                
                cli.Pedido = ped;
                UbicacionBE ubi = new UbicacionBE(); 
                List<string> lstDatoDireccion = new List<string>();
                lstDatoDireccion.Add(lstDireccion.SelectedValue);
                ubi.Direccion = lstDatoDireccion;
                cli.Ubicacion = ubi;
                foreach (VentaBE datos in lstCodigos)
                {
                    detVenta.Cod_Cil_Nuevo = datos.Detalle_Venta.Cod_Cil_Nuevo;
                }
                ventas.Observaciones = txtObservacion.Text;

                String regVenta = serVenta.VentaCilindro(ventas);
                //Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
                MessageBox.Show("La venta ha sido registrada satisfactoriamente", "Venta de Cilindro");

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

        public void ConsultaDatosCliente(string cedula)
        {
            ClienteServiceClient serCliente = new ClienteServiceClient();
            DataTable table = new DataTable();

            try
            {
                long consultaExistencia = serCliente.Consultar_Existencia(cedula);

                if (consultaExistencia == 0)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Venta de Cilindros");
                }
                else
                {
                    ClienteBE cliente = new ClienteBE();
                    cliente = serCliente.Consultar_Cliente(txtCedula.Text);

                    table.Columns.Add("CodigosCil");
                    table.Columns.Add("Tamano");
                    table.Columns.Add("TipoCil");

                    txtCedulaCliente.Text = cliente.Cedula;
                    txtNombreCliente.Text = cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = cliente.Apellido_1;
                    txtSegundoApellido.Text = cliente.Apellido_2;
                    foreach (string datos in cliente.Ubicacion.Direccion)
                    {
                        lstDireccion.Items.Add(datos);
                    } 
                    txtBarrio.Text = cliente.Ubicacion.Barrio;
                    txtTelefono.Text = cliente.Ubicacion.Telefono_1;
                    txtCiudad.Text = cliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = cliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    table.Rows.Add(cliente.Ubicacion.Ubicacion_Cilindro.Cilindro.Codigo_Cilindro, cliente.Ubicacion.Ubicacion_Cilindro.Cilindro.NTamano.Tamano, cliente.Ubicacion.Ubicacion_Cilindro.Cilindro.Tipo_Cilindro);
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

        public void ConsultaDatosPedido(string pedido)
        {
            PedidoServiceClient serPedido = new PedidoServiceClient();
            DataTable table = new DataTable();

            try
            {
                string consultaExistencia = serPedido.Consultar_Existencia(pedido);

                if (consultaExistencia != "Ok")
                {
                    MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Venta de Cilindros");
                }
                else
                {
                    PedidoBE datosPedido = new PedidoBE();
                    datosPedido = serPedido.Consultar_Pedido(pedido);

                    table.Columns.Add("CodigosCil");
                    table.Columns.Add("Tamano");
                    table.Columns.Add("TipoCil");

                    lblPedido.Text = datosPedido.Id_Pedido;
                    txtCedulaCliente.Text = datosPedido.Cliente.Cedula;
                    txtNombreCliente.Text = datosPedido.Cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = datosPedido.Cliente.Apellido_1;
                    txtSegundoApellido.Text = datosPedido.Cliente.Apellido_2;
                    foreach (string datos in datosPedido.Ubicacion.Direccion)
                    {
                        lstDireccion.Items.Add(datos);
                    } txtBarrio.Text = datosPedido.Ubicacion.Barrio;
                    txtTelefono.Text = datosPedido.Ubicacion.Telefono_1;
                    txtCiudad.Text = datosPedido.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = datosPedido.Ciudad.Departamento.Nombre_Departamento;
                    foreach (CilindroBE datos in datosPedido.Cilindro)
                    {
                        table.Rows.Add(datos.Codigo_Cilindro, datos.NTamano.Tamano, datos.Tipo_Cilindro);
                   
                    }
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
                serPedido.Close();
            }
        }

        public void ConsultaDatosPlaca()
        {
            VentaServiceClient serVenta = new VentaServiceClient();
            DataTable table = new DataTable();

            try
            {
                    List<CilindroBE> lstCilindros = new List<CilindroBE>(serVenta.ConsultarCarguePlaca());
                    
                    table.Columns.Add("CodigosCil");
                    table.Columns.Add("Tamano");
                    table.Columns.Add("TipoCil");

                    foreach(CilindroBE datos in lstCilindros){
                    table.Rows.Add(datos.Codigo_Cilindro, datos.NTamano.Tamano, datos.Tipo_Cilindro);
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
                venta.Detalle_Venta = detventa;
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