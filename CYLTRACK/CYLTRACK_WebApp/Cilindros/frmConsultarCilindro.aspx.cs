using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using CYLTRACK_WebApp.CilindroService;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros
{
    public partial class frmConsultarCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
                
        protected void txtCodigoCilindro_TextChanged(object sender, EventArgs e)
        {
            
            //cilindro.Codigo_Cilindro = txtCodigoCilindro.Text;

            
            CilindroServiceClient servCilindro = new CilindroServiceClient();
            
            //CilindroBE cilindro= new CilindroBE();
            CilindroBE [] consulta = servCilindro.ConsultarCilindro();

            var datos = from info in consulta
                         select info;

            foreach (CilindroBE info in datos)
            {
                TxtAno.Text = info.Ano;
                //TxtEmpresa.Text = info.Fabricante.Nombre_Fabricante;
                TxtCodigo.Text = info.Serial_Cilindro;
                //TxtUbicacion.Text = info.Tipo_Ubicacion.Nombre_Ubicacion;
                //TxtTamano.Text = info.NTamano.Tamano;
                LblTotal.Text = info.Codigo_Cilindro;
                TxtRegistro.Text = Convert.ToString((info.Fecha));
            }

            

            DivDatosCilindro.Visible = true;
            BtnNuevaConsulta.Visible = true;


            //if (TxtUbicacion.Text == "Vehiculo")
            //{
            //    //TxtPlaca.Text = cilindro.Vehiculo.Placa;
                //TxtConductor.Text = cilindro.Vehiculo.Conductor_Vehiculo.Conductor.Nombres_Conductor;
                //TxtRuta.Text = cilindro.Vehiculo.Ruta.Nombre_Ruta;

            //    DivInfoVehiculo.Visible = true;
            //}

            //if (TxtUbicacion.Text == "Cliente")
            //{

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

            //    DivInfoCilindro.Visible = true;
            //}

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