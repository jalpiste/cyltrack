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

namespace Cyltrack_phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<ProcesoCyltrack> listaCyltrack = new List<ProcesoCyltrack>();

            listaCyltrack.Add(new ProcesoCyltrack("Cliente"));
            listaCyltrack.Add(new ProcesoCyltrack("Venta"));
            listaCyltrack.Add(new ProcesoCyltrack("Pedido"));
            ListProcesoCyltrack.ItemsSource = listaCyltrack;

        }
        private void hplDato1_Click(object sender, RoutedEventArgs e)
        {
            if (((System.Windows.Controls.ContentControl)(sender)).Content.ToString() == "Registrar Cliente")
                NavigationService.Navigate(new Uri("/Clientes/frmRegistrarCliente.xaml", UriKind.Relative));
            else if (((System.Windows.Controls.ContentControl)(sender)).Content.ToString() == "Consultar Cliente")
                NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative));


            if (((System.Windows.Controls.ContentControl)(sender)).Content.ToString() == "Registrar Pedido")
                NavigationService.Navigate(new Uri("/Pedidos/frmRegistrarPedido.xaml", UriKind.Relative));
            else if (((System.Windows.Controls.ContentControl)(sender)).Content.ToString() == "Consultar Pedido")
                NavigationService.Navigate(new Uri("/Pedidos/frmConsultarPedido.xaml", UriKind.Relative));


            if (((System.Windows.Controls.ContentControl)(sender)).Content.ToString() == "Registrar Venta")
                NavigationService.Navigate(new Uri("/Ventas/frmRegistrarVenta.xaml", UriKind.Relative));
            else if (((System.Windows.Controls.ContentControl)(sender)).Content.ToString() == "Consultar Venta")
                NavigationService.Navigate(new Uri("/Ventas/frmConsultaVenta.xaml", UriKind.Relative));
            else if (((System.Windows.Controls.ContentControl)(sender)).Content.ToString() == "Consultar Cilindro")
                NavigationService.Navigate(new Uri("/Ventas/frmConsultaCilindro.xaml", UriKind.Relative));

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Autenticacion/frmAutenticacion.xaml", UriKind.Relative));
        }
    }
}