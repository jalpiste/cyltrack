using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Cilindros
{
    public partial class frmCargaryDescargarCilindros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            prueba[] pps = new prueba[2];

            prueba pp = new prueba();
            pp.Codigo_Cilindro = "09987";
            pp.Prueba2 = "Tooo";
            prueba pp1 = new prueba();
            pp1.Codigo_Cilindro = "675675";
            pp1.Prueba2 = "Tooo 1";

            pps[0] = pp;
            pps[1] = pp1;
            gvReporte.DataSource = pps;
            gvReporte.DataBind();
                        
        }

        public class prueba
        {
            private string prueba1;

            public string Codigo_Cilindro
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

       
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void lstOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivUbicacionCil.Visible = true;
                                        
        }

        protected void gvReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (gvReporte.SelectedDataKey["Checking"].ToString() == "True")
            {
                
            }
            else 
            {
                gvReporte.DataBind();
            }

        }

                       
    }
}