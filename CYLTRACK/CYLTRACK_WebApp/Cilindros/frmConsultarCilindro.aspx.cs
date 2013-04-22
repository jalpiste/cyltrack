using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmConsultarCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void txtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            CilindroBE consulta = new CilindroBE();
            Ubicacion_CilindroBE ubicacion = new Ubicacion_CilindroBE();

            consulta.Codigo_Cilindro = Convert.ToString(txtCodigoCilindro);
             
            //llamar al servicio y validar en bd

            //Service1Cilindro serv = new Service1Cilindro();
            //consulta = Server.ConsultarCilindro();
            //TxtAno.Text = Convert.ToString(serv.ConsultarCilindro(consulta.Ano));
            //TxtEmpresa.Text = Convert.ToString(serv.ConsultarCilindro(consulta.Id_Fabricante));
            //TxtCodigo.Text = Convert.ToString(serv.ConsultarCilindro(consulta.Codigo_Cilindro));
            //TxtUbicacion.Text = Convert.ToString(serv.ConsultarCilindro(ubicacion.Nombre));
            //TxtCodigo.Text = Convert.ToString(serv.ConsultarCilindro(consulta.Codigo_Cilindro));
      
            DivDatosCilindro.Visible = true;
            BtnNuevaConsulta.Visible = true;
            if (TxtUbicacion.Text == "Vehiculo") 
            {
                DivInfoVehiculo.Visible = true;
            }
            if (TxtUbicacion.Text == "Cliente") 
            {
                DivInfoCilindro.Visible = true;
            }
            
        }

        protected void BtnNuevaConsulta_Click(object sender, EventArgs e)
        {
            DivDatosCilindro.Visible = false;
            DivInfoCilindro.Visible = false;
        }

        protected void BtnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void BtnMenuPrincipal_Click1(object sender, EventArgs e)
        {

        }




    }
}