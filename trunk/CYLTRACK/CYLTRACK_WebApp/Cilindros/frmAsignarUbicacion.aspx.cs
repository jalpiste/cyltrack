using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp
{

    public partial class AsignarUbicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtCodeCilindro_TextChanged(object sender, EventArgs e)
        {
            DivUbicacionCil.Visible = true;
            DivNuevaUbicacion.Visible = true;
            BtnGuardar.Visible = true;
        }

        protected void Ubica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUbica.SelectedIndex == 4)
            {
                lblPlaca.Visible = true;
                lstPlacaVehiculo.Visible = true;
                LblConductor.Visible = true;
                TxtConductor.Visible = true;
                LblRuta.Visible = true;
                LblRutaVehiculo.Visible = true;
            }

        }

        public string ValidationGroup { get; set; }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            //txtCodeCilindro.Text = "";
            //DivUbicacionCil.Visible = false;
            //DivNuevaUbicacion.Visible = false;
        }
       
        
    }
}
