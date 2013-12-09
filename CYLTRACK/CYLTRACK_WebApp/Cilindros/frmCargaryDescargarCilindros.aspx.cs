using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYLTRACK_WebApp.CilindroService;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.Data;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmCargaryDescargarCilindros : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                lstOpcion.Focus();
            }
        }

        List<CilindroBE> lstCodigos = new List<CilindroBE>();

        protected void lstOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPlaca.Focus();
                CilindroServiceClient servCilindro = new CilindroServiceClient();
                
                string datoUbica= null ;
                DataTable table = new DataTable();
        
            try
                {
                    table.Columns.Add("CodigosCil");
                    table.Columns.Add("Tamano");
                    table.Columns.Add("TipoCil");

                    if (lstOpcion.SelectedIndex == 1)
                    {
                        datoUbica= Ubicacion.Plataforma.ToString();
                        DivUbicacionCil.Visible = true;
                        lstPlaca.Visible = true;
                        lblPlaca.Visible = true;
                        BtnGuardar.Visible = true;
                        gvCargue.Visible = true;
                    }
                    else 
                    {
                        datoUbica = Ubicacion.Vehiculo.ToString();
                        DivUbicacionCil.Visible = true;
                        BtnGuardar.Visible = true;
                        gvCargue.Visible = true;
                    }

                    List<Ubicacion_CilindroBE> datosConsulta = new List<Ubicacion_CilindroBE>(servCilindro.ConsultarCilUbicacion(datoUbica));
                    
                    foreach (Ubicacion_CilindroBE datos in datosConsulta)
                    {
                        table.Rows.Add(datos.Cilindro.Codigo_Cilindro, datos.Cilindro.NTamano.Tamano, datos.Cilindro.Tipo_Cilindro);
                        //lstPlaca.Items.Add(datos.Ubicacion.Vehiculo.Placa);
                    }
                    gvCargue.DataSource = table;
                    gvCargue.DataBind();
                    
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }
                finally
                {
                    servCilindro.Close();
                }
                                 
        }

        protected void gvReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (gvCargue.SelectedDataKey["Checking"].ToString() == "True")
            {
                
            }
            else 
            {
                gvCargue.DataBind();
            }

        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void BtnGuardar_Click1(object sender, EventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            
            List<CilindroBE> guardarDatos= new List<CilindroBE>();

            try
            {

                foreach (CilindroBE cilindro in lstCodigos)
                {
                    CilindroBE cil = new CilindroBE();
                    cil.Codigo_Cilindro = cilindro.Codigo_Cilindro;

                    if (lstOpcion.SelectedValue == Ubicacion.Plataforma.ToString())
                    {
                        cil.Ubicacion_Cilindro.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = Ubicacion.Plataforma.ToString();
                    }

                    else
                    {
                        cil.Codigo_Cilindro = cilindro.Codigo_Cilindro;
                        cil.Ubicacion_Cilindro.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = Ubicacion.Vehiculo.ToString();
                    }

                    guardarDatos.Add(cil);
                }
                
                string resp = servCilindro.CargueyDescargueCilindros(guardarDatos.ToArray());
                MessageBox.Show("Los datos han sido guardados satisfactoriamente", "Cargue o descargue de Cilindro");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            {
                servCilindro.Close();
                Response.Redirect("~/Cilindros/frmCargaryDescargarCilindros.aspx");                
            }
        }

        protected void lstPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdAdd.Focus();
            
        }

        protected void Agregar_onClick(object sender, EventArgs e)
        {
              BtnGuardar.Focus();
              DataTable tabla = new DataTable();
               
                try
                {
                    CilindroBE cil = new CilindroBE();
                    cil.Codigo_Cilindro = ((System.Web.UI.WebControls.Button)sender).Attributes["value"].ToString();

                        foreach(CilindroBE datos in lstCodigos)
                            {
                            if(cil.Codigo_Cilindro==datos.Codigo_Cilindro)
                                {
                                lstCodigos.Remove(datos);
                                }
                            };
                                           
                        lstCodigos.Add(cil);
                        tabla.Columns.Add("CodigosAdd");

                        foreach (CilindroBE info in lstCodigos)
                        {
                            tabla.Rows.Add(info.Codigo_Cilindro);
                        }
                        gdAdd.DataSource = tabla;
                        gdAdd.DataBind();                    
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx"); 
                }
                finally 
                {
                    gdAdd.Visible = true;
                }
           }                            
    }
}