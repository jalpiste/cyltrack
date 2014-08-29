using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ReporteService;
using CYLTRACK_WebApp.CilindroService;
using System.Data;
using System.Windows.Forms;


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
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            ReportesBE reporte = new ReportesBE();
            DataTable tabla = new DataTable();
            long codigo;
            try 
            {
                codigo = servCilindro.ConsultarExistenciaCilindro(txtCodigoCil.Text);
                
                if (codigo == 0)
                {
                    MessageBox.Show("El Cilindro no se encuentra registrado en el sistema", "Histórico Cilindro");
                    txtCodigoCil.Text = "";
                    DivHistoricoCilindro.Visible = false;
                    btnImp.Visible = false;
                    btnMenuPrincipal.Visible = false;
                    txtCodigoCil.Focus();
                }
                else
                {

                    List<Ubicacion_CilindroBE> resp = new List<Ubicacion_CilindroBE>(serReporte.HistoricoCilindro(txtCodigoCil.Text));

                    tabla.Columns.Add("Usuario");
                    tabla.Columns.Add("Fecha");
                    tabla.Columns.Add("Ubicacion");
                    tabla.Columns.Add("Descripcion");

                    foreach (Ubicacion_CilindroBE datos in resp)
                    {
                        if (datos.Nombre_Ubicacion == Ubicacion.VEHICULO.ToString())
                        {
                            tabla.Rows.Add(datos.Nombre_Usuario, datos.Cilindro.Fecha, datos.Nombre_Ubicacion, datos.Ubicacion.Vehiculo.Placa);
                            gvCargue.DataSource = tabla;
                            gvCargue.DataBind();
                        }
                        else if (datos.Nombre_Ubicacion == Ubicacion.CLIENTE.ToString())
                        {
                            tabla.Rows.Add(datos.Nombre_Usuario, datos.Cilindro.Fecha, datos.Nombre_Ubicacion, datos.Ubicacion.Direccion);
                            gvCargue.DataSource = tabla;
                            gvCargue.DataBind();
                        }
                        else
                        {
                            tabla.Rows.Add(datos.Nombre_Usuario, datos.Cilindro.Fecha, datos.Nombre_Ubicacion);
                            gvCargue.DataSource = tabla;
                            gvCargue.DataBind();
                        }
                    }

                    DivHistoricoCilindro.Visible = true;
                    btnImp.Visible = true;
                    btnMenuPrincipal.Visible = true;
                    gvCargue.Focus();
                }
            }
            catch (Exception ex) 
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                serReporte.Close();
                txtCodigoCil.Text = "";              
            }
        }


    }
}