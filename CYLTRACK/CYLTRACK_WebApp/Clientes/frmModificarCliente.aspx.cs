using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using CYLTRACK_WebApp.RutaService;
using System.Windows.Forms;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes
{
    public partial class frmModificarCliente : System.Web.UI.Page
    {
        List<CilindroBE> lstDetail = new List<CilindroBE>();
        DataTable objdtLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
            {
                hprNuevaUbicacion.NavigateUrl = "frmNuevaUbicacion.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]) + Server.UrlEncode(txtCedula.Text);
            }
            if (!Page.IsPostBack)
            {
                objdtLista = new DataTable();
                CrearTabla();
                txtCedula.Focus();
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
            objdtLista.Columns.Add("IdUbicacion");
            objdtLista.Columns.Add("Direccion");
            objdtLista.Columns.Add("Barrio");
            objdtLista.Columns.Add("Telefono");
            objdtLista.Columns.Add("Ciudad");

            objdtTabla = objdtLista;
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {

            ClienteServiceClient servCliente = new ClienteServiceClient();
            DataTable table = new DataTable();
            long resp;
            try
            {
                resp = servCliente.ConsultarExistenciasClientes(txtCedula.Text);

                if (resp == 0)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Modificar Cliente");
                    divInfoCliente.Visible = false;
                    txtCedula.Text = "";
                    txtCedula.Focus();
                    btnGuardar.Visible = false;
                }
                else
                {
                    ClienteBE consulta = servCliente.Consultar_Cliente(txtCedula.Text);

                    txtCedulaCli.Text = consulta.Cedula;
                    lblIdCliente.Text = consulta.Id_Cliente;
                    txtNombreCliente.Text = consulta.Nombres_Cliente;
                    txtPrimerApellido.Text = consulta.Apellido_1;
                    txtSegundoApellido.Text = consulta.Apellido_2;

                    table.Columns.Add("IdUbicacion");
                    table.Columns.Add("Direccion");
                    table.Columns.Add("Barrio");
                    table.Columns.Add("Telefono");
                    table.Columns.Add("Ciudad");

                    foreach (UbicacionBE datos in consulta.ListaDirecciones)
                    {
                        table.Rows.Add(datos.Id_Ubicacion, datos.Direccion, datos.Barrio, datos.Telefono_1, datos.Ciudad.Nombre_Ciudad);
                        objdtTabla.Rows.Add(datos.Id_Ubicacion, datos.Direccion, datos.Barrio, datos.Telefono_1, datos.Ciudad.Nombre_Ciudad);
                    }
                    gvDirecciones.DataSource = table;
                    gvDirecciones.DataBind();
                    divInfoCliente.Visible = true;
                    divDireccionesCli.Visible = true;
                    divNuevaDir.Visible = true;                    
                    txtCedula.Text = "";
                    txtCedula.Enabled = true;
                    divNuevaDir.Visible = true;
                    btnMenuPrincipal.Visible = true;
                    gvDirecciones.Focus();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
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
                btnGuardar.Visible = true;

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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            long respCliente;
            long respUbicacion;
            ClienteBE cliente = new ClienteBE();
           
            try
            {
                cliente.Nombres_Cliente = txtNombreCliente.Text;
                cliente.Apellido_1 = txtPrimerApellido.Text;
                cliente.Apellido_2 = txtSegundoApellido.Text;
                cliente.Cedula = txtCedulaCli.Text;
                  
                respCliente = servCliente.ModificarNombreCliente(cliente);

                if (txtDireccion.Text != "") 
                {
                    UbicacionBE ubica = new UbicacionBE();

                    ubica.Id_Ubicacion = lblIdUbica.Text;
                    ubica.Direccion=txtDireccion.Text;
                    ubica.Barrio = txtBarrio.Text ;
                    ubica.Telefono_1= txtTelefono.Text;
                    CiudadBE ciudad = new CiudadBE();
                    ciudad.Id_Ciudad = lstCiudad.SelectedValue;
                    ubica.Ciudad = ciudad;

                    respUbicacion = servCliente.ModificarDirCliente(ubica);
                }

                MessageBox.Show("El cliente fue modificado satisfactoriamente", "Modificar Cliente");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }

            finally
            {
                servCliente.Close();
                Response.Redirect("~/Clientes/frmModificarCliente.aspx");
                txtCedula.Focus();

            }
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //txtNombreCliente.Focus();
            //txtNombreCliente.Text = "";
            //txtPrimerApellido.Text = "";
            //txtSegundoApellido.Text = "";
            //txtDireccion.Text = "";
            //txtBarrio.Text = "";
            //lstDepartamento.Text = "Seleccionar...";
            //lstCiudad.Text = "Seleccionar...";
            //txtTelefono.Text = "";
        }

        protected void txtCedulaCli_TextChanged(object sender, EventArgs e)
        {
            ClienteServiceClient servCliente = new ClienteServiceClient();
            long resp;

            try
            {
                resp = servCliente.ConsultarExistenciasClientes(txtCedulaCli.Text);

                if (resp != 0)
                {
                    MessageBox.Show("La cédula del cliente ya se encuentra registrada en el sistema", "Modificar Cliente");
                }
                else
                {
                    txtCedulaCli.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
            }
        }

        protected void Agregar_onClick(object sender, EventArgs e)
        {
            
            RutaServicesClient servRuta = new RutaServicesClient();
            DataTable table = new DataTable();
            try
            {
                lstDepartamento.DataSource = servRuta.ConsultaDepartamento();
                lstDepartamento.DataValueField = "Id_Departamento";
                lstDepartamento.DataTextField = "Nombre_Departamento";
                lstDepartamento.DataBind();
               
                string dato = ((System.Web.UI.WebControls.Button)sender).Attributes["value"].ToString();

                foreach (DataRow info in objdtTabla.Rows)
                {
                    if (dato == (Convert.ToString(info["IdUbicacion"])))
                    {
                        txtDireccion.Text = (Convert.ToString(info["Direccion"]));
                        txtBarrio.Text = (Convert.ToString(info["Barrio"]));
                        txtTelefono.Text = (Convert.ToString(info["Telefono"]));
                        lblIdUbica.Text = (Convert.ToString(info["IdUbicacion"]));
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
                divModificacionCiente.Visible = true;
                txtDireccion.Focus();
            }
        }

        protected void lstCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {           
            btnGuardar.Visible = true;                
        }

        protected void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;             
           
        }

        protected void txtPrimerApellido_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
        }

        protected void txtSegundoApellido_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
        }

        protected void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
        }

        protected void txtBarrio_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
        }

        protected void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
        }       
    }
}