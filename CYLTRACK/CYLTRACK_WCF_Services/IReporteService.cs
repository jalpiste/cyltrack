using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    [ServiceContract (Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public interface IReporteService
    {
        [OperationContract]
        string Prueba(int i); 
    }
}
