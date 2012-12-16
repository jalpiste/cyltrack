using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Rutas
{
    public partial class frmModificarRuta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lstCiudades.Items.Add(lstCiudad.Text);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            DivModificarDatos.Visible = true;
            btnModificar.Visible = false;
            txtNuevoNombre.Enabled = true;
            btnRemover.Visible = true;
        }

        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {
            txtNuevoNombre.Text = txtNombreRuta.Text;
            txtNombreRuta.Text = "";
            DivPost.Visible = true;
            DivDatos.Visible = true;
            DivCiudad.Visible = true;
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {

            if (lstCiudades.SelectedIndex > -1)
            {
                lstCiudades.Items.Remove(lstCiudades.Text);
            }

            //If (lstCiudades.ListIndex <> -1) Then

            //   List1.RemoveItem List1.ListIndex
            // End If

        }
    }
}