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
            Random ran = new Random();

            PedidoBE conPedido = new PedidoBE();
            conPedido.Id_Pedido = "0023";

            ClienteBE cliente = new ClienteBE();
            cliente.Cedula = "56235624";
            cliente.Nombres_Cliente = "Jaime";
            cliente.Apellido_1 = "Poveda";
            cliente.Apellido_2 = "Sanchez";

            UbicacionBE ubicacion = new UbicacionBE();
            ubicacion.Direccion = "Calle 17 N 10 30";
            ubicacion.Barrio = "Centro";
            ubicacion.Telefono_1 = "3143456789";
            cliente.Ubicacion = ubicacion;

            CiudadBE ciu_cli = new CiudadBE();
            ciu_cli.Nombre_Ciudad = "Chiquinquirá";
            ubicacion.Ciudad = ciu_cli;
            cliente.Ubicacion = ubicacion;

            DepartamentoBE dep_cli = new DepartamentoBE();
            dep_cli.Nombre_Departamento = "Boyacá";
            ciu_cli.Departamento = dep_cli;

            Ubicacion_CilindroBE ubi_cil = new Ubicacion_CilindroBE();
            ubicacion.Ubicacion_Cilindro = ubi_cil;

            CilindroBE cilindro = new CilindroBE();
            cilindro.Codigo_Cilindro = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
            cilindro.Tipo_Cilindro = "Universal";
            ubi_cil.Cilindro = cilindro;

            TamanoBE tamano = new TamanoBE();
            tamano.Tamano = "40";
            cilindro.NTamano = tamano;

            //-----------------------------
            VehiculoBE veh = new VehiculoBE();
            veh.Placa = "XHA940";
            RutaBE ruta = new RutaBE();
            ruta.Nombre_Ruta = "Chiquinquirá-Ubaté";
            ConductorBE cond = new ConductorBE();
            cond.Nombres_Conductor = "Juanito perez";
            veh.Ruta = ruta;
            veh.Conductor = cond;
            ubicacion.Vehiculo = veh;

            conPedido.Cilindro = cilindro;
            conPedido.Ciudad = ciu_cli;
            conPedido.Ubicacion = ubicacion;
            conPedido.Vehiculo = veh;
            conPedido.Ruta = ruta;
            conPedido.Cliente = cliente;
            
            return conPedido;
        }
        /// <summary>
        /// Método para la consulta de existencia de pedido en el sistema
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        public string ConsultarExistencia(string consultar_existencia)
        {
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
