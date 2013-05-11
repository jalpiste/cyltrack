using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmConsultarCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        CilindroBE cilindro = new CilindroBE();
        protected void txtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {


            //cilindro.Codigo_Cilindro = txtCodigoCilindro.Text;

            //llamar al servicio y validar en bd

            //Service1Cilindro serv = new Service1Cilindro();
            //consulta = serv.ConsultarCilindro();
            //se le debe cambia la instancia cilindro por el nombre de la instancia del servicio
            //TxtAno.Text = cilindro.Ano;
            //TxtEmpresa.Text = cilindro.Fabricante.Nombre_Fabricante;
            //TxtCodigo.Text = cilindro.Serial_Cilindro;
            //TxtUbicacion.Text = cilindro.Tipo_Ubicacion.Nombre_Ubicacion;
            //TxtTamano.Text = cilindro.NTamano.Tamano;
            //LblTotal.Text = cilindro.Codigo_Cilindro;
            //TxtRegistro.Text = Convert.ToString((cilindro.Fecha));

            DivDatosCilindro.Visible = true;
            BtnNuevaConsulta.Visible = true;


            if (TxtUbicacion.Text == "Vehiculo")
            {
                //TxtPlaca.Text = cilindro.Vehiculo.Placa;
                //TxtConductor.Text = cilindro.Vehiculo.Conductor_Vehiculo.Conductor.Nombres_Conductor;
                //TxtRuta.Text = cilindro.Vehiculo.Ruta.Nombre_Ruta;

                DivInfoVehiculo.Visible = true;
            }

            if (TxtUbicacion.Text == "Cliente")
            {

               // se le debe cambia la instancia venta por el nombre de la instancia del servicio
                //txtCedula.Text = cilindro.Venta.Cliente.Cedula;
                //TxtNombreCliente.Text = cilindro.Venta.Cliente.Nombres_Cliente;
                //TxtPrimerApellido.Text = cilindro.Venta.Cliente.Apellido_1;
                //TxtSegundoApellido.Text = cilindro.Venta.Cliente.Apellido_2;
                //TxtDireccion.Text = cilindro.Venta.Cliente.Ubicacion.Direccion;
                //TxtBarrio.Text = cilindro.Venta.Cliente.Ubicacion.Barrio;
                //TxtCiudad.Text = cilindro.Venta.Cliente.Ciudad.Nombre_Ciudad;
                //TxtDepartamento.Text = cilindro.Venta.Cliente.Ciudad.Departamento.Nombre_Departamento;
                //TxtTelefono.Text = cilindro.Venta.Cliente.Ubicacion.Telefono_1;
                //Txtentrega.Text = Convert.ToString(cilindro.Venta.Fecha);

                DivInfoCilindro.Visible = true;
            }

        }

        protected void BtnNuevaConsulta_Click(object sender, EventArgs e)
        {
            DivDatosCilindro.Visible = false;
            DivInfoCilindro.Visible = false;
        }

        protected void BtnMenuPrincipal_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }

        protected void BtnMenuPrincipal_Click1(object sender, EventArgs e)
        {

        }




    }
}