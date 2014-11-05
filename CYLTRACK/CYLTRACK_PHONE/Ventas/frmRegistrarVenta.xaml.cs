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


namespace Unisangil.CYLTRACK.Cyltrack_phone.Ventas
{
    public partial class frmRegistrarVenta : PhoneApplicationPage
    {

        public frmRegistrarVenta()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            ContentCliente.Visibility = System.Windows.Visibility.Collapsed;
            ContentVenta.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            VentaServiceClient servVenta = new VentaServiceClient();

            VentaBE detalle_venta = new VentaBE();

            detalle_venta.Id_Ubicacion = txtDir.Text;



            if (Convert.ToBoolean(rbIntercambio.IsChecked))
            {
                detalle_venta.Detalle_Venta.Tipo_Venta = "INTERCAMBIO";
                if (rbMarcado.IsChecked == false && rbUniversal.IsChecked == false)
                {
                    MessageBox.Show("Debe seleccionar un tipo de cilindro");
                }
                if (Convert.ToBoolean(rbMarcado.IsChecked))
                {
                    detalle_venta.Detalle_Venta.Tipo_Cilindro = "MARCADO";
                }

                else
                {
                    detalle_venta.Detalle_Venta.Tipo_Cilindro = "UVIVERSAL";
                }

            }
            else
                detalle_venta.Detalle_Venta.Tipo_Venta = "PRESTAMO";
            
            detalle_venta.Detalle_Venta.Id_Cilindro_Entrada = txtCodCilRecibido.Text;
            detalle_venta.Observaciones = txtObser.Text;
            
            servVenta.RegistrarVentaAsync(detalle_venta);
            servVenta.RegistrarVentaCompleted += new EventHandler<RegistrarVentaCompletedEventArgs>(Detalle);

            ContentVenta.Visibility = System.Windows.Visibility.Collapsed;
            ContentInicial.Visibility = System.Windows.Visibility.Visible;
            
        }
        private void Detalle(object sender, RegistrarVentaCompletedEventArgs e)
        { 
            try
            {
                if(e.Result <0)
                {
                    MessageBox.Show("Ha ocurrido un error. Intente de nuevo");
                }
                else
                    MessageBox.Show("La venta fue registrada satisfactoriamente con el Código de Venta:"+" "+ e.Result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                NavigationService.Navigate(new Uri("/Ventas/frmRegistrarVenta.xaml", UriKind.Relative));
            }

        }
        private void btnCancelarInt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnCancelarRegistro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            txtCedula.Text = "";
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ContentCliente.Visibility = System.Windows.Visibility.Collapsed;
            ContentInicial.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            servCliente.Consultar_ClienteAsync(txtCedula.Text);
            servCliente.Consultar_ClienteCompleted += new EventHandler<Consultar_ClienteCompletedEventArgs>(PoblarCliente);
            txtDir.Focus();
        }

        private void PoblarCliente(object sender, Consultar_ClienteCompletedEventArgs e)
        {
            
            try
            {
                if (e.Result.Cedula == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado");
                    NavigationService.Navigate(new Uri("/Ventas/frmRegistrarVenta.xaml", UriKind.Relative));
                }
                else
                {
                    ContentInicial.Visibility = System.Windows.Visibility.Collapsed;
                    ContentCliente.Visibility = System.Windows.Visibility.Visible;
                    

                    lblCedulaCli.Text = e.Result.Cedula;
                    txtNombres.Text = e.Result.Nombres_Cliente;
                    txtPrApellido.Text = e.Result.Apellido_1;
                    txtSgApellido.Text = e.Result.Apellido_2;
                    lblDirecciones.Text = "";

                    foreach (UbicacionBE ubi in e.Result.ListaDirecciones)
                    {
                        lblDirecciones.Text += ubi.Id_Ubicacion + "--" + ubi.Ciudad.Nombre_Ciudad + "--" + ubi.Barrio + "--" + (ubi.Direccion.Length > 20 ? ubi.Direccion.Substring(0, 20) : ubi.Direccion) + "--"+ubi.Telefono_1 + "\n";
                    }

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
                btnAceptar.Focus();
            }
        
        }

        private void rbIntercambio_Checked_1(object sender, RoutedEventArgs e)
        {
            lblTipoCil.Visibility = System.Windows.Visibility.Visible;
            rbUniversal.Visibility = System.Windows.Visibility.Visible;
            rbMarcado.Visibility = System.Windows.Visibility.Visible;
            lblObser.Visibility = System.Windows.Visibility.Visible;
            txtObser.Visibility = System.Windows.Visibility.Visible;
            btnGuardar.Visibility = System.Windows.Visibility.Visible;
        }

        private void rbPrestamo_Checked_1(object sender, RoutedEventArgs e)
        {
            lblTipoCil.Visibility = System.Windows.Visibility.Collapsed;
            rbUniversal.Visibility = System.Windows.Visibility.Collapsed;
            rbMarcado.Visibility = System.Windows.Visibility.Collapsed;
            lblCilRecibido.Visibility = System.Windows.Visibility.Collapsed;
            txtCodCilRecibido.Visibility = System.Windows.Visibility.Collapsed;
            lblObser.Visibility = System.Windows.Visibility.Visible;
            txtObser.Visibility = System.Windows.Visibility.Visible;
            btnGuardar.Visibility = System.Windows.Visibility.Visible;
            rbUniversal.IsChecked = false;
            rbMarcado.IsChecked = false;
        }

        private void rbUniversal_Checked(object sender, RoutedEventArgs e)
        {
            txtCodCilRecibido.Text = "999999999999";
            lblCilRecibido.Visibility = System.Windows.Visibility.Visible;
            txtCodCilRecibido.Visibility = System.Windows.Visibility.Visible;
        }

        private void rbMarcado_Checked(object sender, RoutedEventArgs e)
        {
            lblCilRecibido.Visibility = System.Windows.Visibility.Visible;
            txtCodCilRecibido.Visibility = System.Windows.Visibility.Visible;
            txtCodCilRecibido.Text = "";
        }

    }
}