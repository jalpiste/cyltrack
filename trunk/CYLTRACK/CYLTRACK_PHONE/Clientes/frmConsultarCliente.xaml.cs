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
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void hplModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            ContentDatosP.Visibility = System.Windows.Visibility.Collapsed;
            ContentModificarCliente.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void hplNuevaDir_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Clientes/frmCambioDireccion.xaml", UriKind.Relative));
        
        }

        private void hplNuevoTel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Clientes/frmCambiarTelefono.xaml", UriKind.Relative));
        }
    
        
        
    }
}