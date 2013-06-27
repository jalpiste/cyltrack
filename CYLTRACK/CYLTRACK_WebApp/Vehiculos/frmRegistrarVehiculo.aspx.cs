using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VehiculoService;
using System.Windows.Forms;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Rutas
{
    

    public partial class frmRegistrarVehículo : System.Web.UI.Page
    {
        // private CharacterCasing CharacterCasing { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtPlaca1.Focus();
        // txtPlaca1.CharacterCasing = CharacterCasing.Upper;
        }
        
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void txtPlaca1_TextChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            VehiculoBE vehiculo = new VehiculoBE();
            String resp;

            try
            {

                vehiculo.Placa = txtPlaca1.Text;
                resp = servVehiculo.Registrar_Vehiculo(vehiculo);

                txtPlaca.Text = txtPlaca1.Text;
                txtPlaca1.Text = "";
                txtMarca.Focus();


                if (resp != "Ok")
                {
                    MessageBox.Show("El vehículo ya se encuentra registrado en el sistema", "Registrar Vehículo");
                }


                DivVehiculo.Visible = true;
                DivPropietario.Visible = true;
                DivSelRuta.Visible = true;
                DivAsignacionConductor.Visible = true;
                lblCedula1.Visible = true;
                txtCedula1.Visible = true;
                btnGuardar.Visible = true;
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
        protected void txtCedula1_TextChanged(object sender, EventArgs e)
        {
            
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            VehiculoBE consultar_conductor = new VehiculoBE();
            
            try
            {
                Conductor_VehiculoBE cond = new Conductor_VehiculoBE();
                consultar_conductor.Conductor_Vehiculo = cond;

                ConductorBE conduc = new ConductorBE();
                //conduc.Cedula = txtCedula1.Text;
                cond.Conductor = conduc;


                consultar_conductor.Conductor_Vehiculo.Conductor.Cedula = txtCedula1.Text;
                VehiculoBE[] consulta = servVehiculo.Consultar_Conductor(consultar_conductor);

                foreach (VehiculoBE info in consulta)
                {
                    if (info.Conductor_Vehiculo.Conductor.Cedula != txtCedula1.Text)
                    {

                        lblImprimirCedula.Text = info.Conductor_Vehiculo.Conductor.Cedula;
                        txtNombreCond.Text = info.Conductor_Vehiculo.Conductor.Nombres_Conductor;
                        txtPrimerApellidoCond.Text = info.Conductor_Vehiculo.Conductor.Apellido_1;
                        txtSegundoApellidoCond.Text = info.Conductor_Vehiculo.Conductor.Apellido_2;

                        
                        txtCedula1.Text = "";
                        lstRuta.Focus();
                        DatosConductor.Visible = true;
                        btnGuardar.Visible = true;
                        txtCedula1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("El conductor no se encuentra registrado en el sistema", "Asignar Conductor");
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

        
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

            String resp;
            VehiculoBE registrar_vehiculo = new VehiculoBE();

            try
            {
                registrar_vehiculo.Placa = txtPlaca.Text;
                registrar_vehiculo.Marca = txtMarca.Text;
                registrar_vehiculo.Cilindraje = txtCilindraje.Text;
                registrar_vehiculo.Modelo = txtModelo.Text;
                registrar_vehiculo.Motor = txtMotor.Text;
                registrar_vehiculo.Chasis = txtChasis.Text;
                registrar_vehiculo.Ced_Prop = txtCedula.Text;
                registrar_vehiculo.Nombres_Prop = txtNombre.Text;
                registrar_vehiculo.Apellido_1_Prop = txtPrimerApellido.Text;
                registrar_vehiculo.Apellido_2_Prop = txtSegundoApellido.Text;

                Conductor_VehiculoBE cond = new Conductor_VehiculoBE();
                registrar_vehiculo.Conductor_Vehiculo = cond;

                ConductorBE regis = new ConductorBE();
                regis.Nombres_Conductor = txtNombreCond.Text;
                regis.Apellido_1 = txtPrimerApellidoCond.Text;
                regis.Apellido_2 = txtSegundoApellidoCond.Text;
                cond.Conductor = regis;

                RutaBE rutaasig = new RutaBE();
                rutaasig.Nombre_Ruta = lstRuta.SelectedValue; // donde asignarle el valor de la ruta seleccionada. en que tabla o que campo
                registrar_vehiculo.Ruta = rutaasig;

                resp = servVehiculo.Registrar_Vehiculo(registrar_vehiculo);

                if (resp == "Ok")
                {
                    MessageBox.Show("El vehículo fue registrado satisfactoriamente", "Registrar Vehículo");
                }
                
                
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servVehiculo.Close();
                Response.Redirect("~/Vehiculos/frmRegistrarVehiculo.aspx");
            }
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

    
    }
}