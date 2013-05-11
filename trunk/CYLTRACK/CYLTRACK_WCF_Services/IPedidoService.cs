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
    [ServiceContract]
    public interface IPedidoService
    {
        /// <summary>
        /// Método encargado del registro de pedidos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="registrar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        String Registrar_Pedido(PedidoBE registrar_ped);

        /// <summary>
        /// Método encargado de la consulta de pedidos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="consultar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente,código pedido</returns>
        [OperationContract]
        List<PedidoBE> Consultar_Pedido(PedidoBE consultar_ped);

        /// <summary>
        /// Método encargado de la modificación de pedidos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="consultar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente,código pedido</returns>
        [OperationContract]
        String Modificar_Pedido(PedidoBE modificar_ped);

        /// <summary>
        /// Método encargado de la cancelación de pedidos en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cancelar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente,código pedido</returns>
        [OperationContract]
        String Cancelar_Pedido(PedidoBE cancelar_ped);
    }
}
