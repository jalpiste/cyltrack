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
    [ServiceContract(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public interface IVehiculoService
    {
        /// <summary>
        /// Método encargado del registro de vehículos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="registrar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>placa vehículo</returns>
        [OperationContract]
        String Registrar_Vehiculo(VehiculoBE vehiculo);

        /// <summary>
        /// Método encargado de la consulta de vehículos en el sistema y su posterior impresión en los controles de texto.
        /// Permite que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="consultar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>Objeto vehículo</returns>
        [OperationContract]
        List<VehiculoBE> ConsultarVehiculo(string placa);

        ///// <summary>
        ///// Método encargado de la consulta de vehículos en el sistema y su posterior impresión en los controles de texto.
        ///// Permite que las aplicaciones llamen a los objetos de negocio directamente.
        ///// </summary>
        ///// <param name="consultar_vehiculo">Objeto de negocio vehículo</param>
        ///// <returns>placa vehículo</returns>
        //[OperationContract]
        //VehiculoBE Consultar_Vehiculo(string vehiculo);

        /// <summary>
        /// Método encargado de la consulta para la confirmación de existencia de vehículo en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        [OperationContract]
        string Consultar_Existencia(string consultar_existencia);

        /// <summary>
        /// Método encargado de la modificación de vehículos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="modificar_vehiculo">Objeto de negocio vehículo</param>
        /// <returns>placa vehículo</returns>
        [OperationContract]
        string Modificar_Vehiculo(string vehiculo);

        /// <summary>
        /// Método encargado de la consulta de conductor del vehículo en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="consultar_conductor">Objeto de negocio vehículo</param>
        /// <returns>cédula conductor</returns>
        [OperationContract]
        VehiculoBE Consultar_Conductor(string conductor);

        /////// <summary>
        /////// Método encargado de la consulta de placas de vehiculos en el sistema. Permite
        /////// que las aplicaciones llamen a los objetos de negocio directamente.
        /////// </summary>
        /////// <param name="ruta">Objeto de negocio ciudad</param> 
        /////// <returns>Placas registradas</returns>
        ////[OperationContract]
        ////List<string> ConsultarPlacaSinParametro();

        ///// <summary>
        ///// Método encargado de la consulta de placas de vehiculos en el sistema. Permite
        ///// que las aplicaciones llamen a los objetos de negocio directamente.
        ///// </summary>
        ///// <param name="ruta">Objeto de negocio ciudad</param> 
        ///// <returns>Placas registradas</returns>
        //[OperationContract]
        //List<string> ConsultarPlaca(string ciudad);
    }
}
