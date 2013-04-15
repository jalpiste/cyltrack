using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    public class CilindroService : ICilindroService
    {
        public string Prueba(int i)
        {
            string pp = "Hola Mundo" + i;
            return pp;
        }       

    }
}
