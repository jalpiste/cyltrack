using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp
{

    public partial class AsignarUbicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Ubica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUbica.SelectedIndex == 4)
            {
                lblPlaca.Visible = true;
                lstPlacaVehiculo.Visible = true;
            }

        }

        protected void Cambiar_Click(object sender, EventArgs e)
        {
            DivNuevaUbicacion.Visible = true;
        }

        protected void txtCodeCilindro_TextChanged(object sender, EventArgs e)
        {
            txtCodigoCilindro.Text = txtCodeCilindro.Text;
            txtCodeCilindro.Text = "";
            DivUbicacionCil.Visible = true;
            DivImpresionCodigo.Visible = true;
        }


        public string ValidationGroup { get; set; }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
