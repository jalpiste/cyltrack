/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Derechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;



namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class CilindroBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        /// <summary>
        /// Método para el registro de cilindros en el sistema
        /// </summary>
        /// <param name="cilindro"></param>
        /// <returns></returns>
        public String CrearCilindro(CilindroBE cilindro)
        {
            String resp = "Ok";
            return resp;
        }
        
        public List<CilindroBE> ConsultarCilindro()
        {
            List<CilindroBE> lstCil = new List<CilindroBE>();
            CilindroBE cil = new CilindroBE();
            cil.Ano = "2012";
            //cil.Fabricante.Nombre_Fabricante = "Cilgas";
            cil.Serial_Cilindro = "51954";
            //cil.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = "Plataforma";
            //cil.NTamano.Tamano = "30";
            cil.Codigo_Cilindro = "12091751964";
            cil.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //--------------------------------
            //cil.Venta.Cliente.Cedula = "7309877";
            //cil.Venta.Cliente.Nombres_Cliente = "Jaime Andres";
            //cil.Venta.Cliente.Apellido_1 = "Ortiz";
            //cil.Venta.Cliente.Apellido_2 = "León";
            //cil.Venta.Cliente.Ubicacion.Direccion = "Calle 3 N 2-49";
            //cil.Venta.Cliente.Ubicacion.Barrio = "El Bosque";
            //cil.Venta.Cliente.Ciudad.Nombre_Ciudad = "Chiquinquirá";
            //cil.Venta.Cliente.Ciudad.Departamento.Nombre_Departamento = "Boyacá";
            //cil.Venta.Cliente.Ubicacion.Telefono_1 = "7266530";
            //cil.Venta.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //-----------------------------
            //cil.Vehiculo.Placa = "XHA940";
            //cil.Vehiculo.Conductor_Vehiculo.Conductor.Nombres_Conductor = "Juanito perez";
            //cil.Vehiculo.Ruta.Nombre_Ruta = "Chiquinquirá-Ubaté";
            
            lstCil.Add(cil);
            return lstCil;
        }

        public String AsignarUbicacion(CilindroBE cilindro)
        {
            return "Ok";
        }

        public List<CilindroBE> CargueyDescargueCilindro(CilindroBE cilindro)
        {
            List<CilindroBE> lstCod = new List<CilindroBE>();
            CilindroBE cil = new CilindroBE();
            //cargue de cilindros
            cil.Codigo_Cilindro = "87867675675";
            cil.Codigo_Cilindro = "74875738658";

            return lstCod;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
