﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.CilindroService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmConsultarCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigoCilindro.Focus();
        }

        protected void txtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            SetFocus(DivInfoCilindro);
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            long respConsultaExistencias;
            
            try
            {
                respConsultaExistencias = servCilindro.ConsultarExistenciaCilindro(txtCodigoCilindro.Text);

                if (respConsultaExistencias == 0)
                {
                    MessageBox.Show("El código digitado no se encuentra registrado en el sistema", "Consulta de Cilindros");
                }
                else
                {
                    CilindroBE respConsultaCilindro = servCilindro.ConsultarCilindro(txtCodigoCilindro.Text);

                    TxtAno.Text = respConsultaCilindro.Ano;
                    TxtEmpresa.Text = respConsultaCilindro.Fabricante.Nombre_Fabricante;
                    TxtCodigo.Text = respConsultaCilindro.Serial_Cilindro;
                    TxtUbicacion.Text = respConsultaCilindro.Tipo_Ubicacion.Nombre_Ubicacion;
                    TxtTamano.Text = respConsultaCilindro.NTamano.Tamano;
                    txtCodigoTotal.Text = respConsultaCilindro.Codigo_Cilindro;
                    TxtRegistro.Text = Convert.ToString(respConsultaCilindro.Fecha);

                    DivDatosCilindro.Visible = true;
                    BtnNuevaConsulta.Visible = true;

                    if (TxtUbicacion.Text == Ubicacion.VEHICULO.ToString())
                    {
                        TxtPlaca.Text = respConsultaCilindro.Vehiculo.Placa;
                        TxtConductor.Text = respConsultaCilindro.Vehiculo.Conductor.Nombres_Conductor;
                        TxtRuta.Text = respConsultaCilindro.Vehiculo.Ruta.Nombre_Ruta;

                        DivInfoVehiculo.Visible = true;
                    }

                    if (TxtUbicacion.Text == Ubicacion.CLIENTE.ToString())
                    {
                        txtCedula.Text = respConsultaCilindro.Tipo_Ubicacion.Ubicacion.Cliente.Cedula;
                        TxtNombreCliente.Text = respConsultaCilindro.Tipo_Ubicacion.Ubicacion.Cliente.Nombres_Cliente;
                        TxtPrimerApellido.Text = respConsultaCilindro.Tipo_Ubicacion.Ubicacion.Cliente.Apellido_1;
                        TxtSegundoApellido.Text = respConsultaCilindro.Tipo_Ubicacion.Ubicacion.Cliente.Apellido_2;
                        TxtDireccion.Text = respConsultaCilindro.Tipo_Ubicacion.Ubicacion.Direccion;
                        TxtBarrio.Text = respConsultaCilindro.Tipo_Ubicacion.Ubicacion.Barrio;
                        TxtCiudad.Text = respConsultaCilindro.Tipo_Ubicacion.Ubicacion.Ciudad.Nombre_Ciudad;
                        TxtDepartamento.Text = respConsultaCilindro.Tipo_Ubicacion.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        TxtTelefono.Text = respConsultaCilindro.Tipo_Ubicacion.Ubicacion.Telefono_1;
                        Txtentrega.Text = Convert.ToString(respConsultaCilindro.Fecha);

                        DivInfoCilindro.Visible = true;
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCilindro.Close();
            }

        }



        protected void BtnNuevaConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                DivDatosCilindro.Visible = false;
                DivInfoCilindro.Visible = false;
            }
            finally
            {
                Response.Redirect("~/Cilindros/frmConsultarCilindro.aspx");
            }

        }

        protected void BtnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

    }
}