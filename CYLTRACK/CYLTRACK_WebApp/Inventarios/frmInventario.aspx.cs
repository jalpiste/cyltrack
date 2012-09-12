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
                DivPlataforma.Visible = true;
                DivBodega.Visible = false;
                DivMantenimiento.Visible = false;
                DivChatarra.Visible = false;
                DivVehiculo.Visible = false; 
            }
            if (lstUbicacion.SelectedIndex == 2)
            {
                DivBodega.Visible = true;
                DivPlataforma.Visible = false;
                DivMantenimiento.Visible = false;
                DivChatarra.Visible = false;
                DivVehiculo.Visible = false; 
            }
            if (lstUbicacion.SelectedIndex == 3)
            {
                DivMantenimiento.Visible = true;
                DivPlataforma.Visible = false;
                DivBodega.Visible = false;
                DivChatarra.Visible = false;
                DivVehiculo.Visible = false; 
            }
            if (lstUbicacion.SelectedIndex == 4)
            {
                DivChatarra.Visible = true;
                DivPlataforma.Visible = false;
                DivBodega.Visible = false;
                DivMantenimiento.Visible = false;
                DivVehiculo.Visible = false; 
            }
            if (lstUbicacion.SelectedIndex == 5)
            {
                lblPlaca.Visible = true;
                lstPlacaVehículo.Visible = true;
                DivVehiculo.Visible = true;
                DivPlataforma.Visible = false;
                DivBodega.Visible = false;
                DivMantenimiento.Visible = false;
                DivChatarra.Visible = false;
                 
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        
    }
}