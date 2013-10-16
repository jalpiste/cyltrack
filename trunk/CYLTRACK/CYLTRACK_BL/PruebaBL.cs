using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_DL;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class PruebaBL
    {
        public long CrearPrueba(PruebaBE prueba)
        {
            PruebaDL crearPru = new PruebaDL();
            long resp = 0;
            try
            {
                resp = crearPru.GuardarPruebaBE(prueba);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }
    }
}
