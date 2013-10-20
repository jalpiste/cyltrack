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
        public List<PruebaBE> ConsultarPruebaBEs()
        {
            List<PruebaBE> pruebas = new List<PruebaBE>();
            try
            {
                string nameSP = "spConsultaPrueba";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);

                DbDataReader datos = db.EjecutarConsulta();
                PruebaBE p = null;
                while (datos.Read())
                {
                    try
                    {
                        p = new PruebaBE();
                        p.IdPrueba = datos.GetInt32(0);
                        p.Descripción = datos.GetString(1);
                        //p.Fecha = datos.GetString(2);
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
                int cod=90;
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

        public void ModificarPruebaBE(PruebaBE prueba)
        {
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "spModificarPrueba";
                db.CrearComandoSP(nameSP);
                db.setParametrosSP("id", prueba.IdPrueba, "descripcion", prueba.Descripción, "fecha", prueba.Fecha);
                db.EjecutarComando();
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                db.CancelarTransaccion();
                throw new Exception("Error al actualizar el objeto Prueba.", ex);
            }

            finally
            {
                db.Desconectar();
            }
        }
    }
}
