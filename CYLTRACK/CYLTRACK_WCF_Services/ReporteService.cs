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
using Unisangil.CYLTRACK.CYLTRACK_BL;
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    [ServiceBehavior(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public class ReporteService : IReporteService
    {
        /// <summary>
        /// Encargado de recibir el código del cilindro de los canales front de venta y llamar
        /// al metodo de negocio para consultar el historico del cilindro
        /// </summary>
        /// <param name="reporte">Objeto de negocio Reporte</param>
        /// <returns>codigo cilindro</returns>
        public List<ReportesBE> HistoricoCilindro(string reporte)
        {
            List<ReportesBE> resp ;
            ReporteBL historicoCil = new ReporteBL();
            resp = historicoCil.HistoricoCilindro(reporte);
            return resp;

        }

        /// <summary>
        /// Encargado de recibir el código del cilindro de los canales front de venta y llamar
        /// al metodo de negocio para consultar el inventario de cilindros
        /// </summary>
        /// <param name="reporte">Objeto de negocio Reporte</param>
        /// <returns>Datos Cilindros</returns>
        public List<ReportesBE> Inventario(ReportesBE reporte)
        {
            List<ReportesBE> resp;
            ReporteBL inventario = new ReporteBL();
            resp = inventario.Inventario(reporte);
            return resp;

        }

        ///<summary>
        ///Encargado de recibir una ciudad de los canales front de venta y llamar
        ///al metodo de negocio para consultar la ciudad del reporte
        ///</summary>
        ///<param name="ciudad">ciudad</param>
        ///<returns>cantidad y cilindros por ciudades</returns>
        public List<UbicacionBE> ConsultaReporteCiudades(string ciudad, string tipoCil)
        {
            List<UbicacionBE> resp;
            ReporteBL consultaReporteCiudades = new ReporteBL();
            resp = consultaReporteCiudades.ConsultaReporteCiudades(ciudad, tipoCil);
            return resp;
        }

        /// <summary>
        /// Encargado de llamar al metodo de negocio para consultar los registros de cilindros
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>Códigos internos de los Cilindros</returns>
        public List<CilindroBE> ReporteCilindro(string tipoCil)
        {
            List<CilindroBE> resp;
            ReporteBL reportCil = new ReporteBL();
            resp = reportCil.ReporteCilindros(tipoCil);
            return resp;
        }

         /// <summary>
        /// Encargado de llamar al metodo de negocio para consultar los registros de cilindros
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>Códigos internos de los Cilindros</returns>
        public List<UbicacionBE> ReporteporPlacas(string tipoCil)
        {
            List<UbicacionBE> resp;
            ReporteBL reportPlacas = new ReporteBL();
            resp = reportPlacas.ReporteporPlacas(tipoCil);
            return resp;
        }

         /// <summary>
        /// Encargado de llamar al metodo de negocio para consultar los registros de cilindros
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>Códigos internos de los Cilindros</returns>
        public List<ClienteBE> ReporteClientes()
        {
            List<ClienteBE> resp;
            ReporteBL reportClientes = new ReporteBL();
            resp = reportClientes.ReporteClientes();
            return resp;
        }
        
         /// <summary>
        /// Encargado de llamar al metodo de negocio para consultar los registros de pedidos
        /// <returns>listados de pedidos</returns>
        public List<PedidoBE> ReportePedidos() 
        {
            List<PedidoBE> resp;
            ReporteBL reportClientes = new ReporteBL();
            resp = reportClientes.ReportePedidos();
            return resp;
        }

        ///<summary>
        ///Encargado de recibir una ruta de los canales front de venta y llamar
        ///al metodo de negocio para consultar ruta
        ///</summary>
        ///<param name="ruta">Objeto de negocio ruta</param>
        ///<returns>Nombre de ruta</returns>
        public List<RutaBE> ConsultarRuta()
        {
            List<RutaBE> resp;
            ReporteBL consultarRuta = new ReporteBL();
            resp = consultarRuta.ReporteRuta();
            return resp;
        }

        ///<summary>
        ///Encargado llamar al metodo de negocio para consultar usuarios
        ///</summary>
        ///<returns>listado de datos usuario</returns>
        public List<UsuarioBE> ReporteUsuario()
        {
            List<UsuarioBE> resp;
            ReporteBL reporteUsuarios = new ReporteBL();
            resp = reporteUsuarios.ReporteUsuario();
            return resp;
        }

        ///<summary>
        ///Encargado llamar al metodo de negocio para consultar los tipos de ubicacion
        ///</summary>
        ///<returns>listado de datos tipos de ubicación</returns>
        public List<Tipo_UbicacionBE> ConsultaTipoUbicacion() 
        {
            List<Tipo_UbicacionBE> resp;
            ReporteBL consultarTipoUbica = new ReporteBL();
            resp = consultarTipoUbica.ConsultaTipoUbicacion();
            return resp;
        }

        ///<summary>
        ///Encargado llamar al metodo de negocio para consultar los tamanos de los cilindros
        ///</summary>
        ///<returns>listado de datos de tamanos de los cilindros</returns>
        public List<TamanoBE> ConsultaTamanoCilindro()
        {
            List<TamanoBE> resp;
            ReporteBL consultarTamanoCilindro = new ReporteBL();
            resp = consultarTamanoCilindro.ConsultaTamanoCilindro();
            return resp;
        }
    }
}
