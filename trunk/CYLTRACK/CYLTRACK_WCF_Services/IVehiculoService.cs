using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Unisangil.CYLTRACK.CYLTRACK_BE;


namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{ 
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClienteService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IVehiculoService
    {
        [OperationContract]
        long Registrar_Vehiculo(VehiculoBE registrar_vehiculo);

        [OperationContract]
        long Consultar_Vehiculo(VehiculoBE consultar_vehiculo);

        [OperationContract]
        long Modificar_Vehiculo(VehiculoBE modificar_vehiculo);

        [OperationContract]
        long Consultar_Conductor(VehiculoBE consultar_conductor);

    }
}
