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
using CYLTRACK_PHONE.RutaService;

namespace Unisangil.CYLTRACK.CYLTRACK_PHONE.Clientes
{
    public partial class frmRegistrarCliente : PhoneApplicationPage
    {
        public frmRegistrarCliente()
        {
            InitializeComponent();
             //RutaServicesClient servRuta = new RutaServicesClient();
            
             //   try
             //   {
             //       List<CiudadBE> datosCiudades = new List<CiudadBE>(servRuta.ConsultaDepartamentoyCiudades());
             //       foreach (CiudadBE datos in datosCiudades)
             //       {
             //           lstCiudad.Items.Add(datos.Nombre_Ciudad);
             //           lstDep.Items.Add(datos.Departamento.Nombre_Departamento);
             //       }
             //   }
             //   catch (Exception ex)
             //   {
             //       NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); 
             //   }
             //   finally
             //   {
             //       servRuta.CloseAsync();
             //   }
            
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
            //ClienteServiceClient servCliente = new ClienteServiceClient();
            
            //String resp;
            //try
            //{
                //resp = servCliente.Consultar_ExistenciaAsync(txtCedula.Text);

                //if (resp != "Ok")
                //{
                //    MessageBox.Show("El cliente ya se encuentra registrado en el sistema");
                //}
                //else
                //{
                    ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
                    ContentDatosP.Visibility = System.Windows.Visibility.Visible;
                //}
            //}
            //catch (Exception ex)
            //{
              //  NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); 
        
            //}
            //finally
            //{
            //    servCliente.CloseAsync();
            //}
            
           
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //ClienteServiceClient servCliente = new ClienteServiceClient();
            //String resp;

            //ClienteBE cliente = new ClienteBE();

            //try
            //{
            //    cliente.Cedula = txtCedula.Text;
            //    cliente.Nombres_Cliente = txtNombres.Text;
            //    cliente.Apellido_1 = txtPrApellido.Text;
            //    cliente.Apellido_2 = txtSgApellido.Text;

            //    UbicacionBE ubicacion = new UbicacionBE();
            //    List<string> lstDatoDireccion = new List<string>();
            //    lstDatoDireccion.Add(txtDir.Text);
            //    //ubicacion.Direccion = lstDatoDireccion;
            //    ubicacion.Barrio = txtBarrio.Text;
            //    ubicacion.Telefono_1 = txtTel.Text;

            //    CiudadBE ciucli = new CiudadBE();
            //   // ciucli.Nombre_Ciudad = lstCiudad.SelectedValue;
            //    ubicacion.Ciudad = ciucli;
            //    cliente.Ubicacion = ubicacion;

            //    DepartamentoBE depcli = new DepartamentoBE();
            //   // depcli.Nombre_Departamento = lstDepartamento.SelectedValue;
            //    ciucli.Departamento = depcli;

            //   // resp = servCliente.Registrar_ClienteAsync(cliente);

                MessageBox.Show("El cliente fue registrado satisfactoriamente");

            //}
            //catch (Exception ex)
            //{
            //    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); 
            //}
            //finally
            //{
            //    servCliente.CloseAsync();
                NavigationService.Navigate(new Uri("/Clientes/frmRegistrarCliente.xaml", UriKind.Relative));
            //}
            
            //ContentDatosP.Visibility = System.Windows.Visibility.Collapsed;
            //ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }
                
}
}