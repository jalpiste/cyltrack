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
            SetFocus(DivInfoCilindro);
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            string respConsultaExistencias;
            CilindroBE respConsultaCilindro;

            try
            {
                respConsultaExistencias = servCilindro.consultadeExistencia(txtCodigoCilindro.Text);

                 if (respConsultaExistencias == null)
                    {
                        MessageBox.Show("El código digitado no se encuentra registrado en el sistema", "Consulta de Cilindros");
                    }
                    else
                    {
                        respConsultaCilindro = servCilindro.ConsultarCilindro(txtCodigoCilindro.Text);

                        TxtAno.Text = respConsultaCilindro.Ano;
                        TxtEmpresa.Text = respConsultaCilindro.Fabricante.Nombre_Fabricante;
                        TxtCodigo.Text = respConsultaCilindro.Serial_Cilindro;
                        TxtUbicacion.Text = respConsultaCilindro.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion;
                        TxtTamano.Text = respConsultaCilindro.NTamano.Tamano;
                        txtCodigoTotal.Text = respConsultaCilindro.Codigo_Cilindro;
                        TxtRegistro.Text = Convert.ToString((respConsultaCilindro.Fecha));

                        DivDatosCilindro.Visible = true;
                        BtnNuevaConsulta.Visible = true;

                        if (TxtUbicacion.Text == Ubicacion.Vehiculo.ToString())
                        {
                            TxtPlaca.Text = respConsultaCilindro.Ubicacion.Vehiculo.Placa;
                            TxtConductor.Text = respConsultaCilindro.Ubicacion.Vehiculo.Conductor.Nombres_Conductor;
                            TxtRuta.Text = respConsultaCilindro.Ubicacion.Vehiculo.Ruta.Nombre_Ruta;

                            DivInfoVehiculo.Visible = true;
                        }

                        if (TxtUbicacion.Text == Ubicacion.Cliente.ToString())
                        {
                            txtCedula.Text = respConsultaCilindro.Ubicacion.Cliente.Cedula;
                            TxtNombreCliente.Text = respConsultaCilindro.Ubicacion.Cliente.Nombres_Cliente;
                            TxtPrimerApellido.Text = respConsultaCilindro.Ubicacion.Cliente.Apellido_1;
                            TxtSegundoApellido.Text = respConsultaCilindro.Ubicacion.Cliente.Apellido_2;
                            foreach (string datos in respConsultaCilindro.Ubicacion.Direccion)
                            {
                                TxtDireccion.Text = datos;
                            } 
                            TxtBarrio.Text = respConsultaCilindro.Ubicacion.Barrio;
                            TxtCiudad.Text = respConsultaCilindro.Ubicacion.Ciudad.Nombre_Ciudad;
                            TxtDepartamento.Text = respConsultaCilindro.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                            TxtTelefono.Text = respConsultaCilindro.Ubicacion.Telefono_1;
                            Txtentrega.Text = Convert.ToString(respConsultaCilindro.Fecha);

                            DivInfoCilindro.Visible = true;
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