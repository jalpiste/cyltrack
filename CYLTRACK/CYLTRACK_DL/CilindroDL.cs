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
   public class CilindroDL
    {
        public long CrearCilindro(CilindroBE cil)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroCilindro";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[10];
                
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrAno";
                parametros[0].Value = cil.Ano;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 4;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrCodigo_Fabricante";
                parametros[1].Value = cil.Fabricante.Codigo_Fabricante;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 5;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrCodigo_Cilindro";
                parametros[2].Value = cil.Codigo_Cilindro;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 12;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrTamano";
                parametros[3].Value = cil.NTamano.Tamano;
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 3;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrEstado";
                parametros[4].Value = cil.Estado;
                parametros[4].Direction = ParameterDirection.Input;
                parametros[4].Size = 10;
                db.Comando.Parameters.Add(parametros[4]);

                parametros[5] = db.Comando.CreateParameter();
                parametros[5].ParameterName = "vrNombre_Ubicacion";
                parametros[5].Value = cil.Ubicacion_Cilindro.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion;
                parametros[5].Direction = ParameterDirection.Input;
                parametros[5].Size = 15;
                db.Comando.Parameters.Add(parametros[5]);

                parametros[6] = db.Comando.CreateParameter();
                parametros[6].ParameterName = "vrTipo_Cilindro";
                parametros[6].Value = cil.Tipo_Cilindro;
                parametros[6].Direction = ParameterDirection.Input;
                parametros[6].Size = 9;
                db.Comando.Parameters.Add(parametros[6]);

                parametros[7] = db.Comando.CreateParameter();
                parametros[7].ParameterName = "vrSerial_Cilindro";
                parametros[7].Value = cil.Serial_Cilindro;
                parametros[7].Direction = ParameterDirection.Input;
                parametros[7].Size = 6;
                db.Comando.Parameters.Add(parametros[7]);

                parametros[8] = db.Comando.CreateParameter();
                parametros[8].ParameterName = "vrCodResult";
                parametros[8].Value = 0;
                parametros[8].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[8]);

                parametros[9] = db.Comando.CreateParameter();
                parametros[9].ParameterName = "vrDescResult";
                parametros[9].Value = "";
                parametros[9].Direction = ParameterDirection.Output;
                parametros[9].Size = 200;
                parametros[9].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[9]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[8].Value.ToString());
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                db.CancelarTransaccion();
                throw new Exception("Error al crear el CilindroBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public CilindroBE ConsultarCilindro(string cilindro)
        {
            CilindroBE cil = new CilindroBE();
            try
            {
                string nameSP = "ConsultarCilindros";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCodigo_Cilindro";
                parametros[0].Value = cilindro;
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
                CilindroBE c = null;
                while (datos.Read())
                {
                    try
                    {
                        c = new CilindroBE();
                        c.Ano = datos.GetString(0);
                        c.Codigo_Cilindro = (datos.GetString(1));
                        c.Tipo_Cilindro = datos.GetString(2);
                        c.Serial_Cilindro = datos.GetString(3);
                        c.Fecha = datos.GetDateTime(4);
                        FabricanteBE fab = new FabricanteBE();
                        fab.Nombre_Fabricante = (datos.GetValue(5).ToString());
                        c.Fabricante = fab;
                        Ubicacion_CilindroBE ubiCil = new Ubicacion_CilindroBE();
                        UbicacionBE ubi = new UbicacionBE();
                        ubi.Ubicacion_Cilindro = ubiCil;
                        Tipo_UbicacionBE tipoUbica = new Tipo_UbicacionBE();
                        tipoUbica.Nombre_Ubicacion = datos.GetString(6);
                        ubi.Tipo_Ubicacion = tipoUbica;
                        ubiCil.Ubicacion = ubi;
                        c.Ubicacion_Cilindro = ubiCil;
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano= (datos.GetString(7));
                        c.NTamano = tam;                        
                        cil= c;
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
            return cil;
        }

        public long ConsultarExistencias(string cil)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaCilindro";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCodigoCilindro";
                parametros[0].Value = cil;
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
                throw new Exception("Error al acceder a la base de datos para obtener los CilindroBEs.");
            }
            return codigo;
        }
        
        public long ConsultaCodigoFabricante(string codigoFabricante)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarCodigoFabricante";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCodigo_Fabricante";
                parametros[0].Value = codigoFabricante;
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
                throw new Exception("Error al acceder a la base de datos para obtener los CilindroBEs.");
            }
            return codigo;
        
        }

        public List<Ubicacion_CilindroBE> ConsultarCilUbicacion(string ubica)
        {
            List<Ubicacion_CilindroBE> ubicacionCil = new List<Ubicacion_CilindroBE>();
            try
            {
                string nameSP = "ConsultarUbicacionCilindros";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrTipoUbicacion";
                parametros[0].Value = ubica;
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
                        ub = new Ubicacion_CilindroBE ();
                        CilindroBE cilindro = new CilindroBE();
                        cilindro.Codigo_Cilindro = (datos.GetString(0));
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = (datos.GetString(1));
                        cilindro.NTamano = tam;
                        cilindro.Tipo_Cilindro=datos.GetString(2);                        
                        ub.Cilindro = cilindro;
                        //VehiculoBE vehiculo = new VehiculoBE();
                        //UbicacionBE ubicacion = new UbicacionBE();
                        //vehiculo.Placa = (datos.GetString(0));
                        //ubicacion.Vehiculo = vehiculo;
                        //ub.Ubicacion = ubicacion;
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
                throw new Exception("Error al acceder a la base de datos para obtener los CilindroBEs.");
            }
            return ubicacionCil;
        }

   }
}
