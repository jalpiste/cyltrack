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
        public String RegistrarVehiculo(VehiculoBE registrar_vehiculo)
        {
            String resp = "1";
            return resp;
        }
        /// <summary>
        /// Método para la consulta de vehículos en el sistema
        /// </summary>
        /// <param name="consultar_vehiculo"></param>
        /// <returns></returns>
        public List<VehiculoBE> ConsultarVehiculo(VehiculoBE consultar_vehiculo)
        {
            List<VehiculoBE> lstVehiculo = new List<VehiculoBE>();
            VehiculoBE vehiculo = new VehiculoBE();

            vehiculo.Placa = "XHA767";
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
            vehiculo.Ruta.Nombre_Ruta = "Chiquinquirá-Ubaté";

            lstVehiculo.Add(vehiculo);
            return lstVehiculo;
        }
        /// <summary>
        /// Método para la modificación de vehículos en el sistema
        /// </summary>
        /// <param name="modificar_vehiculo"></param>
        /// <returns></returns>
        public String ModificarVehiculo(VehiculoBE modificar_vehiculo)
        {
            List<VehiculoBE> consulta = ConsultarVehiculo(modificar_vehiculo);
            List<VehiculoBE> conductor = ConsultarConductor(modificar_vehiculo);
            String resp = "Vehículo Modificado";
            return resp;
        }
        /// <summary>
        /// Método para la consulta de conductores en el sistema
        /// </summary>
        /// <param name="consultar_conductor"></param>
        /// <returns></returns>
        public List<VehiculoBE> ConsultarConductor(VehiculoBE consultar_conductor)
        {
            List<VehiculoBE> lstConductor = new List<VehiculoBE>();
            VehiculoBE conductor = new VehiculoBE();

            conductor.Conductor_Vehiculo.Conductor.Cedula = "11242779";
            conductor.Conductor_Vehiculo.Conductor.Nombres_Conductor = "Daniel";
            conductor.Conductor_Vehiculo.Conductor.Apellido_1 = "López";
            conductor.Conductor_Vehiculo.Conductor.Apellido_2 = "Barinas";

            lstConductor.Add(conductor);
            return lstConductor;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
