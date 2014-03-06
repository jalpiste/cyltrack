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
        public List<VehiculoBE> ConsultarPlacasVehiculos(string placa)
        {
            List<VehiculoBE> vehiculo = new List<VehiculoBE>();
            try
            {
                string nameSP = "ConsultarPlacasVehiculos";
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
                        v.Placa = datos.GetString(0);
                        v.Marca = datos.GetString(1);
                        v.Cilindraje = datos.GetString(2);
                        v.Modelo = datos.GetString(3);
                        v.Motor = datos.GetString(4);
                        v.Chasis = datos.GetString(5);
                        vehiculo.Add(v);
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
            return vehiculo;
 
        }
    }
}
