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
            if (!IsPostBack)
            {
                TxtCodigoCilindro.Focus();
            }
            if(!IsPostBack)
            {
                List<string> listaUbicacion = Auxiliar.ConsultarUbicacion();
                foreach(string datos in listaUbicacion)
                {
                    LstUbicacion.Items.Add(datos);
                }

                Anos[] anos = Auxiliar.ConsultarAnos();
                foreach (Anos datosAnos in anos)
                {
                    LstAno.Items.Add(datosAnos.ToString());
                }

                if (!IsPostBack)
                {
                    List<string> tamanos = Auxiliar.ConsultarTamanos();
                    foreach (string datosTamanos in tamanos)
                    {
                        LstTamano.Items.Add((datosTamanos).Substring(3));
                    }
                }
            }
        }
        protected void TxtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            SetFocus(BtnGuardar);
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            string codigo;
            try 
            {
                codigo = servCilindro.consultadeExistencia(TxtCodigoCilindro.Text);
               
                    if (codigo != "Ok")
                    {
                        MessageBox.Show("El cilindro ya se encuentra creado en el sistema", "Registrar Cilindro");                        
                    }
                    else 
                    {
                        txtCil.Text = TxtCodigoCilindro.Text;
                        TxtCodigoCilindro.Text = "";
                        DivDatosCilindro.Visible = true;
                        BtnGuardar.Visible = true;
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
                cilindro.Id_Cilindro = txtCil.Text;
                Tipo_UbicacionBE tipUbica = new Tipo_UbicacionBE();
                tipUbica.Nombre_Ubicacion= LstUbicacion.SelectedValue;
                UbicacionBE ubi = new UbicacionBE();
                ubi.Tipo_Ubicacion = tipUbica;
                cilindro.Ubicacion = ubi;
                TamanoBE tam = new TamanoBE();
                tam.Tamano= LstTamano.SelectedValue;
                cilindro.NTamano = tam;

                resp = servCilindro.RegistrarCilindro(cilindro);
                
                MessageBox.Show("El cilindro fue registrado satisfactoriamente", "Registrar Cilindro");
                            
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