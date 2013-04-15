using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    [ServiceContract]
    public interface ICilindroService
    {
        [OperationContract]
        string Prueba(int i);
    }
}
