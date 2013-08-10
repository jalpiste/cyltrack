using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYLTRACK_WebApp.CilindroService;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.Data;

namespace CYLTRACK_WebApp.Cilindros
{

    public partial class frmCargaryDescargarCilindros : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
                          
        }

        List<string> lstCodigos = new List<string>();

        protected void lstOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {           
            
                CilindroServiceClient servCilindro = new CilindroServiceClient();
                CilindroBE cil = new CilindroBE();
                string datoUbica= null ;
                DataTable table = new DataTable();
        
            try
                {
                    table.Columns.Add("CodigosCil");
                    table.Columns.Add("Tamano");
                    table.Columns.Add("TipoCil");
                    
                    if (lstOpcion.SelectedIndex == 1)
                    {
                        datoUbica= "Plataforma";                       
                    }
                    else 
                    {
                        datoUbica = "Vehiculo";
                    }
                                    
                    CilindroBE[] datosCod = new CilindroBE[7];

                    datosCod = servCilindro.CargueyDescargueCilindro(datoUbica);
                    foreach (CilindroBE datos in datosCod)
                    {
                        table.Rows.Add(datos.Codigo_Cilindro, datos.NTamano.Tamano, datos.Tipo_Cilindro);
                        lstPlaca.Items.Add(datos.Ubicacion.Vehiculo.Placa);
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
                    DivUbicacionCil.Visible = true;
                    BtnGuardar.Visible = true;
                    gvCargue.Visible = true;
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
            //CilindroServiceClient servCilindro = new CilindroServiceClient();
            //CilindroBE cil = new CilindroBE();
            //CilindroBE[] guardarDatos;
            
            //try
            //{
            //    foreach (CilindroBE cilindro in lstCodigos) 
            //    {
            //        cil.Codigo_Cilindro = cilindro.Codigo_Cilindro;           
            //    }
                
            //    guardarDatos = servCilindro.CargueyDescargueCilindro(cil);
                
            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("~/About.aspx");
            //}
            //finally
            //{
            //    servCilindro.Close();
            //    Response.Redirect("~/Cilindros/frmCargaryDescargarCilindros.aspx");
            //}
        }

        protected void lstPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cil = new CilindroBE();

            try
            {
                //gvCargue.Visible = true;
                
                //CilindroBE[] datosCod = servCilindro.CargueyDescargueCilindro();

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

        protected void Agregar_onClick(object sender, EventArgs e)
        {
              DataTable tabla = new DataTable();
               
                try
                {
                        string registro = ((Button)sender).Attributes["value"].ToString();

                        lstCodigos.ForEach(delegate(String registros)
                            {
                                lstCodigos.Remove(registros);
                            });

                       
                        lstCodigos.Add(registro);

                        tabla.Columns.Add("CodigosAdd");

                        foreach (string info in lstCodigos)
                        {
                            tabla.Rows.Add(info);
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