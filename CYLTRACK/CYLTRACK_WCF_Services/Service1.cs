using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using Unisangil.CYLTRACK.CYLTRACK_BL;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    [ServiceBehavior(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public class Service1 : IService1
    {
        public long CrearPrueba(PruebaBE prueba)
        {
            PruebaBL crearPru = new PruebaBL();
            return crearPru.CrearPrueba(prueba);
        }
    }
}
