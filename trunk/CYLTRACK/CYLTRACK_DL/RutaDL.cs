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
    public class RutaDL
    {
        public List<CiudadBE> ConsultaDepartamentoyCiudades()
        {
           List<CiudadBE> ciudadesDepart = new List<CiudadBE>();
            
            try
            {
                string nameSP = "ConsultarCiudadesyDepartamentos";
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
                CiudadBE c = null;
                while (datos.Read())
                {
                    try
                    {
                        c = new CiudadBE();
                        DepartamentoBE dep = new DepartamentoBE();
                        dep.Id_Departamento = datos.GetValue(0).ToString();
                        dep.Nombre_Departamento = datos.GetString(1);
                        c.Id_Ciudad = datos.GetValue(2).ToString();
                        c.Nombre_Ciudad= (datos.GetString(3));
                        c.Departamento= dep;
                        ciudadesDepart.Add(c);

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
                throw new Exception("Error al acceder a la base de datos para obtener los CilindroBEs.");
            }
            return ciudadesDepart;
            }

        public long CrearRuta(RutaBE ruta)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroRutas";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[5];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrNombre";
                parametros[0].Value = ruta.Nombre_Ruta;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 30;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrCiudades";
                parametros[1].Value = ruta.Ciudad_Ruta.Ciudad.Nombre_Ciudad;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 20;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrSeparador";
                parametros[2].Value = ",";
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 20;
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

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[3].Value.ToString());
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                db.CancelarTransaccion();
                throw new Exception("Error al crear la RutaBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }
        
        public List<RutaBE> ConsultarRutas(string ruta)
        {
            List<RutaBE> lstRuta = new List<RutaBE>();
            try
            {
                string nameSP = "ConsultarRutas";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrNombre";
                parametros[0].Value = ruta;
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
                RutaBE r = null;
                while (datos.Read())
                {
                    try
                    {
                        r = new RutaBE();
                        r.Id_Ruta = (datos.GetValue(0).ToString());
                        r.Nombre_Ruta = datos.GetString(1);
                        Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                        CiudadBE ciu = new CiudadBE();
                        ciu.Id_Ciudad = (datos.GetValue(2).ToString());
                        ciu.Nombre_Ciudad = datos.GetString(3);
                        DepartamentoBE dep = new DepartamentoBE();
                        dep.Id_Departamento = (datos.GetValue(4).ToString());
                        dep.Nombre_Departamento = datos.GetString(5);
                        ciu.Departamento = dep;
                        ciuRuta.Ciudad = ciu;
                        r.Ciudad_Ruta = ciuRuta;
                        lstRuta.Add(r);                        
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
                throw new Exception("Error al acceder a la base de datos para obtener los RutaBEs.");
            }
            return lstRuta;

        }

        public long ConsultaExistenciaRuta(string ruta)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaRutas";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = ruta;
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
                throw new Exception("Error al acceder a la base de datos para obtener los RutaBEs.");
            }
            return codigo;

        }

       }    
}
