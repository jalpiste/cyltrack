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

namespace Cyltrack_phone.Ventas
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
            ContentCilindro.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnConsultar_MouseEnter(object sender, MouseEventArgs e)
        {
            ContentInicial.Visibility = System.Windows.Visibility.Collapsed;
            ContentCliente.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            ContentCilindro.Visibility = System.Windows.Visibility.Collapsed;
            ContentInicial.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnCancelarInt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnCancelarRegistro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}