using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using CYLTRACK_PHONE.ClienteService;
using CYLTRACK_PHONE.VentaService;
using CYLTRACK_PHONE.VehiculoService;


namespace Unisangil.CYLTRACK.CYLTRACK_PHONE.Ventas
{
    public partial class frmConsultaVenta : PhoneApplicationPage
    {
        public frmConsultaVenta()
        {
            InitializeComponent();
        }
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            
            ClienteServiceClient servCliente = new ClienteServiceClient();
           
            servCliente.Consultar_ClienteAsync(txtCedula.Text);
            servCliente.Consultar_ClienteCompleted += new EventHandler<Consultar_ClienteCompletedEventArgs>(PoblarCliente);

            VentaServiceClient servVenta = new VentaServiceClient();

            servVenta.ConsultarVentaAsync(lblCodVenta.Text);
            servVenta.ConsultarVentaCompleted += new EventHandler<ConsultarVentaCompletedEventArgs>(PoblarInfVenta);

        }
        
        private void PoblarCliente(object sender, Consultar_ClienteCompletedEventArgs e)
        {
            
            try
            {
                if (e.Result.Cedula == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado");
                    NavigationService.Navigate(new Uri("/Ventas/frmConsultaVenta.xaml", UriKind.Relative));
                }
                else
                {
                    ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
                    ContentCliente.Visibility = System.Windows.Visibility.Visible;

                    
                    lblCedulaCli.Text = e.Result.Cedula;
                    txtNombres.Text = e.Result.Nombres_Cliente;
                    txtPrApellido.Text = e.Result.Apellido_1;
                    txtSgApellido.Text = e.Result.Apellido_2;
                    lblDirecciones.Text = "";

                    //foreach  (UbicacionBE ubi in e.Result.ListaDirecciones)
                    //{
                    //    lblDirecciones.Text += ubi.Id_Ubicacion + "-" + ubi.Ciudad.Nombre_Ciudad + "-" + ubi.Barrio + "-" + (ubi.Direccion.Length > 20 ? ubi.Direccion.Substring(0, 20) : ubi.Direccion) + "\n";
                    //}

                }
                txtCedula.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                btnContinuar.Focus();
            }
        }

        private void btnNvConsulta_MouseEnter(object sender, MouseEventArgs e)
        {
            ContentCliente.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

            servVehiculo.Consultar_ConductorAsync(lblCodVent.Text);
            servVehiculo.Consultar_ConductorCompleted += new EventHandler<Consultar_ConductorCompletedEventArgs>(PoblarVendedor);
        }

        private void PoblarVendedor(object sender, Consultar_ConductorCompletedEventArgs e)
        {
            txtNombsVendedor.Text = e.Result.Nombres_Conductor + " " + e.Result.Apellido_1 + " " + e.Result.Apellido_2;
        }

        private void PoblarInfVenta(object sender, ConsultarVentaCompletedEventArgs e)
        {

            try
            {
                if (e.Result.Id_Venta == null)
                {
                    MessageBox.Show("El cliente no tiene asignado ninguna venta reciente");
                    NavigationService.Navigate(new Uri("/Ventas/frmConsultaVenta.xaml", UriKind.Relative));
                }
                else
                {
                    lblCodVenta.Text = e.Result.Id_Venta;
                    lblFechaVenta.Text = Convert.ToString(e.Result.Fecha);
                    lblHoraVenta.Text = Convert.ToString(e.Result.Fecha.TimeOfDay);

                    foreach (Detalle_VentaBE info in e.Result.Lista_Detalle_Venta)
                    {
                        lblCilindroVenta.Text += info.Id_Cilindro_Salida + "-" + info.Tamano + "-" + info.Tipo_Cilindro;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                btnNvConsulta.Focus();
            }
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            ContentCliente.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnNvConsulta_Click(object sender, RoutedEventArgs e)
        {
            ContentCilindro.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnMenuPrincipal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

    }
}