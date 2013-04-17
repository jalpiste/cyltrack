﻿using System;
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

namespace Unisangil.CYLTRACK.Cyltrack_phone.Ventas
{
    public partial class frmConsultaVenta : PhoneApplicationPage
    {
        public frmConsultaVenta()
        {
            InitializeComponent();
        }
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            ContentBusq.Visibility = System.Windows.Visibility.Collapsed;
            ContentCliente.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnNvConsulta_MouseEnter(object sender, MouseEventArgs e)
        {
            ContentCliente.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e)
        {
            ContentCliente.Visibility = System.Windows.Visibility.Collapsed;
            ContentCilindro.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            ContentCliente.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;

        }

        private void btnNvConsulta_Click(object sender, RoutedEventArgs e)
        {
            ContentCilindro.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
        }

        
        private void hplDevCil_Click(object sender, RoutedEventArgs e)
        {
            ContentCilindro.Visibility = System.Windows.Visibility.Collapsed;
            ContentCambioCil.Visibility = System.Windows.Visibility.Visible;
            ContentObserv.Visibility = System.Windows.Visibility.Visible;
            PageTitle.Text = "MODIFICAR VENTA";
        }

        

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Los datos fueron enviados satisfactoriamente");
            grdDevCil.Visibility = System.Windows.Visibility.Collapsed;
            ContentCambioCil.Visibility = System.Windows.Visibility.Collapsed;
            ContentObserv.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;


        }

        private void btnAtrasDev_Click(object sender, RoutedEventArgs e)
        {
            ContentCambioCil.Visibility = System.Windows.Visibility.Collapsed;
            ContentObserv.Visibility = System.Windows.Visibility.Collapsed;
            ContentCilindro.Visibility = System.Windows.Visibility.Visible;
            PageTitle.Text = "CONSULTAR VENTA";
            btnMenu.Visibility = System.Windows.Visibility.Visible;
            btnAtrasMod.Visibility = System.Windows.Visibility.Collapsed;
            btnNvConsulta.Visibility = System.Windows.Visibility.Visible;
            btnGuardarMod.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void lstDevolucion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstDevolucion.SelectedIndex == 1) 
            {
                ContentCambioCil.Visibility = System.Windows.Visibility.Visible;
                
            }
        }

        private void btnMenuPrincipal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnAtrasMod_Click(object sender, RoutedEventArgs e)
        {
            ContentCilindro.Visibility = System.Windows.Visibility.Collapsed;
            ContentCilindro.Visibility = System.Windows.Visibility.Visible;
            hplModVenta.Visibility = System.Windows.Visibility.Visible;
            hplDevCil.Visibility = System.Windows.Visibility.Visible;
            PageTitle.Text = "CONSULTAR VENTA";
            btnMenu.Visibility = System.Windows.Visibility.Visible;
            btnAtrasMod.Visibility = System.Windows.Visibility.Collapsed;
            btnNvConsulta.Visibility = System.Windows.Visibility.Visible;
            btnGuardarMod.Visibility = System.Windows.Visibility.Collapsed;
            
        }

        private void btnGuardarMod_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sus datos fueron enviados satisfactoriamente");
            ContentCilindro.Visibility = System.Windows.Visibility.Collapsed;
            ContentObserv.Visibility = System.Windows.Visibility.Collapsed;
            grdDevCil.Visibility = System.Windows.Visibility.Collapsed;
            ContentBusq.Visibility = System.Windows.Visibility.Visible;
            hplModVenta.Visibility = System.Windows.Visibility.Visible;
            hplDevCil.Visibility = System.Windows.Visibility.Visible;

        }
        private void hplModVenta_Click(object sender, RoutedEventArgs e)
        {
            btnMenu.Visibility = System.Windows.Visibility.Collapsed;
            btnAtrasMod.Visibility = System.Windows.Visibility.Visible;
            btnNvConsulta.Visibility = System.Windows.Visibility.Collapsed;
            btnGuardarMod.Visibility = System.Windows.Visibility.Visible;
            hplModVenta.Visibility = System.Windows.Visibility.Collapsed;
            hplDevCil.Visibility = System.Windows.Visibility.Collapsed;
            PageTitle.Text = "MODIFICAR VENTA";
        }

               

    }
}