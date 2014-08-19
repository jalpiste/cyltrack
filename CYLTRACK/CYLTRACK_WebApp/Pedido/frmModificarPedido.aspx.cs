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
using CYLTRACK_WebApp.VehiculoService;
using System.Windows.Forms;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido
{
    public partial class frmModificarPedido : System.Web.UI.Page
    {
        List<Detalle_PedidoBE> lstDetail = new List<Detalle_PedidoBE>();
        DataTable objdtLista;
        List<TamanoBE> lista = new List<TamanoBE>();
        List<TamanoBE> listaAuxiliar = new List<TamanoBE>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtNumPedido.Focus();
                PedidoServiceClient servPed = new PedidoServiceClient();
                ReporteServiceClient servReporte = new ReporteServiceClient();
                try
                {
                    objdtLista = new DataTable();
                    CrearTabla();

                    lstTamanos.DataSource = servReporte.ConsultaTamanoCilindro();
                    lstTamanos.DataValueField = "Id_Tamano";
                    lstTamanos.DataTextField = "Tamano";
                    lstTamanos.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }
                finally
                {
                    servPed.Close();
                    servReporte.Close();
                }
            }       
        }

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
        private void CrearTabla()
        {
            objdtLista.Columns.Add("TamanoCil");
            objdtLista.Columns.Add("CantidadPedido");
            objdtTabla = objdtLista;
        }

        protected void TxtNumPedido_TextChanged(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            DataTable table = new DataTable();

            long respExisPedido;

            try
            {
                respExisPedido = servPedido.ConsultarExistenciaPedido(txtNumPedido.Text);

                if (respExisPedido == 0)
                {
                    MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Consultar Pedido");
                    divInfoCliente.Visible = false;                   
                    txtNumPedido.Text = "";
                    txtNumPedido.Focus();
                }
                else
                {
                    ClienteBE objCliente = servCliente.Consultar_Cliente(Convert.ToString(respExisPedido));

                    txtCedulaCliente.Text = objCliente.Cedula;
                    txtNombreCliente.Text = objCliente.Nombres_Cliente;
                    txtPrimerApellido.Text = objCliente.Apellido_1;
                    txtSegundoApellido.Text = objCliente.Apellido_2;
                    table.Columns.Add("IdUbicacion");
                    table.Columns.Add("Direccion");
                    table.Columns.Add("Barrio");
                    table.Columns.Add("Telefono");
                    table.Columns.Add("Ciudad");

                    foreach (UbicacionBE datos in objCliente.ListaDirecciones)
                    {
                        table.Rows.Add(datos.Id_Ubicacion, datos.Direccion, datos.Barrio, datos.Telefono_1, datos.Ciudad.Nombre_Ciudad);
                        gvDirecciones.DataSource = table;
                        gvDirecciones.DataBind();
                    }
                    gvDirecciones.Visible = true;
                    divDirCliente.Visible = true;
                    divInfoCliente.Visible = true;
                    lblCodigoPedido.Text = txtNumPedido.Text;

                    PedidoBE objPedido = servPedido.Consultar_Pedido(txtNumPedido.Text);

                    foreach (Detalle_PedidoBE datos in objPedido.List_Detalle_Ped)
                    {
                        TamanoBE tam = new TamanoBE();
                        tam.Cantidad = Convert.ToInt32(datos.Cantidad);
                        tam.Tamano = datos.Tamano;
                        lista.Add(tam);
                    }
                    grvPrueba.DataSource = lista;
                    grvPrueba.DataBind();
                    Session["lista"] = lista;
                    Session["listaAuxiliar"] = lista;
                    grvPrueba.Focus();
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
                lblCodigoPedido.Visible = true;
                lblPedido.Visible = true;               
                txtNumPedido.Text = "";               
            }        
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            if(!IsPostBack)
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE ped = new PedidoBE();
            long resp;
            lista = (List<TamanoBE>)Session["lista"];
            listaAuxiliar = (List<TamanoBE>)Session["listaAuxiliar"];
            try
            {
                ped.Id_Pedido = lblCodigoPedido.Text;
                ped.Detalle = txtObservaciones.Text;
                List<Detalle_PedidoBE> lstPedido = new List<Detalle_PedidoBE>();
                foreach (TamanoBE dato in lista)
                {
                    if (dato.Id_Tamano != null)
                    {
                        foreach (TamanoBE info in listaAuxiliar)
                        {
                            if(info.Tamano==dato.Tamano)
                            {
                             Detalle_PedidoBE det = new Detalle_PedidoBE();
                              det.Tamano = dato.Tamano;
                              det.Cantidad = dato.Cantidad.ToString();
                              det.Id_Tamano = dato.Id_Tamano;
                              lstPedido.Add(det);
                            }
                        }
                    }
                }
                ped.List_Detalle_Ped = lstPedido;
                resp = servPedido.Modificar_Pedido(ped);

                MessageBox.Show("El pedido fue modificado satisfactoriamente", "Modificar Pedido");

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

        protected void grvPrueba_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lista = (List<TamanoBE>)Session["lista"];
            btnEjecutar.Enabled = false;
            btnModificar.Enabled = true;
            lstTamanos.SelectedIndex = Convert.ToInt32(lista[e.NewEditIndex].Id_Tamano);
            txtCantidad.Text = lista[e.NewEditIndex].Cantidad.ToString();
            Session["indiceModificar"] = e.NewEditIndex;
            e.Cancel = true;
            txtObservaciones.Focus();
            btnGuardar.Visible = true;
        }

        protected void grvPrueba_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lista = (List<TamanoBE>)Session["lista"];
            lista.Remove(lista[e.RowIndex]);
            Session["lista"] = lista;
            grvPrueba.DataSource = lista;
            grvPrueba.DataBind();
            txtObservaciones.Focus();
            btnGuardar.Visible = true;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lista = (List<TamanoBE>)Session["lista"];
            int indice = (int)Session["indiceModificar"];
            Session.Remove("indiceModificar");
            TamanoBE tamano = new TamanoBE();
            tamano.Tamano = lstTamanos.SelectedItem.Text;
            tamano.Id_Tamano = Convert.ToString(lstTamanos.SelectedIndex);
            int cant = 0;
            tamano.Cantidad = int.TryParse(txtCantidad.Text, out cant) ? cant : 0;
            lista.Remove(lista[indice]);

            foreach (TamanoBE ent in lista)
            {
                if (ent.Tamano == lstTamanos.SelectedItem.Text)
                {
                    tamano.Cantidad += ent.Cantidad;
                    lista.Remove(ent);
                    break;
                }
            }
            lista.Add(tamano);
            Session["lista"] = lista;
            grvPrueba.DataSource = lista;
            grvPrueba.DataBind();
            btnEjecutar.Enabled = true;
            btnModificar.Enabled = false;
            txtObservaciones.Focus();
            btnGuardar.Visible = true;
        }

        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            lista = (List<TamanoBE>)Session["lista"];
            TamanoBE tamano = new TamanoBE();
            tamano.Tamano = lstTamanos.SelectedItem.Text;
            tamano.Id_Tamano = Convert.ToString(lstTamanos.SelectedIndex);
            int cant = 0;
            tamano.Cantidad = int.TryParse(txtCantidad.Text, out cant) ? cant : 0;

            foreach (TamanoBE ent in lista)
            {
                if (ent.Tamano == lstTamanos.SelectedItem.Text)
                {
                    tamano.Cantidad += ent.Cantidad;
                    lista.Remove(ent);
                    break;
                }
            }

            lista.Add(tamano);
            Session["lista"] = lista;
            grvPrueba.DataSource = lista;
            grvPrueba.DataBind();
            txtObservaciones.Focus();
            btnGuardar.Visible = true;
        }

        private void CargaInicialGridView()
        {
            grvPrueba.DataSource = lista;
            grvPrueba.DataBind();
            Session["lista"] = lista;
        }
        
    }
}