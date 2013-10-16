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

                List<string> listaTipoCil = Auxiliar.ConsultaTipoCilindro();
                foreach (string datosCil in listaTipoCil)
                {
                    lstTipoCil.Items.Add(datosCil.ToString());
                } 

                RutaServicesClient servRuta = new RutaServicesClient();
                try
                {
                    List<CiudadBE> datosCiudades = new List<CiudadBE>(servRuta.ConsultaDepartamentoyCiudades());
                    foreach (CiudadBE datos in datosCiudades)
                    {
                        lstCiudad.Items.Add(datos.Nombre_Ciudad);
                        lstDepto.Items.Add(datos.Departamento.Nombre_Departamento);
                    }
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
            DataTable table = new DataTable();
            try 
            {
                if (lstReportes.SelectedValue == Tipo_Reporte.Ciudad.ToString())
                {
                    List<UbicacionBE> lstReporteporCiudades = new List<UbicacionBE>(servReporte.ConsultaReporteCiudades(lstCiudad.SelectedValue, lstTipoCil.SelectedValue));
                    table.Columns.Add("CiudadSiembra");
                    table.Columns.Add("Cil30");
                    table.Columns.Add("Cil40");
                    table.Columns.Add("Cil80");
                    table.Columns.Add("Cil100");
                    table.Columns.Add("Total");

                    foreach (UbicacionBE datos in lstReporteporCiudades)
                    {
                        table.Rows.Add(datos.Ciudad.Nombre_Ciudad, datos.Ubicacion_Cilindro.Cilindro.Cantidad, datos.Ubicacion_Cilindro.Cilindro.Cantidad, datos.Ubicacion_Cilindro.Cilindro.Cantidad, datos.Ubicacion_Cilindro.Cilindro.Cantidad, datos.Ubicacion_Cilindro.Cilindro.Cantidad);
                        gvReporteCiudad.DataSource = table;
                        gvReporteCiudad.DataBind();
                    }
                    gvReporteCiudad.Visible = true;
                    DivReporte.Visible = true;
                }
                
                if (lstReportes.SelectedValue == Tipo_Reporte.Vehiculos.ToString())
                {
                    List<UbicacionBE> lstReporteporPlacas = new List<UbicacionBE>(servReporte.ReporteporPlacas(lstTipoCil.SelectedValue));
                    table.Columns.Add("Placa");
                    table.Columns.Add("Cil30");
                    table.Columns.Add("Cil40");
                    table.Columns.Add("Cil80");
                    table.Columns.Add("Cil100");
                    table.Columns.Add("Total");

                    foreach (UbicacionBE datos in lstReporteporPlacas)
                    {
                        table.Rows.Add(datos.Vehiculo.Placa, datos.Ubicacion_Cilindro.Cilindro.Cantidad, datos.Ubicacion_Cilindro.Cilindro.Cantidad, datos.Ubicacion_Cilindro.Cilindro.Cantidad, datos.Ubicacion_Cilindro.Cilindro.Cantidad, datos.Ubicacion_Cilindro.Cilindro.Cantidad);
                        gvReportePlacas.DataSource = table;
                        gvReportePlacas.DataBind();
                    }
                    gvReportePlacas.Visible = true;
                    DivReporte.Visible = true;
                }
                
                if (lstReportes.SelectedValue == Tipo_Reporte.Cilindros.ToString())
                {
                    List<CilindroBE> lstReporteporCilindro = new List<CilindroBE>(servReporte.ReporteCilindro(lstTipoCil.SelectedValue));

                    table.Columns.Add("Cantidad");
                    table.Columns.Add("Tamano");
                    foreach (CilindroBE datos in lstReporteporCilindro)
                    {
                        table.Rows.Add(datos.Cantidad, datos.NTamano.Tamano);
                        gvReporteTamano.DataSource = table;
                        gvReporteTamano.DataBind();
                    }
                    DivReporte.Visible = true;
                    gvReporteTamano.Visible = true;
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
                            
    }
}