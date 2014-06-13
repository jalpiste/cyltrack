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

                    lstDepartamento.DataSource = servRuta.ConsultaDepartamento();
                    lstDepartamento.DataValueField = "Id_Departamento";
                    lstDepartamento.DataTextField = "Nombre_Departamento";
                    lstDepartamento.DataBind();  
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
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

            long resp;
            try
            {
                resp = servVehiculo.ConsultarExistenciaConductor(txtCedula.Text);

                if (resp != 0)
                {
                    MessageBox.Show("El Conductor ya se encuentra registrado en el sistema", "Registrar Conductor");
                    divInfoConductor.Visible = false;                    
                    btnGuardar.Visible = false;
                    txtCedulaCond.Text = "";
                    txtCedula.Text = "";
                    txtDireccion.Text = "";
                    txtPrimerApellido.Text = "";
                    txtNombreConductor.Text = "";
                    txtTelefono.Text = "";
                    txtCedula.Focus();
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
                servVehiculo.Close();
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
                conductor.Nombres_Conductor = txtNombreConductor.Text.ToUpper();
                conductor.Apellido_1 = txtPrimerApellido.Text.ToUpper();
                conductor.Apellido_2 = txtSegundoApellido.Text.ToUpper();
                conductor.Direccion = txtDireccion.Text.ToUpper();
                conductor.Barrio = txtBarrio.Text.ToUpper();
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

       
        protected void lstDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();

            try
            {
                lstCiudad.DataSource = servRuta.ConsultaCiudades(lstDepartamento.SelectedValue);
                lstCiudad.DataValueField = "Id_Ciudad";
                lstCiudad.DataTextField = "Nombre_Ciudad";
                lstCiudad.DataBind();

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servRuta.Close();
                lstCiudad.Focus();
            }
        }

    }
}