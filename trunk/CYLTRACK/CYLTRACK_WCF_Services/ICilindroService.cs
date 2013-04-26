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
    public interface ICilindroService
    {
       
        [OperationContract]
        long CrearCilindro(CilindroBE cilindro);

        [OperationContract]
        long ConsultarCilindro(CilindroBE codigo_Cilindro);

    }
}
