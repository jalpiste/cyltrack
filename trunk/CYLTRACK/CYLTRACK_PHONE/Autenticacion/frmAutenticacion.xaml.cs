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
using CYLTRACK_PHONE.UsuarioService;


namespace Unisangil.CYLTRACK.CYLTRACK_PHONE.Autenticacion
{
    public partial class frmAutenticacion : PhoneApplicationPage
    {
        public frmAutenticacion()
        {
            InitializeComponent();

        }

        private void btonIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            //UsuarioServiceClient servUsuario = new UsuarioServiceClient();
            //UsuarioBE usuario = new UsuarioBE();
            //try
            //{
            //    usuario.Usuario = txtNomUsuario.Text;
            //    usuario.Contrasena_1 = txtContrasena.Text;
            //    string autentic = servUsuario.AutenticacionAsync(usuario);

            //    if (autentic == Tipo_Autenticacion.PrimeraVez.ToString())
            //    {
            //        ContRegistrar.Visibility = System.Windows.Visibility.Collapsed;
            //        ContIngresoPrimVez.Visibility = System.Windows.Visibility.Visible;
                   
            //    }
            //    if (autentic == Tipo_Autenticacion.SegundaVez.ToString())
            //    {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));      
            //    }
            //    if (autentic == Tipo_Autenticacion.Erroneo.ToString())
            //    {
            //        MessageBox.Show("El usuario ingresado no se encuentra registrado");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    NavigationService.Navigate(new Uri("~/MainPage.xaml", UriKind.Relative));
            //}

            //finally
            //{
            //    servUsuario.CloseAsync();
            //}
            
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void hprlkOlvidoContrasena_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Autenticacion/OlvidoContrasena.xaml", UriKind.Relative));
        }

        private void btnInicioConfig_Click(object sender, RoutedEventArgs e)
        {
            UsuarioServiceClient serUser = new UsuarioServiceClient();
            UsuarioBE user = new UsuarioBE();
            try
            {
                if (txtNuevaContrasena.Text == txtConfirContrasena.Text)
                {
                    user.Contrasena_1 = txtNuevaContrasena.Text;
                    user.Usuario = txtNomUsuario.Text;
                    serUser.AutenticacionAsync(user);
                }
                else
                {
                    MessageBox.Show("Las contraseñas digitadas no coinciden");
                }
            }

            catch (Exception ex)
            {
                NavigationService.Navigate(new Uri("~/MainPage.xaml", UriKind.Relative));
            }

            finally
            {
                serUser.CloseAsync();
                NavigationService.Navigate(new Uri("~/MainPage.xaml", UriKind.Relative));
            }
       

        }

        
    }
}