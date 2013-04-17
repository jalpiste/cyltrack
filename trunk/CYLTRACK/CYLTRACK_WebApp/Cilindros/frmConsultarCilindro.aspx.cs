using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmConsultarCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void txtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            DivDatosCilindro.Visible = true;
            BtnNuevaConsulta.Visible = true;
            if (TxtUbicacion.Text == "Vehiculo") 
            {
                DivInfoVehiculo.Visible = true;
            }
            if (TxtUbicacion.Text == "Cliente") 
            {
                DivInfoCilindro.Visible = true;
            }
            
        }

        protected void BtnNuevaConsulta_Click(object sender, EventArgs e)
        {
            //DivDatosCilindro.Visible = false;
            //DivInfoCilindro.Visible = false;
        }

        protected void BtnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }




    }
}