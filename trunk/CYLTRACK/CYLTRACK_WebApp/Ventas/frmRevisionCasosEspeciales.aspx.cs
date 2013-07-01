using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.VentaService;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas
{
    public partial class frmRevisionCasosEspeciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> tiposCasos = Auxiliar.ConsultarTipoCaso();
                foreach (string datosCasos in tiposCasos)
                {
                    lstCaso.Items.Add(datosCasos);
                }
            }
            if(IsPostBack)
            {
                gvReporte.Focus();
            }
        }
       
        protected void lstCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            VentaServiceClient serVenta = new VentaServiceClient();
            DataTable tabla = new DataTable();
            
            try
            {
                Tipo_CasoBE tipo = new Tipo_CasoBE();
                tipo.Nombre_Caso= lstCaso.SelectedValue;
                CasosBE casos = new CasosBE();
                casos.Tipo_Caso = tipo;
                List<CasosBE> lstDatCasos = new List<CasosBE>(serVenta.RevisionCasosEspeciales(casos));

                tabla.Columns.Add("Id_Caso");
                tabla.Columns.Add("Tipo_Caso");
                foreach (CasosBE datos in lstDatCasos) 
                {
                    tabla.Rows.Add(datos.Id_Casos, datos.Tipo_Caso.Nombre_Caso);
                    gvReporte.DataSource= tabla;
                    gvReporte.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                serVenta.Close();
                gvReporte.Visible = true;
            }           
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }
        protected void btnTipoCaso_OnClick(object sender, EventArgs e)
        {
            string registro = ((Button)sender).Attributes["value"].ToString();
            lblSeleccionGrid.Text = registro;
            Response.Redirect("~/Ventas/frmTiposdeCasos.aspx?Data=" + Server.UrlEncode(lblSeleccionGrid.Text)); 
        }

               
    }
}