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
    /// <summary>
    /// Interface que contiene la agrupación de métodos para la implementación del servicio.
    /// </summary>
    [ServiceContract(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public interface IRutaServices
    {
        /// <summary>
        /// Método encargado del registro de rutas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ruta">Objeto de negocio ruta</param>
        /// <returns>nombre de la ruta</returns>
        [OperationContract]
        long RegistrarRuta(RutaBE ruta);

        /// <summary>
        /// Método encargado de la modificaciòn de rutas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ruta">Objeto de negocio ruta</param> 
        /// <returns>nombre de la ruta</returns>
        [OperationContract]
        long ModificarRuta(RutaBE ruta);
        
        /// <summary>
        /// Método encargado de la consulta de rutas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ruta">Objeto de negocio ruta</param> 
        /// <returns>nombre de la ruta</returns>
        [OperationContract]
        List<RutaBE> ConsultarRuta(string ruta);


        /// <summary>
        /// Método encargado de la consulta de rutas por placas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="placa y ciudad">Objeto de negocio ruta_vehiculo</param> 
        /// <returns>Objeto Ruta</returns>
        [OperationContract]
        RutaBE ConsultarRutaPorPlaca(Ruta_VehiculoBE rutaVehiculo);

        /// <summary>
        /// Método encargado de la consulta de los departamentos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name=""></param> 
        /// <returns>lista de objetos departamentos</returns>
        [OperationContract]
        List<DepartamentoBE> ConsultaDepartamento();

                /// <summary>
        /// Método encargado de la consulta de ciudades  en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="id_departamento">identificador departamento</param> 
        /// <returns>lista de objetos ciudades</returns>
        [OperationContract]
        List<CiudadBE> ConsultaCiudades(string id_dep);

        /// <summary>
        /// Método encargado de la consulta de existencia de rutas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ruta">Objeto de negocio ciudad</param> 
        /// <returns>existencia de ruta</returns>
        [OperationContract]
        long ConsultaExistenciaRuta(string ruta);

        
    }
}
