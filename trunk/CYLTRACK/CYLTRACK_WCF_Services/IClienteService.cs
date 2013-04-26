﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClienteService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        long Registrar_Cliente(ClienteBE registrar_cli);

        [OperationContract]
        long Agregar_Ubicacion(ClienteBE registrar_ubi);

        [OperationContract]
        long Consultar_Cliente(ClienteBE consultar_cli);

        [OperationContract]
        long Modificar_Cliente(ClienteBE modificar_cli);
    }

}
