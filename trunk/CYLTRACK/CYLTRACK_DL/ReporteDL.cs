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
                        tp.Id_Tipo_Ubica = Int32.Parse(datos.GetValue(0).ToString()); 
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
                        tam.Id_Tamano = Int32.Parse(datos.GetValue(0).ToString());
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
        public long ConsultarExistenciasVarios(string dato)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaDatos2";
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
        
    }
}
