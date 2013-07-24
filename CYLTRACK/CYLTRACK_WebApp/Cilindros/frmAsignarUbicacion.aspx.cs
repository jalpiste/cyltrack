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
        public partial class frmAsignarUbicacion : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodeCilindro.Focus();

            if(!IsPostBack)
            {
                List<string> listaUbica = Auxiliar.ConsultarUbicacion();
                foreach(string datos in listaUbica)
                {
                    lstUbica.Items.Add(datos);
                }
            }
        }
        
        protected void txtCodeCilindro_TextChanged(object sender, EventArgs e)
        {
            CilindroServiceClient servAsig = new CilindroServiceClient();
            CilindroBE cil = new CilindroBE();
            CilindroBE ConsultarCilindro;
            string consultarExistencia;
            try 
            {
                consultarExistencia = servAsig.ConsultarExistencias(txtCodeCilindro.Text);

                if (consultarExistencia == null)
                    {
                        MessageBox.Show("El cilindro digitado no se encuentra registrado en el sistema", "Asignación de ubicación");
                    }
                    else
                    {
                        ConsultarCilindro = servAsig.ConsultarCilindro(txtCodeCilindro.Text);
                        txtCodigo.Text = ConsultarCilindro.Codigo_Cilindro;
                        txtUbicacionActual.Text = ConsultarCilindro.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion;
                        lstPlacaVehiculo.Items.Add(ConsultarCilindro.Ubicacion.Vehiculo.Placa);
                        TxtConductor.Text = ConsultarCilindro.Ubicacion.Vehiculo.Conductor.Nombres_Conductor;
                        LblRutaVehiculo.Text = ConsultarCilindro.Ubicacion.Vehiculo.Ruta.Nombre_Ruta;
                        DivUbicacionCil.Visible = true;
                        DivNuevaUbicacion.Visible = true;
                        BtnGuardar.Visible = true;
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
                if (lstUbica.SelectedValue == Ubicacion.Vehiculo.ToString())
                {
                    diVehiculo.Visible = true;
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
                veh.Placa= lstPlacaVehiculo.SelectedValue;
                ubi.Vehiculo = veh;
                cilindro.Ubicacion = ubi;
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
