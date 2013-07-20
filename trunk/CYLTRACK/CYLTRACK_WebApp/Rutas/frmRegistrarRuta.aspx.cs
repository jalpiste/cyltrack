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
                ciu.Nombre_Ciudad= registro;
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
                Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = registro;
                ciuRuta.Ciudad = ciu;
                ruta.Ciudad_Ruta = ciuRuta;

                foreach (RutaBE datos in lstCiudades)
                {
                   if(datos.Ciudad_Ruta.Ciudad.Nombre_Ciudad==ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad)
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

        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            RutaBE ruta = new RutaBE();
            RutaBE[] consulta ;
            try 
            {
                ruta.Nombre_Ruta = txtNombreRuta.Text;
                consulta = servRuta.ConsultarRuta(ruta);
                
                foreach (RutaBE infoRuta in consulta)
                {
                    if (infoRuta.Nombre_Ruta == txtNombreRuta.Text)
                    {
                        MessageBox.Show("La ruta digitada ya se encuentra registrada", "Registrar Ruta");
                    }
                    else
                    {
                        divRuta.Visible = true;
                        txtNomRuta.Text = txtNombreRuta.Text;
                        lstCiudad.Items.Add(infoRuta.Ciudad_Ruta.Ciudad.Nombre_Ciudad);
                        lstDepartamento.Items.Add(infoRuta.Ciudad_Ruta.Ciudad.Departamento.Nombre_Departamento);
                        DivSelCiudades.Visible = true;
                        btnGuardar.Visible = true;
                   }
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
                foreach(RutaBE datos in lstCiudades)
                {
                    ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad = datos.Ciudad_Ruta.Ciudad.Nombre_Ciudad;
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