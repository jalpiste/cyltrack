using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    [ServiceContract]
   public class IVentaService
    {
        [OperationContract]
        string Prueba(int i); 
    }
}
