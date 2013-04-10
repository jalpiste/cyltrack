using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmCasosEspeciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lstCasosEspeciales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCasosEspeciales.SelectedIndex == 1)
            {
                divConsultarCilindro.Visible = true;
            }
            
        }

        protected void lstCodigosVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (lstCodigosVehiculo.SelectedIndexChanged) {
            //    DivDatosCilindro.Visible = true;
            //    divCodigoCorrecto.Visible = true;
            //}
            
        }

        

    }
}