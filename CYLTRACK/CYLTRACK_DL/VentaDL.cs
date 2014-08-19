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
    public class VentaDL
    {
        public long RegistrarVenta(VentaBE venta)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroVenta";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[11];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdCliente";
                parametros[0].Value = venta.IdCliente;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 18;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrObservaciones";
                parametros[1].Value = venta.Observaciones;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 100;
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
                throw new Exception("Error al crear el VentaBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public long RegistrarDetalleVenta(VentaBE venta)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroDetalleVenta";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[9];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdVenta";
                parametros[0].Value = venta.Id_Venta;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 12;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrTipoCil";
                parametros[1].Value = venta.Detalle_Venta.Tipo_Cilindro;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 9;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrTamano";
                parametros[2].Value = venta.Detalle_Venta.Tamano;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 3;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrCodCilEntrada";
                parametros[3].Value = venta.Detalle_Venta.Id_Cilindro_Entrada;
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 12;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrCodCilSalida";
                parametros[4].Value = venta.Detalle_Venta.Id_Cilindro_Salida;
                parametros[4].Direction = ParameterDirection.Input;
                parametros[4].Size = 12;
                db.Comando.Parameters.Add(parametros[4]);
                
                parametros[5] = db.Comando.CreateParameter();
                parametros[5].ParameterName = "vrIdUbica";
                parametros[5].Value = venta.Id_Ubicacion;
                parametros[5].Direction = ParameterDirection.Input;
                parametros[5].Size = 12;
                db.Comando.Parameters.Add(parametros[5]);

                parametros[6] = db.Comando.CreateParameter();
                parametros[6].ParameterName = "vrIdVehiculo";
                parametros[6].Value = venta.IdVehiculo;
                parametros[6].Direction = ParameterDirection.Input;
                parametros[6].Size = 6;
                db.Comando.Parameters.Add(parametros[6]);

                parametros[7] = db.Comando.CreateParameter();
                parametros[7].ParameterName = "vrCodResult";
                parametros[7].Value = 0;
                parametros[7].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[7]);

                parametros[8] = db.Comando.CreateParameter();
                parametros[8].ParameterName = "vrDescResult";
                parametros[8].Value = "";
                parametros[8].Direction = ParameterDirection.Output;
                parametros[8].Size = 200;
                parametros[8].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[8]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[7].Value.ToString());
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                db.CancelarTransaccion();
                throw new Exception("Error al crear el VentaBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public VentaBE ConsultarVenta(string datoConsulta)
        {
            VentaBE venta = new VentaBE();
            try
            {
                string nameSP = "ConsultarVenta";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = datoConsulta;
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
                VentaBE v = null;
                while (datos.Read())
                {
                    try
                    {
                        v = new VentaBE();
                        v.Fecha = datos.GetDateTime(0);
                        v.Observaciones = datos.GetString(1);
                        venta = v;
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
                throw new Exception("Error al acceder a la base de datos para obtener los VentaBEs.");
            }
            return venta;
        }

        public long ConsultarExistenciasVenta(string venta)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaVenta";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = venta;
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
                throw new Exception("Error al acceder a la base de datos para obtener los VentaBEs.");
            }
            return codigo;
        }

        public long RegistrarCasoEspecial(CasosBE caso)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroCasosEspeciales";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[6];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdTipoCasos";
                parametros[0].Value = caso.Tipo_Caso.Id_Tipo_Caso;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 18;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrIdDetalleVenta";
                parametros[1].Value = caso.Detalle_Venta.Id_Detalle_Venta;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 12;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrObservaciones";
                parametros[2].Value = caso.Observaciones;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 100;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrEstado";
                parametros[3].Value = caso.EstadoCaso;
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
                throw new Exception("Error al crear el CasoBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public long ModificarVenta(Detalle_VentaBE detVenta)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "ModificarDetalleVenta";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[7];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdDetalleVenta";
                parametros[0].Value = detVenta.Id_Detalle_Venta;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 12;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrCodCilEntrada";
                parametros[1].Value = detVenta.Id_Cilindro_Entrada;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 12;
                db.Comando.Parameters.Add(parametros[1]);
                
                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrCodCilSalida";
                parametros[2].Value = detVenta.Id_Cilindro_Salida;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 12;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrIdVehiculo";
                parametros[3].Value = detVenta.Id_Vehiculo;
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 6;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrIdUbicacion";
                parametros[4].Value = detVenta.Id_Ubicacion;
                parametros[4].Direction = ParameterDirection.Input;
                parametros[4].Size = 12;
                db.Comando.Parameters.Add(parametros[4]);

                parametros[5] = db.Comando.CreateParameter();
                parametros[5].ParameterName = "vrCodResult";
                parametros[5].Value = 0;
                parametros[5].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[5]);

                parametros[6] = db.Comando.CreateParameter();
                parametros[6].ParameterName = "vrDescResult";
                parametros[6].Value = "";
                parametros[6].Direction = ParameterDirection.Output;
                parametros[6].Size = 200;
                parametros[6].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[6]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[5].Value.ToString());
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                db.CancelarTransaccion();
                throw new Exception("Error al crear el VentaBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

    }
}
