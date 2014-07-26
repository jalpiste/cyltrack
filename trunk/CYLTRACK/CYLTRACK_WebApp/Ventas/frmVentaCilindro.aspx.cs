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
using CYLTRACK_WebApp.ReporteService;
using CYLTRACK_WebApp.VehiculoService;
using System.Data;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmVentaCilindro : System.Web.UI.Page
    {
        List<Detalle_VentaBE> lstVenta = new List<Detalle_VentaBE>();
        List<string> listaCilVehSelec = new List<string>();
        List<string> listaCilVeh = new List<string>();
        List<string> listaCilCliSelec = new List<string>();
        List<string> listaCilCli = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
             ReporteServiceClient servReporte = new ReporteServiceClient();
               
                try
                {
                if (!Page.IsPostBack)
                 {
                    txtCedula.Focus();
                    lstTamano.DataSource = servReporte.ConsultaTamanoCilindro();
                    lstTamano.DataValueField = "Id_Tamano";
                    lstTamano.DataTextField = "Tamano";
                    lstTamano.DataBind();

                    lstTamSiembra.DataSource = servReporte.ConsultaTamanoCilindro();
                    lstTamSiembra.DataValueField = "Id_Tamano";
                    lstTamSiembra.DataTextField = "Tamano";
                    lstTamSiembra.DataBind();

                    List<string> tipoCil = Auxiliar.ConsultaTipoCilindro();
                    foreach (string dato in tipoCil)
                    {
                        lstTipoCil.Items.Add(dato);
                    }
                    //CAMBIAR AL REALIZAR LA AUTENTICACION DEL USUARIO
                    lblIdVehiculo.Text = "1";

                    }
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
      
        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            ClienteServiceClient serCliente = new ClienteServiceClient();
            DataTable table = new DataTable();
            try
            {
                long consultaExistencia = serCliente.ConsultarExistenciasClientes(txtCedula.Text);

                if (consultaExistencia == 0)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consulta de Clientes");
                    divInfoCliente.Visible = false;
                    txtCedula.Text = "";
                    txtCedula.Focus();
                }
                else
                {
                    ClienteBE cliente = serCliente.Consultar_Cliente(txtCedula.Text);

                    txtCedulaCliente.Text = cliente.Cedula;
                    lblIdCliente.Text = cliente.Id_Cliente;
                    txtNombreCliente.Text = cliente.Nombres_Cliente+" "+cliente.Apellido_1+" "+cliente.Apellido_2;

                    table.Columns.Add("IdUbicacion");
                    table.Columns.Add("Direccion");
                    table.Columns.Add("Barrio");
                    table.Columns.Add("Telefono");
                    table.Columns.Add("Ciudad");

                    foreach (UbicacionBE datos in cliente.ListaDirecciones)
                    {
                        table.Rows.Add(datos.Id_Ubicacion, datos.Direccion, datos.Barrio,datos.Telefono_1, datos.Ciudad.Nombre_Ciudad);
                        gvDirecciones.DataSource = table;
                        gvDirecciones.DataBind();
                    }
                    gvDirecciones.Visible = true;
                    divDirCliente.Visible = true;
                    divInfoCliente.Visible = true;
                    DivDetalleVenta.Visible = true;
                    txtCedula.Text = "";
                    txtNumPedido.Text = "";                 
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                serCliente.Close();
                divInfoCliente.Focus();
            }
        }

        protected void txtNumPedido_TextChanged(object sender, EventArgs e)
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
                    lblCodigoPedido.Text = respExisPedido.ToString();
                    lblCodigoPedido.Visible = true;
                    lblPedido.Visible = true;
                    table.Columns.Add("IdUbicacion");
                    table.Columns.Add("Direccion");
                    table.Columns.Add("Barrio");
                    table.Columns.Add("Telefono");
                    table.Columns.Add("Ciudad");

                    foreach (UbicacionBE datos in objCliente.ListaDirecciones)
                    {
                        table.Rows.Add(datos.Id_Ubicacion, datos.Direccion, datos.Barrio, datos.Telefono_1, datos.Ciudad.Nombre_Ciudad);
                    }
                    gvDirecciones.DataSource = table;
                    gvDirecciones.DataBind();
                    divInfoCliente.Visible = true;
                    DivDetalleVenta.Visible = true;
                    divDirCliente.Visible = true;                    

                    PedidoBE objPedido = servPedido.Consultar_Pedido(respExisPedido.ToString());

                    table.Columns.Add("TamanoCil");
                    table.Columns.Add("CantidadPedido");

                    foreach (Detalle_PedidoBE datos in objPedido.List_Detalle_Ped)
                    {
                        table.Rows.Add(datos.Tamano, datos.Cantidad);
                    }
                    lblCodigoPedido.Text = objPedido.Id_Pedido;
                    lblIdCliente.Text = objPedido.IdCliente;
                    gvPedido.DataSource = table;
                    gvPedido.DataBind();
                    DivInfoPedido.Visible = true;
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
                txtCedula.Text = "";
                txtNumPedido.Text = "";
                divInfoCliente.Focus();
            }                       
        
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            VentaServiceClient servVentas = new VentaServiceClient();
            VentaBE ventas = new VentaBE();
           
            long resp;
            try
            {
                ClienteBE cliente = new ClienteBE();

                ventas.IdCliente = lblIdCliente.Text;                
                ventas.Observaciones = txtObservacion.Text;
                ventas.Id_Ubicacion = lblIdUbica.Text;
                ventas.IdVehiculo = lblIdVehiculo.Text;

             //   foreach (DataRow dato in objdtTablaDetVenta.Rows)
             //{
             //    Detalle_VentaBE detVenta = new Detalle_VentaBE();
             //    detVenta.Id_Cilindro_Salida = Convert.ToString(dato["CodigosVehiculo"]);
             //    detVenta.Tamano = Convert.ToString(dato["Tamano"]);
             //    detVenta.Id_Cilindro_Entrada = Convert.ToString(dato["CodigosCliente"] );
             //    ventas.Lista_Detalle_Venta.Add(detVenta);
             //}           

             
             //if (detVenta.Id_Cilindro_Entrada.Length <= 12) 
             //{
             //    if (txtCilSiembra.Text == "")
             //    {
             //        detVenta.Id_Cilindro_Entrada = "999999999999";
             //        detVenta.Tamano = lstTamano.SelectedItem.Text;
             //        detVenta.Tipo_Cilindro = Tipo_Cilindro.UNIVERSAL.ToString();
             //    }
             //    else
             //    {
             //        detVenta.Id_Cilindro_Entrada = txtCilSiembra.Text;
             //        detVenta.Tamano = lstTamSiembra.SelectedItem.Text;
             //        detVenta.Tipo_Cilindro = lstTipoCil.SelectedItem.Text;
             //    }
             //}

             resp=servVentas.RegistrarVenta(ventas);
            }
            catch(Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servVentas.Close();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
         {
             ClienteServiceClient servCliente = new ClienteServiceClient();
             VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
             DataTable tabla = new DataTable();
             VentaBE venta = new VentaBE ();
             DataTable tabla2 = new DataTable();
             
             try
             {
                 Session["VehiculoSelect"] = listaCilVehSelec;
                 List<Ubicacion_CilindroBE> lstCilVehiculos = new List<Ubicacion_CilindroBE>(servVehiculo.ConsultarCilPorVehiculo("1"));
                 List<Ubicacion_CilindroBE> lstCilCliente = new List<Ubicacion_CilindroBE>(servCliente.ConsultarCilPorCliente(lblIdUbica.Text));
                 tabla.Columns.Add("CodigosCilVehiculo");
                 tabla2.Columns.Add("CodigosCliSeleccionados");
                 
                 foreach (Ubicacion_CilindroBE datos in lstCilVehiculos )
                 {
                     if (lstTamano.SelectedItem.Text == datos.Cilindro.NTamano.Tamano)
                     {
                         tabla.Rows.Add(datos.Cilindro.Codigo_Cilindro);
                         listaCilVeh.Add(datos.Cilindro.Codigo_Cilindro);
                     }                                        
                 }
                 Session["Vehiculo"] = listaCilVeh;
                 gvCilVehiculo.DataSource = tabla;
                 gvCilVehiculo.DataBind();
                 
                 foreach (Ubicacion_CilindroBE datos in lstCilCliente)
                 {
                     if (lstTamano.SelectedItem.Text == datos.Cilindro.NTamano.Tamano)
                     {
                         tabla2.Rows.Add(datos.Cilindro.Codigo_Cilindro);
                         listaCilCli.Add(datos.Cilindro.Codigo_Cilindro);
                     }
                 }
                 Session["Cliente"] = listaCilCli;
                 gdCodClientes.DataSource = tabla2;
                 gdCodClientes.DataBind();
                 foreach (DataRow datos in tabla2.Rows)
                 {
                 if ((Convert.ToString(datos["CodigosCliente"]))=="")
                 {
                     divCilSiembra.Visible = true;
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
                 servVehiculo.Close();
                 gdCilSelecCliente.Focus();
                 gdCodClientes.Visible = true;
                 btnGuardar.Visible = true;
             }
         }
         protected void Seleccion_onClick(object sender, EventArgs e)
         {
             try
             {
                 string idUbica = ((System.Web.UI.WebControls.RadioButton)sender).Attributes["value"].ToString();
                 lblIdUbica.Text = idUbica;
                 ((System.Web.UI.WebControls.RadioButton)sender).Checked = false;
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
         protected void SelectTipoVenta(object sender, EventArgs e)
         {
             if(radioTipoDeVenta.SelectedItem.Text=="Intercambio")
             {
             divIntercambioCil.Visible = true;
             }
         }

         protected void CheckVehiculo_onClick(object sender, EventArgs e)
         {
             DataTable tabla = new DataTable();
             try
             {
                 string codCli = ((System.Web.UI.WebControls.CheckBox)sender).Attributes["value"].ToString();
                 listaCilVehSelec = (List<string>)Session["VehiculoSelect"];

                 string aux = ((System.Web.UI.WebControls.CheckBox)sender).Checked.ToString();

                 if (aux == "True")
                 {
                     foreach (string dato in listaCilVehSelec)
                     {
                         if (dato == codCli)
                         {
                             listaCilVehSelec.Remove(dato);
                             break;
                         }
                     }
                     listaCilVehSelec.Add(codCli);
                     Session["VehiculoSelect"] = listaCilVehSelec;                     
                 }
                 else 
                 {
                     foreach (string dato in listaCilVehSelec)
                     {
                         if (dato == codCli)
                         {
                             listaCilVehSelec.Remove(dato);
                             Session["VehiculoSelect"] = listaCilVehSelec; 
                             listaCilVeh.Add(codCli);
                             Session["Vehiculo"] = listaCilVeh; 
                             break;
                         }
                     }
                 }
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

    protected void btnSeleccionarVehiculo_Click(object sender, EventArgs e){
        listaCilVehSelec = (List<string>)Session["VehiculoSelect"];
        listaCilVeh = (List<string>)Session["Vehiculo"];

         DataTable tabla = new DataTable();
         DataTable tabla2 = new DataTable();
         tabla.Columns.Add("CodigosVehiSeleccionados");
         
        foreach(string datos in listaCilVehSelec)
        {
            tabla.Rows.Add(datos);         
        }
         gvSeleccion.DataSource = tabla;
         gvSeleccion.DataBind();

         tabla2.Columns.Add("CodigosCilVehiculo");
         tabla2.Rows.Add(listaCilVeh);
         gvCilVehiculo.DataSource = tabla2;
         gvCilVehiculo.DataBind(); 
     }

    protected void btnQuitar_Click(object sender, EventArgs e){

        string CodigoCil = ((System.Web.UI.WebControls.CheckBox)sender).Attributes["value"].ToString();

       
    }
   
    }
}