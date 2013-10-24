using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        long CrearPrueba(PruebaBE prueba);

        [OperationContract]
        List<PruebaBE> ConsultarPruebas(int idPrueba);

        [OperationContract]
        int ModificarPrueba(PruebaBE prueba);
    }


}
