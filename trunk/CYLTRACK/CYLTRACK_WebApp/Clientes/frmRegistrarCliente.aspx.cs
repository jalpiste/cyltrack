using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.RutaService;
using CYLTRACK_WebApp.ReporteService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes
{
    public partial class frmcrearcliente : System.Web.UI.Page
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
            ClienteServiceClient servCliente = new ClienteServiceClient();

            long resp;
            try
            {
                resp = servCliente.ConsultarExistenciasClientes(txtCedula.Text);

                if (resp != 0)
                {
                    MessageBox.Show("El cliente ya se encuentra registrado en el sistema", "Registrar Cliente");
                    divInfoCliente.Visible = false;
                    txtCedulaCli.Text = "";
                    txtBarrio.Text = "";
                    txtCedula.Text = "";
                    txtDireccion.Text = "";
                    txtNombreCliente.Text = "";
                    txtPrimerApellido.Text = "";
                    txtSegundoApellido.Text = "";
                    txtTelefono.Text = "";
                    btnGuardar.Visible = false;
                    txtCedula.Focus();
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
            long resp;

            ClienteBE cliente = new ClienteBE();

            try
            {
                cliente.Cedula = txtCedulaCli.Text;
                cliente.Nombres_Cliente = txtNombreCliente.Text;
                cliente.Apellido_1 = txtPrimerApellido.Text;
                cliente.Apellido_2 = txtSegundoApellido.Text;

                UbicacionBE ubicacion = new UbicacionBE();
                ubicacion.Direccion = txtDireccion.Text;
                ubicacion.Barrio = txtBarrio.Text;
                ubicacion.Telefono_1 = txtTelefono.Text;

                CiudadBE ciucli = new CiudadBE();
                ciucli.Id_Ciudad = lstCiudad.SelectedValue;
                ubicacion.Ciudad = ciucli;
                cliente.Ubicacion = ubicacion;
                resp = servCliente.Registrar_Cliente(cliente);
                if (resp != -1)
                {
                    MessageBox.Show("El cliente fue registrado satisfactoriamente", "Registrar Cliente");
                }
                else
                {
                    Response.Redirect("~/About.aspx");
                }              
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
            if(!IsPostBack)
            {   
            txtNombreCliente.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtDireccion.Text = "";
            txtBarrio.Text = "";
            txtTelefono.Text = "";
            }
        }

        protected void lstCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTelefono.Focus();
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