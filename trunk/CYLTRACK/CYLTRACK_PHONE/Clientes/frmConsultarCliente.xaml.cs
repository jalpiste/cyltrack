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


namespace Unisangil.CYLTRACK.Cyltrack_phone.Clientes
{
    public partial class frmConsultarCliente : PhoneApplicationPage
    {
        public frmConsultarCliente()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            servCliente.Consultar_ClienteAsync(txtCedula.Text);
            servCliente.Consultar_ClienteCompleted += new EventHandler<Consultar_ClienteCompletedEventArgs>(PoblarCliente);
            servCliente.CloseAsync();
        }

        private void PoblarCliente(object sender, Consultar_ClienteCompletedEventArgs e)
        {
           

            try
            {
                if (e.Result.Cedula == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado");
                    NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative));
                }
                else
                {
                    ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
                    ContentDatosP.Visibility = System.Windows.Visibility.Visible;

                    lblCedulaCli.Text = e.Result.Cedula.ToUpper();
                    txtNombres.Text = e.Result.Nombres_Cliente.ToUpper();
                    txtPrApellido.Text = e.Result.Apellido_1.ToUpper();
                    txtSgApellido.Text = e.Result.Apellido_2.ToUpper();
                    txtDirecciones.Text = "";
                   
                    foreach (UbicacionBE ubi in e.Result.ListaDirecciones)
                    {
                        txtDirecciones.Text += ubi.Id_Ubicacion + "--"+ ubi.Ciudad.Nombre_Ciudad + "--" + ubi.Barrio + "--"+ (ubi.Direccion.Length > 20 ? ubi.Direccion.Substring(0,20): ubi.Direccion) + "--" + ubi.Telefono_1 +"\n";
                    }
   
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
                NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative));

            }
        }

        private void hplAgregarNuevaUbi_Click(object sender, RoutedEventArgs e)
        {

            txtNuevaDir.Text = "";
            txtNuevoBarrio.Text = "";
            txtTelefono.Text = "";

            ContentModificarCliente2.Visibility = System.Windows.Visibility.Collapsed;
            ContentAgregarUbicacion.Visibility = System.Windows.Visibility.Visible;
            PageTitle.Text = "REGISTRAR UBICACIÓN";
        }

        private void AgregarUbiNueva(object sender, Agregar_UbicacionCompletedEventArgs e)
        {
            
            try
            {
                if (e.Result < 0)
                {
                    MessageBox.Show("Error al registrar la nueva dirección, por favor intente de nuevo");
                }
                else
                    MessageBox.Show("La dirección fue registrada satisfactoriamente");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema, intente nuevamente.");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative));
            }

        }
       
        private void hplModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            servCliente.Consultar_ClienteAsync(lblCedulaCli.Text);
            servCliente.Consultar_ClienteCompleted += new EventHandler<Consultar_ClienteCompletedEventArgs>(ModificarCli);
            servCliente.CloseAsync();
        }

        private void ModificarCli(object sender, Consultar_ClienteCompletedEventArgs e)
        {
           
            try
            {
                if (e.Result.Cedula == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado");
                    NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative));
                }

                else
                {
                    ContentDatosP.Visibility = System.Windows.Visibility.Collapsed;
                    ContentModificarCliente2.Visibility = System.Windows.Visibility.Visible;
                    PageTitle.Text = "MODIFICAR CLIENTE";


                    lblCedulaCli2.Text = lblCedulaCli.Text.ToUpper();
                    txtNombres2.Text = e.Result.Nombres_Cliente.ToUpper();
                    txtPrApellido2.Text = e.Result.Apellido_1.ToUpper();
                    txtSgApellido2.Text = e.Result.Apellido_2.ToUpper();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
               NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative));

            }
         
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        
        private void btnMenuConsul_Click(object sender, RoutedEventArgs e)
        {
            ContentModificarCliente2.Visibility = System.Windows.Visibility.Collapsed;
            ContentDatosP.Visibility = System.Windows.Visibility.Visible;
            PageTitle.Text = "CONSUTAR CLIENTE";
        }

        private void btnGuardarModif_Click(object sender, RoutedEventArgs e)
        {
           
            ClienteServiceClient servCliente = new ClienteServiceClient();

            ClienteBE cliente = new ClienteBE();

            cliente.Cedula = lblCedulaCli2.Text;
            cliente.Nombres_Cliente = txtNombres2.Text.ToUpper();
            cliente.Apellido_1 = txtPrApellido2.Text.ToUpper();
            cliente.Apellido_2 = txtSgApellido2.Text.ToUpper();

            UbicacionBE ubi = new UbicacionBE();

            if (Convert.ToBoolean(lblDireccion.Visibility == System.Windows.Visibility.Visible))
            {
                ubi.Id_Ubicacion = lblIdDir.Text;
                ubi.Direccion = txtDir.Text.ToUpper();
                ubi.Barrio = txtBarrio.Text.ToUpper();
                ubi.Telefono_1 = txtTel.Text.ToUpper();
                ubi.Ciudad.Id_Ciudad = "1";

                btnGuardarModif.Margin = new Thickness(19, 643, 0, 0);
                btnMenuConsul.Margin = new Thickness(224, 643, 0, 0);

                servCliente.ModificarDirClienteAsync(ubi);
                servCliente.ModificarDirClienteCompleted += new EventHandler<ModificarDirClienteCompletedEventArgs>(ModificarUbicacion);
            }

            servCliente.ModificarNombreClienteAsync(cliente);
            servCliente.ModificarNombreClienteCompleted += new EventHandler<ModificarNombreClienteCompletedEventArgs>(ModificarCliente);
            
            servCliente.CloseAsync();
                        
        }

        private void ModificarUbicacion(object sender, ModificarDirClienteCompletedEventArgs e)
        {
            
            ContentModificarCliente2.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
            try
            {
                if (e.Result < 0)
                {
                    MessageBox.Show("Error al modificar dirección del cliente, Por favor intente de nuevo");
                }
                else
                    MessageBox.Show("La dirección fue modificada satisfactoriamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema, intente nuevamente.");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative));
            }
        }
        
        private void ModificarCliente(object sender, ModificarNombreClienteCompletedEventArgs e)
        {
            
            ContentModificarCliente2.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
            try
            {
                if (e.Result < 0)
                {
                    MessageBox.Show("Error al modificar el cliente, Por favor intente de nuevo");

                }
                else
                    MessageBox.Show("El cliente fue modificado satisfactoriamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema, intente nuevamente.");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative));
            }

        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            ContentAgregarUbicacion.Visibility = System.Windows.Visibility.Collapsed;
            ContentModificarCliente2.Visibility = System.Windows.Visibility.Visible;
            PageTitle.Text = "MODIFICAR CLIENTE";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
           
            ClienteServiceClient servCliente = new ClienteServiceClient();

            ClienteBE nuevadir = new ClienteBE();
            nuevadir.Cedula = lblCedulaCli2.Text;

            UbicacionBE ubicacion = new UbicacionBE();
            ubicacion.Direccion = txtNuevaDir.Text.ToUpper();
            ubicacion.Barrio = txtNuevoBarrio.Text.ToUpper();
            ubicacion.Telefono_1 = txtTelefono.Text.ToUpper();
            CiudadBE ciu = new CiudadBE();
            ciu.Nombre_Ciudad = "1";
            ubicacion.Ciudad = ciu;
            nuevadir.Ubicacion = ubicacion;


            servCliente.Agregar_UbicacionAsync(nuevadir);
            servCliente.Agregar_UbicacionCompleted += new EventHandler<Agregar_UbicacionCompletedEventArgs>(AgregarUbiNueva);
            servCliente.CloseAsync();
        }

        private void btnNuevaCons_Click(object sender, RoutedEventArgs e)
        {
            ContentDatosP.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            servCliente.ConsultarDirCliPorUbicaAsync(txtIdDir.Text);
            servCliente.ConsultarDirCliPorUbicaCompleted += new EventHandler<ConsultarDirCliPorUbicaCompletedEventArgs>(ModificarDireccion);
     
        }

        private void ModificarDireccion(object sender, ConsultarDirCliPorUbicaCompletedEventArgs e)
        {

            try
            {
                if (e.Result.Id_Ubicacion == null)
                {
                    MessageBox.Show("La dirección no se encuentra registrada, intente de nuevo");
                }
                else
                {
                    lblIdDir.Text = e.Result.Id_Ubicacion;
                    txtDir.Text = e.Result.Direccion.ToUpper();
                    txtBarrio.Text = e.Result.Barrio.ToUpper();
                    txtTel.Text = e.Result.Telefono_1.ToUpper();

                    lblIdDirec.Visibility = System.Windows.Visibility.Visible;
                    lblIdDir.Visibility = System.Windows.Visibility.Visible;
                    lblDireccion.Visibility = System.Windows.Visibility.Visible;
                    txtDir.Visibility = System.Windows.Visibility.Visible;
                    lblBarrio.Visibility = System.Windows.Visibility.Visible;
                    txtBarrio.Visibility = System.Windows.Visibility.Visible;
                    lblDep.Visibility = System.Windows.Visibility.Visible;
                    lblDepNom.Visibility = System.Windows.Visibility.Visible;
                    lblCiudad.Visibility = System.Windows.Visibility.Visible;
                    lblCiudadNombre.Visibility = System.Windows.Visibility.Visible;
                    lblTel.Visibility = System.Windows.Visibility.Visible;
                    txtTel.Visibility = System.Windows.Visibility.Visible;
                }

                txtIdDir.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                NavigationService.Navigate(new Uri("/Clientes/frmConsultarCliente.xaml", UriKind.Relative));
            }
        }

        

        

        




    }
}