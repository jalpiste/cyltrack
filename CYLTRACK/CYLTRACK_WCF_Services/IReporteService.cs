﻿/*
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
        List<UbicacionBE> ConsultaReporteCiudades(string ciudad, string tipoCil);

        /// <summary>
        /// Método encargado de la consulta de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>código cilindro</returns>
        [OperationContract]
        List<CilindroBE> ReporteCilindro(string tipoCil);
        
        
        /// <summary>
        /// Método encargado de la consulta de placas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio placas</param>
        /// <returns>cantidad cilindros por placas</returns>
        [OperationContract]
        List<UbicacionBE> ReporteporPlacas(string tipoCil);

        /// <summary>
        /// Método encargado de la consulta de placas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio placas</param>
        /// <returns>cantidad cilindros por placas</returns>
        [OperationContract]
        List<ClienteBE> ReporteClientes();

        /// <summary>
        /// Método encargado de la consulta de pedidos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <returns>listado de pedidos</returns>
        [OperationContract]
        List<PedidoBE> ReportePedidos();

        /// <summary>
        /// Método encargado de la consulta de rutas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ruta">Objeto de negocio ruta</param> 
        /// <returns>nombre de la ruta</returns>
        [OperationContract]
        List<RutaBE> ConsultarRuta();

        /// <summary>
        /// Método encargado de la consulta de usuarios en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <returns>listado de usuarios</returns>
        [OperationContract]
        List<UsuarioBE> ReporteUsuario();

        /// <summary>
        /// Método encargado de la consulta de los tipos de ubicaciones de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <returns>listado de ubicaciones</returns>
        [OperationContract]
        List<Tipo_UbicacionBE> ConsultaTipoUbicacion();

        /// <summary>
        /// Método encargado de la consulta de los tamaños de los cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <returns>listado de tamanos de los cilindros</returns>
        [OperationContract]
        List<TamanoBE> ConsultaTamanoCilindro();
    }
}
