using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ReporteService;
using System.Data;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Reportes
{
    public partial class frmHistoricoCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                txtCodigoCil.Focus();
            }
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SetFocus(gvCargue);
            ReporteServiceClient serReporte = new ReporteServiceClient();
            ReportesBE reporte = new ReportesBE();
            DataTable tabla = new DataTable();
            
            try 
            {
                List<ReportesBE> resp = new List<ReportesBE>(serReporte.HistoricoCilindro(txtCodigoCil.Text));
                
                 tabla.Columns.Add("CodigosCil");
                 tabla.Columns.Add("Tamano");
                 tabla.Columns.Add("Fecha");
                 tabla.Columns.Add("Ubicacion");

                 foreach (ReportesBE datos in resp)
                 {
                     tabla.Rows.Add(datos.Cilindro.Codigo_Cilindro, datos.Cilindro.NTamano.Tamano, datos.Fecha_Reporte, datos.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion);
                     gvCargue.DataSource = tabla;
                     gvCargue.DataBind();

                 }

                DivHistoricoCilindro.Visible = true;
                btnImp.Visible = true;
                btnMenuPrincipal.Visible = true;

            }
            catch (Exception ex) 
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                serReporte.Close();
                
            }          
            
                        
        }


    }
}