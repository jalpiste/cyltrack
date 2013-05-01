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
            long resp = 0;
            ClienteBL RegisCliente = new ClienteBL();
            resp = RegisCliente.RegistrarCliente(registrar_cli);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir una nueva ubicación del cliente de los canales front de venta y llamar
        /// al metodo de negocio para agregar una ubicación
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>

        public long Agregar_Ubicacion (ClienteBE registrar_ubi)
        {
            long resp = 0;
            ClienteBL RegisUbicacion = new ClienteBL();
            resp = RegisUbicacion.RegistrarUbicacion(registrar_ubi);
            return resp;
        }
        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para realizar la consulta de un cliente
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>

        public long Consultar_Cliente (ClienteBE consultar_cli)
        {
            long resp = 0;
            ClienteBL ConCliente = new ClienteBL();
            resp = ConCliente.ConsultarCliente(consultar_cli);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para modificar el registro de cliente
        /// </summary>
        /// <param name="registrar_cli">Objeto de negocio cliente</param>
        /// <returns>cédula del cliente</returns>
        public long Modificar_Cliente(ClienteBE modificar_cli)
        {
            long resp = 0;
            ClienteBL ModCliente = new ClienteBL();
            resp = ModCliente.ModificarCliente(modificar_cli);
            return resp;
        }
    }
}
