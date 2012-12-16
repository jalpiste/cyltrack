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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnReportar_Click(object sender, EventArgs e)
        {
            txtCodigoCil.Text = "";
        }


    }
}