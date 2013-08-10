using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.RutaService;
using System.Windows.Forms;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Rutas
{
    public partial class frmRegistrarRuta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtNombreRuta.Focus();
            }
            if(IsPostBack)
            {
                btnGuardar.Focus();
            }
            if (!IsPostBack)
            {
                RutaServicesClient servRuta = new RutaServicesClient();
                string dato = "nada por ahora";
                try
                {
                    CiudadBE[] datosCiudades = new CiudadBE[(servRuta.ConsultaDepartamentoyCiudades(dato)).Count()];
                    datosCiudades = servRuta.ConsultaDepartamentoyCiudades(dato);
                    foreach (CiudadBE datos in datosCiudades)
                    {
                        lstCiudad.Items.Add(datos.Nombre_Ciudad);
                        lstDepartamento.Items.Add(datos.Departamento.Nombre_Departamento);
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
        List<string> lstCiudades = new List<string>();
          protected void btnAgregar_Click(object sender, EventArgs e)
        {
            RutaBE ruta = new RutaBE();
            DataTable tabla = new DataTable();

            try
            {
                string registro = lstCiudad.SelectedValue;
               
                   foreach(string datos in lstCiudades)
                    {
                       if(datos==registro){
                        lstCiudades.Remove(registro);
                    }
                   }

                    lstCiudades.Add(registro);

               tabla.Columns.Add("CiudadesAdd");

                foreach (string info in lstCiudades)
                {
                    tabla.Rows.Add(info);
                    gdAdd.DataSource = tabla;
                    gdAdd.DataBind();
                }

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

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            RutaBE ruta = new RutaBE();
            DataTable tabla = new DataTable();

            try
            {
                string registro = ((System.Web.UI.WebControls.Button)sender).Attributes["value"].ToString();
                foreach (string datos in lstCiudades)
                {
                   if(datos==registro)
                   {
                       lstCiudades.Remove(registro);
                   } 
                }
                
                tabla.Columns.Add("CiudadesAdd");

                foreach (string info in lstCiudades)
                {
                    tabla.Rows.Add(info);
                    gdAdd.DataSource = tabla;
                    gdAdd.DataBind();
                }

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

        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            RutaBE ruta = new RutaBE();
            
            try 
            {
                string consultaExistencia = servRuta.ConsultarExistencias(txtNombreRuta.Text);
                
                 if (consultaExistencia == "Ok")
                    {
                        txtNomRuta.Text = txtNombreRuta.Text;
                        DivSelCiudades.Visible = true;
                        btnGuardar.Visible = true;
                        divRuta.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("La ruta digitada ya se encuentra registrada", "Registrar Ruta"); 
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            RutaBE ruta = new RutaBE();
            String registrarRuta;

            try 
            {
                ruta.Nombre_Ruta = txtNomRuta.Text;
                foreach(string datos in lstCiudades)
                {
                    ruta.Ciudad_Ruta.Ciudad[lstCiudades.Count()].Nombre_Ciudad = datos;
                }
                registrarRuta = servRuta.RegistrarRuta(ruta);

                MessageBox.Show("La ruta ingresada fue registrada satisfactoriamente","Registrar Ruta");
                           
              }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                servRuta.Close();
                Response.Redirect("~/Rutas/frmRegistrarRuta.aspx");
            }           
            
        } 
               
    }
}