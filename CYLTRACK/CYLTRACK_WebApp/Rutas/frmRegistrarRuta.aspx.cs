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
        List<CiudadBE> lstDetail = new List<CiudadBE>();
        DataTable objdtLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CiudadBE ciudad = new CiudadBE();
            ciudad.Nombre_Ciudad = lstCiudad.SelectedItem.Text;

            try
            {
                lstDetail.Add(ciudad);

                foreach (CiudadBE info in lstDetail)
                {
                    objdtTabla.Rows.Add(info.Nombre_Ciudad);
                    gdAdd.DataSource = objdtTabla;
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
                btnGuardar.Visible = true;            
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

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }
        protected void gdAdd_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            objdtTabla.Rows.RemoveAt(e.RowIndex);
            gdAdd.DataSource = objdtTabla;
            gdAdd.DataBind();
            btnGuardar.Focus();
        }
        protected void btnRemover_Click(object sender, EventArgs e)
        {
            //RutaBE ruta = new RutaBE();
            //DataTable tabla = new DataTable();

            //try
            //{
            //    string registro = ((System.Web.UI.WebControls.Button)sender).Attributes["value"].ToString();
            //    foreach (string datos in lstCiudades)
            //    {
            //       if(datos==registro)
            //       {
            //           lstCiudades.Remove(registro);
            //       } 
            //    }

            //    tabla.Columns.Add("CiudadesAdd");

            //    foreach (string info in lstCiudades)
            //    {
            //        tabla.Rows.Add(info);
            //        gdAdd.DataSource = tabla;
            //        gdAdd.DataBind();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("~/About.aspx");
            //}
            //finally
            //{
            //    gdAdd.Visible = true;
            //}

        }

        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            
            try
            {
                long consultaExistencia = servRuta.ConsultaExistenciaRuta(txtNombreRuta.Text);

                if (consultaExistencia == 0)
                {
                    txtNomRuta.Text = txtNombreRuta.Text.ToUpper();
                    DivSelCiudades.Visible = true;
                    divRuta.Visible = true;
                    txtNombreRuta.Text = "";
                    lstDepartamento.Focus();
                    btnGuardar.Visible = false;
                }
                else
                {
                    MessageBox.Show("La ruta digitada ya se encuentra registrada", "Registrar Ruta");
                    DivSelCiudades.Visible = false;
                    btnGuardar.Visible = false;
                    divRuta.Visible = false;
                    txtNombreRuta.Text = "";
                    txtNomRuta.Text = "";
                    txtNombreRuta.Focus();
                    lstDetail.Clear();
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
            long registrarRuta;

            try
            {
                ruta.Nombre_Ruta = txtNomRuta.Text;
                foreach (DataRow row in objdtTabla.Rows)
                {
                    CiudadBE ciudad = new CiudadBE();
                    ciudad.Nombre_Ciudad = (Convert.ToString(row["CiudadesAdd"]));
                    lstDetail.Add(ciudad);
                }

                Ciudad_RutaBE ciudadesRuta = new Ciudad_RutaBE();
                CiudadBE ciu = new CiudadBE();
                foreach (CiudadBE datos in lstDetail)
                {
                    ciu.Nombre_Ciudad += datos.Nombre_Ciudad + ",";
                    ciudadesRuta.Ciudad = ciu;
                    ruta.Ciudad_Ruta = ciudadesRuta;
                }
                int var = ciudadesRuta.Ciudad.Nombre_Ciudad.Length;
                ciudadesRuta.Ciudad.Nombre_Ciudad = ciudadesRuta.Ciudad.Nombre_Ciudad.Substring(0, var -1 );
                registrarRuta = servRuta.RegistrarRuta(ruta);
                
                MessageBox.Show("La ruta ingresada fue registrada satisfactoriamente", "Registrar Ruta");
                
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servRuta.Close();
                Response.Redirect("~/Rutas/frmRegistrarRuta.aspx");
                txtNombreRuta.Text = "";
                
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
                lstCiudad.Focus();
            }       
        }

        protected void lstCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAgregar.Visible = true;
        }


    }
}