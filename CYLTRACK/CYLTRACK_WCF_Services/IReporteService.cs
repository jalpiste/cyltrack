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
    public interface IReporteService
    {
        /// <summary>
        /// Método encargado de la consulta del historico de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="reporte">Objeto de negocio reporte</param>
        /// <returns>código del cilindro</returns>
        [OperationContract]
        List<ReportesBE> HistoricoCilindro(string reporte);

        /// <summary>
        /// Método encargado de la consulta del inventario de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="reporte">Objeto de negocio reporte</param>
        [OperationContract]
        List<ReportesBE> Inventario(ReportesBE reporte);

        /// <summary>
        /// Método encargado de la consulta de ciudades en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ruta">Objeto de negocio ciudad</param> 
        /// <returns>nombre de ciudades cantidad de cilindros</returns>
        [OperationContract]
        List<UbicacionBE> ConsultaReporteCiudades(string ciudad);

        /// <summary>
        /// Método encargado de la consulta de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>código cilindro</returns>
        [OperationContract]
        List<CilindroBE> ReporteCilindro();
        
        
        /// <summary>
        /// Método encargado de la consulta de placas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio placas</param>
        /// <returns>cantidad cilindros por placas</returns>
        [OperationContract]
        List<UbicacionBE> ReporteporPlacas();
    }
}
