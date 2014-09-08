using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.ClienteService;
using System.Windows.Forms;
using System.Data;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes
{
    public partial class frmconsultarcliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCedula.Focus();
            }
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
           
            ClienteServiceClient serCliente = new ClienteServiceClient();
            DataTable table = new DataTable();

            try
            {
                long consultaExistencia = serCliente.ConsultarExistenciasClientes(txtCedula.Text);

                if (consultaExistencia == 0)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consulta de Clientes");
                    divInfoCliente.Visible = false;
                    btnNuevaConsulta.Visible = false;
                    txtCedula.Text = "";
                    txtCedula.Focus();
                }
                else
                {
                    txtCedula.Enabled = false;
                    ClienteBE consulta = serCliente.Consultar_Cliente(txtCedula.Text);
                    txtCedulaCli.Text = consulta.Cedula;
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
                    }
                    gvDirecciones.DataSource = table;
                    gvDirecciones.DataBind();
                    
                    divInfoCliente.Visible = true;
                    divDireccionesCli.Visible = true;
                    btnNuevaConsulta.Visible = true;
                    txtCedula.Text = "";
                    btnNuevaConsulta.Focus();

                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                serCliente.Close();

            }
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            txtCedula.Text = "";
            txtCedula.Enabled = true;
            divInfoCliente.Visible = false;
            btnNuevaConsulta.Visible = false;

        }
    }
}