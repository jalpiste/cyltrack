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
    [ServiceContract(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    /// <summary>
    /// Interface que contiene la agrupación de métodos para la implementación del servicio.
    /// </summary>
    public interface ICilindroService
    {
        /// <summary>
        /// Método encargado del registro de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>código cilindro</returns>
        [OperationContract]
        long RegistrarCilindro(CilindroBE cilindro);

        /// <summary>
        /// Método encargado de la consulta de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>código cilindro</returns>
        [OperationContract]
        CilindroBE ConsultarCilindro(string cilindro);


        /// <summary>
        /// Método encargado de la consulta de cilindros de una ubicacion especifica en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>código cilindro</returns>
        [OperationContract]
        List<Ubicacion_CilindroBE> ConsultarCilUbicacion(string ubicacionCil);

        /// <summary>
        /// Método encargado del cambio de ubicacion de los cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objetos de negocio cilindro</param>
        /// <returns>respuesta operacion</returns>
        [OperationContract]
        long ModificarUbicaCilindro(CilindroBE cilindros);

        /// <summary>
        /// Método encargado de la consulta de existencia de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objetos de negocio cilindro</param>
        /// <returns>codigo</returns>
        [OperationContract]
        long ConsultarExistenciaCilindro(string cilindro);

        /// <summary>
        /// Método encargado de la consulta de la existencia de codigos de fabricantes en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objetos de negocio cilindro</param>
        /// <returns>codigo</returns>
        [OperationContract]
        long consultaCodigoFabricante(string codigoFabricante);
    }
}
