﻿using System;
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
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            CilindroBE cilindro = new CilindroBE();
            long codigo;
            try
            {
                codigo = servCilindro.ConsultarExistenciaCilindro(TxtCodigoCilindro.Text);
                int anoActual = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(1));
                string varAno = (TxtCodigoCilindro.Text.Substring(0, 2));

                if (codigo != 0)
                {
                    MessageBox.Show("El Cilindro ya se encuentra creado en el sistema", "Registrar Cilindro");
                    TxtCodigoCilindro.Text = "";
                    DivDatosCilindro.Visible = false;
                    BtnGuardar.Visible = false;
                    TxtCodigoCilindro.Focus();                    
                }
                else
                {
                    txtCil.Text = TxtCodigoCilindro.Text;
                    TxtCodigoCilindro.Text = "";
                    DivDatosCilindro.Visible = true;
                    BtnGuardar.Visible = true;
                    BtnGuardar.Focus();
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

                    if (Convert.ToInt32(varAno) >= 0 || Convert.ToInt32(varAno) <= anoActual)
                    {
                        LstAno.SelectedValue = ("20" + varAno);
                    }
                    else
                    {
                        LstAno.Items.FindByText("19" + varAno);
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
                servCilindro.Close();
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
                VehiculoBE veh = new VehiculoBE();
                veh.Id_Vehiculo = (lstPlacas.SelectedValue);
                cilindro.Vehiculo = veh;
                Tipo_UbicacionBE tipUbica = new Tipo_UbicacionBE();
                tipUbica.Id_Tipo_Ubica = lstUbicacion.SelectedValue;
                cilindro.Tipo_Ubicacion = tipUbica;
                TamanoBE tam = new TamanoBE();
                tam.Id_Tamano = LstTamano.SelectedValue;
                cilindro.NTamano = tam;
                
                if (txtCil.Text == cilindro.Codigo_Cilindro)
                {
                    resp = servCilindro.RegistrarCilindro(cilindro);

                    MessageBox.Show("El Cilindro fue registrado satisfactoriamente", "Registrar Cilindro");
                    
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
                Response.Redirect("~/Cilindros/frmRegistrarCilindro.aspx");
            }
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void TxtEmpresa_TextChanged(object sender, EventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();

            try
            {
                long codigo = servCilindro.consultaCodigoFabricante(TxtEmpresa.Text);

                if (codigo == 0)
                {
                    MessageBox.Show("El código del fabricante no se encuentra registrado en el sistema, comuniquese con el administrador del sistema", "Registrar Cilindro");
                    TxtCodigoCilindro.Text = "";
                    DivDatosCilindro.Visible = false;
                    BtnGuardar.Visible = false;
                    TxtCodigoCilindro.Focus();
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

        protected void lstUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUbicacion.SelectedItem.Text == Ubicacion.VEHICULO.ToString())
            {
                if (lstPlacas.Items.Count == 0)
                {
                    MessageBox.Show("No se ha realizado registros de vehiculos en el sistema", "Registrar Cilindro");
                    lstPlacas.Visible = false;
                    lblPlaca.Visible = false;
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