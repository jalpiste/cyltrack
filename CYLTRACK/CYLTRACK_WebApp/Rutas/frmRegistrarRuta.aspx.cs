using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion
{
    public partial class frmRegistrarRuta : System.Web.UI.Page
    {
      
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lstAgregar.Visible = true;
            lstAgregar.Items.Add(lstCiudad.Text);
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstAgregar.SelectedIndex > -1)
            {
                lstAgregar.Items.Remove(lstAgregar.Text);
            }
        }

        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {
            DivSelCiudades.Visible = true;
            btnRegistrar.Visible = true;
        }

       
    }
}