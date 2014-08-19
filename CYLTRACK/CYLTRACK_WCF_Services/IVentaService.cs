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
        /// <returns>Identificador de la venta</returns>
        [OperationContract]
        long RegistrarVenta(VentaBE ventas);

        /// <summary>
        /// Método encargado de la consulta de existencia de ventas de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cédula cliente,código pedido">cedula, codigo_pedido</param>
        /// <returns>identificador venta</returns>
        [OperationContract]
        long ConsultarExistenciaVenta(string ventas);

        /// <summary>
        /// Método encargado de la consulta de ventas de cilindros en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="cédula,codigoVenta">cédula del cliente o código venta</param>
        /// <returns>Objeto de negocio venta</returns>
        [OperationContract]
        VentaBE ConsultarVenta(string datoConsulta);

        /// <summary>
        /// Método encargado de la revisión de casos especiales en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ventas">Objeto de negocio ventas</param>
        /// <returns></returns>
        [OperationContract]
        List<CasosBE> RevisionCasosEspeciales(string casos);

        /// <summary>
        /// Método encargado del registro de casos especiales en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="ventas">Objeto de negocio ventas</param>
        /// <returns>cédula del cliente</returns>
        [OperationContract]
        long CasosEspeciales(CasosBE casos);

        /// <summary>
        /// Método encargado de la modificacion de ventas en el sistema. Permite
        /// que las aplicaciones llamen a los objetos de negocio directamente.
        /// </summary>
        /// <param name="objeto ventas">Objeto de negocio ventas</param>
        /// <returns>identificador detalleventas</returns>
        [OperationContract]
        long ModificarVenta(Detalle_VentaBE detVenta);

    }
}
