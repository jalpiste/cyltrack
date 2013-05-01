using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Rutas
{
    public partial class frmRegistrarRuta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       // RutaBE ruta = new RutaBE();

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lstAgregar.Visible = true;
            lstAgregar.Items.Add(lstCiudad.Text);
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstAgregar.SelectedIndex > -1)
            {
                lstAgregar.Items.Remove(lstAgregar.Text);
            }
        }

        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {
            // ruta.Nombre_Ruta = txtNombreRuta.Text;
            // validar informacion
            //lstCiudad.Text = ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad;
            //lstDepartamento.Text = ruta.Departamento.Nombre_Departamento;

            DivSelCiudades.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad = lstCiudad.SelectedValue;
            //ruta.Departamento.Nombre_Departamento = lstDepartamento.SelectedValue;
            Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
        }

        
               
    }
}