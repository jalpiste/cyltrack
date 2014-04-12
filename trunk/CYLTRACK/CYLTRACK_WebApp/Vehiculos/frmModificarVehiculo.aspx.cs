using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VehiculoService;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.RutaService;
using CYLTRACK_WebApp.ReporteService;
using System.Windows.Forms;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Vehiculos
{
    public partial class frmModificarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPlaca1.Focus();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void txtPlaca1_TextChanged(object sender, EventArgs e)
        {
            ReporteServiceClient serReporte = new ReporteServiceClient();
            RutaServicesClient servRuta = new RutaServicesClient();
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            long resp;

            try
            {
                resp = serReporte.consultadeExistenciaVarios(txtPlaca1.Text);

                if (resp == 0)
                {
                    MessageBox.Show("El vehículo no se encuentra registrado en el sistema", "Modificar Vehículo");
                }

                else
                {
                    List<VehiculoBE> lstVehiculo = new List<VehiculoBE>(servVehiculo.ConsultarVehiculo(txtPlaca1.Text));

                    foreach (VehiculoBE datos in lstVehiculo)
                    {
                        txtPlaca.Text = txtPlaca1.Text;
                        txtMarca.Text = datos.Marca;
                        txtCilindraje.Text = datos.Cilindraje;
                        lstModelo.Items.Add(datos.Modelo);
                        Anos[] anos = Auxiliar.ConsultarAnos();
                        IEnumerable<Anos> listaAnos = anos.OrderByDescending(g => g).Skip(0);
                        foreach (Anos datosAnos in listaAnos)
                        {
                            lstModelo.Items.Add(datosAnos.ToString());
                        }
                        txtMotor.Text = datos.Motor;
                        txtChasis.Text = datos.Chasis;
                        lstEstado.Items.Add(datos.Estado);
                        List<string> estado = Auxiliar.ConsultaEstado();
                        foreach (string datoEstado in estado)
                        {
                            lstEstado.Items.Add(datoEstado);                            
                        }
                        txtCedula.Text = datos.Ced_Prop;
                        txtCedula2.Text = txtCedula1.Text;
                        txtCedula1.Text = datos.Conductor.Cedula;
                        lblImprimirCedula.Text = txtCedula1.Text;
                        txtNombreCond.Text = datos.Conductor.Nombres_Conductor;
                        txtPrimerApellidoCond.Text = datos.Conductor.Apellido_1;
                        txtSegundoApellidoCond.Text = datos.Conductor.Apellido_2;
                        lstRuta.Items.Add(datos.Ruta.Nombre_Ruta);
                        lstRuta.DataSource = servRuta.ConsultarRuta(string.Empty);
                        lstRuta.DataValueField = "Id_Ruta";
                        lstRuta.DataTextField = "Nombre_Ruta";
                        lstRuta.DataBind();
                        txtMarca.Focus();
                       
                    }
                    DivVehiculo.Visible = true;
                    DivPropietario.Visible = true;
                    DivSelRuta.Visible = true;
                    DivAsignacionConductor.Visible = true;
                    btnGuardar.Visible = true;
                                 
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {

                serReporte.Close();
                servRuta.Close();
                servVehiculo.Close();
            }
        }

     
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

            long resp;
            VehiculoBE modificar_vehiculo = new VehiculoBE();

            try
            {
                modificar_vehiculo.Placa = txtPlaca.Text;
                modificar_vehiculo.Marca = txtMarca.Text;
                modificar_vehiculo.Cilindraje = txtCilindraje.Text;
                modificar_vehiculo.Modelo = lstModelo.SelectedValue;
                modificar_vehiculo.Motor = txtMotor.Text;
                modificar_vehiculo.Chasis = txtChasis.Text;
                modificar_vehiculo.Ced_Prop = txtCedula2.Text;
                modificar_vehiculo.Nombres_Prop = txtNombre.Text;
                modificar_vehiculo.Apellido_1_Prop = txtPrimerApellido.Text;
                modificar_vehiculo.Apellido_2_Prop = txtSegundoApellido.Text;
                modificar_vehiculo.Estado = lstEstado.SelectedValue;

                ConductorBE cond = new ConductorBE();
                cond.Cedula = lblImprimirCedula.Text;
                modificar_vehiculo.Conductor = cond;

                RutaBE rutaasig = new RutaBE();
                rutaasig.Id_Ruta = lstRuta.SelectedValue;
                modificar_vehiculo.Ruta = rutaasig;

                resp = servVehiculo.Modificar_Vehiculo(modificar_vehiculo);

                MessageBox.Show("El vehículo fue modificado satisfactoriamente", "Modificar Vehículo");
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
                ////Conductor_VehiculoBE cond_veh = new Conductor_VehiculoBE();
                ////vehiculo.Conductor_Vehiculo =cond_veh;

                ////ConductorBE cond = new ConductorBE();
                ////cond.Cedula = txtCedulaCond.Text;
                ////cond_veh.Conductor= cond;

                
                ////VehiculoBE consulta = servVehiculo.Consultar_Conductor(txtCedulaCond.Text);

                ////if (consulta.Conductor_Vehiculo.Conductor.Cedula != txtCedulaCond.Text)
                ////    {
                ////        lblImprimirCedula.Text = consulta.Conductor_Vehiculo.Conductor.Cedula;
                ////        txtNombreCond.Text = consulta.Conductor_Vehiculo.Conductor.Nombres_Conductor;
                ////        txtPrimerApellidoCond.Text = consulta.Conductor_Vehiculo.Conductor.Apellido_1;
                ////        txtSegundoApellidoCond.Text = consulta.Conductor_Vehiculo.Conductor.Apellido_2;
                ////        txtCedulaCond.Text = "";
                ////    }

                ////    else
                ////    {
                ////        MessageBox.Show("El conductor no se encuentra registrado en el sistema", "Asignar Conductor");
                ////    }

                ////    txtRuta.Focus();
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

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            ReporteServiceClient servReporte = new ReporteServiceClient();
            try
            {
                long consultarPropVehiculo = servReporte.consultadeExistenciaVarios(txtCedula.Text);

                if (consultarPropVehiculo != 0)
                {
                    txtCedula2.Text = txtCedula.Text;
                    VehiculoBE objVehiculo = servVehiculo.ConsultarPropVehiculo(txtCedula2.Text);
                    txtNombre.Text = objVehiculo.Nombres_Prop;
                    txtPrimerApellido.Text = objVehiculo.Apellido_1_Prop;
                    txtSegundoApellido.Text = objVehiculo.Apellido_2_Prop;
                    txtNombre.Enabled = false;
                    txtPrimerApellido.Enabled = false;
                    txtSegundoApellido.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servVehiculo.Close();
                servReporte.Close();
            }
        }

        protected void txtCedula1_TextChanged(object sender, EventArgs e)
        {
            ReporteServiceClient servReporte = new ReporteServiceClient();
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

            VehiculoBE consultar_conductor = new VehiculoBE();
            long resp;

            try
            {
                resp = servReporte.consultadeExistenciaVarios(txtCedula1.Text);

                if (resp == 0)
                {
                    MessageBox.Show("El conductor no se encuentra registrado en el sistema", "Modificar Vehículo");
                }
                else
                {
                    ConductorBE objConductor = servVehiculo.Consultar_Conductor(txtCedula1.Text);
                    lblImprimirCedula.Text = objConductor.Cedula;
                    txtNombreCond.Text = objConductor.Nombres_Conductor;
                    txtPrimerApellidoCond.Text = objConductor.Apellido_1;
                    txtSegundoApellidoCond.Text = objConductor.Apellido_2;
                    DatosConductor.Visible = true;
                    btnGuardar.Visible = true;
                    txtCedula1.Text = "";
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servReporte.Close();
                servVehiculo.Close();
                lstRuta.Focus();
            }
        }

            
        
    }
}