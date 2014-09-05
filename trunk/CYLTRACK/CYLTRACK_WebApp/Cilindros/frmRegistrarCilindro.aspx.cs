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
                txtCodigoCilindro.Focus();
                btnMenu.Visible = true;
                ReporteServiceClient servReporte = new ReporteServiceClient();
                VehiculoServiceClient servVehiculo = new VehiculoServiceClient();

                try
                {
                        lstUbicacion.DataSource = servReporte.ConsultaTipoUbicacion().Skip(1);
                        lstUbicacion.DataValueField = "Id_Tipo_Ubica";
                        lstUbicacion.DataTextField = "Nombre_Ubicacion";
                        lstUbicacion.DataBind();
                 
                        lstTamano.DataSource = servReporte.ConsultaTamanoCilindro();
                        lstTamano.DataValueField = "Id_Tamano";
                        lstTamano.DataTextField = "Tamano";
                        lstTamano.DataBind();

                    //Anos[] anos = Auxiliar.ConsultarAnos();
                    //IEnumerable<Anos> listaAnos = anos.Skip(1).OrderByDescending(g => g);
                    //foreach (Anos datosAnos in listaAnos)
                    //{
                    //    lstAno.Items.Add(datosAnos.ToString());
                    //}

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
        protected void txtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            long codigo;
            try
            {
                codigo = servCilindro.ConsultarExistenciaCilindro(txtCodigoCilindro.Text);
                int anoActual = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(1));
                string varAno = (txtCodigoCilindro.Text.Substring(0, 2));

                if (codigo != 0)
                {
                    MessageBox.Show("El Cilindro ya se encuentra registrado en el sistema", "Registrar Cilindro");
                    txtCodigoCilindro.Text = "";
                    DivDatosCilindro.Visible = false;
                    btnGuardar.Visible = false;
                    txtCodigoCilindro.Focus();
                    txtEmpresa.Text = "";
                    txtAno.Text = "";
                    txtCodigo.Text = "";
                }
                else
                {
                    txtCil.Text = txtCodigoCilindro.Text;
                    txtCodigoCilindro.Text = "";
                    DivDatosCilindro.Visible = true;                    
                    lstUbicacion.Focus();                    
                    txtEmpresa.Text = txtCil.Text.Substring(2, 4);
                    txtCodigo.Text = txtCil.Text.Substring(6);

                    if (Convert.ToInt32(varAno) >= 0)
                    {
                        if (Convert.ToInt32(varAno) <= anoActual)
                        {
                            txtAno.Text = ("20" + varAno);
                            txtEmpresa_TextChanged(sender, e);
                        }
                        else
                        {
                            if (Convert.ToInt32(varAno) < anoActual)
                            {
                                MessageBox.Show("El año de fabricación del cilindro no es válido, rectifique los datos", "Registrar Cilindro");
                                txtCodigoCilindro.Text = "";
                                DivDatosCilindro.Visible = false;
                                btnGuardar.Visible = false;
                                txtCodigoCilindro.Focus();
                            }
                            else
                            {
                                txtAno.Text = ("19" + varAno);
                                txtEmpresa_TextChanged(sender, e);
                            }
                        }
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            long resp;
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();

            try
            {
                cilindro.Ano = txtAno.Text;
                FabricanteBE fab = new FabricanteBE();
                fab.Codigo_Fabricante = txtEmpresa.Text;
                cilindro.Fabricante = fab;
                cilindro.Serial_Cilindro = txtCodigo.Text;
                cilindro.Codigo_Cilindro = (txtAno.Text).Substring(2) + "" + txtEmpresa.Text + "" + txtCodigo.Text;
                VehiculoBE veh = new VehiculoBE();
                veh.Id_Vehiculo = (lstPlacas.SelectedValue);
                cilindro.Vehiculo = veh;
                Tipo_UbicacionBE tipUbica = new Tipo_UbicacionBE();
                tipUbica.Id_Tipo_Ubica = lstUbicacion.SelectedValue;
                tipUbica.Nombre_Ubicacion = lstUbicacion.SelectedItem.Text;
                cilindro.Tipo_Ubicacion = tipUbica;
                TamanoBE tam = new TamanoBE();
                tam.Id_Tamano = lstTamano.SelectedValue;
                cilindro.NTamano = tam;

                if (txtCil.Text == cilindro.Codigo_Cilindro)
                {
                    resp = servCilindro.RegistrarCilindro(cilindro);
                    if (resp != -1)
                    {
                        MessageBox.Show("El Cilindro fue registrado satisfactoriamente", "Registrar Cilindro");
                    }
                    else 
                    {
                        Response.Redirect("~/About.aspx");
                    }
                }
                else
                {
                    MessageBox.Show("El código escrito no coincide con los datos ingresados", "Registrar Cilindro");
                    txtCodigoCilindro.Text = "";
                }
            }
            catch (Exception ex)
            {

                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCilindro.Close();
                Response.Redirect("~/Cilindros/frmRegistrarCilindro.aspx");
            }
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Redirect("~/Default.aspx");
            }            
        }

        protected void txtEmpresa_TextChanged(object sender, EventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();

            try
            {
                long codigo = servCilindro.consultaCodigoFabricante(txtEmpresa.Text);

                if (codigo == 0)
                {
                    MessageBox.Show("El código del fabricante no se encuentra registrado en el sistema, comuníquese con el administrador del sistema", "Registrar Cilindro");
                    txtCodigoCilindro.Text = "";
                    DivDatosCilindro.Visible = false;
                    btnGuardar.Visible = false;
                    txtCodigoCilindro.Focus();
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

        protected void lstUbicacion_SelectedIndexChanged1(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            btnGuardar.Focus();
            if (lstUbicacion.SelectedItem.Text == Ubicacion.VEHICULO.ToString())
            {
                if (lstPlacas.Items.Count == 0)
                {
                    MessageBox.Show("No se ha realizado registros de vehículos en el sistema", "Registrar Cilindro");
                    lstPlacas.Visible = false;
                    lblPlaca.Visible = false;
                    lstUbicacion.Items.RemoveAt(lstUbicacion.SelectedIndex);
                }
                else
                {
                    lstPlacas.Visible = true;
                    lblPlaca.Visible = true;
                }
            }
            else
                {
                    lstPlacas.Visible = false;
                    lblPlaca.Visible = false;
                }
        }
     }
}