using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{

    public partial class frmAsignarUbicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        CilindroBE cilindro = new CilindroBE();
        protected void txtCodeCilindro_TextChanged(object sender, EventArgs e)
        {
            //valida datos a BD
            //llamar servicio metodo Asignar ubicacion


            //cilindro.Codigo_Cilindro = txtCodeCilindro.Text;

            //txtUbicacionActual.Text = cilindro.Ubicacion.Nombre_Ubicacion; 
            DivUbicacionCil.Visible = true;
            DivNuevaUbicacion.Visible = true;
            BtnGuardar.Visible = true;
        }

        protected void Ubica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUbica.SelectedValue == "Vehiculo")
            {


                //lstPlacaVehiculo.SelectedValue =  cilindro.Vehiculo.Placa;
                //TxtConductor.Text = cilindro.Vehiculo.Conductor_Vehiculo.Conductor.Nombres_Conductor;
                //LblRutaVehiculo.Text = cilindro.Vehiculo.Ruta.Nombre_Ruta;

                lblPlaca.Visible = true;
                lstPlacaVehiculo.Visible = true;
                LblConductor.Visible = true;
                TxtConductor.Visible = true;
                LblRuta.Visible = true;
                LblRutaVehiculo.Visible = true;
            }

        }


        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            //cilindro.Ubicacion.Nombre_Ubicacion = lstUbica.SelectedValue;
            //cilindro.Vehiculo.Placa = lstPlacaVehiculo.SelectedValue;
            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
            //DivUbicacionCil.Visible = false;
            //DivNuevaUbicacion.Visible = false;
        }


    }
}
