using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.RutaService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes
{
    public partial class frmModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
            if (IsPostBack)
            {
                hprNuevaUbicacion.NavigateUrl = "frmNuevaUbicacion.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]) + Server.UrlEncode(txtCedula.Text);
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

                if (resp == 0)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Modificar Cliente");
                    divInfoCliente.Visible = false;
                    txtCedula.Text = "";
                    txtCedula.Focus();
                    btnGuardar.Visible = false;

                }
                else
                {
                    ClienteBE consulta = servCliente.Consultar_Cliente(txtCedula.Text);

                    txtCedulaCli.Text = consulta.Cedula;
                    txtNombreCliente.Text = consulta.Nombres_Cliente;
                    txtPrimerApellido.Text = consulta.Apellido_1;
                    txtSegundoApellido.Text = consulta.Apellido_2;
                    txtDireccion.Text = consulta.Ubicacion.Direccion;
                    txtBarrio.Text = consulta.Ubicacion.Barrio;
                    lstDepartamento.DataValueField = "Id_Departamento";
                    lstDepartamento.DataTextField = "Nombre_Departamento";
                    lstCiudad.DataValueField = "Id_Ciudad";
                    lstCiudad.DataTextField = "Nombre_Ciudad";
                    txtTelefono.Text = consulta.Ubicacion.Telefono_1;

                    divInfoCliente.Visible = true;
                    btnGuardar.Visible = true;
                    txtCedula.Text = "";
                    txtCedulaCli.Focus();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            long resp;
            ClienteBE cliente = new ClienteBE();

            try
            {
                cliente.Nombres_Cliente = txtNombreCliente.Text;
                cliente.Apellido_1 = txtPrimerApellido.Text;
                cliente.Apellido_2 = txtSegundoApellido.Text;
                cliente.Cedula = txtCedulaCli.Text;

                UbicacionBE ubicli = new UbicacionBE();
                ubicli.Direccion = txtDireccion.Text;
                ubicli.Barrio = txtBarrio.Text;
                ubicli.Telefono_1 = txtTelefono.Text;

                CiudadBE ciucli = new CiudadBE();
                ciucli.Id_Ciudad = lstCiudad.SelectedValue;
                ubicli.Ciudad = ciucli;
                cliente.Ubicacion = ubicli;

                resp = servCliente.Modificar_Cliente(cliente);

                MessageBox.Show("El cliente fue modificado satisfactoriamente", "Modificar Cliente");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }

            finally
            {
                servCliente.Close();
                Response.Redirect("~/Clientes/frmModificarCliente.aspx");
                txtCedula.Text = "";
                txtCedula.Focus();

            }
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //txtNombreCliente.Focus();
            //txtNombreCliente.Text = "";
            //txtPrimerApellido.Text = "";
            //txtSegundoApellido.Text = "";
            //txtDireccion.Text = "";
            //txtBarrio.Text = "";
            //lstDepartamento.Text = "Seleccionar...";
            //lstCiudad.Text = "Seleccionar...";
            //txtTelefono.Text = "";
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

        protected void lstCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTelefono.Focus();
        }

        protected void txtCedulaCli_TextChanged(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            long resp;

            try
            {
                resp = servCliente.ConsultarExistenciasClientes(txtCedulaCli.Text);

                if (resp != 0)
                {
                    MessageBox.Show("La cédula del cliente ya se encuentra registrada en el sistema", "Modificar Cliente");
                }
                else
                {
                    txtCedulaCli.Enabled = false;
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
    }
}