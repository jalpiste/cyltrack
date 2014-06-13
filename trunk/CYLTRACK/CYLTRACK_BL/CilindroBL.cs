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
    public class CilindroBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        /// <summary>
        /// Método para el registro de cilindros en el sistema
        /// </summary>
        /// <param name="cilindro"></param>
        /// <returns></returns>
        public long CrearCilindro(CilindroBE cilindro)
        {
            CilindroDL cil = new CilindroDL();
            long resp = 0;
            try
            {
                if (cilindro.Tipo_Ubicacion.Nombre_Ubicacion == "Chatarra")
                {
                    cilindro.Estado = "CHATARRA";
                }
                else 
                {
                    cilindro.Estado = "USO";
                    cilindro.Tipo_Cilindro = "MARCADO";
                }

                if (cilindro.Vehiculo.Id_Vehiculo == "")
                {
                    cilindro.Vehiculo.Id_Vehiculo = "0";
                }

               resp = cil.CrearCilindro(cilindro);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }

        public long ConsultarExistenciaCilindro(string cilindro)
        {
            CilindroDL cil = new CilindroDL();
            long resp = 0;
            try
            {
                resp = cil.ConsultarExistenciaCilindro(cilindro);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }

        public CilindroBE ConsultarCilindro(string cilindro)
        {
            CilindroDL cil = new CilindroDL();
            CilindroBE resp = new CilindroBE();
            try
            {
                resp = cil.ConsultarCilindro(cilindro);   
                //if(resp.Tipo_Ubicacion.Nombre_Ubicacion=="VEHICULO")
                //{
                //    VehiculoDL veh = new VehiculoDL();
                //    VehiculoBE objVehi= new VehiculoBE();
                //    objVehi= veh.ConsultarVehiculo
                //}
            }
            catch (Exception ex)
            {
                
            }

            return resp;
        }
         
        public List<Ubicacion_CilindroBE> ConsultarCilUbicacion(string ubica)
        {
            List<Ubicacion_CilindroBE> lstResp= new List<Ubicacion_CilindroBE>();

            CilindroDL cil = new CilindroDL();
           
            try
            {
                lstResp = cil.ConsultarCilUbicacion(ubica);
            }
            catch (Exception ex)
            {

            }

            return lstResp;
        }

        public long ModificarUbicacionCilindro(CilindroBE cilindro)
        {
            CilindroDL cil = new CilindroDL();
            long resp = 0;
            try
            {
                if (cilindro.Vehiculo.Id_Vehiculo == null)
                {
                    VehiculoBE veh = new VehiculoBE();
                    veh.Id_Vehiculo = "0";
                    cilindro.Vehiculo = veh;
                }

                resp = cil.ModificarUbicacionCilindro(cilindro);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }

        public long consultaCodigoFabricante(string codigoFabricante)
        {
            CilindroDL cil = new CilindroDL();
            long resp = 0;
            try
            {
                resp = cil.ConsultaCodigoFabricante(codigoFabricante);
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
