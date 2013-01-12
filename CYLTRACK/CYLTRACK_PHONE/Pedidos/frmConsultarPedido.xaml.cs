﻿using System;
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

namespace Cyltrack_phone.Pedidos
{
    public partial class frmConsultarPedido : PhoneApplicationPage
    {
        public frmConsultarPedido()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
            ContentConsultar.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void hplCancelarPedido_Click(object sender, RoutedEventArgs e)
        {
            ContentConsultar.Visibility = System.Windows.Visibility.Collapsed;
            ContentCancelar.Visibility = System.Windows.Visibility.Visible;
        }

        private void hplModificarPedido_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pedidos/frmModificarPedido.xaml", UriKind.Relative));
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}