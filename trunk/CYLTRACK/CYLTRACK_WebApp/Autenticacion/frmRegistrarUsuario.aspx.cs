using CYLTRACK_WebApp.UsuarioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.Windows.Forms;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion
{
    public partial class frmRegistrarUsuario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioServiceClient servUsuario = new UsuarioServiceClient();
                UsuarioBE usuario = new UsuarioBE();
                try
                {
                    lstCargo.DataSource = servUsuario.ConsultarCargos();
                    lstCargo.DataValueField = "Id_Perfil";
                    lstCargo.DataTextField = "Perfil";
                    lstCargo.DataBind();

                    List<string> meses = Auxiliar.ConsultarMeses();
                    foreach (string datosMeses in meses)
                    {
                        lstMes.Items.Add(datosMeses);
                    }

                    txtNombreUsuario.Focus();
                    Dias[] dias = Auxiliar.ConsultarDias();
                    foreach (Dias datosDias in dias)
                    {
                        lstDia.Items.Add(datosDias.ToString());
                    }

                    Anos[] anos = Auxiliar.ConsultarAnos();
                    IEnumerable<Anos> listaAnos = anos.OrderByDescending(g => g).Skip(15);
                    foreach (Anos datosAnos in listaAnos)
                    {
                        lstAno.Items.Add(datosAnos.ToString());
                    }
                    List<string> sexo = Auxiliar.ConsultarSexo();
                    foreach (string datosSexo in sexo)
                    {
                        lstGenero.Items.Add(datosSexo);
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/About.aspx");
                }
                finally
                {
                    servUsuario.Close();
                }               
            }           
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            UsuarioServiceClient servUsuario = new UsuarioServiceClient();
            UsuarioBE usuario = new UsuarioBE();
            long registrar;
            
            try
            {
                long consultaUsuario = servUsuario.ConsultarExistencia(txtNombreUsuario.Text);

                if(consultaUsuario!=0)
                {
                    MessageBox.Show("El usuario digitado ya se encuentra registrado en el sistema", "Registrar Usuario");
                }

                else
                {
                usuario.Usuario = txtNombreUsuario.Text;
                usuario.Contrasena_1 = (txtContrasena.Text);
                usuario.Correo = txtEmail.Text;
                usuario.Cedula = txtCedula.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellidos.Text;
                usuario.Direccion = txtDireccion.Text;
                usuario.Telefono = txtTelefono.Text;
                usuario.Genero = lstGenero.SelectedItem.Text;
                usuario.Fecha_Nacim = lstDia.SelectedValue + "," + lstMes.SelectedValue + "," + lstAno.SelectedValue;
                PerfilBE pp = new PerfilBE();
                pp.Id_Perfil = lstCargo.SelectedValue;                
                usuario.Perfil= pp;

                registrar = servUsuario.RegistrarUsuario(usuario);

                MessageBox.Show("El usuario ha sido creado satisfactoriamente", "Registrar Usuario");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/About.aspx");
            }
            finally
            {
                servUsuario.Close();
                Response.Redirect("~/Autenticacion/frmRegistrarUsuario.aspx");
            }

        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void lstGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFocus(lstDia);
        }

        protected void lstDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFocus(lstMes);
        }

        protected void lstMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFocus(lstAno);
        }

        protected void lstAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFocus(lstCargo);
        }

        protected void lstCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFocus(btnCrearUsuario);
        }
    }
}
