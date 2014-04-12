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
using CYLTRACK_WebApp.ReporteService;
using CYLTRACK_WebApp.VehiculoService;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmRegistrarCilindro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtCodigoCilindro.Focus();

                ReporteServiceClient servReporte = new ReporteServiceClient();
                VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

                try
                {
                 
                        lstUbicacion.DataSource = servReporte.ConsultaTipoUbicacion().Skip(1);
                        lstUbicacion.DataValueField = "Id_Tipo_Ubica";
                        lstUbicacion.DataTextField = "Nombre_Ubicacion";
                        lstUbicacion.DataBind();
                 
                        LstTamano.DataSource = servReporte.ConsultaTamanoCilindro();
                        LstTamano.DataValueField = "Id_Tamano";
                        LstTamano.DataTextField = "Tamano";
                        LstTamano.DataBind();

                    Anos[] anos = Auxiliar.ConsultarAnos();
                    IEnumerable<Anos> listaAnos = anos.Skip(1).OrderByDescending(g => g);
                    foreach (Anos datosAnos in listaAnos)
                    {
                        LstAno.Items.Add(datosAnos.ToString());
                    }

                        lstPlacas.DataSource = servVehiculo.ConsultarVehiculo(string.Empty);
                        lstPlacas.DataValueField = "Id_Vehiculo";
                        lstPlacas.DataTextField = "Placa";
                        lstPlacas.DataBind();
                 }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }

                finally
                {
                    servVehiculo.Close();
                    servReporte.Close();
                }
            }
        }
        protected void TxtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            SetFocus(BtnGuardar);
            ReporteServiceClient servReporte = new ReporteServiceClient();
            CilindroBE cilindro = new CilindroBE();
            long codigo;
            try
            {
                codigo = servReporte.consultadeExistencia(TxtCodigoCilindro.Text);

                if (codigo != 0)
                {
                    MessageBox.Show("El Cilindro ya se encuentra creado en el sistema", "Registrar Cilindro");
                    TxtCodigoCilindro.Text = "";
                }
                else
                {
                    txtCil.Text = TxtCodigoCilindro.Text;
                    TxtCodigoCilindro.Text = "";
                    DivDatosCilindro.Visible = true;
                    BtnGuardar.Visible = true;
                    if (txtCil.Text.Length == 11)
                    {
                        TxtEmpresa.Text = txtCil.Text.Substring(2, 3);
                        TxtCodigo.Text = txtCil.Text.Substring(5);
                    }
                    else
                    {
                        TxtEmpresa.Text = txtCil.Text.Substring(2, 4);
                        TxtCodigo.Text = txtCil.Text.Substring(6);
                    }

                    TxtEmpresa_TextChanged(sender, e);
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servReporte.Close();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            long resp;
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();

            try
            {
                cilindro.Ano = LstAno.SelectedValue;
                FabricanteBE fab = new FabricanteBE();
                fab.Codigo_Fabricante = TxtEmpresa.Text;
                cilindro.Fabricante = fab;
                cilindro.Serial_Cilindro = TxtCodigo.Text;
                cilindro.Codigo_Cilindro = (LstAno.SelectedValue).Substring(2) + "" + TxtEmpresa.Text + "" + TxtCodigo.Text;
                Ubicacion_CilindroBE UbicaCil = new Ubicacion_CilindroBE();
                UbicacionBE ubi = new UbicacionBE();
                Tipo_UbicacionBE tipUbica = new Tipo_UbicacionBE();
                tipUbica.Id_Tipo_Ubica = lstUbicacion.SelectedValue;
                ubi.Tipo_Ubicacion = tipUbica;
                UbicaCil.Ubicacion = ubi;
                cilindro.Ubicacion_Cilindro = UbicaCil;
                TamanoBE tam = new TamanoBE();
                tam.Id_Tamano = LstTamano.SelectedValue;
                cilindro.NTamano = tam;

                if (txtCil.Text == cilindro.Codigo_Cilindro)
                {
                    resp = servCilindro.RegistrarCilindro(cilindro);

                    MessageBox.Show("El Cilindro fue registrado satisfactoriamente", "Registrar Cilindro");
                    Response.Redirect("~/Cilindros/frmRegistrarCilindro.aspx");
                }
                else
                {
                    MessageBox.Show("El código escrito no coincide con los datos ingresados", "Registrar Cilindro");
                    TxtCodigoCilindro.Text = "";
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

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void TxtEmpresa_TextChanged(object sender, EventArgs e)
        {
            ReporteServiceClient servReporte = new ReporteServiceClient();

            try
            {
                long codigo = servReporte.consultadeExistencia(TxtEmpresa.Text);

                if (codigo == 0)
                {
                    MessageBox.Show("El código del fabricante no se encuentra registrado en el sistema", "Registrar Cilindro");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servReporte.Close();
            }
        }

        protected void lstUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUbicacion.SelectedItem.Text == Ubicacion.VEHICULO.ToString())
            {
                lstPlacas.Visible = true;
                lblPlaca.Visible = true;
            }
        }

              
     }
}