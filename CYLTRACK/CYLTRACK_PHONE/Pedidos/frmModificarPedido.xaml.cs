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

namespace Unisangi.CYLTRACK.Cyltrack_phone.Pedidos
{
    public partial class frmModificarPedido : PhoneApplicationPage
    {
        public frmModificarPedido()
        {
            InitializeComponent();
        }

       
      
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Los datos fueron guardados satisfactoriamente");
            ContentModificar.Visibility = System.Windows.Visibility.Collapsed;
            NavigationService.Navigate(new Uri("/Pedidos/frmConsultarPedido.xaml", UriKind.Relative));
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

      
    }
}