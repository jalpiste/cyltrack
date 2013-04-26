using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPedidoService" en el código y en el archivo de configuración a la vez.
    
    [ServiceContract]
    public interface IPedidoService
    {
        [OperationContract]
        long Registrar_Pedido(PedidoBE registrar_ped);

        [OperationContract]
        long Consultar_Pedido(PedidoBE consultar_ped);

        [OperationContract]
        long Modificar_Pedido(PedidoBE modificar_ped);

        [OperationContract]
        long Cancelar_Pedido(PedidoBE cancelar_ped);
    }
}
