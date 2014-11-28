using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_WebApp.Reportes;
using CYLTRACK_WebApp.CilindroService;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ReporteService;
using CYLTRACK_WebApp.VehiculoService;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.UI.WebControls.WebParts;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp
{
    public partial class Inventario : System.Web.UI.Page
    {
        List<CilindroBE> lstDetail = new List<CilindroBE>();
        List<CilindroBE> lsAux = new List<CilindroBE>();
        List<CilindroBE> lsAuxDos = new List<CilindroBE>();
        DataTable objdtLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            ReporteServiceClient servReporte = new ReporteServiceClient();
         
            try
            {
                if (!IsPostBack)
                {
                    List<string> tipoCil = Auxiliar.ConsultaTipoCilindro();
                    foreach (string tip in tipoCil)
                    {
                        lstTipoCil.Items.Add(tip);
                    }

                    lstUbicacion.DataSource = servReporte.ConsultaTipoUbicacion().Skip(1);
                    lstUbicacion.DataValueField = "Id_Tipo_Ubica";
                    lstUbicacion.DataTextField = "Nombre_Ubicacion";
                    lstUbicacion.DataBind();
                    objdtLista = new DataTable();
                    CrearTabla();
                }
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

        protected DataTable objdtTabla
        {
            get
            {
                if (ViewState["objdtTabla"] != null)
                {
                    return (DataTable)ViewState["objdtTabla"];
                }
                else
                {
                    return objdtLista;
                }
            }
            set
            {
                ViewState["objdtTabla"] = value;
            }
        }
       
        private void CrearTabla()
        {
            objdtLista.Columns.Add("Ubicacion");
            objdtLista.Columns.Add("CodigosCil");
            objdtLista.Columns.Add("Tamano");
            objdtLista.Columns.Add("TipoCil");
            objdtLista.Columns.Add("TotaCil");
            objdtTabla = objdtLista;
        }
        
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ReporteServiceClient servReporte = new ReporteServiceClient();
            ReportesBE reporte = new ReportesBE();
            DataTable table = new DataTable();
            DataTable tabla2 = new DataTable();
            try 
            {
                reporte.Tipo_Cilindro = "'" + lstTipoCil.SelectedItem.Text + "'";
                reporte.IdUbicacion = "'" + lstUbicacion.SelectedValue + "'";
                reporte.IdVehiculo = "'" + lstPlacaVehículo.SelectedValue + "'";
                reporte.Fecha_Inicial = Convert.ToDateTime(txtFecha.Text);

                List<Ubicacion_CilindroBE> datosConsulta = new List<Ubicacion_CilindroBE>(servReporte.ConsultarCilInventario(reporte));

           // lsAux = (List<TamanoBE>)Session["lista"];
            table.Columns.Add("Ubicacion");
            table.Columns.Add("CodigosCil");
            table.Columns.Add("Tamano");
            table.Columns.Add("TipoCil");
            tabla2.Columns.Add("Ubicacion");
            tabla2.Columns.Add("Cantidad");
            tabla2.Columns.Add("Tamano");
            foreach (Ubicacion_CilindroBE datos in datosConsulta)
            {
                table.Rows.Add(datos.Nombre_Ubicacion, datos.Cilindro.Codigo_Cilindro, datos.Cilindro.NTamano.Tamano, datos.Cilindro.Tipo_Cilindro);
                //if (datos.Cilindro.NTamano.Tamano == "30")
                //{
                tabla2.Rows.Add(datos.Nombre_Ubicacion, datos.Reportes.SumCil30, datos.Cilindro.NTamano.Tamano);
                //}
                //if (datos.Cilindro.NTamano.Tamano == "40")
                //{
                tabla2.Rows.Add(datos.Nombre_Ubicacion, datos.Reportes.SumCil40, datos.Cilindro.NTamano.Tamano);
                //}
                //if (datos.Cilindro.NTamano.Tamano == "80")
                //{
                tabla2.Rows.Add(datos.Nombre_Ubicacion, datos.Reportes.SumCil80, datos.Cilindro.NTamano.Tamano);
                //}
                //if (datos.Cilindro.NTamano.Tamano == "100")
                //{
                tabla2.Rows.Add(datos.Nombre_Ubicacion, datos.Reportes.SumCil100, datos.Cilindro.NTamano.Tamano);
                //}
            }
            gvInventario.DataSource = table;
            gvInventario.DataBind();
            gvCantidad.DataSource = tabla2;
            gvCantidad.DataBind();
            //Session["lsAuxDos"] = table;
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

        protected void lstUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient serVehiculo = new VehiculoServiceClient();
            try
            {
                if (lstUbicacion.SelectedItem.Text == Ubicacion.VEHICULO.ToString())
                {
                    lstPlacaVehículo.DataSource = serVehiculo.ConsultarVehiculo(string.Empty);
                    lstPlacaVehículo.DataValueField = "Id_Vehiculo";
                    lstPlacaVehículo.DataTextField = "Placa";
                    lstPlacaVehículo.DataBind();
                    divPlaca.Visible = true;
                }
                else 
                {
                    divPlaca.Visible = true;                    
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                serVehiculo.Close();
            }  
        }

        protected void btnImp_Click(object sender, EventArgs e)
        {
            //Document document = new Document(); 
            //PdfWriter.GetInstance(document, new FileStream("devjoker.pdf", FileMode.OpenOrCreate)); 
            //document.Open(); 
            //document.Add(new Paragraph("Este es mi primer PDF al vuelo")); 
            //document.Close();

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formulario.pdf");
            FillPDF(Server.MapPath("Plantilla.pdf"), Response.OutputStream);
            
        }

        public void FillPDF(string template, Stream stream)
        {
            
            PdfReader reader = new PdfReader(template);
            PdfStamper stamp = new PdfStamper(reader, stream);

            stamp.AcroFields.SetField("FECHADEREPORTE", txtFecha.Text);
            stamp.AcroFields.SetField("TIPODECILINDRO", lstTipoCil.SelectedItem.Text);
            stamp.AcroFields.SetField("UBICACIÓN", lstTipoCil.SelectedItem.Text);
            stamp.AcroFields.SetField("ITEM", lstPlacaVehículo.SelectedItem.Text);

            //foreach(Datatable )
            //{
            
            //}

            //stamp.AcroFields.SetField("UBICIL1", lstTipoCil.SelectedItem.Text);
            //stamp.AcroFields.SetField("CAMPO2", lstUbicacion.SelectedItem.Text);
            //stamp.AcroFields.SetField("CAMPO1", lstTipoCil.SelectedItem.Text);
            //stamp.AcroFields.SetField("CAMPO2", lstUbicacion.SelectedItem.Text);
            stamp.FormFlattening = true;
            stamp.Close();
        }
     }
}