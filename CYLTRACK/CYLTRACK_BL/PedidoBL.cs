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

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class PedidoBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        /// <summary>
        /// Método para el registro de pedidos en el sistema
        /// </summary>
        /// <param name="registrar_ped"></param>
        /// <returns></returns>
        public string RegistrarPedido(PedidoBE registrar_ped)
        {
            String resp = "Ok";
            return resp;
        }
        /// <summary>
        /// Método para la consulta de pedidos en el sistema
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public PedidoBE ConsultarPedido(string pedido)
        {
            PedidoBE conPedido = new PedidoBE();
            conPedido.Id_Pedido = "0023";
            ///cargar el pedido en interfaces de modificar y consultar
            return conPedido;
        }
        /// <summary>
        /// Método para la consulta de existencia de pedido en el sistema
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        public string ConsultarExistencia(string consultar_existencia)
        {
            //string Id_Pedido = "0023";
            string resp = "Ok";
            return resp;
        }
        /// <summary>
        /// Método para la modificación de pedidos en el sistema
        /// </summary>
        /// <param name="modificar_ped"></param>
        /// <returns></returns>
        public string ModificarPedido(string pedido)
        {
            PedidoBE consulta = ConsultarPedido(pedido);
            String resp = "Ok";
            return resp;
        }
        /// <summary>
        /// Método para la cancelación de pedidos en el sistema
        /// </summary>
        /// <param name="cancelar_ped"></param>
        /// <returns></returns>
        public string CancelarPedido(string motivo)
        {
            PedidoBE consulta = ConsultarPedido(motivo);
            String resp = "Ok";
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion

       
    }
}
