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
                        c.Nombre_Ciudad= (datos.GetString(2));
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

                DbParameter[] parametros = new DbParameter[4];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrNombre";
                parametros[0].Value = ruta.Nombre_Ruta;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 30;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrCiudad";
                parametros[1].Value = ruta.Ciudad_Ruta.Ciudad.ToString();
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 20;
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
                codigo = long.Parse(db.Comando.Parameters[2].Value.ToString());
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

       }    
}
