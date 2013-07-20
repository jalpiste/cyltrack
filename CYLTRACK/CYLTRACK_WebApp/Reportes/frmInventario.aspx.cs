using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_WebApp.Reportes;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ReporteService;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp
{
    public partial class Inventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> tipoCil = Auxiliar.ConsultaTipoCilindro();
                foreach (string tip in tipoCil)
                {
                    lstTipoCil.Items.Add(tip);
                }
            }

            if (!IsPostBack)
            {
                List<string> lstUbica = Auxiliar.ConsultarUbicacion();

                lstUbica.Add("Todos");
                foreach (string datos in lstUbica)
                {
                    lstUbicacion.Items.Add(datos);
                }
                
            }
        }

        protected void Ubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReporteServiceClient servReport = new ReporteServiceClient();
            ReportesBE reporte = new ReportesBE();
            
            try 
            {

                if (lstUbicacion.SelectedIndex == 5)
                {
                    Tipo_UbicacionBE tipUbi = new Tipo_UbicacionBE();
                    UbicacionBE ubi = new UbicacionBE();
                    ubi.Tipo_Ubicacion = tipUbi;
                    reporte.Ubicacion = ubi;
                    CilindroBE cil = new CilindroBE();
                    cil.Tipo_Cilindro = lstTipoCil.SelectedValue;
                    reporte.Cilindro = cil;
                    reporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = lstUbicacion.SelectedValue;
                    List<ReportesBE> lstReporte = new List<ReportesBE>(servReport.Inventario(reporte));

                    foreach (ReportesBE datos in lstReporte)
                    {
                        lstPlacaVehículo.Items.Add(datos.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion);
                    }
                    divPlaca.Visible = true;
                }
                else
                {
                    divPlaca.Visible = false;
                    lstPlacaVehículo.ClearSelection();
                }
                               
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                servReport.Close();
            }
            
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ReporteServiceClient servReporte = new ReporteServiceClient();
            ReportesBE reporte = new ReportesBE();
            DataTable tabla = new DataTable();
            try 
            {
                reporte.Fecha_Reporte = Convert.ToDateTime(txtFecha.Text);
                Tipo_UbicacionBE tipoUbica = new Tipo_UbicacionBE();
                tipoUbica.Nombre_Ubicacion = lstUbicacion.SelectedValue;
                UbicacionBE ubi = new UbicacionBE();
                ubi.Tipo_Ubicacion = tipoUbica;
                reporte.Ubicacion = ubi;
                VehiculoBE veh = new VehiculoBE();
                veh.Placa = lstPlacaVehículo.SelectedValue;
                reporte.Vehiculo = veh;
                CilindroBE cil = new CilindroBE();
                cil.Tipo_Cilindro = lstTipoCil.SelectedValue;
                reporte.Cilindro = cil;
                List<ReportesBE> lstInventario = new List<ReportesBE>(servReporte.Inventario(reporte));

                tabla.Columns.Add("Ubicacion");
                tabla.Columns.Add("Cil30");
                tabla.Columns.Add("Cil40");
                tabla.Columns.Add("Cil80");
                tabla.Columns.Add("Cil100");
                tabla.Columns.Add("TipoCil");

                foreach (ReportesBE datos in lstInventario)
                {
                    tabla.Rows.Add(datos.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion, datos.Cilindro.Cantidad, datos.Cilindro.Cantidad,
                    datos.Cilindro.Cantidad, datos.Cilindro.Cantidad, datos.Cilindro.Tipo_Cilindro);
                    gvInventario.DataSource = tabla;
                    gvInventario.DataBind();
         
                }

                divInventario.Visible = true;
                divBotones.Visible = true;
            
            }
            catch (Exception ex) 
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                servReporte.Close();
            }       
            

        }
     }
}