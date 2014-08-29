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
        /// <param name="reporte">código del cilindro</param>
        /// <returns>Objeto de negocio reporte</returns>
        [OperationContract]
        List<Ubicacion_CilindroBE> HistoricoCilindro(string codigo);


        /// <summary>
        /// Método encargado de la consulta de cilindros de una ubicacion especifica en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="reporte">Objeto de negocio reporte</param>
        /// <returns>Objeto cilindro</returns>
        [OperationContract]
        List<Ubicacion_CilindroBE> ConsultarCilInventario(ReportesBE reporte);

        /// <summary>
        /// Método encargado de la consulta de los tipos de ubicaciones de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <returns>listado de ubicaciones</returns>
        [OperationContract]
        IList<Tipo_UbicacionBE> ConsultaTipoUbicacion();

        /// <summary>
        /// Método encargado de la consulta de los tamaños de los cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <returns>listado de tamanos de los cilindros</returns>
        [OperationContract]
        List<TamanoBE> ConsultaTamanoCilindro();

        /// <summary>
        /// Método encargado de la consulta de la existencia de datos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="dato">Objeto de negocio </param>
        /// <returns>identificador</returns>
        [OperationContract]
        long consultadeExistencia(string dato);

        /// <summary>
        /// Método encargado de la consulta de los tipos de casos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <returns>listado de objetos de tipos de casos </returns>
        [OperationContract]
        List<Tipo_CasoBE> ConsultaTiposCasos();

        /// <summary>
        /// Método encargado de la consulta de reporte de siembras por ciudades en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="reporteBE">Objeto de negocio reporte </param>
        /// <returns>listado de objetos de cilindros </returns>
         [OperationContract]
        List<CilindroBE> ReporteSiembrasCiudad(ReportesBE reporte);


        /// <summary>
        /// Método encargado de la consulta de reporte de siembras por cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="reporteBE">Objeto de negocio reporte </param>
        /// <returns>listado de objetos de cilindros </returns>
         [OperationContract]
        List<CilindroBE> ReporteSiembrasCilindro(ReportesBE reporte);
    }
}
