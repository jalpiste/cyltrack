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
        List<CiudadBE> lstDetail = new List<CiudadBE>();
        DataTable objdtLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtNombreRuta.Focus();
            }
            if (!Page.IsPostBack)
            {
                objdtLista = new DataTable();
                CrearTabla();
            }

            if (!IsPostBack)
            {
                RutaServicesClient servRuta = new RutaServicesClient();
                try
                {
                    lstDepartamento.DataSource = servRuta.ConsultaDepartamento();
                    lstDepartamento.DataValueField = "Id_Departamento";
                    lstDepartamento.DataTextField = "Nombre_Departamento";
                    lstDepartamento.DataBind();

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
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                    objdtTabla.Rows.Add(lstCiudad.SelectedItem.Text);
                    gdAdd.DataSource = objdtTabla;
                    gdAdd.DataBind();
                
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                gdAdd.Visible = true;
                btnGuardar.Focus();
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
        //        ------------------------- fin de tabla acumulada y asignación de valor
        private void CrearTabla()
        {
            objdtLista.Columns.Add("CiudadesAdd");
            objdtTabla = objdtLista;
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
                long consultarExistencia = servRuta.ConsultaExistenciaRuta(txtNombreRuta.Text);
                               
                    if (consultarExistencia==0)
                    {
                        MessageBox.Show("La ruta digitada no se encuentra registrada", "Modificar Ruta");
                        DivCiudad.Visible = false;
                        DivDatos.Visible = false;
                        DivModificarDatos.Visible = false;
                        DivPost.Visible = false;
                        txtNombreRuta.Focus();
                    }
                    else
                    {
                       List<RutaBE> consultaRuta = new List<RutaBE>(servRuta.ConsultarRuta(txtNombreRuta.Text));

                       tabla.Columns.Add("CiudadesAdd");

                        foreach(RutaBE datos in consultaRuta)
                       {
                           txtNuevoNombre.Text = datos.Nombre_Ruta;
                           lblIdRuta.Text = datos.Id_Ruta;
                           objdtTabla.Rows.Add(datos.Ciudad_Ruta.Ciudad.Nombre_Ciudad);
                           gdAdd.DataSource = objdtTabla;
                           gdAdd.DataBind();
                       }
                        txtNuevoNombre.Text = txtNombreRuta.Text;
 
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
        protected void gdAdd_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            objdtTabla.Rows.RemoveAt(e.RowIndex);
            gdAdd.DataSource = objdtTabla;
            gdAdd.DataBind();
            btnGuardar.Focus();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            long datos;
            RutaBE ruta = new RutaBE();

            try 
            {
                    ruta.Nombre_Ruta = txtNuevoNombre.Text;
                    CiudadBE ciudad = new CiudadBE();
                    Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                    foreach (DataRow row in objdtTabla.Rows)
                    {                      
                        ciudad.Nombre_Ciudad += (Convert.ToString(row["CiudadesAdd"])+",");
                        ciuRuta.Ciudad = ciudad;
                    }

                    int var = ciudad.Nombre_Ciudad.Length;
                    ciudad.Nombre_Ciudad = ciudad.Nombre_Ciudad.Substring(0, var - 1);
                    ruta.Ciudad_Ruta = ciuRuta;
                    ruta.Id_Ruta = lblIdRuta.Text;
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

        //protected void btnRemover_Click(object sender, EventArgs e)
        //{
        //    RutaBE ruta = new RutaBE();
        //    DataTable tabla = new DataTable();

        //    try
        //    {
        //        string registro = ((System.Web.UI.WebControls.Button)sender).Attributes["value"].ToString();
                
        //        foreach (string datos in lstCiudades)
        //        {
        //            if (datos == registro)
        //            {
        //                lstCiudades.Remove(registro);
        //            }
        //        }

        //        tabla.Columns.Add("CiudadesAdd");

        //        foreach (string info in lstCiudades)
        //        {
        //            tabla.Rows.Add(info);
        //            gdAdd.DataSource = tabla;
        //            gdAdd.DataBind();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Redirect("~/About.aspx");
        //    }
        //    finally
        //    {
        //        gdAdd.Visible = true;
        //    }
        //}

        protected void txtNuevoNombre_TextChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            RutaBE ruta = new RutaBE();
            DataTable tabla = new DataTable();

            try
            {
                long consultaExistencia = servRuta.ConsultaExistenciaRuta(txtNuevoNombre.Text);
                                
                    if (consultaExistencia!=0)
                    {
                        MessageBox.Show("El nombre de la ruta digitada ya se encuentra registrada", "Modificar Ruta");
                    }
                    else
                    {
                    //    RutaBE consultaRuta = servRuta.ConsultarRutaconParametro(txtNombreRuta.Text);
                        txtNuevoNombre.Text = txtNombreRuta.Text;
                        //gdAdd.DataSource = consultaRuta.Ciudad_Ruta.Ciudad[consultaRuta.Ciudad_Ruta.Ciudad.Count()].Nombre_Ciudad;
                        //gdAdd.DataBind();

                        DivPost.Visible = true;
                        DivDatos.Visible = true;
                        DivCiudad.Visible = true;
                        btnGuardar.Visible = true;
                        gdAdd.Visible = true;
                       
                    }
                
                tabla.Columns.Add("CiudadesAdd");

                //foreach (string datos in lstCiudades)
                //{
                //    tabla.Rows.Add(datos);
                //    gdAdd.DataSource = tabla;
                //    gdAdd.DataBind();
                //}
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

        protected void lstDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();

            try 
            {
                lstCiudad.DataSource = servRuta.ConsultaCiudades(lstDepartamento.SelectedValue);
                lstCiudad.DataValueField = "Id_Ciudad";
                lstCiudad.DataTextField = "Nombre_Ciudad";
                lstCiudad.DataBind();
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
}