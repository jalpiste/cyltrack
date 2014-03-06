/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Derechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using Unisangil.CYLTRACK.CYLTRACK_DL;

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class RutaBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public long RegistrarRuta(RutaBE ruta)
        {
            RutaDL regRuta = new RutaDL();
            long respuesta = new long();
            try
            {
                respuesta = regRuta.CrearRuta(ruta);
            }
            catch (Exception ex)
            {

            }
            return respuesta;
        }

        public String ModificarRuta(RutaBE ruta)
        {
            String resp = "Ok";
            
            return resp;
        }

        public string ConsultarExistencias(string ruta)
        {
            string resp = "Ok";

            return resp;
        }
        public RutaBE ConsultarRutaconParametro(string Ruta)
        {
                RutaBE rutaConsulta = new RutaBE();
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = "Chiquinquirá";
               // rutaConsulta.Ciudad = ciu;
                DepartamentoBE dep = new DepartamentoBE();
                dep.Nombre_Departamento = "Boyacá";
                ciu.Departamento = dep;
                Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                //ciuRuta.Ciudad = lstCiudades;
                //rutaConsulta.Ciudad_Ruta = ciuRuta;
                //rutaConsulta.Nombre_Ruta = "Zona Occidente";               

             return rutaConsulta;
        }

        public List<CiudadBE> ConsultaDepartamentoyCiudades()
        {
            RutaDL ruta = new RutaDL();
            List<CiudadBE> ciudadesDep = new List<CiudadBE>();
            try
            {
                ciudadesDep= ruta.ConsultaDepartamentoyCiudades();
            }
            catch (Exception ex)
            {

            }
            return ciudadesDep;        
        }
        

        #endregion
        #region Metodos privados
        #endregion
    }
}
