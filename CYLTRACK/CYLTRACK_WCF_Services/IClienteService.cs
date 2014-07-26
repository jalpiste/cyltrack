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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClienteService" en el código y en el archivo de configuración a la vez.
    [ServiceContract(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    /// <summary>
    /// Interface que contiene la agrupación de métodos para la implementación del servicio.
    /// </summary>
    public interface IClienteService
    {
        /// <summary>
        /// Método encargado del registro de clientes en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cliente">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        long Registrar_Cliente(ClienteBE cliente);

        /// <summary>
        /// Método encargado del registro una nueva ubicacón de clientes en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ubicacion">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        long Agregar_Ubicacion(ClienteBE cliente);

        /// <summary>
        /// Método encargado de la consulta de clientes en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cliente">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        ClienteBE Consultar_Cliente(string cliente);

        /// <summary>
        /// Método encargado de la modificación de la direccion de clientes en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="Ubicacion">Objeto de negocio ubicacion</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        long ModificarDirCliente(UbicacionBE ubicacion);

        /// <summary>
        /// Método encargado de la modificación de los nombres de clientes en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cliente">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        long ModificarNombreCliente(ClienteBE cliente);

        /// <summary>
        /// Método encargado de la consulta de cilindros de un cliente en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cliente">Identificador del cliente</param>
        /// <returns>Lista de Objetos con códigos cilindro</returns>
        [OperationContract]
        List<Ubicacion_CilindroBE> ConsultarCilPorCliente(string idCliente);

        /// <summary>
        /// Método encargado de la consulta de direcciones de un cliente en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="idUbicacion">Identificador de la ubicación</param>
        /// <returns>Objetos Ubicacion</returns>
        [OperationContract]
        UbicacionBE ConsultarDirCliPorUbica(string idUbica);

        /// <summary>
        /// Método encargado de la consulta de existencia de clientes en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cliente">Objeto de negocio cliente</param>
        /// <returns>código</returns>
        [OperationContract]
        long ConsultarExistenciasClientes(string cliente);
    }

}
