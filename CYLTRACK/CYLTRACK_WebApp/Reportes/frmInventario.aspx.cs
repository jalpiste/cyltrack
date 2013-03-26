using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp
{
    public partial class Inventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Ubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUbicacion.SelectedIndex == 1)
            {
                DivReporte.Visible = true;
                DivPlataforma.Visible = true;
                DivBodega.Visible = false;
                DivMantenimiento.Visible = false;
                DivChatarra.Visible = false;
                DivVehiculo.Visible = false;
            }
            if (lstUbicacion.SelectedIndex == 2)
            {
                DivReporte.Visible = true;
                DivBodega.Visible = true;
                DivPlataforma.Visible = false;
                DivMantenimiento.Visible = false;
                DivChatarra.Visible = false;
                DivVehiculo.Visible = false;
            }
            if (lstUbicacion.SelectedIndex == 3)
            {
                DivReporte.Visible = true;
                DivMantenimiento.Visible = true;
                DivPlataforma.Visible = false;
                DivBodega.Visible = false;
                DivChatarra.Visible = false;
                DivVehiculo.Visible = false;
            }
            if (lstUbicacion.SelectedIndex == 4)
            {
                DivReporte.Visible = true;
                DivChatarra.Visible = true;
                DivPlataforma.Visible = false;
                DivBodega.Visible = false;
                DivMantenimiento.Visible = false;
                DivVehiculo.Visible = false;
            }
            if (lstUbicacion.SelectedIndex == 5)
            {
                DivReporte.Visible = true;
                lblPlaca.Visible = true;
                lstPlacaVehículo.Visible = true;
                DivVehiculo.Visible = true;
                DivPlaca.Visible = true;
                DivPlataforma.Visible = false;
                DivBodega.Visible = false;
                DivMantenimiento.Visible = false;
                DivChatarra.Visible = false;

            }
            if (lstUbicacion.SelectedIndex == 6)
            {
                DivReporte.Visible = true;
                lblPlaca.Visible = true;
                lstPlacaVehículo.Visible = true;
                DivVehiculo.Visible = true;
                DivPlaca.Visible = true;
                DivPlataforma.Visible = true;
                DivBodega.Visible = true;
                DivMantenimiento.Visible = true;
                DivChatarra.Visible = true;

            }
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }


    }
}