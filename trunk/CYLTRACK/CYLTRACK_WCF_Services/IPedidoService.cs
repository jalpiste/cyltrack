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
using System.Runtime.Serialization;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPedidoService" en el código y en el archivo de configuración a la vez.
    /// <summary>
    /// Interface que contiene la agrupación de métodos para la implementación del servicio.
    /// </summary>
    [ServiceContract(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public interface IPedidoService
    {
        /// <summary>
        /// Método encargado del registro de pedidos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="pedido">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        string Registrar_Pedido(PedidoBE pedido);

        /// <summary>
        /// Método encargado de la consulta de pedidos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="pedido">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        PedidoBE Consultar_Pedido(string pedido);

        /// <summary>
        /// Método encargado de la consulta para la confirmación de existencia de pedido o conductores en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        [OperationContract]
        string Consultar_Existencia(string consultar_existencia);

        /// <summary>
        /// Método encargado de la modificación de pedidos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="pedido">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente,código pedido</returns>
        [OperationContract]
        string Modificar_Pedido(string pedido);

        /// <summary>
        /// Método encargado de la cancelación de pedidos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="pedido">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente,código pedido</returns>
        [OperationContract]
        string Cancelar_Pedido(string pedido);
    }
}
