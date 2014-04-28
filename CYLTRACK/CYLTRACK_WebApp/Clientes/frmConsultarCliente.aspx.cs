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
            txtCedula.Focus();
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            btnNuevaConsulta.Focus();
            ClienteServiceClient serCliente = new ClienteServiceClient();
            DataTable table = new DataTable();

            try
            {
                long consultaExistencia = serCliente.ConsultarExistenciasClientes(txtCedula.Text);

                if (consultaExistencia == 0)
                {
                    MessageBox.Show("El cliente no se encuentra registrado en el sistema", "Consulta de Clientes");
                }
                else
                {
                    ClienteBE cliente = new ClienteBE();
                    cliente = serCliente.Consultar_Cliente(txtCedula.Text);

                    table.Columns.Add("CodigosCil");
                    table.Columns.Add("Tamano");
                    table.Columns.Add("TipoCil");

                    txtCedulaCli .Text = cliente.Cedula;
                    txtNombreCliente.Text = cliente.Nombres_Cliente;
                    txtPrimerApellido.Text = cliente.Apellido_1;
                    txtSegundoApellido.Text = cliente.Apellido_2;
                    txtDireccion.Text = cliente.Ubicacion.Direccion;
                    txtBarrio.Text = cliente.Ubicacion.Barrio;
                    txtTelefono.Text = cliente.Ubicacion.Telefono_1;
                    txtCiudad.Text = cliente.Ubicacion.Ciudad.Nombre_Ciudad;
                    txtDepartamento.Text = cliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                    //table.Rows.Add(cliente.Ubicacion.Ubicacion_Cilindro.Cilindro.Codigo_Cilindro, cliente.Ubicacion.Ubicacion_Cilindro.Cilindro.NTamano.Tamano, cliente.Ubicacion.Ubicacion_Cilindro.Cilindro.Tipo_Cilindro);
                    //gdCilindrosCli.DataSource = table;
                    //gdCilindrosCli.DataBind();
                    divInfoCliente.Visible = true;
                    btnNuevaConsulta.Visible = true;
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
            //Response.Redirect("~/Default.aspx");
        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            //txtCedula.Text = "";
            //divInfoCliente.Visible = false;
            //btnNuevaConsulta.Visible = false;
            
        }
    }
}