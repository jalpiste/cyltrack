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
using Unisangil.CYLTRACK.CYLTRACK_BE;
using Unisangil.CYLTRACK.CYLTRACK_BL;
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    /// <summary>
    /// Clase creada para implementar el contrato de servicio de la interfaz.
    /// </summary>
    public class PedidoService : IPedidoService 
    {
        /// <summary>
        /// Encargado de recibir un pedido de los canales front de venta y llamar
        /// al metodo de negocio para crear un pedido de cilindro
        /// </summary>
        /// <param name="registrar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente</returns>
        public long Registrar_Pedido(PedidoBE registrar_ped)
        {
            long resp = 0;
            PedidoBL regisPedido = new PedidoBL();
            resp = regisPedido.RegistrarPedido(registrar_ped);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir un pedido de los canales front de venta y llamar
        /// al metodo de negocio para consultar un pedido de cilindro
        /// </summary>
        /// <param name="consultar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente</returns>
        public long Consultar_Pedido(PedidoBE consultar_ped)
        {
            long resp = 0;
            PedidoBL ConPedido = new PedidoBL();
            resp = ConPedido.ConsultarPedido(consultar_ped);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir un pedido de los canales front de venta y llamar
        /// al metodo de negocio para modificar un pedido de cilindro
        /// </summary>
        /// <param name="modificar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente</returns>
        public long Modificar_Pedido(PedidoBE modificar_ped)
        {
            long resp = 0;
            PedidoBL ModPedido = new PedidoBL();
            resp = ModPedido.ModificarPedido(modificar_ped);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir un pedido de los canales front de venta y llamar
        /// al metodo de negocio para modificar un pedido de cilindro
        /// </summary>
        /// <param name="cancelar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente</returns>
        public long Cancelar_Pedido(PedidoBE cancelar_ped)
        {
            long resp = 0;
            PedidoBL CanPedido = new PedidoBL();
            resp = CanPedido.CancelarPedido(cancelar_ped);
            return resp;
        }
    }
}
