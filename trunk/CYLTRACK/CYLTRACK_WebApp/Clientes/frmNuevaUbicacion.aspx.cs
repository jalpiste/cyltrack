using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE; 

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes
{
    public partial class frmNuevaUbicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //ClienteBE registrar_ubi = new ClienteBE();

            //registrar_ubi.Ubicacion.Direccion = Convert.ToString(txtNuevaDireccion.Text);
            //registrar_ubi.Ubicacion.Barrio = Convert.ToString(txtNuevoBarrio.Text);
            //registrar_ubi.Ubicacion.Telefono_2 = Convert.ToString(txtTelefono.Text);
            //registrar_ubi.Ciudad.Departamento.Nombre_Departamento = Convert.ToString(lstDepartamento.SelectedValue);
            //registrar_ubi.Ciudad.Nombre_Ciudad = Convert.ToString(lstCiudad.SelectedValue);


            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Clientes/frmModificarCliente.aspx");
        }
    }
}