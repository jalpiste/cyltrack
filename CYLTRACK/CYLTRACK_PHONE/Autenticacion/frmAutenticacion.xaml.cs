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

namespace CYLTRACK_PHONE.Autenticacion
{
    public partial class frmAutenticacion : PhoneApplicationPage
    {
        public frmAutenticacion()
        {
            InitializeComponent();

        }

        private void btonIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void hprlkOlvidoContrasena_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Autenticacion/OlvidoContrasena.xaml", UriKind.Relative));
        }

        
    }
}