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
            String resp = "Ok";
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

            pedido.Id_Pedido = "45532";

            ClienteBE ped = new ClienteBE();
            ped.Cedula = "33134665";
            ped.Nombres_Cliente = "María Clara";
            ped.Apellido_1 = "Guzmán";
            ped.Apellido_2 = "Díaz";
            pedido.Cliente = ped;

            UbicacionBE ubi_cli = new UbicacionBE();
            ubi_cli.Direccion = "Calle 13 N 4-47";
            ubi_cli.Barrio = "Las Ferias";
            ubi_cli.Telefono_1 = "3214768823";
            pedido.Ubicacion = ubi_cli;

            CiudadBE ciu_cli = new CiudadBE();
            ciu_cli.Nombre_Ciudad = "Chiquinquirá";
            pedido.Ciudad = ciu_cli;

            DepartamentoBE dep_cli = new DepartamentoBE();
            dep_cli.Nombre_Departamento = "Boyacá";
            ciu_cli.Departamento = dep_cli;

            ////--------------------------------
            VehiculoBE veh_ped = new VehiculoBE();
            veh_ped.Placa = "XHA768";
            pedido.Vehiculo = veh_ped;

            RutaBE ruta_ped = new RutaBE();
            ruta_ped.Nombre_Ruta = "Chiquinquirá-Ubaté";
            pedido.Ruta = ruta_ped;

            pedido.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());

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
            String resp = "Ok";
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
            String resp = "Ok";
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion

       
    }
}
