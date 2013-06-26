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
           ClienteBE consultar_cli = new ClienteBE();
                
           try
           {
               consultar_cli.Cedula = txtCedula.Text;
               ClienteBE[] consulta = servCliente.Consultar_Cliente(consultar_cli);

               foreach (ClienteBE info in consulta)
               {
                   if (info.Cedula != txtCedula.Text)
                   {

                       txtCedulaCli.Text = info.Cedula;
                       txtNombreCliente.Text = info.Nombres_Cliente;
                       txtPrimerApellido.Text = info.Apellido_1;
                       txtSegundoApellido.Text = info.Apellido_2;
                       txtDireccion.Text = info.Ubicacion.Direccion;
                       txtBarrio.Text = info.Ubicacion.Barrio;
                       txtCiudad.Text = info.Ciudad.Nombre_Ciudad;
                       txtDepartamento.Text = info.Ciudad.Departamento.Nombre_Departamento;
                       txtTelefono.Text = info.Ubicacion.Telefono_1;
                       txtCodigoCilindro.Text = info.Cilindro.Codigo_Cilindro;
                       txtTamano.Text = info.Cilindro.NTamano.Tamano;
                       txtTipoCilindro.Text = info.Cilindro.Tipo_Cilindro;

                       divInfoCliente.Visible = true;
                       btnNuevaConsulta.Visible = true;
                   }
                   else
                   {
                       MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consultar Cliente");
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