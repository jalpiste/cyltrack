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

namespace Unisangil.CYLTRACK.CYLTRACK_PHONE.Autenticacion
{
    public partial class frmRegistrarUsuario : PhoneApplicationPage
    {
        public frmRegistrarUsuario()
        {
            InitializeComponent();
        }
        private void btnCrearUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Los datos fueron enviados satisfactoriamente");

        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e)
        {
            ContentRegisUser.Visibility = System.Windows.Visibility.Visible;
            ContRegistrar.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}