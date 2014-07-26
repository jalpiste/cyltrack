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
        /// <param name="vehiculo">Objeto de negocio vehículo</param>
        /// <returns>Placa del vehículo</returns>
        public long Registrar_Vehiculo(VehiculoBE vehiculo)
        {
            long resp;
            VehiculoBL RegisVehiculo = new VehiculoBL();
            resp = RegisVehiculo.CrearVehiculo(vehiculo);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un vehículo de los canales front de venta y llamar
        /// al metodo de negocio para consultar un vehículo
        /// </summary>
        /// <param name="placa">Placa del Vehículo</param>
        /// <returns>Lista con Objetos de negocio de Vehiculo</returns>
        public List<VehiculoBE> ConsultarVehiculo(string placa)
        {
            VehiculoBL consultarVehiculo = new VehiculoBL();
            return consultarVehiculo.ConsultarVehiculo(placa);
        }

        /// <summary>
        /// Encargado de recibir la confirmación de existencia de vehículo de los canales front de venta y llamar
        /// al metodo de negocio para consultar la existencia de un vehículo
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        public long ConsultarExistenciaVehiculo(string placa)
        {
            long resp;
            VehiculoBL ConExisVehiculo = new VehiculoBL();
            resp = ConExisVehiculo.ConsultaExistenciaVehiculo(placa);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la ubicacion de los canales front de venta y llamar
        /// al metodo de negocio para la consulta de cilindros en dicha ubicacion
        /// </summary>
        /// <param name="idVehiculo">Objeto de negocio cilindro</param>
        /// <returns>Códigos de Cilindros</returns>
        public List<Ubicacion_CilindroBE> ConsultarCilPorVehiculo(string idVehiculo)
        {
            List<Ubicacion_CilindroBE> resp;
            VehiculoBL consultaCilVeh = new VehiculoBL();
            resp = consultaCilVeh.ConsultarCilPorVehiculo(idVehiculo);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir la confirmación de existencia de contratista de los canales front de venta y llamar
        /// al metodo de negocio para consultar la existencia de un contratista
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        public long ConsultarExistenciaContratista(string cedula)
        {
            long resp;
            VehiculoBL ConExisContratista = new VehiculoBL();
            resp = ConExisContratista.ConsultaExistenciaContratista(cedula);
            return resp;
        }


        /// <summary>
        /// Encargado de recibir la cedula del conductor de los canales front de venta y llamar
        /// al metodo de negocio para consultar la existencia de un conductor
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public long ConsultarExistenciaConductor(string cedula)
        {
            long resp;
            VehiculoBL ConExisConductor = new VehiculoBL();
            resp = ConExisConductor.ConsultaExistenciaConductor(cedula);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un vehículo de los canales front de venta y llamar
        /// al metodo de negocio para modificar un vehículo
        /// </summary>
        /// <param name="modificar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>IDENTITY</returns>
        public long Modificar_Vehiculo(VehiculoBE modificar_vehiculo)
        {
            long resp;
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
        public ConductorBE Consultar_Conductor(string cedula)
        {
            ConductorBE resp;
            VehiculoBL ConConductor = new VehiculoBL();
            resp = ConConductor.ConsultarConductor(cedula);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la cedula del propietario del vehiculo de los canales front de venta y llamar
        /// al metodo de negocio para consultar un propietario
        /// </summary>
        /// <param name="consultarPropVehiculo">cédula propietario</param>
        /// <returns>objeto de negocio vehiculo</returns>
        public ContratistaBE ConsultarPropVehiculo(string cedula)
        {
            ContratistaBE resp;
            VehiculoBL consultaPropietarioV = new VehiculoBL();
            resp = consultaPropietarioV.ConsultarPropVehiculo(cedula);
            return resp;
        }


        /// <summary>
        /// Encargado de recibir un conductor de los canales front de venta y llamar
        /// al metodo de negocio para crear un registrar conductor
        /// </summary>
        /// <param name="conductor">Objeto de negocio conductor</param>
        /// <returns>Objeto Conductor</returns>
        public long RegistrarConductor(ConductorBE conductor)
        {
            long resp;
            VehiculoBL RegisConductor = new VehiculoBL();
            resp = RegisConductor.RegistrarConductor(conductor);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un contratista de los canales front de venta y llamar
        /// al metodo de negocio para crear un registrar contratista
        /// </summary>
        /// <param name="conductor">Objeto de negocio contratista</param>
        /// <returns>identity</returns>
        public long RegistrarContratista(ContratistaBE contratista)
        {
            long resp;
            VehiculoBL RegisContratista = new VehiculoBL();
            resp = RegisContratista.RegistrarContratista(contratista);
            return resp;
        }
    }
}
