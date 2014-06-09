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

        public long ModificarRuta(RutaBE ruta)
        {
            RutaDL rut = new RutaDL();
            long resp = new long();
            try
            {
               resp = rut.ModificarRuta(ruta);
            }
            catch (Exception ex)
            {

            }
            return resp;

        }

        public string ConsultarExistencias(string ruta)
        {
            string resp = "Ok";

            return resp;
        }
        /// <summary>
        /// Método para la consulta de rutas en el sistema y muestra de información
        /// </summary>
        /// <param name="consultarRutas"></param>
        /// <returns></returns>
        public List<RutaBE> ConsultarRuta(string ruta)
        {
            RutaDL rut = new RutaDL();
            List<RutaBE> lstRuta = new List<RutaBE>();
            try
            {
                if(ruta == "")
                {
                    ruta = "0";
                }
                lstRuta = rut.ConsultarRutas(ruta);                
            }
            catch (Exception ex)
            {

            }
            return lstRuta;
        }

        public long ConsultaExistenciaRuta(string ruta)
        {
            RutaDL rut = new RutaDL();
            long resp = 0;
            try
            {
                resp = rut.ConsultaExistenciaRuta(ruta);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }

        public List<CiudadBE> ConsultaCiudades(string id_dep)
        {
            RutaDL ruta = new RutaDL();
            List<CiudadBE> lstCiudades = new List<CiudadBE>();
            try
            {
                lstCiudades = ruta.ConsultaCiudades(id_dep);
            }
            catch (Exception ex)
            {

            }
            return lstCiudades;        
        }

        public List<DepartamentoBE> ConsultaDepartamento()
        {
            RutaDL ruta = new RutaDL();
            List<DepartamentoBE> lstDepartamentos = new List<DepartamentoBE>();
            try
            {
                lstDepartamentos = ruta.ConsultaDepartamento();
            }
            catch (Exception ex)
            {

            }
            return lstDepartamentos;
        }

        public RutaBE ConsultarRutaPorPlaca(Ruta_VehiculoBE rutaVehiculo)
        {
            RutaDL rut = new RutaDL();
            RutaBE datoRuta = new RutaBE();
            try
            {
                datoRuta = rut.ConsultarRutasPorPlaca(rutaVehiculo);
            }
            catch (Exception ex)
            {

            }
            return datoRuta;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
