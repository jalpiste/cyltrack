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

namespace Cyltrack_phone.Clientes
{
    public partial class frmConsultarCliente : PhoneApplicationPage
    {
        public frmConsultarCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
            ContentDatosP.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnMenuReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void hplModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            ContentDatosP.Visibility = System.Windows.Visibility.Collapsed;
            ContentModificarCliente.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void hplNuevaDir_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Clientes/frmCambioDireccion.xaml", UriKind.Relative));
        
        }

        private void hplNuevoTel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Clientes/frmCambiarTelefono.xaml", UriKind.Relative));
        }

        private void btnMenuConsul_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnGuardarModif_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sus datos fueron enviados satisfactoriamente");
            ContentModificarCliente.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }

        
    }
}