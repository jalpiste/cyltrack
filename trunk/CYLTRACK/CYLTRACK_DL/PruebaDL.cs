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
    public class PruebaDL
    {
        public List<PruebaBE> ConsultarPruebas(int idPrueba)
        {
            List<PruebaBE> pruebas = new List<PruebaBE>();
            try
            {
                string nameSP = "ConsultarPruebas";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdPrueba";
                parametros[0].Value = idPrueba;
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
                PruebaBE p = null;
                while (datos.Read())
                {
                    try
                    {
                        p = new PruebaBE();
                        p.IdPrueba = Int32.Parse(datos.GetValue(0).ToString());
                        p.Descripción = datos.GetString(1);
                        p.Fecha = datos.GetDateTime(2);
                        pruebas.Add(p);
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
                throw new Exception("Error al acceder a la base de datos para obtener los PruebaBEs.");
            }
            return pruebas;
        }

        public long GuardarPruebaBE(PruebaBE pru)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistro";
                string descripcion = "";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDescripcion";
                parametros[0].Value = pru.Descripción;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 50;
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

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[1].Value.ToString());
                descripcion = db.Comando.Parameters[2].Value.ToString();
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                db.CancelarTransaccion();
                throw new Exception("Error al crear el PruebaBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public int ModificarPrueba(PruebaBE prueba)
        {
            int resp = -1;
            string descripcion = "";
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "ModificarPrueba";
                db.CrearComandoSP(nameSP);
                //db.setParametrosSP("id", prueba.IdPrueba, "descripcion", prueba.Descripción, "fecha", prueba.Fecha);

                DbParameter[] parametros = new DbParameter[4];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDescripcion";
                parametros[0].Value = prueba.Descripción;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 50;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrIdPrueba";
                parametros[1].Value = prueba.IdPrueba;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 50;
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

                db.EjecutarComando();
                resp = int.Parse(db.Comando.Parameters[2].Value.ToString());
                descripcion = db.Comando.Parameters[3].Value.ToString();
                db.EjecutarComando();
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                resp = -1;
                db.CancelarTransaccion();
                throw new Exception("Error al actualizar el objeto Prueba.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return resp;
        }
    }
}
