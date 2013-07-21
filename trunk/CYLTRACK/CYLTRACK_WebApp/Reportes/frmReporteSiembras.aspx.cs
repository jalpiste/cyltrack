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
        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DivReporte.Visible = true;
            divBotones.Visible = true;
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void txtFechaFin_TextChanged(object sender, EventArgs e)
        {
            DateTime fechaFin = new DateTime();
            fechaFin = DateTime.Parse(txtFechaFin.Text);

            DateTime fechaInicio = new DateTime();
            fechaInicio = DateTime.Parse(txtFechaIni.Text);

            if (fechaFin < fechaInicio)
            {
                txtFechaFin.Text = "";
                Response.Write("<script type='text/javascript'> alert('La fecha final debe ser mayor o igual a la fecha inicial') </script>");
            }
        }

        protected void lstReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstReportes.SelectedIndex ==1)
            {
                lstDepto.Visible = true;
                lstCiudad.Visible = true;
                gvReporteCiudad.Visible = true;
            }
            if (lstReportes.SelectedIndex == 2)
            {
                gvReporteTamano.Visible = true;
            }
            if (lstReportes.SelectedIndex == 3)
            {
                lstPlaca.Visible = true;
            }
        }

    }
}