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
    public class ClienteDL
    {
        public long CrearCliente(ClienteBE cliente)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroCliente";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[11];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCedula";
                parametros[0].Value = cliente.Cedula;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 12;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrNombres";
                parametros[1].Value = cliente.Nombres_Cliente;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size =20;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrApellido_1";
                parametros[2].Value = cliente.Apellido_1;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 12;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrApellido_2";
                parametros[3].Value = cliente.Apellido_2;
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 15;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrDireccion";
                parametros[4].Value = Convert.ToString(cliente.Ubicacion.Direccion);
                parametros[4].Direction = ParameterDirection.Input;
                parametros[4].Size = 30;
                db.Comando.Parameters.Add(parametros[4]);

                parametros[5] = db.Comando.CreateParameter();
                parametros[5].ParameterName = "vrBarrio";
                parametros[5].Value = cliente.Ubicacion.Barrio;
                parametros[5].Direction = ParameterDirection.Input;
                parametros[5].Size = 30;
                db.Comando.Parameters.Add(parametros[5]);

                parametros[6] = db.Comando.CreateParameter();
                parametros[6].ParameterName = "vrTelefono";
                parametros[6].Value = cliente.Ubicacion.Telefono_1;
                parametros[6].Direction = ParameterDirection.Input;
                parametros[6].Size = 10;
                db.Comando.Parameters.Add(parametros[6]);

                parametros[7] = db.Comando.CreateParameter();
                parametros[7].ParameterName = "vrCiudad";
                parametros[7].Value = cliente.Ubicacion.Ciudad.Nombre_Ciudad;
                parametros[7].Direction = ParameterDirection.Input;
                parametros[7].Size = 20;
                db.Comando.Parameters.Add(parametros[7]);


                parametros[8] = db.Comando.CreateParameter();
                parametros[8].ParameterName = "vrDepartamento";
                parametros[8].Value = cliente.Ubicacion.Ciudad.Departamento.Nombre_Departamento;
                parametros[8].Direction = ParameterDirection.Input;
                parametros[8].Size = 20;
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

        public ClienteBE ConsultarCliente(string cliente)
        {
            ClienteBE cli = new ClienteBE();
            try
            {
                string nameSP = "ConsultarClientes";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCedula";
                parametros[0].Value = cliente;
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
                ClienteBE c = null;
                while (datos.Read())
                {
                    try
                    {
                        c = new ClienteBE();
                        c.Cedula = datos.GetString(0);
                        c.Nombres_Cliente = datos.GetValue(1).ToString();
                        c.Apellido_1 = (datos.GetString(2));
                        c.Apellido_2 = (datos.GetString(3));
                        UbicacionBE ubi = new UbicacionBE();
                        List<string> lstDireccion = new List<string>();
                        lstDireccion.Add(datos.GetString(4));
                        ubi.Direccion= lstDireccion;                        
                        ubi.Telefono_1 = datos.GetString(5);
                        ubi.Barrio = datos.GetString(6);
                        CiudadBE ciu = new CiudadBE();
                        ciu.Nombre_Ciudad = datos.GetString(7);                        
                        DepartamentoBE dep = new DepartamentoBE();
                        dep.Nombre_Departamento = datos.GetString(8);
                        ciu.Departamento = dep;
                        ubi.Ciudad = ciu;
                        c.Ubicacion = ubi;
                        cli = c;
                      
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
            return cli;
        }

        public long ConsultarExistenciasClientes(string cli)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaCliente";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCedula";
                parametros[0].Value = cli;
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
        
    }
}
