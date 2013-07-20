using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.PedidoService;
using System.Windows.Forms;
using System.Data;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account.Pedido
{
    public partial class frmRegistroPedido : System.Web.UI.Page
    {
        List<Detalle_PedidoBE> lstDetail = new List<Detalle_PedidoBE>(); 
        //Detalle_PedidoBE [] lstDetail = new Detalle_PedidoBE [4];
        DataTable objdtLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();

            if (!Page.IsPostBack)
            {
                objdtLista = new DataTable();
                CrearTabla();
            }
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            
            lblCodigoPedido.Visible = true;
            lblNumeroPedido.Visible = true;

            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE consultar_ped = new PedidoBE();
            
            try
            {
                ClienteBE cliente = new ClienteBE();
                cliente.Cedula = txtCedula.Text;
                consultar_ped.Cliente = cliente;

                consultar_ped.Cliente.Cedula = txtCedula.Text;
                PedidoBE[] consulta = servPedido.Consultar_Pedido(consultar_ped);

                foreach (PedidoBE info in consulta)
                {
                    if (info.Cliente.Cedula != txtCedula.Text)
                    {
                        txtCedulaCli.Text = info.Cliente.Cedula;
                        txtNombreCliente.Text = info.Cliente.Nombres_Cliente;
                        txtPrimerApellido.Text = info.Cliente.Apellido_1;
                        txtSegundoApellido.Text = info.Cliente.Apellido_2;
                        lstDireccion.Items.Add(info.Ubicacion.Direccion);// como llamar todas las direcciones disponibles para el cliente???
                        txtBarrio.Text = info.Ubicacion.Barrio;
                        txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = info.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = info.Ubicacion.Telefono_1;

                        divInfoCliente.Visible = true;
                        btnGuardar.Visible = true;
                        lstDireccion.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Registrar Pedido");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servPedido.Close();
            }
        }
        

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //txtNombreCliente.Text = " ";
            //txtPrimerApellido.Text = " ";
            //txtSegundoApellido.Text = " ";
            //txtBarrio.Text = " ";
            //txtCiudad.Text = " ";
            //txtDepartamento.Text = " ";
            //txtTelefono.Text = " ";
            //txtCantidadCilindro.Text = " ";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE registrar_ped = new PedidoBE();
            String resp;
            txtCedula.Text = "";

            try
            {
                UbicacionBE ubicli = new UbicacionBE();
                ubicli.Direccion = lstDireccion.Text;
                registrar_ped.Ubicacion = ubicli;

                VehiculoBE veh = new VehiculoBE();
                veh.Placa = lstPlaca.SelectedValue;
                registrar_ped.Vehiculo = veh;

                RutaBE ruta = new RutaBE();
                ruta.Nombre_Ruta = lblRutaAsignada.Text;
                registrar_ped.Ruta = ruta;

                
                foreach (DataRow row in objdtTabla.Rows)
                {
                  Detalle_PedidoBE det = new Detalle_PedidoBE();
                  TamanoBE tamanito = new TamanoBE();
                  det.Tamano = tamanito;
                   det.Tamano.Tamano= (Convert.ToString(row["TamanoCil"]));
                   det.Cantidad  = (Convert.ToString(row["CantidadPedido"]));
                   lstDetail.Add(det);
                }

                Detalle_PedidoBE detalle = new Detalle_PedidoBE();
                TamanoBE tam = new TamanoBE();
                detalle.Tamano = tam;

                foreach(Detalle_PedidoBE datos in lstDetail)
                {
                    detalle.Tamano.Tamano = datos.Tamano.Tamano;
                    detalle.Cantidad = datos.Cantidad;
                }
                registrar_ped.Detalle_Ped = detalle;
             
                resp = servPedido.Registrar_Pedido(registrar_ped);

                if (resp == "Ok")
                {
                    MessageBox.Show("El pedido fue registrado satisfactoriamente", "Registrar Pedido");
                }  
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
            Response.Redirect("~/Default.aspx");
        }

        
        
  //      ------------------------- inicio de tabla acumulada y asignación de valor

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
//        ------------------------- fin de tabla acumulada y asignación de valor

        private void CrearTabla()
        { 
                objdtLista.Columns.Add("TamanoCil");
                objdtLista.Columns.Add("CantidadPedido");
     
            
            objdtTabla = objdtLista;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        PedidoServiceClient servPedido = new PedidoServiceClient();
        Detalle_PedidoBE detail = new Detalle_PedidoBE();
       
            try
            {
                
                detail.Cantidad = txtCantidadCilindro.Text;
                
                TamanoBE tamanocil = new TamanoBE();
                tamanocil.Tamano = lstTamano.SelectedValue;
                detail.Tamano = tamanocil;


                foreach (Detalle_PedidoBE det in lstDetail)
                {
                    
                    if (det.Tamano.Tamano == detail.Tamano.Tamano)
                    {
                        detail.Cantidad += det.Tamano.Tamano;
                        lstDetail.Remove(det);
                    }
                }

                lstDetail.Add(detail);

        
                foreach (Detalle_PedidoBE info in lstDetail)
                {
                    objdtTabla.Rows.Add(info.Tamano.Tamano, info.Cantidad);
                    gvPedido.DataSource = objdtTabla;
                    gvPedido.DataBind();
                    
                }
                        
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                gvPedido.Visible = true;
                servPedido.Close();
                btnGuardar.Focus();
            }
     
    }
        protected void lstDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstDireccion.Focus();
        }

        protected void gvPedido_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            objdtTabla.Rows.RemoveAt(e.RowIndex);
            gvPedido.DataSource = objdtTabla;
            gvPedido.DataBind();
            btnGuardar.Focus();
            // DataTable tabla = new DataTable();
           // ////gvPedido.DeleteRow(gvPedido.SelectedIndex);
           // tabla = tblGridRow();
           // tabla.Rows.RemoveAt(e.RowIndex);
           // gvPedido.DataSource = tabla;
           // gvPedido.DataBind();
           //// tabla.Rows(e.RowIndex).Delete();
        }

        //private DataTable tblGridRow()
        //{
        //    throw new NotImplementedException();
        //}

        
    }
}