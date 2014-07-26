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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();

            if (!Page.IsPostBack)
            {
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

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();

            long respExisCliente;
            long respExisPedido;

            try
            {
                respExisCliente = servCliente.ConsultarExistenciasClientes(txtCedula.Text);

                if (respExisCliente == 0)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consultar Pedido");
                    divInfoCliente.Visible = false;
                    txtCedula.Text = "";
                    txtCedula.Focus();
                }

                else
                {
                    respExisPedido = servPedido.ConsultarExistenciaPedido(txtCedula.Text);

                    if (respExisPedido == 0)
                    {
                        MessageBox.Show("El pedido no se encuentra registrado en el sistema", "Consultar Pedido");
                        divInfoCliente.Visible = false;
                        txtCedula.Text = "";
                        txtNumPedido.Text = "";
                        txtCedula.Focus();
                    }
                    else
                    {
                        ClienteBE objCliente = servCliente.Consultar_Cliente(txtCedula.Text);

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

                        PedidoBE objPedido = servPedido.Consultar_Pedido(txtCedulaCliente.Text);

                        lblCodigoPedido.Text = objPedido.Id_Pedido;
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
                    }
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
                txtCedula.Text = "";
                txtNumPedido.Text = "";
                btnGuardar.Visible = true;
            }                     
        
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
                    txtCedula.Text = "";
                    txtNumPedido.Text = "";
                    txtCedula.Focus();
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
                txtCedula.Text = "";
                txtNumPedido.Text = "";
                btnGuardar.Visible = true;
            }        
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE ped = new PedidoBE();
            long resp;
            txtCedula.Text = "";

            try
            {
                ped.Id_Pedido = lblCodigoPedido.Text;
                ped.Detalle = txtObservaciones.Text;
                List<Detalle_PedidoBE> lstPedido = new List<Detalle_PedidoBE>();
                foreach (TamanoBE dato in lista)
                {
                    Detalle_PedidoBE det = new Detalle_PedidoBE();
                    det.Tamano = dato.Tamano;
                    det.Cantidad = dato.Cantidad.ToString();
                    det.Id_Tamano = dato.Id_Tamano;
                    lstPedido.Add(det);
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

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //txtCantidadCilindro.Text = " ";
            //txtCedulaCliente.Text = " ";
            //TxtNumPedido.Text = " ";
        }
        
        protected void lstDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            divDirCliente.Focus();
        }

        protected void Seleccion_onClick(object sender, EventArgs e)
        {
            try
            {
                string idUbica = ((System.Web.UI.WebControls.RadioButton)sender).Attributes["value"].ToString();
                //lblIdUbica.Text = idUbica;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                btnGuardar.Focus();
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
        }

        protected void grvPrueba_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lista = (List<TamanoBE>)Session["lista"];
            lista.Remove(lista[e.RowIndex]);
            Session["lista"] = lista;
            grvPrueba.DataSource = lista;
            grvPrueba.DataBind();
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
        }

        private void CargaInicialGridView()
        {
            grvPrueba.DataSource = lista;
            grvPrueba.DataBind();
            Session["lista"] = lista;
        }
        
    }
}