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
        /// <param name="codigo">codigo cilindro</param>
        /// <returns>Objeto de negocio Reporte</returns>
        public List<Ubicacion_CilindroBE> HistoricoCilindro(string codigo)
        {
            List<Ubicacion_CilindroBE> resp ;
            ReporteBL historicoCil = new ReporteBL();
            resp = historicoCil.HistoricoCilindro(codigo);
            return resp;

        }

        /// <summary>
        /// Encargado de recibir la ubicacion de los canales front de venta y llamar
        /// al metodo de negocio para la consulta de cilindros en dicha ubicacion
        /// </summary>
        /// <param name="reporte">Objeto de negocio reporte</param>
        /// <returns>Objeto de Cilindros</returns>
        public List<Ubicacion_CilindroBE> ConsultarCilInventario(ReportesBE reporte)
        {
            List<Ubicacion_CilindroBE> resp;
            ReporteBL consultaUbicacion = new ReporteBL();
            resp = consultaUbicacion.ConsultarCilInventario(reporte);
            return resp;
        }

        ///<summary>
        ///Encargado llamar al metodo de negocio para consultar los tipos de ubicacion
        ///</summary>
        ///<returns>listado de datos tipos de ubicación</returns>
        public IList<Tipo_UbicacionBE> ConsultaTipoUbicacion() 
        {
            IList<Tipo_UbicacionBE> resp;
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

        public long consultadeExistencia(string dato)
        {
            long resp;
            ReporteBL consulExistencia = new ReporteBL();
            resp = consulExistencia.consultadeExistencia(dato);
            return resp;
        }

        ///<summary>
        ///Encargado llamar al metodo de negocio para consultar los tipos de casos
        ///</summary>
        ///<returns>lista de Objetos de negocio Tipos de casos</returns>
        public List<Tipo_CasoBE> ConsultaTiposCasos()
        {
            List<Tipo_CasoBE> resp;
            ReporteBL consultarTipoCasos = new ReporteBL();
            resp = consultarTipoCasos.ConsultaTipoCasos();
            return resp;
        }

        public List<CilindroBE> ReporteSiembrasCilindro(ReportesBE reporte)
        {
            List<CilindroBE> resp;
            ReporteBL reporteSiembraCil = new ReporteBL();
            resp = reporteSiembraCil.ReporteSiembrasCilindro(reporte);
            return resp;
        }

        public List<CilindroBE> ReporteSiembrasCiudad(ReportesBE reporte)
        {
            List<CilindroBE> resp;
            ReporteBL reporteSiembraCil = new ReporteBL();
            resp = reporteSiembraCil.ReporteSiembrasCiudad(reporte);
            return resp;
        }
    }
}
