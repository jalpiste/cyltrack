using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using System.Windows.Forms;
using CYLTRACK_WebApp.RutaService;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes
{
    public partial class frmNuevaUbicacion : System.Web.UI.Page
    {
        string cedula;
        public void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtNuevaDireccion.Focus();
                
            }

            if (!IsPostBack)
            {
                string dato = Server.UrlDecode(Request.QueryString["ReturnUrl"]);
                //cedula = dato;
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
               
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            ClienteServiceClient servCliente = new ClienteServiceClient();
            String resp;
            
            try
            {
                ClienteBE cliente = new ClienteBE();

                UbicacionBE ubi = new UbicacionBE();
                List<string> lstDatoDireccion = new List<string>();
                lstDatoDireccion.Add(txtNuevaDireccion.Text);
                ubi.Direccion = lstDatoDireccion;
                ubi.Barrio = txtNuevoBarrio.Text;
                ubi.Telefono_2 = txtTelefono.Text;
                cliente.Ubicacion = ubi;

                CiudadBE ciucli = new CiudadBE();
                ciucli.Nombre_Ciudad = lstCiudad.SelectedValue;
                ubi.Ciudad = ciucli;

                DepartamentoBE depcli = new DepartamentoBE();
                depcli.Nombre_Departamento = lstDepartamento.SelectedValue;
                ciucli.Departamento = depcli;

                cliente.Cedula = cedula;
                
                resp = servCliente.Agregar_Ubicacion(cliente);

                MessageBox.Show("La nueva ubicación fue registrada satisfactoriamente", "Registrar Nueva Ubicación");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
                Response.Redirect("~/Clientes/frmModificarCliente.aspx");
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Clientes/frmModificarCliente.aspx");
        }

        protected void lstDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCiudad.Focus();
        }

        
    }
}