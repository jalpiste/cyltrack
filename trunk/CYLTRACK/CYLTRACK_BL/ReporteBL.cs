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
    public class ReporteBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public List<ReportesBE> HistoricoCilindro(ReportesBE reporte)
        {
            List<ReportesBE> resp = new List<ReportesBE>();
            ReportesBE report = new ReportesBE();
            CilindroBE cil = new CilindroBE();
            TamanoBE tam = new TamanoBE();
            cil.NTamano = tam;
            report.Cilindro = cil;
            report.Cilindro.Codigo_Cilindro = reporte.Cilindro.Codigo_Cilindro;
            report.Cilindro.NTamano.Tamano = "30";
            report.Fecha_Reporte = DateTime.Now;
            UbicacionBE ubi = new UbicacionBE();
            Tipo_UbicacionBE tipoUbica = new Tipo_UbicacionBE();
            ubi.Tipo_Ubicacion= tipoUbica;            
            report.Ubicacion = ubi;
            report.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = "Vehiculo";

            resp.Add(report);

            return resp;
        }

        public List<ReportesBE> Inventario(ReportesBE reporte)
        {
            List<ReportesBE> resp= new List<ReportesBE>();
            ReportesBE report = new ReportesBE();

            Tipo_UbicacionBE tipoUbica = new Tipo_UbicacionBE();
            UbicacionBE ubi = new UbicacionBE();
            ubi.Tipo_Ubicacion = tipoUbica;
            report.Ubicacion = ubi;
            VehiculoBE veh = new VehiculoBE();
            report.Vehiculo = veh;
            CilindroBE cil = new CilindroBE();
            report.Cilindro = cil;
            if (reporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion == "Vehiculo")
            {
                report.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = "XHA940";
                report.Cilindro.Tipo_Cilindro = "Universal";
                report.Cilindro.Cantidad = 5;
            } 
            else 
            {
                report.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = reporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion;
                report.Cilindro.Tipo_Cilindro = reporte.Cilindro.Tipo_Cilindro;
                report.Cilindro.Cantidad = 5;
            }
            
            
            
            resp.Add(report);
            return resp;
        }

        #endregion
        #region Metodos privados
        #endregion
    }
}
