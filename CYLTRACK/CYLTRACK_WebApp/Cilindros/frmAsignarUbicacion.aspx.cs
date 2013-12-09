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

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
        public partial class frmAsignarUbicacion : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtCodeCilindro.Focus();
                ReporteServiceClient servReporte = new ReporteServiceClient();
                List<Tipo_UbicacionBE> lstipoUbica = new List<Tipo_UbicacionBE>(servReporte.ConsultaTipoUbicacion());
                foreach (Tipo_UbicacionBE datosUbicacion in lstipoUbica)
                {
                    lstUbica.Items.Add(datosUbicacion.Nombre_Ubicacion);
                }
            }
        }
        
        protected void txtCodeCilindro_TextChanged(object sender, EventArgs e)
        {
            lstUbica.Focus();
            CilindroServiceClient servAsig = new CilindroServiceClient();
            CilindroBE cil = new CilindroBE();
            CilindroBE ConsultarCilindro;
            long consultarExistencia;
            try 
            {
                consultarExistencia = servAsig.consultadeExistencia(txtCodeCilindro.Text);

                if (consultarExistencia == 0)
                    {
                        MessageBox.Show("El cilindro digitado no se encuentra registrado en el sistema", "Asignación de ubicación");
                    }
                    else
                    {
                        ConsultarCilindro = servAsig.ConsultarCilindro(txtCodeCilindro.Text);
                        txtCodigo.Text = ConsultarCilindro.Codigo_Cilindro;
                        txtUbicacionActual.Text = ConsultarCilindro.Ubicacion_Cilindro.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion;
                        lstPlacaVehiculo.Items.Add(ConsultarCilindro.Ubicacion_Cilindro.Ubicacion.Vehiculo.Placa);
                        TxtConductor.Text = ConsultarCilindro.Ubicacion_Cilindro.Ubicacion.Vehiculo.Conductor.Nombres_Conductor;
                        LblRutaVehiculo.Text = ConsultarCilindro.Ubicacion_Cilindro.Ubicacion.Vehiculo.Ruta.Nombre_Ruta;
                        DivUbicacionCil.Visible = true;
                        DivNuevaUbicacion.Visible = true;
                        
                    }               
            }

            catch (Exception ex) 
            {
                Response.Redirect("~/About.aspx");
            }
            finally 
            {
                servAsig.Close();                
            }
     }

        protected void Ubica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BtnGuardar.Visible = true;
                if (lstUbica.SelectedValue == Ubicacion.Vehiculo.ToString())
                {
                    diVehiculo.Visible = true;
                    lstPlacaVehiculo.Focus();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }

        }


        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string resp;
            CilindroServiceClient servAsig = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            try 
            {
                cilindro.Codigo_Cilindro = txtCodeCilindro.Text;
                Tipo_UbicacionBE tipUbi = new Tipo_UbicacionBE();
                tipUbi.Nombre_Ubicacion = lstUbica.SelectedValue;
                UbicacionBE ubi = new UbicacionBE();
                ubi.Tipo_Ubicacion = tipUbi;
                VehiculoBE veh = new VehiculoBE();
                veh.Placa= (lstPlacaVehiculo.SelectedValue);
                Ubicacion_CilindroBE UbiCil = new Ubicacion_CilindroBE();
                ubi.Vehiculo = veh;
                UbiCil.Ubicacion = ubi;
                cilindro.Ubicacion_Cilindro = UbiCil;
                resp = servAsig.AsignarUbicacion(cilindro);

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

    }
}
