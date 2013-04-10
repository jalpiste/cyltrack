using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    public class ReporteService : IReporteService
    {
        public string Prueba(int i)
        {
            string pp = "Hola Mundo" + i;
            return pp;
        } 
    }
}
