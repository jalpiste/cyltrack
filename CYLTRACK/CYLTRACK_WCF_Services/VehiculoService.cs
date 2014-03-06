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
    [ServiceBehavior(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public class VehiculoService : IVehiculoService
    {
        /// <summary>
        /// Encargado de recibir un vehículo de los canales front de venta y llamar
        /// al metodo de negocio para crear un registrar vehículo
        /// </summary>
        /// <param name="registrar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>Placa del vehículo</returns>
        public string Registrar_Vehiculo(VehiculoBE registrar_vehiculo)
        {
            String resp;
            VehiculoBL RegisVehiculo = new VehiculoBL();
            resp = RegisVehiculo.RegistrarVehiculo(registrar_vehiculo);
            return resp;
        }

        public List<VehiculoBE> ConsultarVehiculo(string placa)
        {
            VehiculoBL consultarVehiculo = new VehiculoBL();
            return consultarVehiculo.ConsultarVehiculo(placa);
        }
        ///// <summary>
        ///// Encargado de recibir un vehículo de los canales front de venta y llamar
        ///// al metodo de negocio para consultar un vehículo
        ///// </summary>
        ///// <param name="consultar_vehiculo">Objeto de negocio vehículo</param>
        ///// <returns>Placa del vehículo</returns>
        //public VehiculoBE Consultar_Vehiculo(string consultar_vehiculo)
        //{
        //    VehiculoBE resp;
        //    VehiculoBL ConVehiculo = new VehiculoBL();
        //    resp = ConVehiculo.ConsultarVehiculo(consultar_vehiculo);
        //    return resp;
        //}
        /// <summary>
        /// Encargado de recibir la confirmación de existencia de vehículo de los canales front de venta y llamar
        /// al metodo de negocio para consultar la existencia de un vehículo
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        public string Consultar_Existencia(string consultar_existencia)
        {
            String resp;
            VehiculoBL ConExis = new VehiculoBL();
            resp = ConExis.ConsultarExistencia(consultar_existencia);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir un vehículo de los canales front de venta y llamar
        /// al metodo de negocio para modificar un vehículo
        /// </summary>
        /// <param name="modificar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>Placa del vehículo</returns>
        public string Modificar_Vehiculo(string modificar_vehiculo)
        {
            String resp;
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
        public VehiculoBE Consultar_Conductor(string consultar_conductor)
        {
            VehiculoBE resp;
            VehiculoBL ConConductor = new VehiculoBL();
            resp = ConConductor.ConsultarConductor(consultar_conductor);
            return resp;
        }

        //////<summary>
        //////Encargado de  llamar
        //////al metodo de negocio para consultar placas
        //////</summary>
        //////<param name="ruta">placa</param>
        //////<returns>placas de vehiculos</returns>
        //////public List<string> ConsultarPlaca(string ciudad)
        //////{
        //////    List<string> resp;
        //////    VehiculoBL consultarPlacas = new VehiculoBL();
        //////    resp = consultarPlacas.ConsultarPlacas(ciudad);
        //////    return resp;
        //////}

        /////<summary>
        /////Encargado de  llamar
        /////al metodo de negocio para consultar placas
        /////</summary>
        /////<param name="ruta">placa</param>
        /////<returns>placas de vehiculos</returns>
        //public List<string> ConsultarPlacaSinParametro()
        //{
        //    List<string> resp;
        //    VehiculoBL consultarPlacas = new VehiculoBL();
        //    resp = consultarPlacas.ConsultarPlacasSinParametro();
        //    return resp;
        //}
    }
}
