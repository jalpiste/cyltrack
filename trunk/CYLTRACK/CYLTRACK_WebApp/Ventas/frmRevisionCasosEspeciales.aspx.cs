using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmRevisionCasosEspeciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            prueba[] pps = new prueba[2];
            prueba pp = new prueba();
            pp.Id_Caso = "097";
            pp.Tipo_Caso = "Escape";
            prueba pp1 = new prueba();
            pp1.Id_Caso = "098";
            pp1.Tipo_Caso = "Cilindro Erroneo";

            pps[0] = pp;
            pps[1] = pp1;
            gvReporte.DataSource = pps;
            gvReporte.DataBind();
        }
        VentaBE ventas = new VentaBE();
        public class prueba
        {
            private string prueba1;

            public string Id_Caso
            {
                get { return prueba1; }
                set { prueba1 = value; }
            }
            private string prueba2;

            public string Tipo_Caso
            {
                get { return prueba2; }
                set { prueba2 = value; }
            }
        }

        protected void lstCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lstCaso.Text= ventas.Casos_Especiales.Tipo_Caso.Nombre_Caso;
            gvReporte.Visible = true;
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        
    }
}