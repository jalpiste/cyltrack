﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.RutaService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account
{
    public partial class frmcrearcliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtCedula.Focus();
            }
            
            if (!IsPostBack)
            {
                RutaServicesClient servRuta = new RutaServicesClient();
                try
                {
                    List<CiudadBE> datosCiudades = new List<CiudadBE>(servRuta.ConsultaDepartamentoyCiudades());
                    foreach (CiudadBE datos in datosCiudades)
                    {
                        lstCiudad.Items.Add(datos.Nombre_Ciudad);
                        lstDepartamento.Items.Add(datos.Departamento.Nombre_Departamento);
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }
                finally
                {
                    servRuta.Close();
                }
            }
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            
            String resp;
            try
            {
                resp = servCliente.Consultar_Existencia(txtCedula.Text);

                if (resp != "Ok")
                {
                    MessageBox.Show("El cliente ya se encuentra registrado en el sistema", "Registrar Cliente");
                }
                else
                {
                    divInfoCliente.Visible = true;
                    btnGuardar.Visible = true;
                    txtNombreCliente.Focus();
                    txtCedulaCli.Text = txtCedula.Text;
                    txtCedula.Text = "";
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
            }
        }
        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            String resp;

            ClienteBE registrar_cli = new ClienteBE();

            try
            {
                registrar_cli.Cedula = txtCedulaCli.Text;
                registrar_cli.Nombres_Cliente = txtNombreCliente.Text;
                registrar_cli.Apellido_1 = txtPrimerApellido.Text;
                registrar_cli.Apellido_2 = txtSegundoApellido.Text;
                
                UbicacionBE ubicacion = new UbicacionBE();
                List<string> lstDatoDireccion = new List<string>();
                lstDatoDireccion.Add(txtDireccion.Text);
                ubicacion.Direccion = lstDatoDireccion;
                ubicacion.Barrio = txtBarrio.Text;
                ubicacion.Telefono_1 = txtTelefono.Text;
                
                CiudadBE ciucli = new CiudadBE();
                ciucli.Nombre_Ciudad = lstCiudad.SelectedValue;
                ubicacion.Ciudad = ciucli;
                registrar_cli.Ubicacion = ubicacion;

                DepartamentoBE depcli = new DepartamentoBE();
                depcli.Nombre_Departamento = lstDepartamento.SelectedValue;
                ciucli.Departamento = depcli;
                
                resp = servCliente.Registrar_Cliente(registrar_cli);

                MessageBox.Show("El cliente fue registrado satisfactoriamente", "Registrar Cliente");
                
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
                Response.Redirect("~/Clientes/frmRegistrarCliente.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreCliente.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtDireccion.Text = "";
            txtBarrio.Text = "";
            txtTelefono.Text = "";
        }

        protected void lstCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTelefono.Focus();
        }

        protected void lstDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCiudad.Focus();
        }
    }
}