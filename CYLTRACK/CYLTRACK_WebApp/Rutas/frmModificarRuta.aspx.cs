using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Rutas
{
    public partial class frmModificarRuta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lstCiudades.Items.Add(lstCiudad.Text);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //RutaBE ruta = new RutaBE();
            //lstDepartamento.Text = ruta.Departamento.Nombre_Departamento;
            //lstCiudad.Text = ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad;
            DivModificarDatos.Visible = true;
            btnModificar.Visible = false;
            txtNuevoNombre.Enabled = true;
            btnRemover.Visible = true;
        }

        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {

            //RutaBE ruta = new RutaBE();
            //ruta.Nombre_Ruta = txtNombreRuta.Text;
            //txtNuevoNombre.Text = txtNombreRuta.Text;
            //lstCiudades.Text = ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad;

            DivPost.Visible = true;
            DivDatos.Visible = true;
            DivCiudad.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
             if (lstCiudades.SelectedIndex > -1)
            {
                lstCiudades.Items.Remove(lstCiudades.Text);
            }

            //If (lstCiudades.ListIndex <> -1) Then

            //   List1.RemoveItem List1.ListIndex
            // End If

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //RutaBE ruta = new RutaBE();
            //ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad = lstCiudades.Text;//no estoy segura que guarde todos los datos de la lista
            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
        }

        
    }
}