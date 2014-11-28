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
        List<CiudadBE> listaCiudades = new List<CiudadBE>();
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

            DataTable table = new DataTable();
            listaCiudades = (List<CiudadBE>)Session["listaCiudades"];
            CiudadBE ciu = new CiudadBE();
            ciu.Nombre_Ciudad = lstCiudad.SelectedItem.Text;
            ciu.Id_Ciudad = Convert.ToString(lstCiudad.SelectedIndex);
            //ciu.Descripcion = "N";

            foreach (CiudadBE ent in listaCiudades)
            {
                if (ent.Nombre_Ciudad == lstCiudad.SelectedItem.Text)
                {                    
                    listaCiudades.Remove(ent);
                    break;
                }
            }

            listaCiudades.Add(ciu);
            Session["listaCiudades"] = listaCiudades;
            table.Columns.Add("CiudadesAdd");
            table.Columns.Add("IdCiudad");
            foreach (CiudadBE datos in listaCiudades)
            {
                table.Rows.Add(datos.Nombre_Ciudad, datos.Id_Ciudad);
            }
            gdAdd.DataSource = table;
            gdAdd.DataBind();           
            btnGuardar.Visible = true;
        
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
            objdtLista.Columns.Add("Id_Ciudad");
            objdtTabla = objdtLista;
        }

        protected void btnModificarIni_Click(object sender, EventArgs e)
        {
            DivModificarDatos.Visible = true;
            txtNuevoNombre.Enabled = true;
            txtNombreRuta.Enabled = false;
            gdAdd.Enabled = true;
            btnModificarIni.Visible = false;
            
        }
        
        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
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
                        txtNombreRuta.Enabled = true;
                        txtNombreRuta.Focus();
                    }
                    else
                    {

                      RutaBE  objRuta = servRuta.ConsultarRuta(txtNombreRuta.Text);

                        tabla.Columns.Add("CiudadesAdd");
                        tabla.Columns.Add("IdCiudad");
                        txtNuevoNombre.Text = objRuta.Nombre_Ruta;
                        lblIdRuta.Text = objRuta.Id_Ruta;
                        listaCiudades = objRuta.Lista_Ciudades;
                        lstDetail = objRuta.Lista_Ciudades;
                        foreach (CiudadBE info in listaCiudades)
                       {
                          tabla.Rows.Add(info.Nombre_Ciudad, info.Id_Ciudad);
                       }
                          gdAdd.DataSource = tabla;
                          gdAdd.DataBind();
                          Session["listaCiudades"] = listaCiudades;
                          Session["lstDetail"] = lstDetail;
                      
                        txtNuevoNombre.Text = txtNombreRuta.Text;
                       
                        DivPost.Visible = true;
                        DivDatos.Visible = true;
                        DivCiudad.Visible = true;
                        btnGuardar.Visible = true;
                        gdAdd.Visible = true;
                        txtNombreRuta.Enabled = false;
                        txtNuevoNombre.Enabled = false;         
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
       
        protected void gdAdd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            listaCiudades = (List<CiudadBE>)Session["listaCiudades"];
            lstCiudad.SelectedIndex = Convert.ToInt32(listaCiudades[e.NewEditIndex].Id_Ciudad);
            Session["indiceModificar"] = e.NewEditIndex;
            e.Cancel = true;
            btnGuardar.Visible = true;
        }

        protected void gdAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("CiudadesAdd");
            tabla.Columns.Add("IdCiudad");

            listaCiudades = (List<CiudadBE>)Session["listaCiudades"];
            

           listaCiudades.Remove(listaCiudades[e.RowIndex]);
            Session["listaCiudades"] = listaCiudades;
            lstDetail = (List<CiudadBE>)Session["lstDetail"];
            
            foreach (CiudadBE dato in lstDetail)
            {
                foreach (CiudadBE info in listaCiudades)
                {
                    if (dato.Nombre_Ciudad != info.Nombre_Ciudad)
                    {
                        dato.Nombre_Ciudad = "DatoBorrado";
                    }
                }

                if(listaCiudades.Count==0)
                {
                dato.Nombre_Ciudad = "DatoBorrado";
                }
            }
            foreach (CiudadBE datos in listaCiudades)
            {
                tabla.Rows.Add(datos.Nombre_Ciudad, datos.Id_Ciudad);
            }
            gdAdd.DataSource = tabla;
            gdAdd.DataBind();                       
            btnGuardar.Visible = true;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            listaCiudades = (List<CiudadBE>)Session["listaCiudades"];
            int indice = (int)Session["indiceModificar"];
            Session.Remove("indiceModificar");
            CiudadBE ciu = new CiudadBE();
            ciu.Nombre_Ciudad = lstCiudad.SelectedItem.Text;
            ciu.Id_Ciudad = Convert.ToString(lstCiudad.SelectedIndex);
           // ciu.Descripcion = "M";                      
            listaCiudades.Remove(listaCiudades[indice]);

            //foreach (CiudadBE ent in listaCiudades)
            //{
            //    if (ent.Nombre_Ciudad == lstCiudad.SelectedItem.Text)
            //    {
            //        ciu.Cantidad += ent.Cantidad;
            //        lista.Remove(ent);
            //        break;
            //    }
            //}
            listaCiudades.Add(ciu);
            Session["listaCiudades"] = listaCiudades;
            table.Columns.Add("CiudadesAdd");
           
            foreach (CiudadBE datos in listaCiudades)
            {
                table.Rows.Add(datos.Nombre_Ciudad);
            }
            gdAdd.DataSource = table;
            gdAdd.DataBind();            
            btnGuardar.Visible = true;            
            txtNuevoNombre.Enabled = true;
            txtNombreRuta.Enabled = false;
            gdAdd.Enabled = true;  
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RutaServicesClient servRuta = new RutaServicesClient();
            RutaBE ruta = new RutaBE();

            long resp;
            listaCiudades = (List<CiudadBE>)Session["listaCiudades"];
            lstDetail = (List<CiudadBE>)Session["lstDetail"];

            try
            {
                if (txtNombreRuta.Text == txtNuevoNombre.Text)
                {
                    ruta.Nombre_Ruta = "";
                }
                else 
                {
                    ruta.Nombre_Ruta = txtNuevoNombre.Text;
                }
                
                List<CiudadBE> lstCiud = new List<CiudadBE>();
                foreach (CiudadBE dato in listaCiudades)
                {
                    foreach (CiudadBE info in lstDetail)
                        {
                               if (dato.Nombre_Ciudad != info.Nombre_Ciudad)
                                {
                                    CiudadBE ciu = new CiudadBE();
                                    ciu.Nombre_Ciudad = dato.Nombre_Ciudad;
                                    ciu.Id_Ciudad = dato.Id_Ciudad;
                                    lstCiud.Add(ciu);
                                }

                               if (info.Nombre_Ciudad == "DatoBorrado")
                               {
                                   CiudadBE ciu = new CiudadBE();
                                   ciu.Nombre_Ciudad = info.Nombre_Ciudad;
                                   ciu.Id_Ciudad = info.Id_Ciudad;
                                   ciu.Id_Ciudad_Ruta = info.Id_Ciudad_Ruta;
                                   lstCiud.Add(ciu);
                               }
                    }
                }
                ruta.Lista_Ciudades = lstCiud;
                resp = servRuta.ModificarRuta(ruta);

                MessageBox.Show("La ruta fue modificada satisfactoriamente", "Modificar Ruta");

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servRuta.Close();
                Response.Redirect("~/Pedido/frmModificarPedido.aspx");
            }

            
       }

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