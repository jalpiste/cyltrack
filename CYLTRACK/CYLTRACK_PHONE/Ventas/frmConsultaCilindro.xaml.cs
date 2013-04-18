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
    public partial class frmConsultaCilindro : PhoneApplicationPage
    {
        public frmConsultaCilindro()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
            ContentCil.Visibility = System.Windows.Visibility.Visible;
            txtCedula.Text = "";
        }

        private void btnCancelarConsulta_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnContinuarDatos_Click(object sender, RoutedEventArgs e)
        {
            if (txtUbicacion.Text == "Cliente")
            {
                ContentCil.Visibility = System.Windows.Visibility.Collapsed;
                ContentDatosP.Visibility = System.Windows.Visibility.Visible;

            }

        }

        private void btnCancelarConsul_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnNuevaConsulta_Click(object sender, RoutedEventArgs e)
        {
            ContentDatosP.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            ContentDatosP.Visibility = System.Windows.Visibility.Collapsed;
            ContentCil.Visibility = System.Windows.Visibility.Visible;
        }

       
       
    }
}