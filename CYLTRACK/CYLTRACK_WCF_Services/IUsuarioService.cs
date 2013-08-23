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
    public interface IUsuarioService
    {
        /// <summary>
        /// Método encargado del registro de usuarios en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="usuario">Objeto de negocio usuario</param>
        /// <returns>nombre de usuario</returns>
        [OperationContract]
        string RegistrarUsuario(UsuarioBE usuario);

        /// <summary>
        /// Método encargado de la consulta de cargos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <returns>nombre de los cargos</returns>
        [OperationContract]
        List<PerfilBE> ConsultarCargos();

        /// <summary>
        /// Método encargado del registro de usuarios en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="usuario">Objeto de negocio usuario</param>
        /// <returns>nombre de usuario</returns>
        [OperationContract]
        string ConsultarExistencia(string usuario);

        
        /// <summary>
        /// Método encargado de la autenticaciòn de usuarios en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="usuario">Objeto de negocio usuario</param>
        /// <returns>nombre de usuario</returns>
        [OperationContract]
        bool Autenticacion(UsuarioBE usuario);

        /// <summary>
        /// Método encargado de la recuperaciòn de contraseña de los usuarios en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="usuario">Objeto de negocio usuario</param>
        /// <returns>nombre de usuario</returns>
        [OperationContract]
        string RecuperarContrasena(string usuario);
    }
}
