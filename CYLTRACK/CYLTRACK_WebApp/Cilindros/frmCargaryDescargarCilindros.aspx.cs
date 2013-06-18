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

        List<CilindroBE> lstCodigos = new List<CilindroBE>();

        protected void lstOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            {
                CilindroServiceClient servCilindro = new CilindroServiceClient();
                CilindroBE cil = new CilindroBE();
                DataTable table = new DataTable();

                try
                {
                    table.Columns.Add("CodigosCil");
                    table.Columns.Add("Tamano");
                    table.Columns.Add("TipoCil");

                    if (lstOpcion.SelectedIndex == 1)
                    {
                        Tipo_UbicacionBE tipUbi = new Tipo_UbicacionBE();
                        tipUbi.Nombre_Ubicacion = "Plataforma";
                        UbicacionBE ubi = new UbicacionBE();
                        ubi.Tipo_Ubicacion = tipUbi;
                        cil.Ubicacion = ubi;

                    }
                    if (lstOpcion.SelectedIndex == 2)
                    {
                        Tipo_UbicacionBE tipUbi = new Tipo_UbicacionBE();
                        tipUbi.Nombre_Ubicacion = "Vehiculo";
                        UbicacionBE ubi = new UbicacionBE();
                        ubi.Tipo_Ubicacion = tipUbi;
                        cil.Ubicacion = ubi;

                    }
                    CilindroBE[] datosCod = new CilindroBE[7];

                    datosCod = servCilindro.CargueyDescargueCilindro(cil);
                    foreach (CilindroBE datos in datosCod)
                    {
                        table.Rows.Add(datos.Codigo_Cilindro, datos.NTamano.Tamano, datos.Tipo_Cilindro);
                        lstPlaca.Items.Add(datos.Vehiculo.Placa);
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
               //CilindroServiceClient servCilindro = new CilindroServiceClient();
                //CilindroBE cil = new CilindroBE();
                //try
                //{
                //    CilindroBE[] datosCod = servCilindro.CargueyDescargueCilindro(cil);
                //    foreach (CilindroBE datos in datosCod)
                //    {
                //        lstPlaca.Items.Add(datos.Vehiculo.Placa);
                //    }
                //    DivUbicacionCil.Visible = true;
                //    BtnGuardar.Visible = true;
                //}
                //catch (Exception ex)
                //{
                //    Response.Redirect("~/About.aspx");
                //}
                //finally
                //{
                //    servCilindro.Close();
                //}
                        
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
                
                CilindroBE cil = new CilindroBE();
                DataTable tabla = new DataTable();
               
                try
                {
                        string registro = ((Button)sender).Attributes["value"].ToString();
                        cil.Codigo_Cilindro = registro;
                        foreach (CilindroBE detalle in lstCodigos)
                        {
                            if (detalle.Codigo_Cilindro == cil.Codigo_Cilindro)
                            {
                                cil.Codigo_Cilindro += detalle.Codigo_Cilindro;
                                lstCodigos.Remove(detalle);
                            }

                        }
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