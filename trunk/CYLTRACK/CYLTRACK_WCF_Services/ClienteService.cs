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
    public class ClienteService : IClienteService
    {
        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para crear un registro de cliente
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>
        
        public long Registrar_Cliente(ClienteBE registrar_cli)
        {
            long resp ;
            ClienteBL RegisCliente = new ClienteBL();
            resp = RegisCliente.CrearCliente(registrar_cli);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir una nueva ubicación del cliente de los canales front de venta y llamar
        /// al metodo de negocio para agregar una ubicación
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>

        public long Agregar_Ubicacion (ClienteBE cliente)
        {
            long resp ;
            ClienteBL RegisUbicacion = new ClienteBL();
            resp = RegisUbicacion.AgregarUbicacion(cliente);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para la consulta de cilindros en dicha ubicacion
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>lista de Objeto de Cilindros</returns>
        public List<Ubicacion_CilindroBE> ConsultarCilPorCliente(string idCliente)
        {
            List<Ubicacion_CilindroBE> resp;
            ClienteBL consultaCilCliente = new ClienteBL();
            resp = consultaCilCliente.ConsultarCilPorCliente(idCliente);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para realizar la consulta de un cliente
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>

        public ClienteBE Consultar_Cliente (String consultar_cli)
        {
            ClienteBE resp;
            ClienteBL ConCliente = new ClienteBL();
            resp = ConCliente.ConsultarCliente(consultar_cli);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para realizar la consulta de un cliente
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>

        public UbicacionBE ConsultarDirCliPorUbica(string idUbica)
        {
            UbicacionBE resp;
            ClienteBL ConCliente = new ClienteBL();
            resp = ConCliente.ConsultarDirPorUbicacion(idUbica);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para modificar el registro de cliente
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>
        public long ModificarDirCliente(UbicacionBE ubicacion)
        {
            long resp;
            ClienteBL ModCliente = new ClienteBL();
            resp = ModCliente.ModificarDirCliente(ubicacion);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para modificar el registro de cliente
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>
        public long ModificarNombreCliente(ClienteBE modificar_cli)
        {
            long resp;
            ClienteBL ModCliente = new ClienteBL();
            resp = ModCliente.ModificarNombreCliente(modificar_cli);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para la consulta de existencia del registro de cliente
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>código</returns>
        public long ConsultarExistenciasClientes(string cliente)
        {
            long resp;
            ClienteBL ConsultaExistenciaCliente = new ClienteBL();
            resp = ConsultaExistenciaCliente.ConsultarExistenciasClientes(cliente);
            return resp;
        }
    }
}
