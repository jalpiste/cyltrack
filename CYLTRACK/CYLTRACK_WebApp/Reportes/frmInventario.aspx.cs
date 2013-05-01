using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_WebApp.Reportes;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp
{
    public partial class Inventario : System.Web.UI.Page
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

            //lstDesdeMes.Text = reporte.Mes_Reporte;
            //lstUbicacion.Text = reporte.Ubicacion_Cilindro.Nombre;
            //lstPlacaVehículo.Text = reporte.Vehiculo.Placa;

        }

        ReportesBE reporte = new ReportesBE();

        protected void Ubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstUbicacion.SelectedIndex == 5)
            {
                divPlaca.Visible = true;
            }

        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //reporte.Fecha_Reporte = Convert.ToDateTime(txtDesdeDia.Text + "." + lstDesdeMes.SelectedValue + "." + txtDesdeAño.Text);
            //reporte.Ubicacion_Cilindro.Nombre = lstUbicacion.SelectedValue;
            //reporte.Vehiculo.Placa = lstPlacaVehículo.SelectedValue;

            divInventario.Visible = true;
            divBotones.Visible = true;

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