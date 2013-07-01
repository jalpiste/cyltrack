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
        public List<ReportesBE> HistoricoCilindro(ReportesBE reporte)
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
    }
}
