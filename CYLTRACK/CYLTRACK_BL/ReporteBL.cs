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
            ReportesBE[] lista = new ReportesBE[7];
            Random ran = new Random();
            for (int i = 0; i < 7; i++)
            {
                ReportesBE datReporte = new ReportesBE();

                CilindroBE cil = new CilindroBE();
                cil.Codigo_Cilindro = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                cil.Tipo_Cilindro = "Marcado";
                TamanoBE tam = new TamanoBE();
                tam.Tamano = "30";
                cil.NTamano = tam;
                datReporte.Cilindro = cil;
                VehiculoBE veh = new VehiculoBE();
                veh.Placa = "UIZ987";
                UbicacionBE ubicacion = new UbicacionBE();
                Tipo_UbicacionBE tipoUbica = new Tipo_UbicacionBE();
                ubicacion.Tipo_Ubicacion = tipoUbica;
                ubicacion.Vehiculo = veh;
                datReporte.Ubicacion = ubicacion;

                if (reporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion == "Vehiculo")
                {
                    datReporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = "XHA940";
                    datReporte.Cilindro.Tipo_Cilindro = "Universal";
                    datReporte.Cilindro.Cantidad = 5;
                }
                else
                {
                    datReporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = reporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion;
                    datReporte.Cilindro.Tipo_Cilindro = reporte.Cilindro.Tipo_Cilindro;
                    datReporte.Cilindro.Cantidad = 5;
                }
            
                lista[i] = datReporte;
            }

            resp = lista.ToList();

            return resp;
        }

        #endregion
        #region Metodos privados
        #endregion
    }
}
