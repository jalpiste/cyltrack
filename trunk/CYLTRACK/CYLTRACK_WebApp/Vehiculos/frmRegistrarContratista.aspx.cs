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
    public partial class frmRegistrarContratista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCedula.Focus();
            }                       
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

            long resp;
            try
            {
                resp = servVehiculo.ConsultarExistenciaContratista(txtCedula.Text);

                if (resp != 0)
                {
                    MessageBox.Show("El Contratista ya se encuentra registrado en el sistema", "Registrar Contratista");
                    divInfoContratista.Visible = false;
                    btnGuardar.Visible = false;
                    txtCedula.Text = "";
                    txtCedulaCont.Text = "";
                    txtDireccion.Text = "";
                    txtNombreContratista.Text = "";
                    txtPrimerApellido.Text = "";
                    txtCedula.Focus();
                }
                else
                {
                    divInfoContratista.Visible = true;
                    btnGuardar.Visible = true;
                    txtNombreContratista.Focus();
                    txtCedulaCont.Text = txtCedula.Text;
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
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();
            long resp;

            ContratistaBE contratista = new ContratistaBE();

            try
            {
                contratista.Cedula = txtCedulaCont.Text;
                contratista.Nombres = txtNombreContratista.Text;
                contratista.Apellidos = txtPrimerApellido.Text;
                contratista.Direccion = txtDireccion.Text;
                contratista.Telefono = txtTelefono.Text;                
                resp = servVehiculo.RegistrarContratista(contratista);

                MessageBox.Show("El Contratista fue registrado satisfactoriamente", "Registrar Contratista");

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servVehiculo.Close();
                Response.Redirect("~/Vehiculos/frmRegistrarContratista.aspx");
                txtCedula.Focus();
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreContratista.Text = "";
            txtPrimerApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }      
        
    }
}