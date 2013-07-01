using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.CilindroService;
using System.Windows.Forms;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmRegistrarCilindro : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtCodigoCilindro.Focus();
        }
        protected void TxtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            CilindroBE [] codigo;
            try {

                cilindro.Codigo_Cilindro = TxtCodigoCilindro.Text;
                codigo = servCilindro.ConsultarCilindro(cilindro);
                foreach(CilindroBE datosList in codigo)
                {
                    if (datosList.Codigo_Cilindro == TxtCodigoCilindro.Text)
                    {
                        MessageBox.Show("El cilindro ya se encuentra creado en el sistema", "Registrar Cilindro");
                    }
                    else 
                    {
                        txtCil.Text = TxtCodigoCilindro.Text;
                        DivDatosCilindro.Visible = true;
                        BtnGuardar.Visible = true;
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

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            String resp;
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();

            try {

                cilindro.Ano = LstAno.SelectedValue;
                FabricanteBE fab = new FabricanteBE();
                fab.Id_Fabricante= TxtEmpresa.Text;
                cilindro.Fabricante = fab;
                cilindro.Id_Cilindro = TxtCodigoCilindro.Text;
                Tipo_UbicacionBE tipUbica = new Tipo_UbicacionBE();
                tipUbica.Nombre_Ubicacion= LstUbicacion.SelectedValue;
                UbicacionBE ubi = new UbicacionBE();
                ubi.Tipo_Ubicacion = tipUbica;
                cilindro.Ubicacion = ubi;
                TamanoBE tam = new TamanoBE();
                tam.Tamano= LstTamano.SelectedValue;
                cilindro.NTamano = tam;

                resp = servCilindro.RegistrarCilindro(cilindro);
                
                if (resp == "Ok")
                {
                    MessageBox.Show("El cilindro fue registrado satisfactoriamente", "Registrar Cilindro");
                }
               
            }
            catch (Exception ex) {

                Response.Redirect("~/About.aspx");
            }
            finally {

                servCilindro.Close();
                Response.Redirect("~/Cilindros/frmRegistrarCilindro.aspx");

            }
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

      }
}