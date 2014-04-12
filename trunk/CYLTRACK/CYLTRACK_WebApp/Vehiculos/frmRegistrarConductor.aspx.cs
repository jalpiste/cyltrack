using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VehiculoService;
using CYLTRACK_WebApp.RutaService;
using CYLTRACK_WebApp.ReporteService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Vehiculos
{
    public partial class frmRegistrarConductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            ReporteServiceClient servReporte = new ReporteServiceClient();

            long resp;
            try
            {
                resp = servReporte.consultadeExistenciaVarios(txtCedula.Text);

                if (resp != 0)
                {
                    MessageBox.Show("El Conductor ya se encuentra registrado en el sistema", "Registrar Conductor");
                }
                else
                {
                    divInfoConductor.Visible = true;
                    btnGuardar.Visible = true;
                    txtNombreConductor.Focus();
                    txtCedulaCond.Text = txtCedula.Text;
                    txtCedula.Text = "";
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servReporte.Close();
            }
        }
        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo= new VehiculoServiceClient();
            long resp;

            ConductorBE conductor = new ConductorBE();

            try
            {
                conductor.Cedula = txtCedulaCond.Text;
                conductor.Nombres_Conductor = txtNombreConductor.Text;
                conductor.Apellido_1 = txtPrimerApellido.Text;
                conductor.Apellido_2 = txtSegundoApellido.Text;
                conductor.Direccion = txtDireccion.Text;
                conductor.Barrio = txtBarrio.Text;
                conductor.Telefono = txtTelefono.Text;

                CiudadBE ciucli = new CiudadBE();
                ciucli.Nombre_Ciudad = lstCiudad.SelectedValue;
                
                DepartamentoBE depcli = new DepartamentoBE();
                depcli.Nombre_Departamento = lstDepartamento.SelectedValue;
                ciucli.Departamento = depcli;
                conductor.Ciudad = ciucli;

                resp = servVehiculo.RegistrarConductor(conductor);

                MessageBox.Show("El conductor fue registrado satisfactoriamente", "Registrar Conductor");

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servVehiculo.Close();
                Response.Redirect("~/Vehiculos/frmRegistrarConductor.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreConductor.Text = "";
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