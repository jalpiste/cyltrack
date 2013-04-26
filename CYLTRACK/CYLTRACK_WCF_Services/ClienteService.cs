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
    /// Clase que implementa el contrato de servicio.
    /// </summary>

    public class ClienteService : IClienteService
    {
        /// <summary>
        /// Encargado de recibir un cliente de los canales front de venta y llamar
        /// al metodo de negocio para crear un registro de cliente
        /// </summary>
        
        public long Registrar_Cliente(ClienteBE registrar_cli)
        {
            long resp = 0;
            ClienteBL RegisCliente = new ClienteBL();
            resp = RegisCliente.RegistrarCliente(registrar_cli);
            return resp;
        }

        public long Agregar_Ubicacion (ClienteBE registrar_ubi)
        {
            long resp = 0;
            ClienteBL RegisUbicacion = new ClienteBL();
            resp = RegisUbicacion.RegistrarUbicacion(registrar_ubi);
            return resp;
        }

        public long Consultar_Cliente (ClienteBE consultar_cli)
        {
            long resp = 0;
            ClienteBL ConCliente = new ClienteBL();
            resp = ConCliente.ConsultarCliente(consultar_cli);
            return resp;
        }

        public long Modificar_Cliente(ClienteBE modificar_cli)
        {
            long resp = 0;
            ClienteBL ModCliente = new ClienteBL();
            resp = ModCliente.ModificarCliente(modificar_cli);
            return resp;
        }
    }
}
