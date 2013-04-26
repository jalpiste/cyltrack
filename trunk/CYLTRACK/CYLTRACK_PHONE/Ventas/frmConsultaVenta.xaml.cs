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
            ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
            ContentCliente.Visibility = System.Windows.Visibility.Visible;
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
            ContentCliente.Visibility = System.Windows.Visibility.Collapsed;
            ContentCilindro.Visibility = System.Windows.Visibility.Visible;
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