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
    public class VehiculoBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        /// <summary>
        /// Método para el registro de vehículos en el sistema
        /// </summary>
        /// <param name="registrar_vehiculo"></param>
        /// <returns></returns>
        public string RegistrarVehiculo(VehiculoBE registrar_vehiculo)
        {
            String resp = "Ok";
            return resp;
        }
        /// <summary>
        /// Método para la consulta de existencia de vehículos en el sistema 
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        public string ConsultarExistencia(string consultar_existencia)
        {
            string resp = "Ok";
            return resp;
        }
        /// <summary>
        /// Método para la consulta de vehículos en el sistema y muestra de información
        /// </summary>
        /// <param name="consultar_vehiculo"></param>
        /// <returns></returns>
        public VehiculoBE ConsultarVehiculo(string consultar_vehiculo)
        {
            VehiculoBE vehiculo = new VehiculoBE();
            vehiculo.Placa = "XHA098";
            vehiculo.Marca = "Kia";
            vehiculo.Cilindraje = "2800";
            vehiculo.Modelo = "2010";
            vehiculo.Motor = "ODJGDSJ335252VVDS";
            vehiculo.Chasis = "ODJGDSJ335252VVDS111";
            //--------------------------------
            vehiculo.Ced_Prop = "7320591";
            vehiculo.Nombres_Prop = "Cristobal";
            vehiculo.Apellido_1_Prop = "Colón";
            vehiculo.Apellido_2_Prop = "Mendieta";
            //--------------------------------
            Conductor_VehiculoBE cond = new Conductor_VehiculoBE();
            vehiculo.Conductor_Vehiculo = cond;

            ConductorBE conductor = new ConductorBE();
            conductor.Cedula = "19080347";
            conductor.Nombres_Conductor = "Pablo";
            conductor.Apellido_1 = "Pérez";
            conductor.Apellido_2 = "Pinto";
            cond.Conductor = conductor;

            RutaBE ruta = new RutaBE();
            ruta.Nombre_Ruta = "Chiquinquirá-Boyacá";
            vehiculo.Ruta = ruta;
            //--------------------------------

            return vehiculo;
        }

        public List<string> ConsultarPlacas(string ciudad)
        {
            List<string> lstPlacas = new List<string>();
            string[] letras = new string[] { "A", "R", "J", "L", "P", "V" };
            Random ran = new Random();

            for (int i = 0; i < 5; i++)
            {
                lstPlacas.Add( letras[i] + "" + letras[i] + "" + letras[i] + "" + ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString());
            }
            return lstPlacas;
        }
        /// <summary>
        /// Método para la modificación de vehículos en el sistema
        /// </summary>
        /// <param name="modificar_vehiculo"></param>
        /// <returns></returns>
        public string ModificarVehiculo(string modificar_vehiculo)
        {
            VehiculoBE consulta = ConsultarVehiculo(modificar_vehiculo);
            VehiculoBE conductor = ConsultarConductor(modificar_vehiculo);
            String resp = "Ok";
            return resp;
        }
        /// <summary>
        /// Método para la consulta de conductores en el sistema
        /// </summary>
        /// <param name="consultar_conductor"></param>
        /// <returns></returns>
        public VehiculoBE ConsultarConductor(string consultar_conductor)
        {
            
            VehiculoBE conductor = new VehiculoBE();


            Conductor_VehiculoBE cond_veh = new Conductor_VehiculoBE();
            conductor.Conductor_Vehiculo = cond_veh;

            ConductorBE cond = new ConductorBE();
            cond.Cedula = "11242779";
            cond.Nombres_Conductor = "Daniel";
            cond.Apellido_1 = "López";
            cond.Apellido_2 = "Barinas";
            cond_veh.Conductor = cond;

            return conductor;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
