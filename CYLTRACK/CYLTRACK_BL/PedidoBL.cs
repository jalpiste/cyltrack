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
        public String RegistrarPedido(PedidoBE registrar_ped)
        {
            String resp = "1";
            return resp;
        }
        /// <summary>
        /// Método para la consulta de pedidos en el sistema
        /// </summary>
        /// <param name="consultar_ped"></param>
        /// <returns></returns>
        public List<PedidoBE> ConsultarPedido(PedidoBE consultar_ped)
        {
            List<PedidoBE> lstPedido = new List<PedidoBE>();
            PedidoBE pedido = new PedidoBE();
            pedido.Cliente.Cedula = "1053544325";
            pedido.Cliente.Nombres_Cliente = "María Clara";
            pedido.Cliente.Apellido_1 = "Guzmán";
            pedido.Cliente.Apellido_2 = "Díaz";
            pedido.Ubicacion.Direccion = "Calle 13 N 4-47";
            pedido.Ubicacion.Barrio = "Las Ferias";
            pedido.Ciudad.Nombre_Ciudad = "Chiquinquirá";
            pedido.Ciudad.Departamento.Nombre_Departamento = "Boyacá";
            pedido.Ubicacion.Telefono_1 = "3214768823";
            //--------------------------------
            pedido.Vehiculo.Placa = "XHA768";
            pedido.Ruta.Nombre_Ruta = "Chiquinquirá-Ubaté";
            pedido.Detalle_Ped.Tamano.Tamano  = "30";
            pedido.Detalle_Ped.Cantidad = "9";
            pedido.Fecha  = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            pedido.Venta.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            lstPedido.Add(pedido);
            return lstPedido;
        }
        /// <summary>
        /// Método para la modificación de pedidos en el sistema
        /// </summary>
        /// <param name="modificar_ped"></param>
        /// <returns></returns>
        public String ModificarPedido(PedidoBE modificar_ped)
        {
            List<PedidoBE> consulta = ConsultarPedido(modificar_ped);
            String resp = "Pedido Modificado";
            return resp;
        }
        /// <summary>
        /// Método para la cancelación de pedidos en el sistema
        /// </summary>
        /// <param name="cancelar_ped"></param>
        /// <returns></returns>
        public String CancelarPedido(PedidoBE cancelar_ped)
        {
            List<PedidoBE> consulta = ConsultarPedido(cancelar_ped);
            String resp = "Pedido Cancelado";
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion

       
    }
}
