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
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();

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
                    PedidoBE objPedido = servPedido.Consultar_Pedido(txtNumPedido.Text);

                    if (objPedido.Estado == "2")
                    {
                        MessageBox.Show("El pedido se encuentra cancelado en el sistema", "Consultar Pedido");
                        divInfoCliente.Visible = false;
                        divDirCliente.Visible = false;
                        DivInfoPedido.Visible = false;
                        txtCedula.Text = "";
                        txtNumPedido.Text = "";
                        txtCedula.Focus();
                    }
                    else
                    {
                        table2.Columns.Add("Tamano");
                        table2.Columns.Add("Cantidad");

                        foreach (Detalle_PedidoBE datos in objPedido.List_Detalle_Ped)
                        {
                            table2.Rows.Add(datos.Tamano, datos.Cantidad);
                            gvPedido.DataSource = table2;
                            gvPedido.DataBind();
                        }

                        DivInfoPedido.Visible = true;

                        ClienteBE objCliente = servCliente.Consultar_Cliente(Convert.ToString(respExisPedido));

                        txtCedulaCliente.Text = objCliente.Cedula;
                        txtNombreCliente.Text = objCliente.Nombres_Cliente + " " + objCliente.Apellido_1 + " " + objCliente.Apellido_2;
                        lblCodigoPedido.Text = txtNumPedido.Text;
                        table1.Columns.Add("IdUbicacion");
                        table1.Columns.Add("Direccion");
                        table1.Columns.Add("Barrio");
                        table1.Columns.Add("Telefono");
                        table1.Columns.Add("Ciudad");

                        foreach (UbicacionBE datos in objCliente.ListaDirecciones)
                        {
                            table1.Rows.Add(datos.Id_Ubicacion, datos.Direccion, datos.Barrio, datos.Telefono_1, datos.Ciudad.Nombre_Ciudad);
                            gvDirecciones.DataSource = table1;
                            gvDirecciones.DataBind();
                        }

                        divInfoCliente.Visible = true;
                        divDirCliente.Visible = true;
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
            List<Detalle_VentaBE> lstDetalle_venta = new List<Detalle_VentaBE>();
            
           
            long resp;
            try
            {
                ClienteBE cliente = new ClienteBE();

                ventas.IdCliente = lblIdCliente.Text;                
                ventas.Observaciones = txtObservacion.Text;
                ventas.Id_Ubicacion = lblIdUbica.Text;
                ventas.IdVehiculo = lblIdVehiculo.Text;
                listaCilVehSelec = (List<string>)Session["VehiculoSelect"];
                listaCilCliSelec = (List<string>)Session["ClienteSelect"];
                int cantVehiculo=listaCilVehSelec.Count;
                int cantCliente = listaCilCliSelec.Count;
                if (cantCliente == cantVehiculo)
                {
                    foreach (string dato in listaCilVehSelec)
                    {
                        foreach (string info in listaCilCliSelec)
                        {
                            Detalle_VentaBE detVenta = new Detalle_VentaBE();
                            detVenta.Id_Cilindro_Salida = dato;
                            detVenta.Tamano = lstTamano.SelectedItem.Text.ToString();
                            detVenta.Id_Cilindro_Entrada = info;
                            detVenta.Tipo_Cilindro = Tipo_Cilindro.MARCADO.ToString();
                            lstDetalle_venta.Add(detVenta);
                            detVenta.Tipo_Venta = radioTipoDeVenta.SelectedItem.Text;
                        }
                    }
                    ventas.Lista_Detalle_Venta= lstDetalle_venta;
                    resp = servVentas.RegistrarVenta(ventas);

                    MessageBox.Show("La venta fue registrada satisfactoriamente en el sistema bajo el código: " + resp, "Venta de Cilindros");
           
                }
                else
                {
                    if (cantCliente==0 && cantVehiculo==1)
                    {
                        foreach (string dato in listaCilVehSelec)
                        {
                            Detalle_VentaBE detVenta = new Detalle_VentaBE();
                            detVenta.Id_Cilindro_Salida = dato;
                            detVenta.Tamano = lstTamano.SelectedItem.Text.ToString();
                            detVenta.Id_Cilindro_Entrada = "999999999999";
                            detVenta.Tipo_Cilindro = Tipo_Cilindro.UNIVERSAL.ToString();
                            lstDetalle_venta.Add(detVenta);
                            detVenta.Tipo_Venta = radioTipoDeVenta.SelectedItem.Text;
                        }
                        ventas.Lista_Detalle_Venta = lstDetalle_venta;
                        resp = servVentas.RegistrarVenta(ventas);

                        MessageBox.Show("La venta fue registrada satisfactoriamente en el sistema bajo el código: " + resp, "Venta de Cilindros");
                    }

                    else 
                    {
                        MessageBox.Show("La cantidad de cilindros prestados no puede ser mayor que uno (1), rectifique la cantidad", "Venta de Cilindros");
                    }                   
                    
                }                     
            }
            catch(Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servVentas.Close();
                Response.Redirect("~/Ventas/frmVentaCilindro.aspx");
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
                 List<Ubicacion_CilindroBE> lstCilVehiculos = new List<Ubicacion_CilindroBE>(servVehiculo.ConsultarCilPorVehiculo("1"));
                 List<Ubicacion_CilindroBE> lstCilCliente = new List<Ubicacion_CilindroBE>(servCliente.ConsultarCilPorCliente(lblIdUbica.Text));
                 tabla.Columns.Add("CodigosCilVehiculo");
                 tabla2.Columns.Add("CodigosCilCliente");
                 
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
                 btnGuardar.Visible = true;
                 gdCilSelecCliente.Visible = true;
                 gdCodClientes.Visible = true;
                 gvCilVehiculo.Visible = true;
                 gvSeleccion.Visible = true;
                 btnQuitar.Visible = true;
                 btnQuitar2.Visible = true;
                 btnSeleccionar.Visible = true;
                 btnSelect.Visible = true;  
                 if (tabla2.Rows.Count==0)
                 {
                     divCilSiembra.Visible = true;
                     btnQuitar2.Visible = false;
                     btnSelect.Visible = false;
                     gdCilSelecCliente.Visible = false;
                     gdCodClientes.Visible = false;
                     
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
                 
             }
         }
         protected void Seleccion_onClick(object sender, EventArgs e)
         {
             try
             {
                 string idUbica = ((System.Web.UI.WebControls.RadioButton)sender).Attributes["value"].ToString();
                 lblIdUbica.Text = idUbica;
                 //((System.Web.UI.WebControls.RadioButton)sender).Checked = false;
                 DivDetalleVenta.Visible = true;
                 Session["VehiculoSelect"] = listaCilVehSelec;
                 Session["ClienteSelect"] = listaCilCliSelec;
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
             if (radioTipoDeVenta.SelectedItem.Text == "Intercambio")
             {
                 divIntercambioCil.Visible = true;
             }
             else 
             {
                 divIntercambioCil.Visible = false;
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
                     listaCilVeh = (List<string>)Session["Vehiculo"];
                     listaCilVeh.Remove(codCli);
                     Session["lista"] = listaCilVeh;
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
         foreach (string datos in listaCilVeh)
         {
             tabla2.Rows.Add(datos);
         }
         
         gvCilVehiculo.DataSource = tabla2;
         gvCilVehiculo.DataBind(); 
     }

        protected void CheckSelecVehiculo_onClick(object sender, EventArgs e)
    {
        DataTable tabla = new DataTable();
        try
        {
            string codCli = ((System.Web.UI.WebControls.CheckBox)sender).Attributes["value"].ToString();
            listaCilVeh = (List<string>)Session["Vehiculo"];

            string aux = ((System.Web.UI.WebControls.CheckBox)sender).Checked.ToString();

            if (aux == "True")
            {
                foreach (string dato in listaCilVeh)
                {
                    if (dato == codCli)
                    {
                        listaCilVeh.Remove(dato);
                        break;
                    }
                }
                listaCilVeh.Add(codCli);
                Session["Vehiculo"] = listaCilVeh;
                listaCilVehSelec = (List<string>)Session["VehiculoSelect"];
                listaCilVehSelec.Remove(codCli);
                Session["lista"] = listaCilVehSelec;
            }
            else
            {
                foreach (string dato in listaCilVeh)
                {
                    if (dato == codCli)
                    {
                        listaCilVeh.Remove(dato);
                        Session["Vehiculo"] = listaCilVeh;
                        listaCilVehSelec.Add(codCli);
                        Session["VehiculoSelect"] = listaCilVehSelec;
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

        protected void CheckCliente_onClick(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            try
            {
                string codCli = ((System.Web.UI.WebControls.CheckBox)sender).Attributes["value"].ToString();
                listaCilCliSelec = (List<string>)Session["ClienteSelect"];

                string aux = ((System.Web.UI.WebControls.CheckBox)sender).Checked.ToString();

                if (aux == "True")
                {
                    foreach (string dato in listaCilCliSelec)
                    {
                        if (dato == codCli)
                        {
                            listaCilCliSelec.Remove(dato);
                            break;
                        }
                    }
                    listaCilCliSelec.Add(codCli);
                    Session["ClienteSelect"] = listaCilCliSelec;
                    listaCilCli = (List<string>)Session["Cliente"];
                    listaCilCli.Remove(codCli);
                    Session["lista"] = listaCilCli;
                }
                else
                {
                    foreach (string dato in listaCilCliSelec)
                    {
                        if (dato == codCli)
                        {
                            listaCilCliSelec.Remove(dato);
                            Session["ClienteSelect"] = listaCilCliSelec;
                            listaCilCli.Add(codCli);
                            Session["Cliente"] = listaCilCli;
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

        protected void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            listaCilCliSelec = (List<string>)Session["ClienteSelect"];
            listaCilCli = (List<string>)Session["Cliente"];

            DataTable tabla = new DataTable();
            DataTable tabla2 = new DataTable();
            tabla.Columns.Add("CodigosCliSeleccionados");

            foreach (string datos in listaCilCliSelec)
            {
                tabla.Rows.Add(datos);
            }
            gdCilSelecCliente.DataSource = tabla;
            gdCilSelecCliente.DataBind();

            tabla2.Columns.Add("CodigosCilCliente");
            foreach (string datos in listaCilCli)
            {
                tabla2.Rows.Add(datos);
            }

            gdCodClientes.DataSource = tabla2;
            gdCodClientes.DataBind();
        }

        protected void CheckSelecCliente_onClick(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            try
            {
                string codCli = ((System.Web.UI.WebControls.CheckBox)sender).Attributes["value"].ToString();
                listaCilCli = (List<string>)Session["Cliente"];

                string aux = ((System.Web.UI.WebControls.CheckBox)sender).Checked.ToString();

                if (aux == "True")
                {
                    foreach (string dato in listaCilCli)
                    {
                        if (dato == codCli)
                        {
                            listaCilCli.Remove(dato);
                            break;
                        }
                    }
                    listaCilCli.Add(codCli);
                    Session["Cliente"] = listaCilCli;
                    listaCilCliSelec = (List<string>)Session["ClienteSelect"];
                    listaCilCliSelec.Remove(codCli);
                    Session["lista"] = listaCilCliSelec;
                }
                else
                {
                    foreach (string dato in listaCilCli)
                    {
                        if (dato == codCli)
                        {
                            listaCilCli.Remove(dato);
                            Session["Cliente"] = listaCilCli;
                            listaCilCliSelec.Add(codCli);
                            Session["ClienteSelect"] = listaCilCliSelec;
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

    }
}