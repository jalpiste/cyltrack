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
        public String Registrar_Pedido(PedidoBE registrar_ped)
        {
            String resp;
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
        public List<PedidoBE> Consultar_Pedido(PedidoBE consultar_ped)
        {
            List<PedidoBE> resp;
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
        public String Modificar_Pedido(PedidoBE modificar_ped)
        {
            String resp;
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
        public String Cancelar_Pedido(PedidoBE cancelar_ped)
        {
            String resp;
            PedidoBL CanPedido = new PedidoBL();
            resp = CanPedido.CancelarPedido(cancelar_ped);
            return resp;
        }
    }
}
