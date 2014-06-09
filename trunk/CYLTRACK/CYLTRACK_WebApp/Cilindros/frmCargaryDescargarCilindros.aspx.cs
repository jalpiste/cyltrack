using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYLTRACK_WebApp.CilindroService;
using CYLTRACK_WebApp.VehiculoService;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.Data;
using System.Windows.Forms;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmCargaryDescargarCilindros : System.Web.UI.Page
    {
        List<CilindroBE> lstDetail = new List<CilindroBE>();
        DataTable objdtLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                objdtLista = new DataTable();
                CrearTabla();
            }

            if (!IsPostBack)
            {
                lstOpcion.Focus();
            }
        }

        List<CilindroBE> lstCodigos = new List<CilindroBE>();

        protected void lstOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPlaca.Focus();
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            VehiculoServiceClient serVehiculo = new VehiculoServiceClient();

            string datoUbica = null;
            DataTable table = new DataTable();

            try
            {
                table.Columns.Add("CodigosCil");
                table.Columns.Add("Tamano");
                table.Columns.Add("TipoCil");

                if (lstOpcion.SelectedIndex == 1)
                {
                    datoUbica = Ubicacion.PLATAFORMA.ToString();
                    DivUbicacionCil.Visible = true;
                    lstPlaca.Visible = true;
                    BtnGuardar.Visible = true;
                    gvCargue.Visible = true;
                }
                else
                {
                    datoUbica = Ubicacion.VEHICULO.ToString();
                    DivUbicacionCil.Visible = true;
                    BtnGuardar.Visible = true;
                    gvCargue.Visible = true;
                }

                List<Ubicacion_CilindroBE> datosConsulta = new List<Ubicacion_CilindroBE>(servCilindro.ConsultarCilUbicacion(datoUbica));
                
                lstPlaca.DataSource = serVehiculo.ConsultarVehiculo(string.Empty);
                lstPlaca.DataValueField = "Id_Vehiculo";
                lstPlaca.DataTextField = "Placa";
                lstPlaca.DataBind();

                foreach (Ubicacion_CilindroBE datos in datosConsulta)
                {
                    table.Rows.Add(datos.Cilindro.Codigo_Cilindro, datos.Cilindro.Tipo_Cilindro, datos.Cilindro.NTamano.Tamano);
                }
                gvCargue.DataSource = table;
                gvCargue.DataBind();

            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servCilindro.Close();
                serVehiculo.Close();
            }

        }
        protected DataTable objdtTabla
        {
            get
            {
                if (ViewState["objdtTabla"] != null)
                {
                    return (DataTable)ViewState["objdtTabla"];
                }
                else
                {
                    return objdtLista;
                }
            }

            set
            {
                ViewState["objdtTabla"] = value;
            }
        }
        //        ------------------------- fin de tabla acumulada y asignación de valor
        private void CrearTabla()
        {
            objdtLista.Columns.Add("CodigosAdd");
            objdtTabla = objdtLista;
        }

        protected void gvCargueyDescargue_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            objdtTabla.Rows.RemoveAt(e.RowIndex);
            gdAdd.DataSource = objdtTabla;
            gdAdd.DataBind();
            BtnGuardar.Focus();
        }

        

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void BtnGuardar_Click1(object sender, EventArgs e)
        {
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            long resp;

            try
            {
                CilindroBE cil = new CilindroBE();
                foreach (DataRow info in objdtTabla.Rows)
                {                    
                    cil.Codigo_Cilindro += Convert.ToString(info["CodigosAdd"])+",";

                    Tipo_UbicacionBE tipUbi = new Tipo_UbicacionBE();
                    cil.Tipo_Ubicacion = tipUbi;
                    VehiculoBE veh = new VehiculoBE();
                    cil.Vehiculo = veh;

                    if (lstOpcion.SelectedIndex == 2)
                    {
                        cil.Tipo_Ubicacion.Nombre_Ubicacion = Ubicacion.PLATAFORMA.ToString();
                        cil.Vehiculo.Id_Vehiculo = "0";                       
                    }

                    else
                    {
                        cil.Tipo_Ubicacion.Nombre_Ubicacion = Ubicacion.VEHICULO.ToString();
                        cil.Vehiculo.Id_Vehiculo = lstPlaca.SelectedValue;
                    }                    
                }

                int var = cil.Codigo_Cilindro.Length;
                cil.Codigo_Cilindro = cil.Codigo_Cilindro.Substring(0, var - 1);
                  
                resp = servCilindro.ModificarUbicaCilindro(cil);
                MessageBox.Show("Los datos han sido guardados satisfactoriamente", "Cargue o descargue de Cilindro");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            {
                servCilindro.Close();
                Response.Redirect("~/Cilindros/frmCargaryDescargarCilindros.aspx");
            }
        }

        protected void lstPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdAdd.Focus();

        }

        protected void Agregar_onClick(object sender, EventArgs e)
        {
            BtnGuardar.Focus();
            
            try
            {
                CilindroBE cil = new CilindroBE();
                cil.Codigo_Cilindro = ((System.Web.UI.WebControls.Button)sender).Attributes["value"].ToString();

                foreach (DataRow info in objdtTabla.Rows)
                {
                    if (cil.Codigo_Cilindro == (Convert.ToString(info["CodigosAdd"])))
                    {
                        info.RowState.ToString().Remove(0,1);
                        //lstDetail.Add(detail);
                    }                    
                }
                lstDetail.Add(cil);

                foreach (CilindroBE info in lstDetail)
                {
                    objdtTabla.Rows.Add(info.Codigo_Cilindro);
                    gdAdd.DataSource = objdtTabla;
                    gdAdd.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                gdAdd.Visible = true;
            }

        }
    }
}