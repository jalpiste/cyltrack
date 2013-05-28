using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.CilindroService;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmRegistrarCilindro : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void TxtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            //CilindroBE cilindro = new CilindroBE();
            //cilindro.Codigo_Cilindro = TxtCodigoCilindro.Text;
            //ir a BD a vañlidar si existe
            // si existe mostrar mensaje
            DivDatosCilindro.Visible = true;
            BtnGuardar.Visible = true;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            String resp;
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            cilindro.Ano = (LstAno.SelectedValue);
            //cilindro.Fabricante.Codigo_Fabricante = (TxtEmpresa.Text);
            cilindro.Id_Cilindro = (TxtCodigoCilindro.Text);
            //cilindro.Tipo_Ubicacion.Nombre_Ubicacion = (LstUbicacion.SelectedValue);
            //cilindro.NTamano.Tamano = (LstTamano.SelectedValue);
           
            resp = servCilindro.RegistrarCilindro(cilindro);


            if (resp == "Ok")
            {
                Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
                DivDatosCilindro.Visible = false;
            }
            else
            {
                Response.Write("<script type='text/javascript'> alert('No se pudo crear el cilindro en el sistema') </script>");
                DivDatosCilindro.Visible = false;
            }
            servCilindro.Close();

        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {


        }




    }
}