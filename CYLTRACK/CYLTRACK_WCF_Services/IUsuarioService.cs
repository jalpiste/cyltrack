using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    /// <summary>
    /// Interface 
    /// </summary>
    [ServiceContract]
    public interface IUsuarioService

    {
        [OperationContract]
        long Registrar_Usuario(UsuarioBE registrar_usuario);
    }
}
