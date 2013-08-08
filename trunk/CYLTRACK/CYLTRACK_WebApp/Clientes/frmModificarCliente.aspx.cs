using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account.Clientes
{
    public partial class frmModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
            hprNuevaUbicacion.NavigateUrl = "frmNuevaUbicacion.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            txtCedulaCli.Focus();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            string resp;
           
            try
            {
                resp = servCliente.Consultar_Existencia(txtCedula.Text);

                if (resp == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Modificar Cliente");
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
                       lstDepartamento.Items.Add(consulta.Ciudad.Departamento.Nombre_Departamento);
                       lstCiudad.Items.Add(consulta.Ciudad.Nombre_Ciudad);
                       txtTelefono.Text = consulta.Ubicacion.Telefono_1;

                       divInfoCliente.Visible = true;
                       btnGuardar.Visible = true;
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            String resp;
            ClienteBE modificar_cli = new ClienteBE();

            try
            {
                modificar_cli.Nombres_Cliente = txtNombreCliente.Text;
                modificar_cli.Apellido_1 = txtPrimerApellido.Text;
                modificar_cli.Apellido_2 = txtSegundoApellido.Text;

                UbicacionBE ubicli = new UbicacionBE();
                ubicli.Direccion = txtDireccion.Text;
                ubicli.Barrio = txtBarrio.Text;
                ubicli.Telefono_1 = txtTelefono.Text;
                modificar_cli.Ubicacion = ubicli;

                CiudadBE ciucli = new CiudadBE();
                ciucli.Nombre_Ciudad = lstCiudad.SelectedValue;
                modificar_cli.Ciudad = ciucli;

                DepartamentoBE depcli = new DepartamentoBE();
                depcli.Nombre_Departamento = lstDepartamento.SelectedValue;
                ciucli.Departamento = depcli;
            
                divInfoCliente.Visible = false;
                btnGuardar.Visible = false;
                txtCedula.Text = "";
                
                resp = servCliente.Modificar_Cliente(Convert.ToString(modificar_cli));
                
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
            lstCiudad.Focus();
        }

        protected void lstCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTelefono.Focus();
        }

    }
}