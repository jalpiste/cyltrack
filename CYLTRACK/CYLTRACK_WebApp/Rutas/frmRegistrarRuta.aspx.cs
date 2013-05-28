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
    public partial class frmRegistrarRuta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        RutaServicesClient servRuta = new RutaServicesClient();
        RutaBE ruta = new RutaBE();
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
            
            //String nombreRuta;
            //ruta.Nombre_Ruta = txtNombreRuta.Text;
            //nombreRuta = servRuta.RegistrarRuta(ruta);

            //if (nombreRuta == "Creada")
            //{
            //    Response.Write("<script type='text/javascript'> alert('El nombre de la ruta ya ha sido creada') </script>");
            //}
            //else
            //{
            RutaBE[] consulta = servRuta.ConsultarRuta(ruta);

            var datos = from infoRuta in consulta
                        select infoRuta;

            foreach (RutaBE infoRuta in datos)
            {
                lstCiudad.Items.Add(infoRuta.Nombre_Ruta);
                //lstDepartamento.Text = infoRuta.Departamento.Nombre_Departamento;
            }
                
            //    }
           DivSelCiudades.Visible = true;
           btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RutaServicesClient servicioRuta = new RutaServicesClient();
            RutaBE ruta = new RutaBE();
            String creacionRuta;

            ruta.Nombre_Ruta = txtNombreRuta.Text;
            //ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad = lstAgregar.SelectedValue;

            creacionRuta = servicioRuta.RegistrarRuta(ruta);

            if (creacionRuta == "Ok") 
            {
                Response.Write("<script type='text/javascript'> alert('La ruta ha sido creada satisfactoriamente') </script>");
                DivSelCiudades.Visible = false;
                btnGuardar.Visible = false;
            }
            else
            {
                Response.Write("<script type='text/javascript'> alert('Error al tratar de crear la ruta') </script>");
                DivSelCiudades.Visible = false;
                btnGuardar.Visible = false;
            }

        }
  
               
    }
}