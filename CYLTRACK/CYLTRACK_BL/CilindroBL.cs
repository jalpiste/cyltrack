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
                if (cilindro.Ubicacion_Cilindro.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion == "Chatarra")
                {
                    cilindro.Estado = "Chatarra";
                }
                else 
                {
                    cilindro.Estado = "Uso";
                    cilindro.Tipo_Cilindro = "Marcado";
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

        public long consultadeExistencia(string cilindro)
        {
            CilindroDL cil = new CilindroDL();
            long resp = 0;
            try
            {
                resp = cil.ConsultarExistencias(cilindro);
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
            }
            catch (Exception ex)
            {
                
            }

            return resp;
        }
         
        public string AsignarUbicacion(CilindroBE cilindro)
        {
            string resp;
            resp = "Ok";
            return resp;
        }

        public List<CilindroBE> ConsultarCilUbicacion(string ubica)
        {
            List<CilindroBE> lstCod = new List<CilindroBE>();
           
                if (ubica == "Plataforma")
                {
                    Random ran = new Random();
                    for (int i = 0; i < 7; i++)
                    {
                        CilindroBE datCil= new CilindroBE();
                        
                        datCil.Codigo_Cilindro=((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                        datCil.Tipo_Cilindro = "Universal";
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = "40";
                        datCil.NTamano = tam;
                        VehiculoBE veh = new VehiculoBE();
                        veh.Placa = "CAD678";
                        Ubicacion_CilindroBE ubiCil = new Ubicacion_CilindroBE();
                        UbicacionBE ubicacion = new UbicacionBE();
                        ubicacion.Vehiculo = veh;
                        ubiCil.Ubicacion = ubicacion;
                        datCil.Ubicacion_Cilindro = ubiCil;
                        lstCod.Add(datCil);
                    }
            }
                if (ubica == "Vehiculo")
                {
                    Random ran = new Random();
                    for (int i = 0; i < 7; i++)
                    {
                        CilindroBE datCil= new CilindroBE();
                        
                        datCil.Codigo_Cilindro=((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                        datCil.Tipo_Cilindro = "Marcado";
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = "30";
                        datCil.NTamano = tam;
                        VehiculoBE veh = new VehiculoBE();
                        veh.Placa = "UIZ987";
                        Ubicacion_CilindroBE ubiCil = new Ubicacion_CilindroBE();
                        UbicacionBE ubicacion = new UbicacionBE();
                        ubicacion.Vehiculo = veh;
                        ubiCil.Ubicacion = ubicacion;
                        datCil.Ubicacion_Cilindro = ubiCil;
                        lstCod.Add(datCil);
                    }                   
            }
            
            return lstCod;
        }

        public string CargueyDescargueCilindros(List<CilindroBE> cilindro)
        {
            string resp = "Ok";
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
