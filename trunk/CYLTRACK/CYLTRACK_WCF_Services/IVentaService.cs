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
    public interface IVentaService
    {
        /// <summary>
        /// Método encargado del registro de ventas de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ventas">Objeto de negocio ventas</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        String VentaCilindro(VentaBE ventas);

        /// <summary>
        /// Método encargado de la consulta de ventas de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ventas">Objeto de negocio ventas</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        List<VentaBE> ConsultarVenta(VentaBE ventas);

        /// <summary>
        /// Método encargado de la revisión de casos especiales en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ventas">Objeto de negocio ventas</param>
        /// <returns></returns>
        [OperationContract]
        List<CasosBE> RevisionCasosEspeciales(CasosBE casos);

        /// <summary>
        /// Método encargado del registro de casos especiales en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ventas">Objeto de negocio ventas</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        String CasosEspeciales(CasosBE casos);

    }
}
