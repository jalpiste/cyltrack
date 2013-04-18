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

namespace CYLTRACK_PHONE.Pedidos
{
    public partial class frmRegistrarPedido : PhoneApplicationPage
    {
        public frmRegistrarPedido()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
            ContentRegistrar.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

     
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Los datos fueron guardados satisfactoriamente");
            ContentRegistrar.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }   
    }
}