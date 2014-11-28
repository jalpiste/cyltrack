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
        List<CiudadBE> listaCiudades = new List<CiudadBE>();
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

                    //CiudadBE ciu = new CiudadBE();
                    //DepartamentoBE dep = new DepartamentoBE();
                    //dep.Id_Departamento = "8";
                    //ciu.Departamento = dep;
                    //long reg = servRuta.RegistroCiudades(ciu);
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
            DataTable tabla = new DataTable();
            listaCiudades = (List<CiudadBE>)Session["listaCiudades"];

            CiudadBE ciudad = new CiudadBE();
            ciudad.Nombre_Ciudad = lstCiudad.SelectedItem.Text;
            ciudad.Id_Ciudad = (lstCiudad.SelectedValue);
            
            try
            {
                foreach (CiudadBE ent in listaCiudades)
                {
                    if (ent.Nombre_Ciudad == lstCiudad.SelectedItem.Text)
                    {
                        listaCiudades.Remove(ent);
                        break;
                    }
                }
                listaCiudades.Add(ciudad);
                Session["listaCiudades"] = listaCiudades;

                lstDetail.Add(ciudad);

                tabla.Columns.Add("CiudadesAdd");                

                foreach (CiudadBE info in listaCiudades)
                {
                    tabla.Rows.Add(info.Nombre_Ciudad);
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
        
        private void CrearTabla()
        {
            objdtLista.Columns.Add("CiudadesAdd");
            objdtTabla = objdtLista;
            gdAdd.DataSource = listaCiudades;
            gdAdd.DataBind();
            Session["listaCiudades"] = listaCiudades;
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }
        protected void gdAdd_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            listaCiudades = (List<CiudadBE>)Session["listaCiudades"];
            listaCiudades.Remove(listaCiudades[e.RowIndex]);
            Session["listaCiudades"] = listaCiudades;
            gdAdd.DataSource = listaCiudades;
            gdAdd.DataBind();
            btnGuardar.Focus();
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
                    txtNombreRuta.Enabled = false;
                    txtNomRuta.Enabled = false;
                }
                else
                {
                    MessageBox.Show("La ruta digitada ya se encuentra registrada", "Registrar Ruta");
                    DivSelCiudades.Visible = false;
                    btnGuardar.Visible = false;
                    divRuta.Visible = false;
                    txtNombreRuta.Enabled = true;
                    txtNomRuta.Enabled = true;
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
            
            listaCiudades = (List<CiudadBE>)Session["listaCiudades"];
            try
            {
                ruta.Nombre_Ruta = txtNomRuta.Text;
                List<CiudadBE> lstCiuGuardar = new List<CiudadBE>();
                foreach (CiudadBE dato in listaCiudades)
                {
                    CiudadBE ciu = new CiudadBE();
                    ciu.Nombre_Ciudad = dato.Nombre_Ciudad;
                    ciu.Id_Ciudad = dato.Id_Ciudad;
                    lstCiuGuardar.Add(ciu);
                }
                ruta.Lista_Ciudades = lstCiuGuardar;

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