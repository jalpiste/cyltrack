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

                DbParameter[] parametros = new DbParameter[15];

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
                parametros[6].ParameterName = "vrCed_Prop";
                parametros[6].Value = vehiculo.Ced_Prop;
                parametros[6].Direction = ParameterDirection.Input;
                parametros[6].Size = 12;
                db.Comando.Parameters.Add(parametros[6]);

                parametros[7] = db.Comando.CreateParameter();
                parametros[7].ParameterName = "vrNombres_Prop";
                parametros[7].Value = vehiculo.Nombres_Prop;
                parametros[7].Direction = ParameterDirection.Input;
                parametros[7].Size = 20;
                db.Comando.Parameters.Add(parametros[7]);

                parametros[8] = db.Comando.CreateParameter();
                parametros[8].ParameterName = "vrApellido_1_Prop";
                parametros[8].Value = vehiculo.Apellido_1_Prop;
                parametros[8].Direction = ParameterDirection.Input;
                parametros[8].Size = 15;
                db.Comando.Parameters.Add(parametros[8]);

                parametros[9] = db.Comando.CreateParameter();
                parametros[9].ParameterName = "vrApellido_2_Prop";
                parametros[9].Value = vehiculo.Apellido_2_Prop;
                parametros[9].Direction = ParameterDirection.Input;
                parametros[9].Size = 15;
                db.Comando.Parameters.Add(parametros[9]);

                parametros[10] = db.Comando.CreateParameter();
                parametros[10].ParameterName = "vrEstado";
                parametros[10].Value = vehiculo.Estado;
                parametros[10].Direction = ParameterDirection.Input;
                parametros[10].Size = 8;
                db.Comando.Parameters.Add(parametros[10]);

                parametros[11] = db.Comando.CreateParameter();
                parametros[11].ParameterName = "vrCedulaCond";
                parametros[11].Value = vehiculo.Conductor.Cedula;
                parametros[11].Direction = ParameterDirection.Input;
                parametros[11].Size = 12;
                db.Comando.Parameters.Add(parametros[11]);

                parametros[12] = db.Comando.CreateParameter();
                parametros[12].ParameterName = "vrIdRuta";
                parametros[12].Value = vehiculo.Ruta.Id_Ruta;
                parametros[12].Direction = ParameterDirection.Input;
                parametros[12].Size = 30;
                db.Comando.Parameters.Add(parametros[12]);

                parametros[13] = db.Comando.CreateParameter();
                parametros[13].ParameterName = "vrCodResult";
                parametros[13].Value = 0;
                parametros[13].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[13]);

                parametros[14] = db.Comando.CreateParameter();
                parametros[14].ParameterName = "vrDescResult";
                parametros[14].Value = "";
                parametros[14].Direction = ParameterDirection.Output;
                parametros[14].Size = 200;
                parametros[14].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[14]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[13].Value.ToString());
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

        public VehiculoBE ConsultarPropVehiculo(string cedula)
        {
            VehiculoBE veh = new VehiculoBE();
            try
            {
                string nameSP = "ConsultarPropVehiculo";
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
                VehiculoBE v = null;
                while (datos.Read())
                {
                    try
                    {
                        v = new VehiculoBE();
                        v.Nombres_Prop = datos.GetString(0);
                        v.Apellido_1_Prop = datos.GetString(1);
                        v.Apellido_2_Prop = datos.GetString(2);
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
                        v.Ced_Prop = datos.GetString(8);
                        v.Nombres_Prop = datos.GetString(9);
                        v.Apellido_1_Prop = datos.GetString(10);
                        v.Apellido_2_Prop = datos.GetString(11);
                        ConductorBE cond = new ConductorBE();
                        cond.Id_Conductor = datos.GetValue(12).ToString();
                        cond.Nombres_Conductor = datos.GetString(13);
                        cond.Apellido_1 = datos.GetString(14);
                        cond.Apellido_2 = datos.GetString(15);
                        cond.Cedula = datos.GetString(16);
                        RutaBE ruta = new RutaBE();
                        ruta.Id_Ruta = datos.GetValue(17).ToString();
                        ruta.Nombre_Ruta = datos.GetString(18);
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

                DbParameter[] parametros = new DbParameter[15];

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
                parametros[6].ParameterName = "vrCed_Prop";
                parametros[6].Value = vehiculo.Ced_Prop;
                parametros[6].Direction = ParameterDirection.Input;
                parametros[6].Size = 12;
                db.Comando.Parameters.Add(parametros[6]);

                parametros[7] = db.Comando.CreateParameter();
                parametros[7].ParameterName = "vrNombres_Prop";
                parametros[7].Value = vehiculo.Nombres_Prop;
                parametros[7].Direction = ParameterDirection.Input;
                parametros[7].Size = 20;
                db.Comando.Parameters.Add(parametros[7]);

                parametros[8] = db.Comando.CreateParameter();
                parametros[8].ParameterName = "vrApellido_1_Prop";
                parametros[8].Value = vehiculo.Apellido_1_Prop;
                parametros[8].Direction = ParameterDirection.Input;
                parametros[8].Size = 15;
                db.Comando.Parameters.Add(parametros[8]);

                parametros[9] = db.Comando.CreateParameter();
                parametros[9].ParameterName = "vrApellido_2_Prop";
                parametros[9].Value = vehiculo.Apellido_2_Prop;
                parametros[9].Direction = ParameterDirection.Input;
                parametros[9].Size = 15;
                db.Comando.Parameters.Add(parametros[9]);

                parametros[10] = db.Comando.CreateParameter();
                parametros[10].ParameterName = "vrEstado";
                parametros[10].Value = vehiculo.Estado;
                parametros[10].Direction = ParameterDirection.Input;
                parametros[10].Size = 8;
                db.Comando.Parameters.Add(parametros[10]);

                parametros[11] = db.Comando.CreateParameter();
                parametros[11].ParameterName = "vrCedulaCond";
                parametros[11].Value = vehiculo.Conductor.Cedula;
                parametros[11].Direction = ParameterDirection.Input;
                parametros[11].Size = 12;
                db.Comando.Parameters.Add(parametros[11]);

                parametros[12] = db.Comando.CreateParameter();
                parametros[12].ParameterName = "vrIdRuta";
                parametros[12].Value = vehiculo.Ruta.Id_Ruta;
                parametros[12].Direction = ParameterDirection.Input;
                parametros[12].Size = 30;
                db.Comando.Parameters.Add(parametros[12]);

                parametros[13] = db.Comando.CreateParameter();
                parametros[13].ParameterName = "vrCodResult";
                parametros[13].Value = 0;
                parametros[13].Direction = ParameterDirection.Output;
                db.Comando.Parameters.Add(parametros[13]);

                parametros[14] = db.Comando.CreateParameter();
                parametros[14].ParameterName = "vrDescResult";
                parametros[14].Value = "";
                parametros[14].Direction = ParameterDirection.Output;
                parametros[14].Size = 200;
                parametros[14].DbType = DbType.String;
                db.Comando.Parameters.Add(parametros[14]);

                db.EjecutarComando();
                codigo = long.Parse(db.Comando.Parameters[13].Value.ToString());
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

    }
}
