using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.CilindroService;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmConsultarCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigoCilindro.Focus();
        }

        protected void txtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            CilindroBE[] resp;

            try
            {
                cilindro.Codigo_Cilindro = txtCodigoCilindro.Text;
                resp = servCilindro.ConsultarCilindro(cilindro);

                foreach (CilindroBE datosCil in resp)
                {
                    if (datosCil.Codigo_Cilindro == txtCodigoCilindro.Text)
                    {
                        MessageBox.Show("El código digitado no esta registrado en el sistema", "Consulta de Cilindros");
                    }
                    else
                    {
                        TxtAno.Text = datosCil.Ano;
                        TxtEmpresa.Text = datosCil.Fabricante.Nombre_Fabricante;
                        TxtCodigo.Text = datosCil.Serial_Cilindro;
                        TxtUbicacion.Text = datosCil.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion;
                        TxtTamano.Text = datosCil.NTamano.Tamano;
                        LblTotal.Text = datosCil.Codigo_Cilindro;
                        TxtRegistro.Text = Convert.ToString((datosCil.Fecha));

                        DivDatosCilindro.Visible = true;
                        BtnNuevaConsulta.Visible = true;

                        if (TxtUbicacion.Text == "Vehiculo")
                        {
                            TxtPlaca.Text = datosCil.Ubicacion.Vehiculo.Placa;
                            TxtConductor.Text = datosCil.Ubicacion.Vehiculo.Conductor.Nombres_Conductor;
                            TxtRuta.Text = datosCil.Ubicacion.Vehiculo.Ruta.Nombre_Ruta;

                            DivInfoVehiculo.Visible = true;
                        }

                        if (TxtUbicacion.Text == "Cliente")
                        {
                            txtCedula.Text = datosCil.Ubicacion.Cliente.Cedula;
                            TxtNombreCliente.Text = datosCil.Ubicacion.Cliente.Nombres_Cliente;
                            TxtPrimerApellido.Text = datosCil.Ubicacion.Cliente.Apellido_1;
                            TxtSegundoApellido.Text = datosCil.Ubicacion.Cliente.Apellido_2;
                            TxtDireccion.Text = datosCil.Ubicacion.Direccion;
                            TxtBarrio.Text = datosCil.Ubicacion.Barrio;
                            TxtCiudad.Text = datosCil.Ubicacion.Ciudad.Nombre_Ciudad;
                            TxtDepartamento.Text = datosCil.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                            TxtTelefono.Text = datosCil.Ubicacion.Telefono_1;
                            Txtentrega.Text = Convert.ToString(datosCil.Fecha);

                            DivInfoCilindro.Visible = true;
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCilindro.Close();
            }

        }



        protected void BtnNuevaConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                DivDatosCilindro.Visible = false;
                DivInfoCilindro.Visible = false;
            }
            finally
            {
                Response.Redirect("~/Cilindros/frmConsultarCilindro.aspx");
            }
            
        }

        protected void BtnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

      }
}