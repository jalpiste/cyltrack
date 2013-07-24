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
        public List<RutaBE> ConsultarRuta(string Ruta)
        {
            List<RutaBE> lstRuta = new List<RutaBE>();
            
                RutaBE rutaConsulta = new RutaBE();
                rutaConsulta.Nombre_Ruta = "Zona Occidente";
                Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = "Chiquinquirá";
                DepartamentoBE dep = new DepartamentoBE();
                dep.Nombre_Departamento = "Boyacá";
                ciu.Departamento = dep;
                ciuRuta.Ciudad = ciu;
                ciu.Nombre_Ciudad = "Simijaca";
                rutaConsulta.Ciudad = ciu;
                
                rutaConsulta.Ciudad_Ruta = ciuRuta;

                lstRuta.Add(rutaConsulta);

             return lstRuta;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
