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
using CYLTRACK_PHONE.ClienteService;


namespace Unisangil.CYLTRACK.CYLTRACK_PHONE.Clientes
{
    public partial class frmRegistrarCliente : PhoneApplicationPage
    {
        public frmRegistrarCliente()
        {
            InitializeComponent();
            
           
        }

        private void btnMenuRegistro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); 
        
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
  
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
         
            ClienteServiceClient servCliente = new ClienteServiceClient();
            servCliente.Consultar_ClienteAsync(txtCedula.Text);
            servCliente.Consultar_ClienteCompleted += new EventHandler<Consultar_ClienteCompletedEventArgs>(ConsultarCliente);
        }

        private void ConsultarCliente(object sender, Consultar_ClienteCompletedEventArgs e)
         {
            ClienteServiceClient servCliente = new ClienteServiceClient();

            try
            {
                if (e.Result.Cedula != null)
                {
                    MessageBox.Show("El cliente ya se encuentra registrado");
                    NavigationService.Navigate(new Uri("/Clientes/frmRegistrarCliente.xaml", UriKind.Relative));
                }
                else
                {
                    
                    txtNombres.Focus();
                    lblCedulaCli.Text = txtCedula.Text;


                    txtNombres.Text = "";
                    txtPrApellido.Text = "";
                    txtSgApellido.Text = "";
                    txtDir.Text = "";
                    txtBarrio.Text = "";
                    txtTel.Text = "";
                    
                    ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
                    ContentDatosP.Visibility = System.Windows.Visibility.Visible;
                    txtNombres.Focus();
                }
                txtCedula.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema");
                
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

            }
            finally
            {
                servCliente.CloseAsync();
            }
           
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();

            ClienteBE cliente = new ClienteBE();


                cliente.Cedula = lblCedulaCli.Text;
                cliente.Nombres_Cliente = txtNombres.Text.ToUpper();
                cliente.Apellido_1 = txtPrApellido.Text.ToUpper();
                cliente.Apellido_2 = txtSgApellido.Text.ToUpper();

                UbicacionBE ubicacion = new UbicacionBE();
                ubicacion.Direccion = txtDir.Text.ToUpper();
                ubicacion.Barrio = txtBarrio.Text.ToUpper();
                ubicacion.Telefono_1 = txtTel.Text;
                CiudadBE ciudad = new CiudadBE();
                ciudad.Nombre_Ciudad = lblCiudadNombre.Text.ToUpper();
                ubicacion.Ciudad = ciudad;                          
                cliente.Ubicacion = ubicacion;

            
            servCliente.Registrar_ClienteAsync(cliente);
            servCliente.Registrar_ClienteCompleted += new EventHandler<Registrar_ClienteCompletedEventArgs>(RegistrarCliente);
            servCliente.CloseAsync();
        }

        private void RegistrarCliente(object sender, Registrar_ClienteCompletedEventArgs e)
        {
            ContentDatosP.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
            try
            {
            if(e.Result <0)
            {
                MessageBox.Show("Error al crear el cliente, Por favor intente de nuevo");

            }
            else
               MessageBox.Show("El cliente fue registrado satisfactoriamente. Código: " + e.Result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema, intente nuevamente.");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                NavigationService.Navigate(new Uri("/Clientes/frmRegistrarCliente.xaml", UriKind.Relative));
            }

        }
                
    }
}