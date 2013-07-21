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
using CYLTRACK_PHONE.PedidoService;

namespace Unisangil.CYLTRACK.Cyltrack_phone.Pedidos
{
    public partial class frmRegistrarPedido : PhoneApplicationPage
    {
        public frmRegistrarPedido()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE pedido = new PedidoBE();
            //PedidoBE[] consulta = servPedido.Consultar_PedidoAsync(pedido);
            //PedidoBE consultar_ped = new PedidoBE();

            try
            {

                //foreach (PedidoBE info in consulta)
                //{
                //    txtNombres.Text = info.Cliente.Nombres_Cliente;
                //    txtPrApellido.Text = info.Cliente.Apellido_1;
                //    txtSgApellido.Text = info.Cliente.Apellido_2;
                //    lstDir.SelectedValue = info.Ubicacion.Direccion;// como llamar todas las direcciones disponibles para el cliente???
                //    lblCiudad.Text = info.Ciudad.Nombre_Ciudad;
                //    lstTel.SelectedValue = info.Ubicacion.Telefono_1;
                //}

                ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
                ContentRegistrar.Visibility = System.Windows.Visibility.Visible;
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                servPedido.CloseAsync();
                NavigationService.Navigate(new Uri("/Pedidos/frmRegistrarPedido.xaml", UriKind.Relative));
            }
 
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE registrar_ped = new PedidoBE();
            //String infPedido;

            try
            {

                //registrar_ped.Vehiculo.Placa = Convert.ToString (lstVehiculo.SelectedValue);
                //registrar_ped.Ruta.Nombre_Ruta = lblRuta.Text;
                ////registrar_ped.Detalle_Ped.Tamano.Tamano = GRIDVIEW; // como asignarle a la base de datos la información del pedido que está en la lista (tam_cant)
                //registrar_ped.Detalle_Ped.Cantidad = GRIDVIEW;

                //infPedido = servPedido.Registrar_PedidoAsync (registrar_ped);

                //if (infPedido == "Ok")
                //{
                //    MessageBox.Show("Sus datos fueron enviados satisfactoriamente");
                //}
                //else
                //{
                //    MessageBox.Show("Error al intentar registrar el pedido");

                //}

                ContentRegistrar.Visibility = System.Windows.Visibility.Collapsed;
                ContentBusq.Visibility = System.Windows.Visibility.Visible;
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                servPedido.CloseAsync();
                NavigationService.Navigate(new Uri("/Pedidos/frmRegistrarPedido.xaml", UriKind.Relative));
            }
 
        }
    }
}