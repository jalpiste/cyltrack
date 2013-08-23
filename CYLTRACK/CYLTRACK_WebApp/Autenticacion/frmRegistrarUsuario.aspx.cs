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
                txtNombreUsuario.Focus();                
            }


            if (!IsPostBack)
            {
                List<string> meses = Auxiliar.ConsultarMeses();
                foreach (string datosMeses in meses)
                {
                    lstMes.Items.Add(datosMeses);
                }
            }

            if (!IsPostBack)
            {
                Dias[] dias = Auxiliar.ConsultarDias();
                foreach (Dias datosDias in dias)
                {
                    lstDia.Items.Add(datosDias.ToString());
                }
            }
            if (!IsPostBack)
            {
                Anos[] anos = Auxiliar.ConsultarAnos();
                IEnumerable<Anos> listaAnos = anos.OrderByDescending(g => g).Skip(15);
                foreach (Anos datosAnos in listaAnos)
                {
                    lstAno.Items.Add(datosAnos.ToString());
                }

            }
            if (!IsPostBack)
            {
                List<string> sexo = Auxiliar.ConsultarSexo();
                foreach (string datosSexo in sexo)
                {
                    lstGenero.Items.Add(datosSexo);
                }
            }
            

            if (!IsPostBack)
            {
                UsuarioServiceClient servUsuario = new UsuarioServiceClient();
                UsuarioBE usuario = new UsuarioBE();
                try
                {
                    List<PerfilBE> lstPerfiles = new List<PerfilBE>(servUsuario.ConsultarCargos());
                   
                    foreach(PerfilBE datos in lstPerfiles)
                    {
                        lstCargo.Items.Add(datos.Perfil);
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
            string registrar;
            
            try
            {
                string consultaUsuario = servUsuario.ConsultarExistencia(txtNombreUsuario.Text);

                if(consultaUsuario!="Ok")
                {
                    MessageBox.Show("El usuario digitado ya se encuentra registrado en el sistema", "Registrar Usuario");
                }

                else
                {
                usuario.Usuario = txtNombreUsuario.Text;
                usuario.Contrasena_1 = txtContrasena.Text;
                usuario.Correo = txtEmail.Text;
                usuario.Cedula = txtCedula.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellidos.Text;
                usuario.Direccion = txtDireccion.Text;
                usuario.Telefono = txtTelefono.Text;
                usuario.Genero = lstGenero.SelectedValue;
                usuario.Fecha_Nacim = lstDia.SelectedValue + "," + lstMes.SelectedValue + "," + lstAno.SelectedValue;
                PerfilBE pp = new PerfilBE();
                pp.Perfil = lstCargo.SelectedValue;
                List<PerfilBE> perfiles = new List<PerfilBE>();
                perfiles.Add(pp);
                usuario.Perfil = perfiles;

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
