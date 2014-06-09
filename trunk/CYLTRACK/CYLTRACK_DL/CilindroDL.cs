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

                DbParameter[] parametros = new DbParameter[11];
                
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
                parametros[3].ParameterName = "vrIdTamano";
                parametros[3].Value = cil.NTamano.Id_Tamano;
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
                parametros[5].ParameterName = "vrId_Tipo_Ubica";
                parametros[5].Value = cil.Tipo_Ubicacion.Id_Tipo_Ubica;
                parametros[5].Direction = ParameterDirection.Input;
                parametros[5].Size = 4;
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
                parametros[8].ParameterName = "vrId_Vehiculo";
                parametros[8].Value = cil.Vehiculo.Id_Vehiculo;
                parametros[8].Direction = ParameterDirection.Input;
                parametros[8].Size = 6;
                db.Comando.Parameters.Add(parametros[8]);

                parametros[9] = db.Comando.CreateParameter();
                parametros[9].ParameterName = "vrCodResult";
                parametros[9].Value = 0;
                parametros[9].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[9]);

                parametros[10] = db.Comando.CreateParameter();
                parametros[10].ParameterName = "vrDescResult";
                parametros[10].Value = "";
                parametros[10].Direction = ParameterDirection.Output;
                parametros[10].Size = 200;
                parametros[10].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[10]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[9].Value.ToString());
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
                        c.Id_Cilindro = datos.GetValue(0).ToString();
                        c.Ano = datos.GetString(1);
                        c.Codigo_Cilindro = datos.GetString(2);
                        c.Tipo_Cilindro = datos.GetString(3);
                        c.Serial_Cilindro = datos.GetString(4); 
                        c.Fecha = datos.GetDateTime(5);
                        FabricanteBE fab = new FabricanteBE();
                        fab.Nombre_Fabricante = (datos.GetValue(6).ToString());
                        c.Fabricante = fab;
                        Tipo_UbicacionBE tipUbi = new Tipo_UbicacionBE();
                        tipUbi.Nombre_Ubicacion= datos.GetString(7);
                        c.Tipo_Ubicacion = tipUbi;
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = (datos.GetString(8));
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

        public long ConsultarExistenciaCilindro(string cil)
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
                parametros[0].ParameterName = "vrDatoConsulta";
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
                string nameSP = "ConsultarExistenciaFabricante";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
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
                        cilindro.Tipo_Cilindro=datos.GetString(1);                        
                        ub.Cilindro = cilindro;
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = (datos.GetString(2));
                        cilindro.NTamano = tam;
                        //VehiculoBE vehiculo = new VehiculoBE();
                        //UbicacionBE ubicacion = new UbicacionBE();
                        //vehiculo.Placa = (datos.GetString(3));
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

        public long ModificarUbicacionCilindro(CilindroBE cil)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CargueyDescargueCilindros";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[6];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCodigosCilindros";
                parametros[0].Value = cil.Codigo_Cilindro;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 100;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrNombreUbi";
                parametros[1].Value = cil.Tipo_Ubicacion.Nombre_Ubicacion;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 15;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrIdVehiculo";
                parametros[2].Value = cil.Vehiculo.Id_Vehiculo;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 6;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrSeparador";
                parametros[3].Value = ",";
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 1;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrCodResult";
                parametros[4].Value = 0;
                parametros[4].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[4]);

                parametros[5] = db.Comando.CreateParameter();
                parametros[5].ParameterName = "vrDescResult";
                parametros[5].Value = "";
                parametros[5].Direction = ParameterDirection.Output;
                parametros[5].Size = 200;
                parametros[5].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[5]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[4].Value.ToString());
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


   }
}
