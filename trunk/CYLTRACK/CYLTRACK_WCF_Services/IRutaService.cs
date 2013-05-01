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
    [ServiceContract]
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
        long ConsultarRuta(RutaBE ruta);
    }
}
