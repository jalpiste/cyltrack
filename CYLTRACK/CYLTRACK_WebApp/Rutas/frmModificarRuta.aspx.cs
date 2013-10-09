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
    public partial class frmModificarRuta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtNombreRuta.Focus();
            }

            if (!IsPostBack)
            {
                RutaServicesClient servRuta = new RutaServicesClient();
                try
                {
                    List<CiudadBE> datosCiudades = new List<CiudadBE>(servRuta.ConsultaDepartamentoyCiudades());
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

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }
        List<string> lstCiudades = new List<string>();
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            RutaBE ruta = new RutaBE();
            DataTable tabla = new DataTable();

            try
            {
                string registro = lstCiudad.SelectedValue;
                //lstCiudades.Add(registro);
                foreach (string datos in lstCiudades)
                {
                    if (datos == registro)
                    {
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
                DivModificarDatos.Visible = true;
                btnModificar.Visible = false;
                txtNuevoNombre.Enabled = true;
                gdAdd.Enabled = true;        
        }
        
        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            RutaBE ruta = new RutaBE();
            DataTable tabla = new DataTable();

            try 
            {
                string consultarExistencia = servRuta.ConsultaExistencia(txtNombreRuta.Text);
                               
                    if (consultarExistencia==null)
                    {
                        MessageBox.Show("La ruta digitada no se encuentra registrada", "Modificar Ruta");
                    }
                    else
                    {
                        RutaBE consultaRuta = servRuta.ConsultarRutaconParametro(txtNombreRuta.Text);
                        txtNuevoNombre.Text = txtNombreRuta.Text;
                        List<CiudadBE> lstCiudades = servRuta.ConsultarRutaconParametro(txtNombreRuta.Text).Ciudad_Ruta.Ciudad;

                        tabla.Columns.Add("CiudadesAdd");

                        foreach (CiudadBE datos in lstCiudades)
                        {
                            tabla.Rows.Add(datos);
                            gdAdd.DataSource = tabla;
                            gdAdd.DataBind();
                        }
 
                        DivPost.Visible = true;
                        DivDatos.Visible = true;
                        DivCiudad.Visible = true;
                        btnGuardar.Visible = true;
                        gdAdd.Visible = true;                                                              
                    }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                servRuta.Close();
                gdAdd.Visible = true;
            }
                    
        } 

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            String datos;
            RutaBE ruta = new RutaBE();

            try 
            {
                    ruta.Nombre_Ruta = txtNuevoNombre.Text;
                    //CiudadBE ciu = new CiudadBE();
                    Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                    //ciuRuta.Ciudad[lstCiudades.Count()].Nombre_Ciudad = ciu;
                    ruta.Ciudad_Ruta = ciuRuta;

                    foreach (string info in lstCiudades)
                    {
                        ruta.Ciudad_Ruta.Ciudad[lstCiudades.Count()].Nombre_Ciudad = info;
                    }

                    datos = servRuta.ModificarRuta(ruta);

                    MessageBox.Show("La ruta fue modificada satisfactoriamente", "Modificar Ruta");
                }
           
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                servRuta.Close();
                Response.Redirect("~/Rutas/frmModificarRuta.aspx");
            }
            
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
                    if (datos == registro)
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

        protected void txtNuevoNombre_TextChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            RutaBE ruta = new RutaBE();
            DataTable tabla = new DataTable();

            try
            {
                string consultaExistencia = servRuta.ConsultaExistencia(txtNuevoNombre.Text);
                                
                    if (consultaExistencia!=null)
                    {
                        MessageBox.Show("El nombre de la ruta digitada ya se encuentra registrada", "Modificar Ruta");
                    }
                    else
                    {
                        RutaBE consultaRuta = servRuta.ConsultarRutaconParametro(txtNombreRuta.Text);
                        txtNuevoNombre.Text = txtNombreRuta.Text;
                        gdAdd.DataSource = consultaRuta.Ciudad_Ruta.Ciudad[consultaRuta.Ciudad_Ruta.Ciudad.Count()].Nombre_Ciudad;
                        gdAdd.DataBind();

                        DivPost.Visible = true;
                        DivDatos.Visible = true;
                        DivCiudad.Visible = true;
                        btnGuardar.Visible = true;
                        gdAdd.Visible = true;
                       
                    }
                
                tabla.Columns.Add("CiudadesAdd");

                foreach (string datos in lstCiudades)
                {
                    tabla.Rows.Add(datos);
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
                servRuta.Close();
                gdAdd.Visible = true;
            }
           
        }                
        
    }
}