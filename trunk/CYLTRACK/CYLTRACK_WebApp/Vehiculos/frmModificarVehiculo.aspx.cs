using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VehiculoService;
using System.Windows.Forms;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Vehiculos
{
    public partial class frmModificarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPlaca.Focus();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            VehiculoBE consultar_vehiculo = new VehiculoBE();
            
            try
            {
                consultar_vehiculo.Placa = txtPlaca.Text;
                VehiculoBE[] consulta = servVehiculo.Consultar_Vehiculo(consultar_vehiculo);


                foreach (VehiculoBE info in consulta)
                {
                    
                    if (info.Placa != txtPlaca.Text)
                    {
                        txtPlaca.Text = "";
                        txtIdVehiculo.Focus();
                        txtIdVehiculo.Text = info.Placa;
                        txtMarca.Text = info.Marca;
                        txtCilindraje.Text = info.Cilindraje;
                        txtModelo.Text = info.Modelo;
                        txtMotor.Text = info.Motor;
                        txtChasis.Text = info.Chasis;

                        txtCedula.Text = info.Ced_Prop;
                        txtNombre.Text = info.Nombres_Prop;
                        txtPrimerApellido.Text = info.Apellido_1_Prop;
                        txtSegundoApellido.Text = info.Apellido_2_Prop;

                        lblImprimirCedula.Text = info.Conductor_Vehiculo.Conductor.Cedula;
                        txtNombreCond.Text = info.Conductor_Vehiculo.Conductor.Nombres_Conductor;
                        txtPrimerApellidoCond.Text = info.Conductor_Vehiculo.Conductor.Apellido_1;
                        txtSegundoApellidoCond.Text = info.Conductor_Vehiculo.Conductor.Apellido_2;
          
                        txtRuta.Text = info.Ruta.Nombre_Ruta;
                        
                        DivDatosVehiculo.Visible = true;
                        DivPropietario.Visible = true;
                        DivAsigRuta.Visible = true;
                        DivConductor.Visible = true;
                        DivConductorAsignado.Visible = true;
                        divDatosRuta.Visible = true;
                        btnGuardar.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("La placa del vehículo no se encuentra registrada en el sistema", "Modificar Vehículo");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }

            finally
            {
                servVehiculo.Close();
            }
        }


        //protected void btnModificar_Click(object sender, EventArgs e)
        //{
        //    txtIdVehiculo.Enabled = true;
        //    txtMarca.Enabled = true;
        //    txtCilindraje.Enabled = true;
        //    txtModelo.Enabled = true;
        //    txtMotor.Enabled = true;
        //    txtChasis.Enabled = true;
        //    txtCedula.Enabled = true;
        //    txtRuta.Visible = false;
        //    lstRuta.Visible = true;
        //    lblPost.Text = "Asignación de Ruta";
        //    lblPoster2.Text = "Asignación de Conductor";
        //    txtNombre.Enabled = true;
        //    txtPrimerApellido.Enabled = true;
        //    txtSegundoApellido.Enabled = true;
        //    txtCedulaCond.Enabled = true;
        //}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            String resp;
            VehiculoBE modificar_vehiculo = new VehiculoBE();

            try
            {   
                modificar_vehiculo.Id_Vehiculo = txtIdVehiculo.Text;
                modificar_vehiculo.Marca = txtMarca.Text;
                modificar_vehiculo.Cilindraje = txtCilindraje.Text;
                modificar_vehiculo.Modelo = txtModelo.Text;
                modificar_vehiculo.Motor = txtMotor.Text;
                modificar_vehiculo.Chasis = txtChasis.Text;
                modificar_vehiculo.Ced_Prop = txtCedula.Text;
                modificar_vehiculo.Nombres_Prop = txtNombre.Text;
                modificar_vehiculo.Apellido_1_Prop = txtPrimerApellido.Text;
                modificar_vehiculo.Apellido_2_Prop = txtSegundoApellido.Text;

                Conductor_VehiculoBE cond = new Conductor_VehiculoBE();
                modificar_vehiculo.Conductor_Vehiculo = cond;

                ConductorBE regis = new ConductorBE();
                regis.Nombres_Conductor = txtNombreCond.Text;
                regis.Apellido_1 = txtPrimerApellidoCond.Text;
                regis.Apellido_2 = txtSegundoApellidoCond.Text;
                cond.Conductor = regis;

                RutaBE ruta = new RutaBE();
                ruta.Nombre_Ruta = txtRuta.Text; // donde asignarle el valor de la ruta seleccionada. en que tabla o que campo
                modificar_vehiculo.Ruta = ruta;

                btnGuardar.Visible = false;
                DivDatosVehiculo.Visible = false;
                DivPropietario.Visible = false;
                DivAsigRuta.Visible = false;
                DivConductor.Visible = false;
                DivConductorAsignado.Visible = false;
                divDatosRuta.Visible = false;
                btnGuardar.Visible = false;

                resp = servVehiculo.Modificar_Vehiculo(modificar_vehiculo);

                if (resp == "Ok")
                {
                    MessageBox.Show("El vehículo fue modificado satisfactoriamente", "Modificar Vehículo");
                }
               
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servVehiculo.Close();
                Response.Redirect("~/Vehiculos/frmModificarVehiculo.aspx");
            }
        }

        
        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }


        protected void txtCedulaCond_TextChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            VehiculoBE vehiculo = new VehiculoBE();
            

            try
            {
                Conductor_VehiculoBE cond_veh = new Conductor_VehiculoBE();
                vehiculo.Conductor_Vehiculo =cond_veh;

                ConductorBE cond = new ConductorBE();
                cond.Cedula = txtCedulaCond.Text;
                cond_veh.Conductor= cond;

                vehiculo.Conductor_Vehiculo.Conductor.Cedula = txtCedulaCond.Text;
                VehiculoBE[] consulta = servVehiculo.Consultar_Conductor(vehiculo);

                foreach (VehiculoBE info in consulta)
                {
                    if (info.Conductor_Vehiculo.Conductor.Cedula != txtCedulaCond.Text)
                    {
                        lblImprimirCedula.Text = info.Conductor_Vehiculo.Conductor.Cedula;
                        txtNombreCond.Text = info.Conductor_Vehiculo.Conductor.Nombres_Conductor;
                        txtPrimerApellidoCond.Text = info.Conductor_Vehiculo.Conductor.Apellido_1;
                        txtSegundoApellidoCond.Text = info.Conductor_Vehiculo.Conductor.Apellido_2;
                        txtCedulaCond.Text = "";
                        
                    }

                    else
                    {
                        MessageBox.Show("El conductor no se encuentra registrado en el sistema", "Asignar Conductor");
                    }

                    txtRuta.Focus();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servVehiculo.Close();
            }
            
        }

        protected void lstRuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRuta.Text = lstRuta.SelectedValue.ToString();
            txtRuta.Focus();

        }
    }
}