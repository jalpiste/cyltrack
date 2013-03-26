using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Reporte
{
    public partial class frmHistoricoCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void txtCodigoCil_TextChanged(object sender, EventArgs e)
        {
            DivReporte.Visible = true;
            DivMostrarReporte.Visible = true;
        }


    }
}