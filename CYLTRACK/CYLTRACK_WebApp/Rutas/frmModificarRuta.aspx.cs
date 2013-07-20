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
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }
        List<RutaBE> lstCiudades = new List<RutaBE>();
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            RutaBE ruta = new RutaBE();
            DataTable tabla = new DataTable();

            try
            {
                string registro = lstCiudad.SelectedValue;
                Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = registro;
                ciuRuta.Ciudad = ciu;
                ruta.Ciudad_Ruta = ciuRuta;
                foreach (RutaBE datos in lstCiudades)
                {
                    if (datos.Ciudad_Ruta.Ciudad.Nombre_Ciudad == ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad)
                    {
                        ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad += datos.Ciudad_Ruta.Ciudad.Nombre_Ciudad;
                        lstCiudades.Remove(datos);
                    }
                }

                lstCiudades.Add(ruta);

                tabla.Columns.Add("CiudadesAdd");

                foreach (RutaBE info in lstCiudades)
                {
                    tabla.Rows.Add(info.Ciudad_Ruta.Ciudad.Nombre_Ciudad);
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
                ruta.Nombre_Ruta = txtNombreRuta.Text;
                RutaBE[] consulta = servRuta.ConsultarRuta(ruta);

                foreach (RutaBE info in consulta)
                {
                    if (info.Nombre_Ruta != txtNombreRuta.Text)
                    {
                        MessageBox.Show("La ruta digitada no se encuentra registrada", "Modificar Ruta");
                    }
                    else
                    {
                        txtNuevoNombre.Text = txtNombreRuta.Text;
                        lstCiudad.Items.Add(info.Ciudad.Nombre_Ciudad);
                        lstDepartamento.Items.Add(info.Ciudad.Departamento.Nombre_Departamento);
                        
                        DivPost.Visible = true;
                        DivDatos.Visible = true;
                        DivCiudad.Visible = true;
                        btnGuardar.Visible = true;
                        gdAdd.Visible = true;
                        lstCiudades.Add(info);                                            
                    }
                }

                tabla.Columns.Add("CiudadesAdd");

                foreach(RutaBE datos in lstCiudades)
                {
                    tabla.Rows.Add(datos.Ciudad_Ruta.Ciudad.Nombre_Ciudad);
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            String datos;
            RutaBE ruta = new RutaBE();

            try 
            {
                    ruta.Nombre_Ruta = txtNuevoNombre.Text;
                    CiudadBE ciu = new CiudadBE();
                    Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                    ciuRuta.Ciudad = ciu;
                    ruta.Ciudad_Ruta = ciuRuta;

                    foreach (RutaBE info in lstCiudades)
                    {
                        ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad = info.Ciudad.Nombre_Ciudad;
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
                Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = registro;
                ciuRuta.Ciudad = ciu;
                ruta.Ciudad_Ruta = ciuRuta;

                foreach (RutaBE datos in lstCiudades)
                {
                    if (datos.Ciudad_Ruta.Ciudad.Nombre_Ciudad == ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad)
                    {
                        lstCiudades.Remove(ruta);
                    }
                }

                tabla.Columns.Add("CiudadesAdd");

                foreach (RutaBE info in lstCiudades)
                {
                    tabla.Rows.Add(info.Ciudad_Ruta.Ciudad.Nombre_Ciudad);
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
                ruta.Nombre_Ruta = txtNuevoNombre.Text;
                RutaBE[] consulta = servRuta.ConsultarRuta(ruta);

                foreach (RutaBE info in consulta)
                {
                    if (info.Nombre_Ruta == txtNuevoNombre.Text)
                    {
                        MessageBox.Show("El nombre de la ruta digitada ya se encuentra registrada", "Modificar Ruta");
                    }
                    else
                    {
                        txtNuevoNombre.Text = txtNombreRuta.Text;
                        lstCiudad.Items.Add(info.Ciudad.Nombre_Ciudad);
                        lstDepartamento.Items.Add(info.Ciudad.Departamento.Nombre_Departamento);

                        DivPost.Visible = true;
                        DivDatos.Visible = true;
                        DivCiudad.Visible = true;
                        btnGuardar.Visible = true;
                        gdAdd.Visible = true;
                        lstCiudades.Add(info);
                    }
                }

                tabla.Columns.Add("CiudadesAdd");

                foreach (RutaBE datos in lstCiudades)
                {
                    tabla.Rows.Add(datos.Ciudad_Ruta.Ciudad.Nombre_Ciudad);
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