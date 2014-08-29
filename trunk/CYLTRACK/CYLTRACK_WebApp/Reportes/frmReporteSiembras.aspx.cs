using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYLTRACK_WebApp.VehiculoService;
using CYLTRACK_WebApp.RutaService;
using CYLTRACK_WebApp.CilindroService;
using CYLTRACK_WebApp.ReporteService;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using Unisangil.CYLTRACK.CYLTRACK_WebApp;
using System.Data;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Reporte
{
    public partial class frmReporteSiembras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<string> listaUbica = Auxiliar.ConsultarTipoReporte();
                IEnumerable<string> listaUbicacion = listaUbica.Skip(5);
                foreach (string datosUbica in listaUbicacion)
                {
                    lstReportes.Items.Add(datosUbica.ToString());
                }

               
                RutaServicesClient servRuta = new RutaServicesClient();
                try
                {
                    lstDepto.DataSource = servRuta.ConsultaDepartamento();
                    lstDepto.DataValueField = "Id_Departamento";
                    lstDepto.DataTextField = "Nombre_Departamento";
                    lstDepto.DataBind();                  
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }
                finally
                {
                    servRuta.Close();
                }
                        
        } 
     }
        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ReporteServiceClient servReporte = new ReporteServiceClient();
            ReportesBE reporte = new ReportesBE();
            try 
            {
                if (lstReportes.SelectedValue == Tipo_Reporte.Ciudad.ToString())
                {
                    DataTable table = new DataTable();
                    reporte.IdUbicacion = lstCiudad.SelectedItem.Text;
                    reporte.Fecha_Inicial = Convert.ToDateTime(txtFechaIni.Text);
                    reporte.Fecha_Final = Convert.ToDateTime(txtFechaFin.Text);
                    List<CilindroBE> lstReporteporCiudades = new List<CilindroBE>(servReporte.ReporteSiembrasCiudad(reporte));
                    table.Columns.Add("CiudadSiembra");
                    table.Columns.Add("Cil30");
                    table.Columns.Add("Cil40");
                    table.Columns.Add("Cil80");
                    table.Columns.Add("Cil100");
                    table.Columns.Add("Total");

                    foreach (CilindroBE datos in lstReporteporCiudades)
                    {
                        table.Rows.Add(lstCiudad.SelectedItem.Text, datos.Reportes.SumCil30, datos.Reportes.SumCil40, datos.Reportes.SumCil80, datos.Reportes.SumCil100,
                        datos.NTamano.Cantidad = datos.Reportes.SumCil30 + datos.Reportes.SumCil40 + datos.Reportes.SumCil80 + datos.Reportes.SumCil100);
                        gvReporteCiudad.DataSource = table;
                        gvReporteCiudad.DataBind();
                    }
                    gvReporteCiudad.Visible = true;
                    DivReporte.Visible = true;
                }
                
                if (lstReportes.SelectedValue == Tipo_Reporte.Vehiculos.ToString())
                {
                    //ReportesBE reporte = new ReportesBE();
                    //reporte.IdUbicacion = lstCiudad.SelectedItem.Text;
                    //reporte.Tipo_Cilindro = lstTipoCil.SelectedItem.Text;
                    //List<CilindroBE> lstReporteporCiudades = new List<CilindroBE>(servReporte.ReporteSiembrasCiudad(reporte));
                    //table.Columns.Add("CiudadSiembra");
                    //table.Columns.Add("Cil30");
                    //table.Columns.Add("Cil40");
                    //table.Columns.Add("Cil80");
                    //table.Columns.Add("Cil100");
                    //table.Columns.Add("Total");

                    //foreach (CilindroBE datos in lstReporteporCiudades)
                    //{
                    //    table.Rows.Add(lstCiudad.SelectedItem.Text, datos.Reportes.SumCil30, datos.Reportes.SumCil40, datos.Reportes.SumCil80, datos.Reportes.SumCil100,
                    //    datos.NTamano.Cantidad = datos.Reportes.SumCil30 + datos.Reportes.SumCil40 + datos.Reportes.SumCil80 + datos.Reportes.SumCil100);
                    //    gvReporteCiudad.DataSource = table;
                    //    gvReporteCiudad.DataBind();
                    //}
                    //gvReporteCiudad.Visible = true;
                    //DivReporte.Visible = true;
                }
                
                if (lstReportes.SelectedValue == Tipo_Reporte.Cilindros.ToString())
                {
                    DataTable table = new DataTable();
                    reporte.Fecha_Inicial = Convert.ToDateTime(txtFechaIni.Text);
                    reporte.Fecha_Final = Convert.ToDateTime(txtFechaFin.Text);
                    List<CilindroBE> lstReporteporCilindros = new List<CilindroBE>(servReporte.ReporteSiembrasCilindro(reporte));
                    table.Columns.Add("Cil30");
                    table.Columns.Add("Cil40");
                    table.Columns.Add("Cil80");
                    table.Columns.Add("Cil100");
                    table.Columns.Add("Total");

                    foreach (CilindroBE datos in lstReporteporCilindros)
                    {
                        table.Rows.Add(datos.Reportes.SumCil30, datos.Reportes.SumCil40, datos.Reportes.SumCil80, datos.Reportes.SumCil100,
                        datos.NTamano.Cantidad = datos.Reportes.SumCil30 + datos.Reportes.SumCil40 + datos.Reportes.SumCil80 + datos.Reportes.SumCil100);
                        gvReporteTamano.DataSource = table;
                        gvReporteTamano.DataBind();
                    }
                    gvReporteTamano.Visible = true;
                    DivReporte.Visible = true;
                }
                
            }
            catch(Exception ex)
            {
                Response.Redirect("~/Default.aspx");
            }
            finally
            {
                servReporte.Close();
                divBotones.Visible = true;
            }            
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
                DivReporte.Visible = false;
                gvReporteTamano.Visible = false;
            }
        }

        protected void lstReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstReportes.SelectedValue == Tipo_Reporte.Ciudad.ToString())
            {
                divCiudad.Visible = true;
            }
        }

        protected void lstDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();

            try
            {
                lstCiudad.DataSource = servRuta.ConsultaCiudades(lstDepto.SelectedValue);
                lstCiudad.DataValueField = "Id_Ciudad";
                lstCiudad.DataTextField = "Nombre_Ciudad";
                lstCiudad.DataBind();

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servRuta.Close();
                lstCiudad.Focus();
            }       
        }
                            
    }
}