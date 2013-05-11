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
using Unisangil.CYLTRACK.CYLTRACK_BL;
using System.ServiceModel;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    /// <summary>
    /// Clase que implementa el contrato de servicio.
    /// </summary>
    public class RutaService : IRutaServices
    {
        /// <summary>
        /// Encargado de recibir una ruta de los canales front de venta y llamar
        /// al metodo de negocio para crear el registro de ruta
        /// </summary>
        /// <param name="ruta">Objeto de negocio ruta</param>
        /// <returns>Nombre de Ruta</returns>
        public String RegistrarRuta(RutaBE ruta)
        {
            String resp;
            RutaBL registrarRuta = new RutaBL();
            resp = registrarRuta.RegistrarRuta(ruta);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir una ruta de los canales front de venta y llamar
        /// al metodo de negocio para modificar ruta
        /// </summary>
        /// <param name="ruta">Objeto de negocio ruta</param>
        /// <returns>Nombre de ruta</returns>
        public String ModificarRuta(RutaBE ruta)
        {
            String resp;
            RutaBL modificarRuta = new RutaBL();
            resp = modificarRuta.ModificarRuta(ruta);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir una ruta de los canales front de venta y llamar
        /// al metodo de negocio para consultar ruta
        /// </summary>
        /// <param name="ruta">Objeto de negocio ruta</param>
        /// <returns>Nombre de ruta</returns>
        public List<RutaBE> ConsultarRuta(RutaBE ruta)
        {
            List<RutaBE> resp ;
            RutaBL consultarRuta = new RutaBL();
            resp = consultarRuta.ConsultarRuta(ruta);
            return resp;
        }
    }
}
