/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Deerechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Data;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_DL
{
    public class ReporteDL
    {
        public IList<Tipo_UbicacionBE> ConsultarTipoUbicaciones()
        {
            IList<Tipo_UbicacionBE> lstTipoUbicacion = new List<Tipo_UbicacionBE>();
            try
            {
                string nameSP = "ConsultarTipoUbicaciones";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[2];
                
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCodResult";
                parametros[0].Value = 0;
                parametros[0].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrDescResult";
                parametros[1].Value = "";
                parametros[1].Direction = ParameterDirection.Output;
                parametros[1].Size = 200;
                parametros[1].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[1]);

                DbDataReader datos = db.EjecutarConsulta();
                Tipo_UbicacionBE tp = null;
                while (datos.Read())
                {
                    try
                    {
                        tp = new Tipo_UbicacionBE();
                        tp.Id_Tipo_Ubica = (datos.GetValue(0).ToString()); 
                        tp.Nombre_Ubicacion = datos.GetString(1);
                        lstTipoUbicacion.Add(tp);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new Exception("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new Exception("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al acceder a la base de datos para obtener los Tipo_UbicacionBEs.");
            }
            return lstTipoUbicacion;
        }
        public List<TamanoBE> ConsultarTamanosCilindros()
        {
            List<TamanoBE> lstTamanosCilindros = new List<TamanoBE>();
            try
            {
                string nameSP = "ConsultarTamanosCilindros";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[2];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCodResult";
                parametros[0].Value = 0;
                parametros[0].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrDescResult";
                parametros[1].Value = "";
                parametros[1].Direction = ParameterDirection.Output;
                parametros[1].Size = 200;
                parametros[1].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[1]);

                DbDataReader datos = db.EjecutarConsulta();
                TamanoBE tam = null;
                while (datos.Read())
                {
                    try
                    {
                        tam = new TamanoBE();
                        tam.Id_Tamano = datos.GetValue(0).ToString();
                        tam.Tamano = datos.GetString(1);
                        tam.Descripcion = datos.GetString(2);
                        lstTamanosCilindros.Add(tam);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new Exception("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new Exception("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al acceder a la base de datos para obtener los TamanoBEs.");
            }
            return lstTamanosCilindros;
        }
        public long ConsultarExistencias(string dato)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaDatos";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = dato;
                parametros[0].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrCodResult";
                parametros[1].Value = 0;
                parametros[1].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrDescResult";
                parametros[2].Value = "";
                parametros[2].Direction = ParameterDirection.Output;
                parametros[2].Size = 200;
                parametros[2].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[2]);

                DbDataReader datos = db.EjecutarConsulta();
                while (datos.Read())
                {
                    try
                    {
                        codigo = long.Parse(datos.GetValue(0).ToString());
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new Exception("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new Exception("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al acceder a la base de datos");
            }
            return codigo;
        }
        public List<Ubicacion_CilindroBE> ConsultarCilInventario(ReportesBE reporte)
        {
            List<Ubicacion_CilindroBE> ubicacionCil = new List<Ubicacion_CilindroBE>();
            try
            {
                string nameSP = "ConsultarCilInventario";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[5];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrTipoUbicacion";
                parametros[0].Value = reporte.IdUbicacion;
                parametros[0].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrFecha";
                parametros[1].Value = reporte.Fecha_Inicial;
                parametros[1].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrTipoCil";
                parametros[2].Value = reporte.Tipo_Cilindro;
                parametros[2].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrCodResult";
                parametros[3].Value = 0;
                parametros[3].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrDescResult";
                parametros[4].Value = "";
                parametros[4].Direction = ParameterDirection.Output;
                parametros[4].Size = 200;
                parametros[4].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[4]);

                DbDataReader datos = db.EjecutarConsulta();
                Ubicacion_CilindroBE ub = null;

                while (datos.Read())
                {
                    try
                    {
                        ub = new Ubicacion_CilindroBE();
                        CilindroBE cilindro = new CilindroBE();
                        cilindro.Codigo_Cilindro = (datos.GetString(0));
                        cilindro.Tipo_Cilindro = datos.GetString(1);
                        ub.Cilindro = cilindro;
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = (datos.GetString(2));
                        cilindro.NTamano = tam;
                        ub.Nombre_Ubicacion = datos.GetString(3);

                        ubicacionCil.Add(ub);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new Exception("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new Exception("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al acceder a la base de datos para obtener los ReporteBEs.");
            }
            return ubicacionCil;
        }
        public List<Tipo_CasoBE> ConsultarTipoCasos()
        {
            List<Tipo_CasoBE> lstTipoCasos = new List<Tipo_CasoBE>();
            try
            {
                string nameSP = "ConsultarTipoCasos";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[2];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCodResult";
                parametros[0].Value = 0;
                parametros[0].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrDescResult";
                parametros[1].Value = "";
                parametros[1].Direction = ParameterDirection.Output;
                parametros[1].Size = 200;
                parametros[1].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[1]);

                DbDataReader datos = db.EjecutarConsulta();
                Tipo_CasoBE tc = null;
                while (datos.Read())
                {
                    try
                    {
                        tc = new Tipo_CasoBE();
                        tc.Id_Tipo_Caso = datos.GetValue(0).ToString();
                        tc.Nombre_Caso = datos.GetString(1);
                        tc.Descripcion_Tipo_Caso = datos.GetString(2);
                        lstTipoCasos.Add(tc);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new Exception("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new Exception("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al acceder a la base de datos para obtener los TipoCasosBEs.");
            }
            return lstTipoCasos;
        }
        public List<Ubicacion_CilindroBE> ConsultarHistoricoCilindro(string codigo)
        {
            List<Ubicacion_CilindroBE> ubicacionCil = new List<Ubicacion_CilindroBE>();
            try
            {
                string nameSP = "ConsultarHistorialCilindro";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCodigoCil";
                parametros[0].Value = codigo;
                parametros[0].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[0]);

                
                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrCodResult";
                parametros[1].Value = 0;
                parametros[1].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrDescResult";
                parametros[2].Value = "";
                parametros[2].Direction = ParameterDirection.Output;
                parametros[2].Size = 200;
                parametros[2].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[2]);

                DbDataReader datos = db.EjecutarConsulta();
                Ubicacion_CilindroBE ub = null;

                while (datos.Read())
                {
                    try
                    {
                        ub = new Ubicacion_CilindroBE();
                        CilindroBE cilindro = new CilindroBE();
                        cilindro.Id_Cilindro = (datos.GetValue(0).ToString());
                        cilindro.Tipo_Cilindro = datos.GetString(1);                        
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = (datos.GetString(2));
                        cilindro.NTamano = tam;
                        cilindro.Fecha = datos.GetDateTime(3);
                        ub.Cilindro = cilindro;
                        ub.Id_Ubicacion_Cilindro = datos.GetValue(4).ToString();
                        ub.Nombre_Ubicacion = datos.GetString(5);
                        ubicacionCil.Add(ub);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new Exception("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new Exception("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al acceder a la base de datos para obtener los ReporteBEs.");
            }
            return ubicacionCil;
        }

        public List<CilindroBE> ReporteSiembrasCilindro(ReportesBE reporte)
        {
            List<CilindroBE> lstReporte = new List<CilindroBE>();
            try
            {
                string nameSP = "ReporteSiembrasPorCilindro";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[4];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrFechaInicial";
                parametros[0].Value = reporte.Fecha_Inicial;
                parametros[0].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrFechaFinal";
                parametros[1].Value = reporte.Fecha_Final;
                parametros[1].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrCodResult";
                parametros[2].Value = 0;
                parametros[2].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrDescResult";
                parametros[3].Value = "";
                parametros[3].Direction = ParameterDirection.Output;
                parametros[3].Size = 200;
                parametros[3].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[3]);

                DbDataReader datos = db.EjecutarConsulta();
                CilindroBE cil = null;

                while (datos.Read())
                {
                    try
                    {
                        cil = new CilindroBE();
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = (datos.GetString(0));
                        cil.NTamano = tam;
                        cil.Codigo_Cilindro = datos.GetString(1);                        
                        lstReporte.Add(cil);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new Exception("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new Exception("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al acceder a la base de datos para obtener los ReporteBEs.");
            }
            return lstReporte;
        }

        public List<CilindroBE> ReporteSiembrasCiudades(ReportesBE reporte)
        {
            List<CilindroBE> lstReporte = new List<CilindroBE>();
            try
            {
                string nameSP = "ReporteSiembrasPorCiudad";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[5];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrTipoConsulta";
                parametros[0].Value = reporte.IdUbicacion;
                parametros[0].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrFechaInicial";
                parametros[1].Value = reporte.Fecha_Inicial;
                parametros[1].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrFechaFinal";
                parametros[2].Value = reporte.Fecha_Final;
                parametros[2].Direction = ParameterDirection.Input;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrCodResult";
                parametros[3].Value = 0;
                parametros[3].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrDescResult";
                parametros[4].Value = "";
                parametros[4].Direction = ParameterDirection.Output;
                parametros[4].Size = 200;
                parametros[4].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[4]);

                DbDataReader datos = db.EjecutarConsulta();
                CilindroBE cil = null;

                while (datos.Read())
                {
                    try
                    {
                        cil = new CilindroBE();
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = (datos.GetString(0));
                        cil.NTamano = tam;
                        cil.Codigo_Cilindro = datos.GetString(1);
                        lstReporte.Add(cil);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new Exception("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new Exception("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al acceder a la base de datos para obtener los ReporteBEs.");
            }
            return lstReporte;
        }
    }
}
