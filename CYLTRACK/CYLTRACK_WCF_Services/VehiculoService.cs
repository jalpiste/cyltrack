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
using Unisangil.CYLTRACK.CYLTRACK_BL;
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    /// <summary>
    /// Clase que implementa el contrato de servicio.
    /// </summary>
    public class VehiculoService : IVehiculoService
    {
        /// <summary>
        /// Encargado de recibir un vehículo de los canales front de venta y llamar
        /// al metodo de negocio para crear un registrar vehículo
        /// </summary>
        /// <param name="registrar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>Placa del vehículo</returns>
        public long Registrar_Vehiculo(VehiculoBE registrar_vehiculo)
        {
            long resp = 0;
            VehiculoBL RegisVehiculo = new VehiculoBL();
            resp = RegisVehiculo.RegistrarVehiculo(registrar_vehiculo);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir un vehículo de los canales front de venta y llamar
        /// al metodo de negocio para consultar un vehículo
        /// </summary>
        /// <param name="consultar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>Placa del vehículo</returns>
        public long Consultar_Vehiculo(VehiculoBE consultar_vehiculo)
        {
            long resp = 0;
            VehiculoBL ConVehiculo = new VehiculoBL();
            resp = ConVehiculo.ConsultarVehiculo(consultar_vehiculo);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir un vehículo de los canales front de venta y llamar
        /// al metodo de negocio para modificar un vehículo
        /// </summary>
        /// <param name="modificar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>Placa del vehículo</returns>
        public long Modificar_Vehiculo(VehiculoBE modificar_vehiculo)
        {
            long resp = 0;
            VehiculoBL ModVehiculo = new VehiculoBL();
            resp = ModVehiculo.ModificarVehiculo(modificar_vehiculo);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir un conductor de los canales front de venta y llamar
        /// al metodo de negocio para consultar un vehículo
        /// </summary>
        /// <param name="consultar_conductor">Objeto de negocio vehículo</param>
        /// <returns>cedula conductor</returns>
        public long Consultar_Conductor(VehiculoBE consultar_conductor)
        {
            long resp = 0;
            VehiculoBL ConConductor = new VehiculoBL();
            resp = ConConductor.ConsultarConductor(consultar_conductor);
            return resp;
        }
    }
}
