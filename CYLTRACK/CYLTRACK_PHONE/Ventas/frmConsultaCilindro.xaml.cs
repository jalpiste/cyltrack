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
using CYLTRACK_PHONE.CilindroService;
using CYLTRACK_PHONE.ClienteService;

namespace Unisangil.CYLTRACK.Cyltrack_phone.Ventas
{
    public partial class frmConsultaCilindro : PhoneApplicationPage
    {
        public frmConsultaCilindro()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            servCilindro.ConsultarCilindroAsync(txtCedula.Text);
            servCilindro.ConsultarCilindroCompleted += new EventHandler<ConsultarCilindroCompletedEventArgs>(PoblarCilindro);

            //ClienteServiceClient serCliente = new ClienteServiceClient();
            //serCliente.Consultar_ClienteAsync(txtCedula.Text);
            //serCliente.Consultar_ClienteCompleted += new EventHandler<Consultar_ClienteCompletedEventArgs>(PoblarCliente);
            
        }

        //private void PoblarCliente(object sender, Consultar_ClienteCompletedEventArgs e)
        //{
        //    if (txtUbicacion.Text == "CLIENTE")
        //    {
        //        txtCedula.Text = e.Result.Cedula;
        //        txtNombres.Text = e.Result.Nombres_Cliente;
        //        txtPrApellido.Text = e.Result.Apellido_1;
        //        txtSgApellido.Text = e.Result.Apellido_2;
        //        txtDir.Text = e.Result.Ubicacion.Direccion;
        //        txtBarrio.Text = e.Result.Ubicacion.Barrio;
        //        txtDepartamento.Text = e.Result.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
        //        txtCiudad.Text = e.Result.Ubicacion.Ciudad.Nombre_Ciudad;
        //        txtTel.Text = e.Result.Ubicacion.Telefono_1;
        //        btnContinuarDatos.Visibility = System.Windows.Visibility.Visible;
        //        btnConsultaNueva.Visibility = System.Windows.Visibility.Collapsed;
        //    }
        //}

        private void PoblarCilindro(object sender, ConsultarCilindroCompletedEventArgs e)
        {
            try
            {
                if (e.Result.Codigo_Cilindro == null)
                {
                    MessageBox.Show("El cilindro no se encuentra registrado");
                    NavigationService.Navigate(new Uri("/Ventas/frmConsultaCilindro.xaml", UriKind.Relative));
                }
                else
                {
                    
                    lblCilindro.Text = e.Result.Codigo_Cilindro;
                    txtAnoFab.Text = e.Result.Ano;
                    txtCodEmpresa.Text = e.Result.Fabricante.Nombre_Fabricante;
                    txtCodigoCil.Text = e.Result.Serial_Cilindro;
                    txtTamano.Text = e.Result.NTamano.Tamano;
                    txtUbicacion.Text = e.Result.Tipo_Ubicacion.Nombre_Ubicacion;
                    txtFecha.Text = Convert.ToString(e.Result.Fecha);

                    ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
                    ContentCil.Visibility = System.Windows.Visibility.Visible;

                    if (txtUbicacion.Text == "VEHICULO")
                    {
                        txtPlaca.Text = e.Result.Vehiculo.Placa;
                        txtNomCond.Text = e.Result.Vehiculo.Conductor.Nombres_Conductor + " ";
                        txtApellidosCond.Text = e.Result.Vehiculo.Conductor.Apellido_1 + " " + e.Result.Vehiculo.Conductor.Apellido_2;
                        txtRuta.Text = e.Result.Vehiculo.Ruta.Nombre_Ruta;
                        btnContinuarDatos.Visibility = System.Windows.Visibility.Visible;
                        btnConsultaNueva.Visibility = System.Windows.Visibility.Collapsed;
                    }

                    else if (txtUbicacion.Text == "CLIENTE")
                    {
                        txtCedula.Text = e.Result.Cliente.Cedula;
                        txtNombres.Text = e.Result.Cliente.Nombres_Cliente;
                        txtPrApellido.Text = e.Result.Cliente.Apellido_1;
                        txtSgApellido.Text = e.Result.Cliente.Apellido_2;
                        txtDir.Text = e.Result.Ubicacion.Direccion;
                        txtBarrio.Text = e.Result.Ubicacion.Barrio;
                        txtDepartamento.Text = e.Result.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtCiudad.Text = e.Result.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtTel.Text = e.Result.Ubicacion.Telefono_1;
                        btnContinuarDatos.Visibility = System.Windows.Visibility.Visible;
                        btnConsultaNueva.Visibility = System.Windows.Visibility.Collapsed;
                    }

                   
                    txtCedula.Text = "";    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el sistema");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            finally
            {
                
            }
        }

        
        private void btnCancelarConsulta_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnContinuarDatos_Click(object sender, RoutedEventArgs e)
        {
            if (txtUbicacion.Text == "CLIENTE")
            {
                ContentCil.Visibility = System.Windows.Visibility.Collapsed;
                ContentUbiCli.Visibility = System.Windows.Visibility.Visible;
            }
            if (txtUbicacion.Text == "VEHICULO")
            {
                ContentCil.Visibility = System.Windows.Visibility.Collapsed;
                ContentUbiVeh.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void btnCancelarConsul_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnNuevaConsulta_Click(object sender, RoutedEventArgs e)
        {
            ContentUbiCli.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnNuevaConsul_Click(object sender, RoutedEventArgs e)
        {
            ContentUbiVeh.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnConsultaNueva_Click(object sender, RoutedEventArgs e)
        {
            ContentCil.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            ContentUbiCli.Visibility = System.Windows.Visibility.Collapsed;
            ContentCil.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnAtr_Click(object sender, RoutedEventArgs e)
        {
            ContentUbiVeh.Visibility = System.Windows.Visibility.Collapsed;
            ContentCil.Visibility = System.Windows.Visibility.Visible;
        }
       
       
    }
}