/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Derechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using Unisangil.CYLTRACK.CYLTRACK_DL;

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class VehiculoBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        /// <summary>
        /// Método para el registro de vehículos en el sistema
        /// </summary>
        /// <param name="registrar_vehiculo"></param>
        /// <returns></returns>
        public long CrearVehiculo(VehiculoBE vehiculo)
        {
            VehiculoDL veh = new VehiculoDL();
            long resp =0;
            try
            {
                if (vehiculo.Estado == "Activo")
                {
                    vehiculo.Estado = "1";
                }
                else 
                {
                    vehiculo.Estado = "0";
                }
                resp = veh.CrearVehiculo(vehiculo);
            }
            catch (Exception ex)
            {

            }
            return resp;
        }
        /// <summary>
        /// Método para la consulta de existencia de vehículos en el sistema 
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        public long ConsultaExistenciaVehiculo(string vehiculo)
        {
            VehiculoDL veh = new VehiculoDL();
            long resp = 0;
            try
            {
                resp = veh.ConsultaExistenciaVehiculo(vehiculo);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }

        public long ConsultaExistenciaConductor(string cedula)
        {
            VehiculoDL veh = new VehiculoDL();
            long resp = 0;
            try
            {
                resp = veh.ConsultaExistenciaConductor(cedula);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }

        public long ConsultaExistenciaContratista(string cedula)
        {
            VehiculoDL veh = new VehiculoDL();
            long resp = 0;
            try
            {
                resp = veh.ConsultaExistenciaContratistas(cedula);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }
        /// <summary>
        /// Método para la consulta de vehículos en el sistema y muestra de información
        /// </summary>
        /// <param name="consultar_vehiculo"></param>
        /// <returns></returns>
        public List<VehiculoBE> ConsultarVehiculo(string placa)
        {
            VehiculoDL veh = new VehiculoDL();
            List<VehiculoBE> vehiculo = new List<VehiculoBE>();
            try
            {
                if (placa == "") 
                {
                    placa = "0";
                }
                
                vehiculo = veh.ConsultarVehiculo(placa);
                foreach (VehiculoBE datos in vehiculo)
                {
                    if (datos.Estado == "1")
                    {
                        datos.Estado = "Activo";
                    }
                    else
                        datos.Estado = "Inactivo";
                }
               
            }
            catch (Exception ex)
            {

            }
            return vehiculo;
        }
        /// <summary>
        /// Método para la modificación de vehículos en el sistema
        /// </summary>
        /// <param name="modificar_vehiculo"></param>
        /// <returns>codigo</returns>
        public long ModificarVehiculo(VehiculoBE modificar_vehiculo)
        {
            VehiculoDL veh = new VehiculoDL();
            long resp = 0;
            try
            {
                if (modificar_vehiculo.Estado == "Activo")
                {
                    modificar_vehiculo.Estado = "1";
                }
                else
                {
                    modificar_vehiculo.Estado = "0";
                }
                resp = veh.ModificarVehiculo(modificar_vehiculo);
            }
            catch (Exception ex)
            {

            }
            return resp;
        }
        /// <summary>
        /// Método para la consulta de conductores en el sistema
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public ConductorBE ConsultarConductor(string cedula)
        {

            VehiculoDL veh = new VehiculoDL();
            ConductorBE cond = new ConductorBE();
            try
            {
                cond = veh.ConsultarConductor(cedula);
            }
            catch (Exception ex)
            {

            }
            return cond;
        }
        public ContratistaBE ConsultarPropVehiculo(string cedula)
        {

            VehiculoDL veh = new VehiculoDL();
            ContratistaBE cont = new ContratistaBE();
            try
            {
                cont = veh.ConsultarPropVehiculo(cedula);
            }
            catch (Exception ex)
            {

            }
            return cont;
        }
        public long RegistrarConductor(ConductorBE conductor)
        {
            VehiculoDL veh = new VehiculoDL();

            long resp = 0;
            try
            {
                resp = veh.RegistrarConductor(conductor);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }
        public long RegistrarContratista(ContratistaBE contratista)
        {
            VehiculoDL veh = new VehiculoDL();

            long resp = 0;
            try
            {
                resp = veh.RegistrarContratista(contratista);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }
        
        #endregion
        #region Metodos privados
        #endregion
    }
}
