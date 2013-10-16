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
     ///<summary>
     ///Clase que implementa el contrato de servicio.
     ///</summary>
    [ServiceBehavior(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public class RutaService : IRutaServices
    {
         ///<summary>
         ///Encargado de recibir una ruta de los canales front de venta y llamar
         ///al metodo de negocio para crear el registro de ruta
         ///</summary>
         ///<param name="ruta">Objeto de negocio ruta</param>
         ///<returns>Nombre de Ruta</returns>
        public string RegistrarRuta(RutaBE ruta)
        {
            string resp;
            RutaBL registrarRuta = new RutaBL();
            resp = registrarRuta.RegistrarRuta(ruta);
            return resp;
        }

         ///<summary>
         ///Encargado de recibir una ruta de los canales front de venta y llamar
         ///al metodo de negocio para modificar ruta
         ///</summary>
         ///<param name="ruta">Objeto de negocio ruta</param>
         ///<returns>Nombre de ruta</returns>
        public string ModificarRuta(RutaBE ruta)
        {
            string resp;
            RutaBL modificarRuta = new RutaBL();
            resp = modificarRuta.ModificarRuta(ruta);
            return resp;
        }

         ///<summary>
         ///Encargado de recibir una ruta de los canales front de venta y llamar
         ///al metodo de negocio para consultar ruta
         ///</summary>
         ///<param name="ruta">Objeto de negocio ruta</param>
         ///<returns>Nombre de ruta</returns>
        public RutaBE ConsultarRutaconParametro(string ruta)
        {
            RutaBE resp;
            RutaBL consultarRutaParametro = new RutaBL();
            resp = consultarRutaParametro.ConsultarRutaconParametro(ruta);
            return resp;
        }

        ///<summary>
        ///Encargado de recibir una ciudad de los canales front de venta y llamar
        ///al metodo de negocio para consultar ruta
        ///</summary>
        ///<param name="ruta">valor de negocio ruta</param>
        ///<returns>existencia de ruta</returns>
        public List<CiudadBE> ConsultaDepartamentoyCiudades()
        {
            List<CiudadBE> resp;
            RutaBL consultarDepyCiudad = new RutaBL();
            resp = consultarDepyCiudad.ConsultaDepartamentoyCiudades();
            return resp;
        }

        ///<summary>
        ///Encargado de recibir una ciudad de los canales front de venta y llamar
        ///al metodo de negocio para consultar ruta
        ///</summary>
        ///<param name="ruta">valor de negocio ruta</param>
        ///<returns>existencia de ruta</returns>
        public string ConsultaExistencia(string ruta)
        {
            string resp;
            RutaBL consultarExistencia = new RutaBL();
            resp = consultarExistencia.ConsultarExistencias(ruta);
            return resp;
        }

        
    }
}
