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
    public class UsuarioDL
    {
        public long ConsultarExistenciaUsuarios(string usuario)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaUsuarios";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = usuario;
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
                throw new Exception("Error al acceder a la base de datos para obtener los UsuarioBEs.");
            }
            return codigo;
        }

        public long CrearUsuario(UsuarioBE usuario)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroUsuario";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[14];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrUsuario";
                parametros[0].Value = usuario.Usuario;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 10;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrNombre";
                parametros[1].Value = usuario.Nombre;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 20;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrApellido";
                parametros[2].Value = usuario.Apellido;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 15;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrCedula";
                parametros[3].Value = usuario.Cedula;
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 12;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrContraseña";
                parametros[4].Value = usuario.Contrasena_1;
                parametros[4].Direction = ParameterDirection.Input;
                parametros[4].Size = 80;
                db.Comando.Parameters.Add(parametros[4]);

                parametros[5] = db.Comando.CreateParameter();
                parametros[5].ParameterName = "vrEstado";
                parametros[5].Value = usuario.Estado;
                parametros[5].Direction = ParameterDirection.Input;
                parametros[5].Size = 1;
                db.Comando.Parameters.Add(parametros[5]);

                parametros[6] = db.Comando.CreateParameter();
                parametros[6].ParameterName = "vrGenero";
                parametros[6].Value = usuario.Genero;
                parametros[6].Direction = ParameterDirection.Input;
                parametros[6].Size = 1;
                db.Comando.Parameters.Add(parametros[6]);

                parametros[7] = db.Comando.CreateParameter();
                parametros[7].ParameterName = "vrFecha_Nacimiento";
                parametros[7].Value = usuario.Fecha_Nacim;
                parametros[7].Direction = ParameterDirection.Input;
                parametros[7].Size = 50;
                db.Comando.Parameters.Add(parametros[7]);

                parametros[8] = db.Comando.CreateParameter();
                parametros[8].ParameterName = "vrDireccion";
                parametros[8].Value = usuario.Direccion;
                parametros[8].Direction = ParameterDirection.Input;
                parametros[8].Size = 30;
                db.Comando.Parameters.Add(parametros[8]);

                parametros[9] = db.Comando.CreateParameter();
                parametros[9].ParameterName = "vrCorreo";
                parametros[9].Value = usuario.Correo;
                parametros[9].Direction = ParameterDirection.Input;
                parametros[9].Size = 50;
                db.Comando.Parameters.Add(parametros[9]);

                parametros[10] = db.Comando.CreateParameter();
                parametros[10].ParameterName = "vrTelefono";
                parametros[10].Value = usuario.Telefono;
                parametros[10].Direction = ParameterDirection.Input;
                parametros[10].Size = 10;
                db.Comando.Parameters.Add(parametros[10]);

                parametros[11] = db.Comando.CreateParameter();
                parametros[11].ParameterName = "vrId_Perfil";
                parametros[11].Value = usuario.Perfil;
                parametros[11].Direction = ParameterDirection.Input;
                parametros[11].Size = 18;
                db.Comando.Parameters.Add(parametros[11]);

                parametros[12] = db.Comando.CreateParameter();
                parametros[12].ParameterName = "vrCodResult";
                parametros[12].Value = 0;
                parametros[12].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[12]);

                parametros[13] = db.Comando.CreateParameter();
                parametros[13].ParameterName = "vrDescResult";
                parametros[13].Value = "";
                parametros[13].Direction = ParameterDirection.Output;
                parametros[13].Size = 200;
                parametros[13].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[13]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[12].Value.ToString());
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                db.CancelarTransaccion();
                throw new Exception("Error al crear el UsuarioBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

    }
}
