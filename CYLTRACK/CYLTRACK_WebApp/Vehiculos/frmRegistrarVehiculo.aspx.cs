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

    public partial class frmRegistrarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // txtPlaca1.CharacterCasing = CharacterCasing.Upper;
            RutaServicesClient servRuta = new RutaServicesClient();
            try
            {
                if (!IsPostBack)
                {
                    txtPlaca1.Focus();
                    List<RutaBE> lstRutas = new List<RutaBE>(servRuta.ConsultarRuta(string.Empty));
                    foreach (RutaBE datos in lstRutas)
                    {
                        lstRuta.DataSource = servRuta.ConsultarRuta(string.Empty);
                        lstRuta.DataValueField = "Id_Ruta";
                        lstRuta.DataTextField = "Nombre_Ruta";
                        lstRuta.DataBind();

                    }
                    if (lstRuta.Items.Count == 0)
                    {
                        MessageBox.Show("No existen rutas registradas en el sistema", "Registrar Vehículo");
                        DivAsignacionConductor.Visible = false;
                        DivDatosPropietario.Visible = false;
                        DivSelRuta.Visible = false;
                        DivVehiculo.Visible = false;
                    }
                    Anos[] anos = Auxiliar.ConsultarAnos();
                    IEnumerable<Anos> listaAnos = anos.OrderByDescending(g => g).Skip(0);
                    foreach (Anos datosAnos in listaAnos)
                    {
                        lstModelo.Items.Add(datosAnos.ToString());
                    }
                    List<string> estado = Auxiliar.ConsultaEstado();
                    foreach (string datoEstado in estado)
                    {
                        lstEstado.Items.Add(datoEstado);
                    }
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void txtPlaca1_TextChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient serVehiculo = new VehiculoServiceClient();
            long resp;

            try
            {
                resp = serVehiculo.ConsultarExistenciaVehiculo(txtPlaca1.Text);

                if (resp != 0)
                {
                    MessageBox.Show("El vehículo ya se encuentra registrado en el sistema", "Registrar Vehículo");
                    txtPlaca1.Text = "";
                    DivVehiculo.Visible = false;
                    DivSelRuta.Visible = false;
                    DivDatosPropietario.Visible = false;
                    DivConsultaPropietario.Visible = false;
                    DivAsignacionConductor.Visible = false;
                    DivDatosConductor.Visible = false;
                    txtPlaca1.Focus();
                    txtMarca.Text = "";
                    txtCilindraje.Text = "";
                    txtMotor.Text = "";
                    txtChasis.Text = "";
                    txtApellidos.Text = "";
                    txtCedConductor.Text = "";
                    txtCedula.Text = "";
                    txtCedula2.Text = "";
                    txtNombreCond.Text = "";
                    txtNombres.Text = "";

                }


                else
                {
                    txtPlaca.Text = txtPlaca1.Text;
                    txtPlaca1.Text = "";
                    txtMarca.Focus();
                    DivVehiculo.Visible = true;
                    DivDatosPropietario.Visible = true;
                    DivSelRuta.Visible = true;
                    DivAsignacionConductor.Visible = true;
                    lblCedula1.Visible = true;
                    txtCedula1.Visible = true;
                    btnGuardar.Visible = true;
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                serVehiculo.Close();
            }
        }
        protected void txtCedula1_TextChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

            VehiculoBE consultar_conductor = new VehiculoBE();
            long resp;

            try
            {
                resp = servVehiculo.ConsultarExistenciaConductor(txtCedula1.Text);

                if (resp == 0)
                {
                    MessageBox.Show("El conductor no se encuentra registrado en el sistema", "Registro de Vehículos");

                    txtCedula1.Text = "";
                    txtCedConductor.Text = "";
                    txtNombreCond.Text = "";
                    txtSegundoApellidoCond.Text = "";
                    txtPrimerApellidoCond.Text = "";
                    DivDatosConductor.Visible = false;
                    txtCedula1.Focus();
                }
                else
                {
                    ConductorBE objConductor = servVehiculo.Consultar_Conductor(txtCedula1.Text);
                    txtCedConductor.Text = objConductor.Cedula;
                    txtNombreCond.Text = objConductor.Nombres_Conductor;
                    txtPrimerApellidoCond.Text = objConductor.Apellido_1;
                    txtSegundoApellidoCond.Text = objConductor.Apellido_2;
                    DivDatosConductor.Visible = true;
                    btnGuardar.Visible = true;
                    txtCedula1.Text = "";
                    btnGuardar.Focus();
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

            long resp;
            VehiculoBE registrar_vehiculo = new VehiculoBE();

            try
            {
                registrar_vehiculo.Placa = txtPlaca.Text;
                registrar_vehiculo.Marca = txtMarca.Text;
                registrar_vehiculo.Cilindraje = txtCilindraje.Text;
                registrar_vehiculo.Modelo = lstModelo.SelectedValue;
                registrar_vehiculo.Motor = txtMotor.Text;
                registrar_vehiculo.Chasis = txtChasis.Text;
                registrar_vehiculo.Estado = lstEstado.SelectedValue;

                ConductorBE cond = new ConductorBE();
                cond.Cedula = txtCedConductor.Text;
                registrar_vehiculo.Conductor = cond;

                ContratistaBE contrat = new ContratistaBE();
                contrat.Cedula = txtCedula2.Text;
                registrar_vehiculo.Contratista = contrat;

                RutaBE rutaasig = new RutaBE();
                rutaasig.Id_Ruta = lstRuta.SelectedValue;
                registrar_vehiculo.Ruta = rutaasig;

                resp = servVehiculo.Registrar_Vehiculo(registrar_vehiculo);

                MessageBox.Show("El vehículo fue registrado satisfactoriamente", "Registrar Vehículo");
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

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            try
            {
                long consultarPropVehiculo = servVehiculo.ConsultarExistenciaContratista(txtCedula.Text);

                if (consultarPropVehiculo != 0)
                {

                    txtCedula2.Text = txtCedula.Text;
                    ContratistaBE objContratista = servVehiculo.ConsultarPropVehiculo(txtCedula2.Text);
                    txtCedula.Text = "";
                    txtNombres.Text = objContratista.Nombres;
                    txtApellidos.Text = objContratista.Apellidos;
                    DivConsultaPropietario.Visible = true;
                    txtCedula1.Focus();
                }
                else
                {
                    MessageBox.Show("El propietario no se encuentra registrado en el sistema", "Registro de Vehículos");

                    txtCedula.Text = "";
                    txtCedula2.Text = "";
                    txtNombres.Text = "";
                    txtApellidos.Text = "";
                    DivConsultaPropietario.Visible = false;
                    txtCedula.Focus();
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
            btnGuardar.Focus();
        }


    }
}