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
            prueba[] pps = new prueba[2];
            prueba pp = new prueba();
            pp.Prueba1 = "Hola";
            pp.Prueba2 = "Tooo";
            prueba pp1 = new prueba();
            pp1.Prueba1 = "Hola 1";
            pp1.Prueba2 = "Tooo 1";

            pps[0] = pp;
            pps[1] = pp1;
            gvReporte.DataSource = pps;
            gvReporte.DataBind();

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

        public class prueba
        {
            private string prueba1;

            public string Prueba1
            {
                get { return prueba1; }
                set { prueba1 = value; }
            }
            private string prueba2;

            public string Prueba2
            {
                get { return prueba2; }
                set { prueba2 = value; }
            }
        }

    }
}