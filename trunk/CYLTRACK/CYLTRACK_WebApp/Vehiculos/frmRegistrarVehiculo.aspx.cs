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
using System.Windows.Forms;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Rutas
{   

    public partial class frmRegistrarVehículo : System.Web.UI.Page
    {
        // private CharacterCasing CharacterCasing { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtPlaca1.Focus();
            if (!IsPostBack)
            {
                Anos[] anos = Auxiliar.ConsultarAnos();
                IEnumerable<Anos> listaAnos = anos.OrderByDescending(g => g).Skip(0);
                foreach (Anos datosAnos in listaAnos)
                {
                    lstModelo.Items.Add(datosAnos.ToString());
                }

            }
        // txtPlaca1.CharacterCasing = CharacterCasing.Upper;
        }
        
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void txtPlaca1_TextChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            RutaServicesClient servRuta = new RutaServicesClient();
            String resp;

            try
            {
                resp = servVehiculo.Consultar_Existencia(txtPlaca1.Text);

                if (resp != "Ok")
                {
                    MessageBox.Show("El vehículo ya se encuentra registrado en el sistema", "Registrar Vehículo");
                }

                else
                {
                    txtPlaca.Text = txtPlaca1.Text;
                    txtPlaca1.Text = "";
                    txtMarca.Focus();
                    DivVehiculo.Visible = true;
                    DivPropietario.Visible = true;
                    DivSelRuta.Visible = true;
                    DivAsignacionConductor.Visible = true;
                    lblCedula1.Visible = true;
                    txtCedula1.Visible = true;
                    btnGuardar.Visible = true;
                    List<RutaBE> lstRutas = new List<RutaBE>(servRuta.ConsultarRuta());
                    foreach(RutaBE datos in lstRutas)
                    {
                    lstRuta.Items.Add(datos.Nombre_Ruta);
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
        protected void txtCedula1_TextChanged(object sender, EventArgs e)
        {            
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            VehiculoBE consultar_conductor = new VehiculoBE();
            string resp;
            
            try
            {
                resp = servVehiculo.Consultar_Existencia(txtCedula1.Text);

                    if (resp == null)
                    {
                       MessageBox.Show("El conductor no se encuentra registrado en el sistema", "Asignar Conductor");
                    }
                    else
                    {
                        VehiculoBE objConductor = servVehiculo.Consultar_Conductor(txtCedula1.Text);

                        lblImprimirCedula.Text = objConductor.Conductor_Vehiculo.Conductor.Cedula;
                        txtNombreCond.Text = objConductor.Conductor_Vehiculo.Conductor.Nombres_Conductor;
                        txtPrimerApellidoCond.Text = objConductor.Conductor_Vehiculo.Conductor.Apellido_1;
                        txtSegundoApellidoCond.Text = objConductor.Conductor_Vehiculo.Conductor.Apellido_2;


                        txtCedula1.Text = "";
                        lstRuta.Focus();
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
                registrar_vehiculo.Modelo = lstModelo.SelectedValue;
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
            
            
            ClienteServiceClient ServCliente = new ClienteServiceClient();

            string consultarCliente = ServCliente.Consultar_Existencia(txtCedula.Text);

            if (consultarCliente != "Ok")
            {
                MessageBox.Show("El propietario no se encuentra registrada en el sistema", "Registrar Vehículo");
            }

            else
            {
                ClienteBE objCliente = ServCliente.Consultar_Cliente(txtCedula.Text);
                txtNombre.Text = objCliente.Nombres_Cliente;
                txtPrimerApellido.Text = objCliente.Apellido_1;
                txtSegundoApellido.Text = objCliente.Apellido_2;

            }
        }
    }
}