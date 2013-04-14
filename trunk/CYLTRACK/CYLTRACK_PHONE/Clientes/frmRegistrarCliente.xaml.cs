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

namespace Unisangi.CYLTRACK.Cyltrack_phone.Clientes
{
    public partial class frmRegistrarCliente : PhoneApplicationPage
    {
        public frmRegistrarCliente()
        {
            InitializeComponent();
        }

        private void btnMenuRegistro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); 
        
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
            ContentDatosP.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sus datos fueron enviados satisfactoriamente");
            ContentDatosP.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }


        
}
}