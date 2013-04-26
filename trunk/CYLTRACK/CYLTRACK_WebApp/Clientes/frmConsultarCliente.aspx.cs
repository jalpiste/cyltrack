using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Account
{
    public partial class frmconsultarcliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {

           divInfoCliente.Visible = true;
           btnNuevaConsulta.Visible = true;


           //ClienteBE consultar_cli = new ClienteBE();

           // txtNombreCliente.Text = Convert.ToString(consultar_cli.Nombres);
           // txtPrimerApellido.Text = Convert.ToString(consultar_cli.Apellido_1);
           // txtSegundoApellido.Text = Convert.ToString(consultar_cli.Apellido_2);
           // txtDireccion.Text = Convert.ToString(consultar_cli.Ubicacion.Direccion);
           // txtBarrio.Text = Convert.ToString(consultar_cli.Ubicacion.Barrio);
           // txtCiudad.Text = Convert.ToString(consultar_cli.Ciudad.Nombre_Ciudad);
           // txtDepartamento.Text = Convert.ToString(consultar_cli.Ciudad.Departamento.Nombre_Departamento);
           // txtTelefono.Text = Convert.ToString(consultar_cli.Ubicacion.Telefono_1);
           // txtCodigoCilindro.Text = Convert.ToString(consultar_cli.Cilindro.Codigo_Cilindro);
           // txtTamano.Text = Convert.ToString(consultar_cli.Cilindro.Tamano);
           // txtTipoCilindro.Text = Convert.ToString(consultar_cli.Cilindro.Tipo_Cilindro);

        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            divInfoCliente.Visible = false;
            btnNuevaConsulta.Visible = false;
        }


    }
}