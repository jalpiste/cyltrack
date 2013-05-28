using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.RutaService;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Rutas
{
    public partial class frmModificarRuta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
        }

        
        RutaBE ruta = new RutaBE();
        RutaServicesClient servRuta = new RutaServicesClient();
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lstCiudades1.Items.Add(lstCiudad.SelectedValue);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
                //lstCiudad.Text = ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad;
                DivModificarDatos.Visible = true;
                btnModificar.Visible = false;
                txtNuevoNombre.Enabled = true;
                btnRemoverCiudades.Visible = true;
          }

        protected void txtNombreRuta_TextChanged(object sender, EventArgs e)
        {
            RutaBE[] consulta = servRuta.ConsultarRuta(ruta);

            var datos = from info in consulta
                        select info;

            foreach(RutaBE info in datos)
            {
            txtNuevoNombre.Text = txtNombreRuta.Text;
            lstCiudades1.Items.Add(info.Nombre_Ruta);
            lstCiudades1.Items.Add(info.Nombre_Ruta);
            lstCiudad .Items.Add(info.Nombre_Ruta);
            lstCiudad .Items.Add(info.Nombre_Ruta);

            DivPost.Visible = true;
            DivDatos.Visible = true;
            DivCiudad.Visible = true;
            btnGuardar.Visible = true;
            }
                     
        }

  

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String datos;
            RutaBE ruta = new RutaBE();
            ruta.Nombre_Ruta = lstCiudades1.Text;//no estoy segura que guarde todos los datos de la lista
            datos = servRuta.ModificarRuta(ruta);

            if (datos == "Ok")
            {
                Response.Write("<script type='text/javascript'> alert('Sus datos fueron enviados satisfactoriamente') </script>");
                DivPost.Visible = false;
                DivDatos.Visible = false;
                DivCiudad.Visible = false;
                btnGuardar.Visible = false;
                DivModificarDatos.Visible = false;
            }
            else 
            {
                Response.Write("<script type='text/javascript'> alert('Error al tratar de modificar la ruta') </script>");
                DivPost.Visible = false;
                DivDatos.Visible = false;
                DivCiudad.Visible = false;
                btnGuardar.Visible = false;
                DivModificarDatos.Visible = false;
            }

           }


        protected void btnRemoverCiudades_Click(object sender, EventArgs e)
        {
            if(lstCiudades1.Items.Count > 0 )
            {
               // lstCiudades1.Items.Remove(lstCiudades1.Text);
                lstCiudades1.Items.Remove(Convert.ToString(lstCiudades1.SelectedIndex));
              
            }
        }

      
        
    }
}