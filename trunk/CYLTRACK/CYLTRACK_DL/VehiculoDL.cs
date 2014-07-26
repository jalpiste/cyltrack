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
    public class VehiculoDL
    {
        public long CrearVehiculo(VehiculoBE vehiculo)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroVehiculo";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[12];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrPlaca";
                parametros[0].Value = vehiculo.Placa;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 6;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrMarca";
                parametros[1].Value = vehiculo.Marca;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 20;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrCilindraje";
                parametros[2].Value = vehiculo.Cilindraje;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 6;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrModelo";
                parametros[3].Value = vehiculo.Modelo;
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 4;
                db.Comando.Parameters.Add(parametros[3]);

                
                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrMotor";
                parametros[4].Value = vehiculo.Motor;
                parametros[4].Direction = ParameterDirection.Input;
                parametros[4].Size = 30;
                db.Comando.Parameters.Add(parametros[4]);

                parametros[5] = db.Comando.CreateParameter();
                parametros[5].ParameterName = "vrChasis";
                parametros[5].Value = vehiculo.Chasis;
                parametros[5].Direction = ParameterDirection.Input;
                parametros[5].Size = 30;
                db.Comando.Parameters.Add(parametros[5]);

                parametros[6] = db.Comando.CreateParameter();
                parametros[6].ParameterName = "vrEstado";
                parametros[6].Value = vehiculo.Estado;
                parametros[6].Direction = ParameterDirection.Input;
                parametros[6].Size = 1;
                db.Comando.Parameters.Add(parametros[6]);

                parametros[7] = db.Comando.CreateParameter();
                parametros[7].ParameterName = "vrCedulaCond";
                parametros[7].Value = vehiculo.Conductor.Cedula;
                parametros[7].Direction = ParameterDirection.Input;
                parametros[7].Size = 12;
                db.Comando.Parameters.Add(parametros[7]);

                parametros[8] = db.Comando.CreateParameter();
                parametros[8].ParameterName = "vrIdRuta";
                parametros[8].Value = vehiculo.Ruta.Id_Ruta;
                parametros[8].Direction = ParameterDirection.Input;
                parametros[8].Size = 30;
                db.Comando.Parameters.Add(parametros[8]);

                parametros[9] = db.Comando.CreateParameter();
                parametros[9].ParameterName = "vrCedulaContra";
                parametros[9].Value = vehiculo.Contratista.Cedula;
                parametros[9].Direction = ParameterDirection.Input;
                parametros[9].Size = 12;
                db.Comando.Parameters.Add(parametros[9]);

                parametros[10] = db.Comando.CreateParameter();
                parametros[10].ParameterName = "vrCodResult";
                parametros[10].Value = 0;
                parametros[10].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[10]);

                parametros[11] = db.Comando.CreateParameter();
                parametros[11].ParameterName = "vrDescResult";
                parametros[11].Value = "";
                parametros[11].Direction = ParameterDirection.Output;
                parametros[11].Size = 200;
                parametros[11].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[11]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[10].Value.ToString());
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                db.CancelarTransaccion();
                throw new Exception("Error al crear la VehiculoBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public ConductorBE ConsultarConductor(string cedula)
        {
            ConductorBE cond = new ConductorBE();
            try
            {
                string nameSP = "ConsultarConductor";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCedula";
                parametros[0].Value = cedula;
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
                ConductorBE c = null;
                while (datos.Read())
                {
                    try
                    {
                        c = new ConductorBE();
                        c.Id_Conductor = datos.GetValue(0).ToString();
                        c.Cedula = datos.GetString(1);
                        c.Nombres_Conductor = datos.GetString(2);
                        c.Apellido_1 = (datos.GetString(3));
                        c.Apellido_2 = (datos.GetString(4));
                        c.Direccion = datos.GetString(5);
                        c.Telefono = datos.GetString(6);
                        cond = c;

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
                throw new Exception("Error al acceder a la base de datos para obtener los VehiculoBEs.");
            }
            return cond;
        }

        public ContratistaBE ConsultarPropVehiculo(string cedula)
        {
            ContratistaBE contratista = new ContratistaBE();
            try
            {
                string nameSP = "ConsultarContratista";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCedula";
                parametros[0].Value = cedula;
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
                ContratistaBE c = null;
                while (datos.Read())
                {
                    try
                    {
                        c = new ContratistaBE();
                        c.Id_Contratista = datos.GetValue(0).ToString();
                        c.Cedula = datos.GetString(1);
                        c.Nombres = datos.GetString(2);
                        c.Apellidos = (datos.GetString(3));
                        contratista = c;
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
                throw new Exception("Error al acceder a la base de datos para obtener los ContratistaBEs.");
            }
            return contratista;
        }
        
        public long RegistrarConductor(ConductorBE conductor)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroConductor";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[10];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCedula";
                parametros[0].Value = conductor.Cedula;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 12;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrNombres";
                parametros[1].Value = conductor.Nombres_Conductor;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 20;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrApellido_1";
                parametros[2].Value = conductor.Apellido_1;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 12;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrApellido_2";
                parametros[3].Value = conductor.Apellido_2;
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 15;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrDireccion";
                parametros[4].Value = conductor.Direccion;
                parametros[4].Direction = ParameterDirection.Input;
                parametros[4].Size = 30;
                db.Comando.Parameters.Add(parametros[4]);

                parametros[5] = db.Comando.CreateParameter();
                parametros[5].ParameterName = "vrBarrio";
                parametros[5].Value = conductor.Barrio;
                parametros[5].Direction = ParameterDirection.Input;
                parametros[5].Size = 30;
                db.Comando.Parameters.Add(parametros[5]);

                parametros[6] = db.Comando.CreateParameter();
                parametros[6].ParameterName = "vrTelefono";
                parametros[6].Value = conductor.Telefono;
                parametros[6].Direction = ParameterDirection.Input;
                parametros[6].Size = 10;
                db.Comando.Parameters.Add(parametros[6]);

                parametros[7] = db.Comando.CreateParameter();
                parametros[7].ParameterName = "vrCiudad";
                parametros[7].Value = conductor.Ciudad.Nombre_Ciudad;
                parametros[7].Direction = ParameterDirection.Input;
                parametros[7].Size = 20;
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
                throw new Exception("Error al crear el VehiculoBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public List<VehiculoBE> ConsultarVehiculo(string placa)
        {
            List<VehiculoBE> lstVehiculo = new List<VehiculoBE>();
            try
            {
                string nameSP = "ConsultarVehiculos";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrPlaca";
                parametros[0].Value = placa;
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
                VehiculoBE v = null;
                while (datos.Read())
                {
                    try
                    {
                        v = new VehiculoBE();
                        v.Id_Vehiculo = datos.GetValue(0).ToString();
                        v.Placa = datos.GetString(1);
                        v.Estado = datos.GetString(2);
                        v.Marca = datos.GetString(3);
                        v.Cilindraje = datos.GetString(4);
                        v.Modelo = datos.GetString(5);
                        v.Motor = datos.GetString(6);
                        v.Chasis = datos.GetString(7);
                        ConductorBE cond = new ConductorBE();
                        cond.Id_Conductor = datos.GetValue(8).ToString();
                        cond.Nombres_Conductor = datos.GetString(9);
                        cond.Apellido_1 = datos.GetString(10);
                        cond.Apellido_2 = datos.GetString(11);
                        cond.Cedula = datos.GetString(12);
                        RutaBE ruta = new RutaBE();
                        ruta.Id_Ruta = datos.GetValue(13).ToString();
                        ruta.Nombre_Ruta = datos.GetString(14);
                        v.Id_Ubicacion = datos.GetValue(15).ToString();
                        ContratistaBE contratista = new ContratistaBE();
                        contratista.Id_Contratista = datos.GetValue(16).ToString();
                        contratista.Cedula = datos.GetString(17);
                        contratista.Nombres = datos.GetString(18);
                        contratista.Apellidos = datos.GetString(19);
                        v.Contratista = contratista;
                        v.Conductor = cond;
                        v.Ruta = ruta;
                        lstVehiculo.Add(v);

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
                throw new Exception("Error al acceder a la base de datos para obtener los VehiculoBEs.");
            }
            return lstVehiculo;
        }

        public long ModificarVehiculo(VehiculoBE vehiculo)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "ModificarVehiculo";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[12];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrPlaca";
                parametros[0].Value = vehiculo.Placa;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 6;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrMarca";
                parametros[1].Value = vehiculo.Marca;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 20;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrCilindraje";
                parametros[2].Value = vehiculo.Cilindraje;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 6;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrModelo";
                parametros[3].Value = vehiculo.Modelo;
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 4;
                db.Comando.Parameters.Add(parametros[3]);


                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrMotor";
                parametros[4].Value = vehiculo.Motor;
                parametros[4].Direction = ParameterDirection.Input;
                parametros[4].Size = 30;
                db.Comando.Parameters.Add(parametros[4]);

                parametros[5] = db.Comando.CreateParameter();
                parametros[5].ParameterName = "vrChasis";
                parametros[5].Value = vehiculo.Chasis;
                parametros[5].Direction = ParameterDirection.Input;
                parametros[5].Size = 30;
                db.Comando.Parameters.Add(parametros[5]);

                parametros[6] = db.Comando.CreateParameter();
                parametros[6].ParameterName = "vrEstado";
                parametros[6].Value = vehiculo.Estado;
                parametros[6].Direction = ParameterDirection.Input;
                parametros[6].Size = 1;
                db.Comando.Parameters.Add(parametros[6]);

                parametros[7] = db.Comando.CreateParameter();
                parametros[7].ParameterName = "vrCedulaCond";
                parametros[7].Value = vehiculo.Conductor.Cedula;
                parametros[7].Direction = ParameterDirection.Input;
                parametros[7].Size = 12;
                db.Comando.Parameters.Add(parametros[7]);

                parametros[8] = db.Comando.CreateParameter();
                parametros[8].ParameterName = "vrIdRuta";
                parametros[8].Value = vehiculo.Ruta.Id_Ruta;
                parametros[8].Direction = ParameterDirection.Input;
                parametros[8].Size = 30;
                db.Comando.Parameters.Add(parametros[8]);

                parametros[9] = db.Comando.CreateParameter();
                parametros[9].ParameterName = "vrCedulaContra";
                parametros[9].Value = vehiculo.Contratista.Cedula;
                parametros[9].Direction = ParameterDirection.Input;
                parametros[9].Size = 12;
                db.Comando.Parameters.Add(parametros[9]);

                parametros[10] = db.Comando.CreateParameter();
                parametros[10].ParameterName = "vrCodResult";
                parametros[10].Value = 0;
                parametros[10].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[10]);

                parametros[11] = db.Comando.CreateParameter();
                parametros[11].ParameterName = "vrDescResult";
                parametros[11].Value = "";
                parametros[11].Direction = ParameterDirection.Output;
                parametros[11].Size = 200;
                parametros[11].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[11]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[10].Value.ToString());
                db.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                db.CancelarTransaccion();
                throw new Exception("Error al crear la VehiculoBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public long ConsultaExistenciaVehiculo(string vehiculo)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaVehiculos";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = vehiculo;
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
                throw new Exception("Error al acceder a la base de datos para obtener los VehiculoBEs.");
            }
            return codigo;

        }

        public long ConsultaExistenciaConductor(string cedula)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaConductor";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = cedula;
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
                throw new Exception("Error al acceder a la base de datos para obtener los VehiculoBEs.");
            }
            return codigo;

        }

        public long ConsultaExistenciaContratistas(string cedula)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarExistenciaContratistas";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrDatoConsulta";
                parametros[0].Value = cedula;
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
                throw new Exception("Error al acceder a la base de datos para obtener los ContratistaBEs.");
            }
            return codigo;

        }

        public long RegistrarContratista(ContratistaBE contratista)
        {
            long codigo = 0;
            BaseDatos db = new BaseDatos();
            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string nameSP = "CrearRegistroContratista";
                db.CrearComandoSP(nameSP);

                DbParameter[] parametros = new DbParameter[10];

                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrCedula";
                parametros[0].Value = contratista.Cedula;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[0].Size = 12;
                db.Comando.Parameters.Add(parametros[0]);

                parametros[1] = db.Comando.CreateParameter();
                parametros[1].ParameterName = "vrNombres";
                parametros[1].Value = contratista.Nombres;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[1].Size = 20;
                db.Comando.Parameters.Add(parametros[1]);

                parametros[2] = db.Comando.CreateParameter();
                parametros[2].ParameterName = "vrApellidos";
                parametros[2].Value = contratista.Apellidos;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[2].Size = 12;
                db.Comando.Parameters.Add(parametros[2]);

                parametros[3] = db.Comando.CreateParameter();
                parametros[3].ParameterName = "vrDireccion";
                parametros[3].Value = contratista.Direccion;
                parametros[3].Direction = ParameterDirection.Input;
                parametros[3].Size = 30;
                db.Comando.Parameters.Add(parametros[3]);

                parametros[4] = db.Comando.CreateParameter();
                parametros[4].ParameterName = "vrTelefono";
                parametros[4].Value = contratista.Telefono;
                parametros[4].Direction = ParameterDirection.Input;
                parametros[4].Size = 10;
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
                throw new Exception("Error al crear el registro de  ContratistaBE.", ex);
            }

            finally
            {
                db.Desconectar();
            }
            return codigo;
        }

        public VehiculoBE ConsultaPlacaPorUbicacion(string idUbicacion)
        {
            VehiculoBE veh = new VehiculoBE();
            BaseDatos db = new BaseDatos();
            try
            {
                string nameSP = "ConsultarPlacasPorUbicacion";
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdUbicacion";
                parametros[0].Value = idUbicacion;
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
                VehiculoBE v = null;
                while (datos.Read())
                {
                    try
                    {
                        v = new VehiculoBE();
                        v.Id_Vehiculo = datos.GetValue(0).ToString();
                        v.Placa = datos.GetString(1);
                        RutaBE r = new RutaBE();
                        r.Id_Ruta = datos.GetValue(2).ToString();
                        r.Nombre_Ruta = (datos.GetString(3));
                        v.Ruta = r;
                        ConductorBE c = new ConductorBE();
                        c.Id_Conductor = (datos.GetValue(4).ToString());
                        c.Nombres_Conductor = datos.GetString(5);
                        c.Apellido_1 = datos.GetString(6);
                        c.Apellido_2 = datos.GetString(7);
                        v.Conductor = c;
                        veh = v;
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
                throw new Exception("Error al acceder a la base de datos para obtener los VehiculoBEs.");
            }
            return veh;
        }

        public List<Ubicacion_CilindroBE> ConsultarCilPorVehiculo(string IdVehiculo)
        {
            List<Ubicacion_CilindroBE> ubicacionCil = new List<Ubicacion_CilindroBE>();
            try
            {
                string nameSP = "ConsultarCilPorVehiculo";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComandoSP(nameSP);
                DbParameter[] parametros = new DbParameter[3];
                parametros[0] = db.Comando.CreateParameter();
                parametros[0].ParameterName = "vrIdVehiculo";
                parametros[0].Value = IdVehiculo;
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
                        ub = new Ubicacion_CilindroBE();
                        CilindroBE cilindro = new CilindroBE();
                        cilindro.Codigo_Cilindro = (datos.GetString(0));
                        cilindro.Tipo_Cilindro = datos.GetString(1);
                        ub.Cilindro = cilindro;
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = (datos.GetString(2));
                        cilindro.NTamano = tam;
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
                throw new Exception("Error al acceder a la base de datos para obtener los VehiculoBEs.");
            }
            return ubicacionCil;
        }


    }
}
