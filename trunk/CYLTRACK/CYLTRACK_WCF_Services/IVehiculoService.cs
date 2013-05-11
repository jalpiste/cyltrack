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
using System.ServiceModel;
using Unisangil.CYLTRACK.CYLTRACK_BE;


namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{ 
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClienteService" en el código y en el archivo de configuración a la vez.
    /// <summary>
    /// Interface que contiene la agrupación de métodos para la implementación del servicio.
    /// </summary>
    [ServiceContract]
    public interface IVehiculoService
    {
        /// <summary>
        /// Método encargado del registro de vehículos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="registrar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>placa vehículo</returns>
        [OperationContract]
        String Registrar_Vehiculo(VehiculoBE registrar_vehiculo);

        /// <summary>
        /// Método encargado de la consulta de vehículos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="consultar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>placa vehículo</returns>
        [OperationContract]
        List<VehiculoBE> Consultar_Vehiculo(VehiculoBE consultar_vehiculo);

        /// <summary>
        /// Método encargado de la modificación de vehículos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="modificar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>placa vehículo</returns>
        [OperationContract]
        String Modificar_Vehiculo(VehiculoBE modificar_vehiculo);

        /// <summary>
        /// Método encargado de la consulta de conductor del vehículo en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="consultar_conductor">Objeto de negocio vehículo</param>
        /// <returns>cédula conductor</returns>
        [OperationContract]
        List<VehiculoBE> Consultar_Conductor(VehiculoBE consultar_conductor);

    }
}
