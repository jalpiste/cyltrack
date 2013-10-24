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
            PruebaDL pru = new PruebaDL();
            long resp = 0;
            try
            {
                resp = pru.GuardarPruebaBE(prueba);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }

        public List<PruebaBE> ConsultarPruebas(int idPrueba)
        {
            PruebaDL pru = new PruebaDL();
            List<PruebaBE> pruebas = new List<PruebaBE>();
            try
            {
                pruebas = pru.ConsultarPruebas(idPrueba);
            }
            catch (Exception ex)
            {

            }
            return pruebas;
        }

        public int ModificarPrueba(PruebaBE prueba)
        {
            PruebaDL pru = new PruebaDL();
            int resp = 0;
            try
            {
                resp = pru.ModificarPrueba(prueba);
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
