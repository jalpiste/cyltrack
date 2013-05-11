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
            String resp = "Ruta registrada";
            return resp;
        }

        public String ModificarRuta(RutaBE ruta)
        {
            String resp = "ruta modificada";
            
            return resp;
        }
        public List<RutaBE> ConsultarRuta(RutaBE ruta)
        {
            List<RutaBE> lstRuta = new List<RutaBE>();
            RutaBE dRuta = new RutaBE();
            dRuta.Nombre_Ruta = "Zona Occidente";
            dRuta.Departamento.Nombre_Departamento = "Boyacá";
            dRuta.Ciudad_Ruta.Ciudad.Nombre_Ciudad = "Otanche";
            dRuta.Ciudad_Ruta.Ciudad.Nombre_Ciudad = "Muzo";
            lstRuta.Add(dRuta);
            return lstRuta;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
