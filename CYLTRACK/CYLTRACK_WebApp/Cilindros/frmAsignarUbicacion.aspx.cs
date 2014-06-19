using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.CilindroService;
using System.Windows.Forms;
using CYLTRACK_WebApp.ReporteService;
using CYLTRACK_WebApp.VehiculoService;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmAsignarUbicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ReporteServiceClient servReporte = new ReporteServiceClient();
                    
                try
                {
                    lstUbica.DataSource = servReporte.ConsultaTipoUbicacion();
                    lstUbica.DataValueField = "Id_Tipo_Ubica";
                    lstUbica.DataTextField = "Nombre_Ubicacion";
                    lstUbica.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }
            finally
            {
                servReporte.Close();
                txtCodeCilindro.Focus();
            }
            }
        }

        protected void txtCodeCilindro_TextChanged(object sender, EventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            
            long consultarExistencia;
            try
            {
                consultarExistencia = servCilindro.ConsultarExistenciaCilindro(txtCodeCilindro.Text);

                if (consultarExistencia == 0)
                {
                    MessageBox.Show("El cilindro digitado no se encuentra registrado en el sistema", "Asignación de ubicación");
                    DivCodigo.Visible = false;
                    diVehiculo.Visible= false;
                    DivNuevaUbicacion.Visible = false;
                    DivUbicacionCil.Visible = false;
                    txtCodeCilindro.Focus();
                }
                else
                {
                    CilindroBE ConsultarCilindro = servCilindro.ConsultarCilindro(txtCodeCilindro.Text);
                    txtCodigo.Text = ConsultarCilindro.Codigo_Cilindro;
                    txtUbicacionActual.Text = ConsultarCilindro.Tipo_Ubicacion.Nombre_Ubicacion;
                    DivUbicacionCil.Visible = true;
                    DivNuevaUbicacion.Visible = true;
                    txtCodeCilindro.Text = "";
                    lstUbica.Focus();
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

        protected void Ubica_SelectedIndexChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

            try
            {
                if (lstUbica.SelectedItem.ToString() == Ubicacion.VEHICULO.ToString())
                {

                    lstPlacaVehiculo.DataSource = servVehiculo.ConsultarVehiculo(string.Empty);
                    lstPlacaVehiculo.DataValueField = "Id_Vehiculo";
                    lstPlacaVehiculo.DataTextField = "Placa";
                    lstPlacaVehiculo.DataBind();
                    diVehiculo.Visible = true;
                    lstPlacaVehiculo.Focus();
                }
                else 
                {
                    diVehiculo.Visible = false;
                    lstPlacaVehiculo.Controls.Clear();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }

            finally 
            {
                servVehiculo.Close();
                BtnGuardar.Visible = true;
            }

        }


        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            long resp;
            CilindroServiceClient servAsig = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            try
            {
                cilindro.Codigo_Cilindro = txtCodigo.Text;
                Tipo_UbicacionBE tipoUbi = new Tipo_UbicacionBE();
                tipoUbi.Nombre_Ubicacion=lstUbica.SelectedItem.Text;
                cilindro.Tipo_Ubicacion = tipoUbi;

                if (tipoUbi.Nombre_Ubicacion == Ubicacion.VEHICULO.ToString())
                {
                    VehiculoBE veh = new VehiculoBE();
                    veh.Id_Vehiculo = lstPlacaVehiculo.SelectedValue;
                    cilindro.Vehiculo = veh;
                }
                else 
                {
                    VehiculoBE veh = new VehiculoBE();
                    veh.Id_Vehiculo = "0";
                    cilindro.Vehiculo = veh;
                }
                resp = servAsig.ModificarUbicaCilindro(cilindro);

                MessageBox.Show("La asignación de ubicación fue cambiada satisfactoriamente", "Asignar Ubicación");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servAsig.Close();
                Response.Redirect("~/Cilindros/frmAsignarUbicacion.aspx");
            }

        }

        protected void lstPlacaVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

            try 
            {
                List<VehiculoBE> lstVehiculo = new List<VehiculoBE>(servVehiculo.ConsultarVehiculo(lstPlacaVehiculo.SelectedItem.Text));

                foreach(VehiculoBE datos in lstVehiculo)
                {
                    TxtConductor.Text = datos.Conductor.Nombres_Conductor+" "+datos.Conductor.Apellido_1+" "+datos.Conductor.Apellido_2;
                    LblRutaVehiculo.Text = datos.Ruta.Nombre_Ruta;
                }
                
        
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servVehiculo.Close();                
            }
           }

        
    }
}
