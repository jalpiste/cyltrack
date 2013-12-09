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

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class RutaBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public String RegistrarRuta(RutaBE ruta)
        {
            String resp = "Ok";
            return resp;
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
                rutaConsulta.Ciudad = ciu;
                DepartamentoBE dep = new DepartamentoBE();
                dep.Nombre_Departamento = "Boyacá";
                ciu.Departamento = dep;
                Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                List<CiudadBE> lstCiudades = new List<CiudadBE>();
                lstCiudades.Add(ciu);
                ciuRuta.Ciudad = lstCiudades;
                rutaConsulta.Ciudad_Ruta = ciuRuta;
                rutaConsulta.Nombre_Ruta = "Zona Occidente";               

             return rutaConsulta;
        }

        public List<CiudadBE> ConsultaDepartamentoyCiudades()
        {
           List<CiudadBE> lstCiudades = new List<CiudadBE>();
            for (int i = 0; i < 4; i++ )
            {
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = "CHIQUINQUIRA";
                DepartamentoBE dep = new DepartamentoBE();
                dep.Nombre_Departamento = "BOYACA";
                ciu.Departamento = dep;
                lstCiudades.Add(ciu);
            }           
            return lstCiudades;
        }
        

        #endregion
        #region Metodos privados
        #endregion
    }
}
