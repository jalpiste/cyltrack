using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account
{
    public partial class frmconsultarcliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            btnNuevaConsulta.Focus();
            ClienteServiceClient servCliente = new ClienteServiceClient();
            string resp;

            try
            {
                resp = servCliente.Consultar_Existencia(txtCedula.Text);

                if (resp == null)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consultar Cliente");
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
                        txtCiudad.Text = consulta.Ubicacion.Ciudad.Nombre_Ciudad;
                        txtDepartamento.Text = consulta.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                        txtTelefono.Text = consulta.Ubicacion.Telefono_1;
                        //txtCodigoCilindro.Text = info.Cilindro.Codigo_Cilindro;
                        //txtTamano.Text = info.Cilindro.NTamano.Tamano;
                        //txtTipoCilindro.Text = info.Cilindro.Tipo_Cilindro;

                        divInfoCliente.Visible = true;
                        btnNuevaConsulta.Visible = true;
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
            //Response.Redirect("~/Default.aspx");
        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            txtCedula.Text = "";
            divInfoCliente.Visible = false;
            btnNuevaConsulta.Visible = false;
            
        }


    }
}