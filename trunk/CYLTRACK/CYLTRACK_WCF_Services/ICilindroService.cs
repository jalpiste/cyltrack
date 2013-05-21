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
        String RegistrarCilindro(CilindroBE cilindro);


        /// <summary>
        /// Método encargado de la consulta de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>código cilindro</returns>
        [OperationContract]
        List<CilindroBE> ConsultarCilindro(CilindroBE cilindro);


        /// <summary>
        /// Método encargado de la asignación de ubicación de cilindros dentro de la planta en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>código cilindro</returns>
        [OperationContract]
        String AsignarUbicacion(CilindroBE cilindro);


        /// <summary>
        /// Método encargado del cargue y descargue de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>código cilindro</returns>
        [OperationContract]
        List<CilindroBE> CargueyDescargueCilindro(CilindroBE cilindro);

    }
}
