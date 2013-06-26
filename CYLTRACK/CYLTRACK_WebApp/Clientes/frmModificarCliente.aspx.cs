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
            ClienteBE consultar_cli = new ClienteBE();
           
           
            try
            {
                consultar_cli.Cedula = txtCedula.Text;
                ClienteBE[] consulta = servCliente.Consultar_Cliente(consultar_cli);

               foreach (ClienteBE info in consulta)
               {

                   if(info.Cedula != txtCedula.Text)
                   {

                   txtCedulaCli.Text = info.Cedula;
                   txtNombreCliente.Text = info.Nombres_Cliente;
                   txtPrimerApellido.Text = info.Apellido_1;
                   txtSegundoApellido.Text = info.Apellido_2;
                   txtDireccion.Text = info.Ubicacion.Direccion;
                   txtBarrio.Text = info.Ubicacion.Barrio;
                   lstDepartamento.Items.Add(info.Ciudad.Departamento.Nombre_Departamento);
                   lstCiudad.Items.Add(info.Ciudad.Nombre_Ciudad);
                   txtTelefono.Text = info.Ubicacion.Telefono_1;


                   divInfoCliente.Visible = true;
                   btnGuardar.Visible = true;
                   txtCedula.Text = "";
                   }
                   else
                   {
                       MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Modificar Cliente");
                   }
             
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
                
                resp = servCliente.Modificar_Cliente(modificar_cli);

                if (resp == "Ok")
                {
                    MessageBox.Show("El cliente fue modificado satisfactoriamente", "Modificar Cliente");
                }
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