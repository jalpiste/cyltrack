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
    public partial class frmModificarPedido : PhoneApplicationPage
    {
        public frmModificarPedido()
        {
            InitializeComponent();
        }



        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            //   String resp;
            PedidoBE modificar_ped = new PedidoBE();

            try
            {
              
                //modificar_ped.Ubicacion.Direccion = Convert.ToString(lstDir.SelectedValue);
                //modificar_ped.Vehiculo.Placa = lstPlaca.Text;
                //modificar_ped.Ubicacion.Telefono_1 = Convert.ToString(lstTel.SelectedValue);
                //modificar_ped.Detalle_Ped.Tamano.Tamano = GRIDVIEW; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
                //modificar_ped.Detalle_Ped.Cantidad = GRIDVIEW; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista

                //resp = servPedido.Modificar_PedidoAsync (modificar_ped);

                //if (resp == "Ok")
                //{
                //    MessageBox.Show("Los datos fueron guardados satisfactoriamente");
                //}
                //else
                //{
                //    MessageBox.Show("Error al intentar modificar el pedido");
                //}

                ContentModificar.Visibility = System.Windows.Visibility.Collapsed;
                NavigationService.Navigate(new Uri("/Pedidos/frmConsultarPedido.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                servPedido.CloseAsync();
                NavigationService.Navigate(new Uri("/Pedidos/frmModificarPedido.xaml", UriKind.Relative));
            }
 
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

      
    }
}