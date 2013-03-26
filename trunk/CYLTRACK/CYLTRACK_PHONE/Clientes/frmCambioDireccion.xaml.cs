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
    public partial class frmCambioDireccion : PhoneApplicationPage
    {
        public frmCambioDireccion()
        {
            InitializeComponent();
        }

        private void btnAtrasDir_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sus datos fueron enviados satisfactoriamente");
            NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative)); 
        }
    }
}