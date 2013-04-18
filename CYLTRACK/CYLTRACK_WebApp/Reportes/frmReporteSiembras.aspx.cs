using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Reporte
{
    public partial class frmReporteSiembras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Ubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUbicacion.SelectedIndex == 1)
            {
                lblPlaca.Visible = true;
                lstPlacaVehículo.Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DivReporte.Visible = true;
            divBotones.Visible = true;

        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}