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
using Unisangil.CYLTRACK.CYLTRACK_DL;

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class ReporteBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public List<Ubicacion_CilindroBE> HistoricoCilindro(string codigo)
        {
            List<Ubicacion_CilindroBE> lstResp = new List<Ubicacion_CilindroBE>();
            VehiculoBE veh = new VehiculoBE();
            ReporteDL rep = new ReporteDL();
            VehiculoDL vehDL = new VehiculoDL();
            UbicacionBE ubi = new UbicacionBE();
            ClienteDL cliDL = new ClienteDL();
            try
            {
                lstResp = rep.ConsultarHistoricoCilindro(codigo);
                foreach(Ubicacion_CilindroBE datos in lstResp)
                {
                if(datos.Nombre_Ubicacion=="VEHICULO")
                {
                    veh = vehDL.ConsultaPlacaPorUbicacion(datos.Id_Ubicacion_Cilindro);                    
                    ubi.Vehiculo = veh;
                    datos.Ubicacion = ubi;
                }
                if (datos.Nombre_Ubicacion == "CLIENTE")
                {
                    ubi = cliDL.ConsultarDirClientePorUbicacion(datos.Id_Ubicacion_Cilindro);                    
                    datos.Ubicacion = ubi;
                }
                }
            }
            catch (Exception ex)
            {

            }

            return lstResp;
        }
        public IList<Tipo_UbicacionBE> ConsultaTipoUbicacion() 
        {
            ReporteDL reporte = new ReporteDL();
            IList<Tipo_UbicacionBE> lstReport = new List<Tipo_UbicacionBE>();
            try
            {
                lstReport = reporte.ConsultarTipoUbicaciones();
            }
            catch (Exception ex)
            {
                
            }
            return lstReport;
        }
        public List<TamanoBE> ConsultaTamanoCilindro() 
        {
            ReporteDL reporte = new ReporteDL();
            List<TamanoBE> lstReport = new List<TamanoBE>();
            try
            {
                lstReport = reporte.ConsultarTamanosCilindros();
            }
            catch (Exception ex)
            {
                
            }
            return lstReport;
        }
        public long consultadeExistencia(string dato)
        {
            ReporteDL rep = new ReporteDL();
            long resp = 0;
            try
            {
                resp = rep.ConsultarExistencias(dato);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }
        public List<Ubicacion_CilindroBE> ConsultarCilInventario(ReportesBE reporte)
        {
            List<Ubicacion_CilindroBE> lstResp = new List<Ubicacion_CilindroBE>();

            ReporteDL rep = new ReporteDL();
            try
            {
                lstResp = rep.ConsultarCilInventario(reporte);

                ReportesBE objRep = new ReportesBE();

                foreach (Ubicacion_CilindroBE datos in lstResp)
                {
                    if (datos.Cilindro.NTamano.Tamano == "30")
                    {
                        objRep.SumCil30 += 1;
                    }
                    if (datos.Cilindro.NTamano.Tamano == "40")
                    {
                        objRep.SumCil40 += 1;
                    }
                    if (datos.Cilindro.NTamano.Tamano == "80")
                    {
                        objRep.SumCil80 += 1;
                    }
                    if (datos.Cilindro.NTamano.Tamano == "100")
                    {
                        objRep.SumCil100 += 1;
                    }

                    datos.Reportes = objRep;
                }

            }
            catch (Exception ex)
            {

            }

            return lstResp;
        }
        public List<Tipo_CasoBE> ConsultaTipoCasos()
        {
            ReporteDL reporte = new ReporteDL();
            List<Tipo_CasoBE> lstTipoCaso = new List<Tipo_CasoBE>();
            try
            {
                lstTipoCaso = reporte.ConsultarTipoCasos();
            }
            catch (Exception ex)
            {

            }
            return lstTipoCaso;
        }
        public List<CilindroBE> ReporteSiembrasCilindro(ReportesBE reporte)
        {
            List<CilindroBE> lstResp = new List<CilindroBE>();

            ReporteDL rep = new ReporteDL();
            try
            {
                lstResp = rep.ReporteSiembrasCilindro(reporte);

                ReportesBE objRep = new ReportesBE();

                foreach (CilindroBE datos in lstResp)
                {
                    if (datos.NTamano.Tamano == "30")
                    {
                        objRep.SumCil30 += 1;
                    }
                    if (datos.NTamano.Tamano == "40")
                    {
                        objRep.SumCil40 += 1;
                    }
                    if (datos.NTamano.Tamano == "80")
                    {
                        objRep.SumCil80 += 1;
                    }
                    if (datos.NTamano.Tamano == "100")
                    {
                        objRep.SumCil100 += 1;
                    }
                    datos.Reportes = objRep; 
                }

            }
            catch (Exception ex)
            {

            }

            return lstResp;
        }
        public List<CilindroBE> ReporteSiembrasCiudad(ReportesBE reporte)
        {
            List<CilindroBE> lstResp = new List<CilindroBE>();

            ReporteDL rep = new ReporteDL();
            try
            {
                lstResp = rep.ReporteSiembrasCiudades(reporte);

                ReportesBE objRep = new ReportesBE();

                foreach (CilindroBE datos in lstResp)
                {
                    if (datos.NTamano.Tamano == "30")
                    {
                        objRep.SumCil30 += 1;
                    }
                    if (datos.NTamano.Tamano == "40")
                    {
                        objRep.SumCil40 += 1;
                    }
                    if (datos.NTamano.Tamano == "80")
                    {
                        objRep.SumCil80 += 1;
                    }
                    if (datos.NTamano.Tamano == "100")
                    {
                        objRep.SumCil100 += 1;
                    }
                    datos.Reportes = objRep;                    
                }

            }
            catch (Exception ex)
            {

            }

            return lstResp;
        }
        #endregion
        
        #region Metodos privados
        #endregion
    }
}
