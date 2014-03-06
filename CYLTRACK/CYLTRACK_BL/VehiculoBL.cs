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
using Unisangil.CYLTRACK.CYLTRACK_DL;

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
        public List<VehiculoBE> ConsultarVehiculo(string placa)
        {
            VehiculoDL veh = new VehiculoDL();
            List<VehiculoBE> vehiculo = new List<VehiculoBE>();
            try
            {
                vehiculo = veh.ConsultarPlacasVehiculos(placa);
            }
            catch (Exception ex)
            {

            }
            return vehiculo;
        }

        /// <summary>
        /// Método para la modificación de vehículos en el sistema
        /// </summary>
        /// <param name="modificar_vehiculo"></param>
        /// <returns></returns>
        public string ModificarVehiculo(string modificar_vehiculo)
        {
            //VehiculoBE consulta = ConsultarVehiculo(modificar_vehiculo);
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
