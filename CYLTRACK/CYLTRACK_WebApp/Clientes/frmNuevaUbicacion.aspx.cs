using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes
{
    public partial class frmNuevaUbicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNuevaDireccion.Focus();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            ClienteServiceClient servCliente = new ClienteServiceClient();
            String resp;
            ClienteBE registrar_ubi = new ClienteBE();

            try
            {
                UbicacionBE ubi = new UbicacionBE();
                ubi.Direccion = txtNuevaDireccion.Text;
                ubi.Barrio = txtNuevoBarrio.Text;
                ubi.Telefono_2 = txtTelefono.Text;
                registrar_ubi.Ubicacion = ubi;

                CiudadBE ciucli = new CiudadBE();
                ciucli.Nombre_Ciudad = lstCiudad.SelectedValue;
                registrar_ubi.Ciudad = ciucli;

                DepartamentoBE depcli = new DepartamentoBE();
                depcli.Nombre_Departamento = lstDepartamento.SelectedValue;
                ciucli.Departamento = depcli;
                
                resp = servCliente.Agregar_Ubicacion(registrar_ubi);

                if (resp == "Ok")
                {
                    MessageBox.Show("La nueva ubicación fue registrada satisfactoriamente", "Registrar Nueva Ubicación");
                }
                
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCliente.Close();
                Response.Redirect("~/Clientes/frmNuevaUbicacion.aspx");
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