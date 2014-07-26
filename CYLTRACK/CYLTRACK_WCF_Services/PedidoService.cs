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
    [ServiceBehavior(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public class PedidoService : IPedidoService 
    {
        /// <summary>
        /// Encargado de recibir un pedido de los canales front de venta y llamar
        /// al metodo de negocio para crear un pedido de cilindro
        /// </summary>
        /// <param name="registrar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente</returns>
        public long Registrar_Pedido(PedidoBE pedido)
        {
            long resp;
            PedidoBL regisPedido = new PedidoBL();
            resp = regisPedido.RegistrarPedido(pedido);
            return resp;
        }
        /// <summary>
        /// Encargado de consultar un pedido de los canales front de venta y llamar
        /// al metodo de negocio para consultar un pedido
        /// </summary>
        /// <param name="consultar_vehiculo"></param>
        /// <returns></returns>
        public PedidoBE Consultar_Pedido(string pedido)
        {
            PedidoBE resp;
            PedidoBL ConPed = new PedidoBL();
            resp = ConPed.ConsultarPedido(pedido);
            return resp;
        }



        /// <summary>
        /// Encargado de recibir un pedido de los canales front de venta y llamar
        /// al metodo de negocio para modificar un pedido de cilindro
        /// </summary>
        /// <param name="modificar_ped">Objeto de negocio pedido</param>
        /// <returns>cédula del cliente</returns>
        public long Modificar_Pedido(PedidoBE pedido)
        {
            long resp;
            PedidoBL ModPedido = new PedidoBL();
            resp = ModPedido.ModificarPedido(pedido);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir un pedido de los canales front de venta y llamar
        /// al metodo de negocio para cancelar un pedido de cilindro
        /// </summary>
        /// <param name="cancelar_ped">Objeto de negocio pedido</param>
        /// <returns>identificar del pedido</returns>
        public long Cancelar_Pedido(PedidoBE pedido)
        {
            long resp;
            PedidoBL CanPedido = new PedidoBL();
            resp = CanPedido.CancelarPedido(pedido);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir el numero del pedido de los canales front de venta y llamar
        /// al metodo de negocio para la consulta de existencia de pedidos
        /// </summary>
        /// <param name="ubicacion">Objeto de negocio cilindro</param>
        /// <returns>codigo</returns>
        public long ConsultarExistenciaPedido(string pedido)
        {
            long resp;
            PedidoBL consultaExistenciaPedido = new PedidoBL();
            resp = consultaExistenciaPedido.ConsultaExistenciaPedido(pedido);
            return resp;
        }
    }
}
