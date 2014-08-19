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
    public class PedidoDL
    {
        public long CrearPedido(PedidoBE pedido)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroPedido";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[5];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrId_Cliente";
                parametros[0].Value = pedido.IdCliente;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 18;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrDetalle";
                parametros[1].Value = pedido.Detalle;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 100;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrEstado";
                parametros[2].Value = pedido.Estado;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 1;
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
                throw new Exception("Error al crear el PedidoBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public long CrearRegistroDetallePedido(Detalle_PedidoBE Detalle_Pedido)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroDetallePedido";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[5];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdPedido";
                parametros[0].Value = Detalle_Pedido.Id_Pedido;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 12;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrCantidad";
                parametros[1].Value = Detalle_Pedido.Cantidad;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 100;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrTamano";
                parametros[2].Value = Detalle_Pedido.Tamano;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 100;
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
                throw new Exception("Error al crear el Detalle_PedidoBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public PedidoBE ConsultarPedido(string pedido)
        {
            PedidoBE ped = new PedidoBE();
            try
            {
                string nameSP = "ConsultarPedido";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = pedido;
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
                PedidoBE p = null;
                List<Detalle_PedidoBE> lstDetPed = new List<Detalle_PedidoBE>();
                while (datos.Read())
                {
                    try
                    {
                        p = new PedidoBE();
                        p.Id_Pedido = datos.GetValue(0).ToString();
                        p.IdCliente = datos.GetValue(1).ToString();
                        Detalle_PedidoBE detPed = new Detalle_PedidoBE();
                        detPed.Fecha = datos.GetDateTime(2);
                        p.Detalle = (datos.GetString(3));                        
                        detPed.Cantidad = datos.GetString(4);
                        detPed.Tamano = datos.GetString(5);
                        p.Estado = datos.GetString(6);
                        p.IdCliente = datos.GetValue(7).ToString();
                        lstDetPed.Add(detPed);
                        p.List_Detalle_Ped=(lstDetPed);                        
                        ped = p;  
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
                throw new Exception("Error al acceder a la base de datos para obtener los PedidoBEs.");
            }
            return ped;
        }

       public long ModificarPedido(PedidoBE pedido)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "ModificarPedido";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[4];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdPedido";
                parametros[0].Value = pedido.Id_Pedido;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 12;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrObservaciones";
                parametros[1].Value = pedido.Detalle;
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
                throw new Exception("Error al modificar el PedidoBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public long ModificarDetallePedido(Detalle_PedidoBE detallePedido)
       {
           long codigo = 0;
           BaseDatos db = new BaseDatos();
           try
           {
               db.Conectar();
               db.ComenzarTransaccion();
               string nameSP = "ModificarDetallePedido";
               db.CrearComandoSP(nameSP);

               DbParameter[] parametros = new DbParameter[5];

               parametros[0] = db.Comando.CreateParameter();
               parametros[0].ParameterName = "vrCantidad";
               parametros[0].Value = detallePedido.Cantidad;
               parametros[0].Direction = ParameterDirection.Input;
               parametros[0].Size = 4;
               db.Comando.Parameters.Add(parametros[0]);

               parametros[1] = db.Comando.CreateParameter();
               parametros[1].ParameterName = "vrTamano";
               parametros[1].Value = detallePedido.Tamano;
               parametros[1].Direction = ParameterDirection.Input;
               parametros[1].Size = 3;
               db.Comando.Parameters.Add(parametros[1]);

               parametros[2] = db.Comando.CreateParameter();
               parametros[2].ParameterName = "vrIdPedido";
               parametros[2].Value = detallePedido.Id_Pedido;
               parametros[2].Direction = ParameterDirection.Input;
               parametros[2].Size = 12;
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
               throw new Exception("Error al modificar el Detalle_PedidoBE.", ex);
           }

           finally
           {
               db.Desconectar();
           }
           return codigo;
       }

        public long ConsultaExistenciaPedido(string pedido)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaPedido";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = pedido;
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
                throw new Exception("Error al acceder a la base de datos para obtener los PedidoBEs.");
            }
            return codigo;

        }

        public long CancelarPedido(PedidoBE pedido)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CancelarPedido";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[4];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdPedido";
                parametros[0].Value = pedido.Id_Pedido;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 12;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrMotivoCancel";
                parametros[1].Value = pedido.Motivo_Cancel;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 200;
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
                throw new Exception("Error al crear el PedidoBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

    }
}
