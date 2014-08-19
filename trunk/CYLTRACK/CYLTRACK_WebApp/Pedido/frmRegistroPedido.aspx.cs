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
        List<TamanoBE> lista = new List<TamanoBE>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();

            if (!Page.IsPostBack)
            {
                PedidoServiceClient servPed = new PedidoServiceClient();

                objdtLista = new DataTable();
                CrearTabla();
                CargaInicialGridView();
            }

            if (!IsPostBack)
            {
                ReporteServiceClient servReporte = new ReporteServiceClient();
                try
                {
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
                    servReporte.Close();
                }
            }
        }
               
        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            VehiculoServiceClient servVeh = new VehiculoServiceClient();
            DataTable table = new DataTable();
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
                   lblIdCedula.Text = objCliente.Id_Cliente;
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
                   divDirCliente.Visible = true;
                   divInfoCliente.Visible = true;                   
                   lstTamanos.Focus();
                   txtCedula.Text = "";                   
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

       protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE ped = new PedidoBE();
            long resp;            
            lista = (List<TamanoBE>)Session["lista"];
            try
            {
                ped.IdCliente = lblIdCedula.Text;
                                 
                ped.Detalle = txtObservaciones.Text;
                List<Detalle_PedidoBE> lstPedido = new List<Detalle_PedidoBE>();
                foreach (TamanoBE dato in lista)
                {                   
                    Detalle_PedidoBE det = new Detalle_PedidoBE();
                    det.Tamano = dato.Tamano;
                    det.Cantidad = dato.Cantidad.ToString();
                    lstPedido.Add(det);                    
                }
                ped.List_Detalle_Ped = lstPedido;

                resp = servPedido.Registrar_Pedido(ped);

               MessageBox.Show("El pedido fue registrado satisfactoriamente bajo el número: "+resp, "Registrar Pedido");
                  
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
           if (!IsPostBack)
            {
                Response.Redirect("~/Default.aspx");
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
        }

        protected void grvPrueba_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lista = (List<TamanoBE>)Session["lista"];
            lista.Remove(lista[e.RowIndex]);
            Session["lista"] = lista;
            grvPrueba.DataSource = lista;
            grvPrueba.DataBind();
            txtObservaciones.Focus();
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