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
using Unisangil.CYLTRACK.CYLTRACK_DL;

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
        public long RegistrarPedido(PedidoBE registrar_ped)
        {
            PedidoDL pedido = new PedidoDL();
            long resPedido = 0;
            long resDetallePedido = 0;
            try
            {
                if (registrar_ped.Detalle == "")
                {
                    registrar_ped.Detalle = "0";
                }
                registrar_ped.Estado = "1";

                resPedido = pedido.CrearPedido(registrar_ped);               

                foreach (Detalle_PedidoBE datos in registrar_ped.List_Detalle_Ped)
                {
                    Detalle_PedidoBE det = new Detalle_PedidoBE();
                    det.Tamano = datos.Tamano;
                    det.Cantidad = datos.Cantidad;
                    det.Id_Pedido = resPedido.ToString();
                    resDetallePedido = pedido.CrearRegistroDetallePedido(det);
                }
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resPedido = -1;
            }

            return resPedido;
        }
        /// <summary>
        /// Método para la consulta de pedidos en el sistema
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public PedidoBE ConsultarPedido(string cedula)
        {
            PedidoDL ped = new PedidoDL();
            PedidoBE resp = new PedidoBE();
            try
            {
                resp = ped.ConsultarPedido(cedula);
                Detalle_PedidoBE detAux = new Detalle_PedidoBE();
                //foreach(Detalle_PedidoBE datos in resp.List_Detalle_Ped )
                //{
                //    if (datos.Tamano == detAux.Tamano)
                //    {
                //        datos.Cantidad += detAux.Cantidad;
                //        datos.ToString().Remove(0, 1);                        
                //    }
                //    detAux.Tamano = datos.Tamano;
                //    detAux.Cantidad = datos.Cantidad;                                    
                //}
                                
            }
            catch (Exception ex)
            {
            
            }

            return resp;

        }
        /// <summary>
        /// Método para la consulta de existencia de pedido en el sistema
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        public long ModificarPedido(PedidoBE pedido)
        {
            PedidoDL pedidoDL = new PedidoDL();
            long respModPedido = 0;
            long respModDetallePedido = 0;

            try
            {
                if (pedido.Detalle != "")
                {
                    respModPedido = pedidoDL.ModificarPedido(pedido);
                }
                
                foreach(Detalle_PedidoBE datos in pedido.List_Detalle_Ped)
                {
                   if(datos.Id_Tamano!=null)
                   {
                       Detalle_PedidoBE det = new Detalle_PedidoBE();
                       det.Tamano = datos.Tamano;
                       det.Cantidad = datos.Cantidad;
                       det.Id_Pedido = pedido.Id_Pedido;
                       respModDetallePedido = pedidoDL.ModificarDetallePedido(det);
                   }                    
                }
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                respModDetallePedido = -1;
            }

            return respModDetallePedido;
        }
        /// <summary>
        /// Método para la cancelación de pedidos en el sistema
        /// </summary>
        /// <param name="cancelar_ped"></param>
        /// <returns></returns>
        public long CancelarPedido(PedidoBE pedido)
        {
            PedidoDL pedidoDL = new PedidoDL();
            long resp = 0;
            try
            {
                resp = pedidoDL.CancelarPedido(pedido);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }

        public long ConsultaExistenciaPedido(string pedido)
        
        {
            PedidoDL ped = new PedidoDL();
            long resp = 0;
            try
            {
                resp = ped.ConsultaExistenciaPedido(pedido);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }
        #endregion
        #region Metodos privados
        #endregion

       
    }
}
