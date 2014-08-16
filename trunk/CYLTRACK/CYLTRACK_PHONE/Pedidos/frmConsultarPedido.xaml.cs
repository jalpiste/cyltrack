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
    public partial class frmConsultarPedido : PhoneApplicationPage
    {
        public frmConsultarPedido()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            PedidoServiceClient servPedido = new PedidoServiceClient();
            PedidoBE consultar_ped = new PedidoBE();

            //PedidoBE[] consulta = servPedido.Consultar_PedidoAsync (consultar_ped);

            try
            {

                //foreach (PedidoBE info in consulta)
                //{

                //    //lblCod.Text = info.Id_Pedido;
                //    //txtNombres.Text = info.Cliente.Nombres_Cliente;
                //    //txtPrApellido.Text = info.Cliente.Apellido_1;
                //    //txtSgApellido.Text = info.Cliente.Apellido_2;
                //    //txtDir.Text = info.Ubicacion.Direccion;
                //    //txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                //    //txtTel.Text = info.Ubicacion.Telefono_1;

                //    //txtVehiculo.Text = info.Vehiculo.Placa;
                //    //txtRuta.Text = info.Ruta.Nombre_Ruta;
                //    ////GRIDVIEW lstAgregar.Text = info.Detalle_Ped.Tamano.Tamano; // como obtener el valor del tamaño y ponerlo en la primera parte de la lista
                //    ////GRIDWIEW lstAgregar.Text = info.Detalle_Ped.Cantidad; // como obtener el valor de la cantidad y ponerlo en la segunda parte de la lista
                //    //lblFechaPedido.Text = Convert.ToString(info.Fecha);

                //}
                ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
                ContentConsultar.Visibility = System.Windows.Visibility.Visible;
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                servPedido.CloseAsync();
                NavigationService.Navigate(new Uri("/Pedidos/frmConsultarPedido.xaml", UriKind.Relative));
            }
 

        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        private void hplCancelarPedido_Click(object sender, RoutedEventArgs e)
        {
            ContentConsultar.Visibility = System.Windows.Visibility.Collapsed;
            ContentCancelar.Visibility = System.Windows.Visibility.Visible;
            PageTitle.Text = "CANCELAR PEDIDO";
        }

        private void hplModificarPedido_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pedidos/frmModificarPedido.xaml", UriKind.Relative));
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnMenuConsul_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnMenuConsul2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnNuevaConsul_Click(object sender, RoutedEventArgs e)
        {
            ContentConsultar.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnAtrasCancel_Click(object sender, RoutedEventArgs e)
        {
            ContentCancelar.Visibility = System.Windows.Visibility.Collapsed;
            ContentConsultar.Visibility = System.Windows.Visibility.Visible;
            PageTitle.Text = "CONSULTAR PEDIDO";
        }

        private void btnGuardarCancel_Click(object sender, RoutedEventArgs e)
        {

            PedidoServiceClient servPedido = new PedidoServiceClient();
            //   String resp;
            PedidoBE cancelar_ped = new PedidoBE();

            try
            {
                
                cancelar_ped.Motivo_Cancel = txtObservaciones.Text;
                //cancelar_ped.Fecha = Convert.ToDateTime(lblFecha.Text);

                //resp = servPedido.Cancelar_PedidoAsync(cancelar_ped);

                //if (resp == "Ok")
                //{
                //    MessageBox.Show("Sus datos fueron enviados satisfactoriamente");
                //}
                //else
                //{
                //    MessageBox.Show("No se pudo cancelar el pedido en el sistema");
                //}

                ContentCancelar.Visibility = System.Windows.Visibility.Collapsed;
                ContentBusq.Visibility = System.Windows.Visibility.Visible;
                PageTitle.Text = "CONSULTAR PEDIDO";
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                servPedido.CloseAsync();
                NavigationService.Navigate(new Uri("/Pedidos/frmConsultarPedido.xaml", UriKind.Relative));
            }
 
        }  
        
        
    }
}