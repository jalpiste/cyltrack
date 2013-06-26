using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account
{
    public partial class frmcrearcliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            ClienteBE cliente = new ClienteBE();
            String resp;
            try
            {

                cliente.Cedula = txtCedula.Text;
                resp = servCliente.Registrar_Cliente(cliente);

                if (resp != "Ok")
                {
                    MessageBox.Show("El cliente ya se encuentra registrado en el sistema", "Registrar Cliente");
                }


                divInfoCliente.Visible = true;
                btnGuardar.Visible = true;
                txtNombreCliente.Focus();
                txtCedulaCli.Text = txtCedula.Text;
                txtCedula.Text = "";
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

            String resp;

            ClienteBE registrar_cli = new ClienteBE();

            try
            {
                
                registrar_cli.Cedula = txtCedulaCli.Text;
                registrar_cli.Nombres_Cliente = txtNombreCliente.Text;
                registrar_cli.Apellido_1 = txtPrimerApellido.Text;
                registrar_cli.Apellido_2 = txtSegundoApellido.Text;
                
                UbicacionBE ubicli = new UbicacionBE();
                ubicli.Direccion = txtDireccion.Text;
                ubicli.Barrio = txtBarrio.Text;
                ubicli.Telefono_1 = txtTelefono.Text;
                registrar_cli.Ubicacion = ubicli;

                CiudadBE ciucli = new CiudadBE();
                ciucli.Nombre_Ciudad = lstCiudad.SelectedValue;
                registrar_cli.Ciudad = ciucli;

                DepartamentoBE depcli = new DepartamentoBE();
                depcli.Nombre_Departamento = lstDepartamento.SelectedValue;
                ciucli.Departamento = depcli;
                
                resp = servCliente.Registrar_Cliente(registrar_cli);

                if (resp == "Ok")
                {
                    MessageBox.Show("El cliente fue registrado satisfactoriamente", "Registrar Cliente");

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
            txtNombreCliente.Text = "";
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