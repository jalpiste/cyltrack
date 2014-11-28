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
    public class RutaBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public long RegistrarRuta(RutaBE ruta)
        {
            RutaDL regRuta = new RutaDL();
            long respRuta = new long();
            long respDet_Ruta = new long();
            try
            {
                respRuta = regRuta.CrearRuta(ruta);

                foreach (CiudadBE datos in ruta.Lista_Ciudades)
                {
                    Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                    ciuRuta.Id_Ciudad= datos.Id_Ciudad;
                    ciuRuta.Id_Ruta= respRuta.ToString();
                    respDet_Ruta = regRuta.CrearRegistroDetalleRuta(ciuRuta);
                }
            }
            catch (Exception ex)
            {

            }
            return respRuta;
        }

        public long ModificarRuta(RutaBE ruta)
        {
            RutaDL rutaDL = new RutaDL();
            long respModRuta = 0;
            long respModDetalleRuta = 0;

            try
            {
                if (ruta.Nombre_Ruta != "")
                {
                    respModRuta = rutaDL.ModificarRuta(ruta);
                }

                foreach (CiudadBE datos in ruta.Lista_Ciudades)
                {
                    if (datos.Id_Ciudad_Ruta != null)
                    {
                        Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                        ciuRuta.Id_Ciudad = datos.Id_Ciudad;
                        ciuRuta.Id_Ciudad_Ruta = datos.Id_Ciudad_Ruta;
                        respModDetalleRuta = rutaDL.ModificarDetalleRuta(ciuRuta);
                    }
                    else
                    {
                        Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
                        ciuRuta.Id_Ciudad = datos.Id_Ciudad;
                        ciuRuta.Id_Ruta = ruta.Id_Ruta;
                        respModDetalleRuta = rutaDL.CrearRegistroDetalleRuta(ciuRuta);
                    }
                }
            }

            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                respModDetalleRuta = -1;
            }

            return respModDetalleRuta;

        }

        public string ConsultarExistencias(string ruta)
        {
            string resp = "Ok";

            return resp;
        }
        /// <summary>
        /// Método para la consulta de rutas en el sistema y muestra de información
        /// </summary>
        /// <param name="consultarRutas"></param>
        /// <returns></returns>
        public RutaBE ConsultarRuta(string ruta)
        {
            RutaDL rut = new RutaDL();
            RutaBE Ruta = new RutaBE();
            try
            {
                if(ruta == "")
                {
                    ruta = "0";
                }
                Ruta = rut.ConsultarRutas(ruta);                
            }
            catch (Exception ex)
            {

            }
            return Ruta;
        }

        public List<RutaBE> ConsultarNombreRuta()
        {
            RutaDL rut = new RutaDL();
            List<RutaBE> lstRuta = new List<RutaBE>();
            try
            {
               lstRuta = rut.ConsultarNombreRutas();
            }
            catch (Exception ex)
            {

            }
            return lstRuta;
        }

        public long ConsultaExistenciaRuta(string ruta)
        {
            RutaDL rut = new RutaDL();
            long resp = 0;
            try
            {
                resp = rut.ConsultaExistenciaRuta(ruta);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }

        public List<CiudadBE> ConsultaCiudades(string id_dep)
        {
            RutaDL ruta = new RutaDL();
            List<CiudadBE> lstCiudades = new List<CiudadBE>();
            try
            {
                lstCiudades = ruta.ConsultaCiudades(id_dep);
            }
            catch (Exception ex)
            {

            }
            return lstCiudades;        
        }

        public List<DepartamentoBE> ConsultaDepartamento()
        {
            RutaDL ruta = new RutaDL();
            List<DepartamentoBE> lstDepartamentos = new List<DepartamentoBE>();
            try
            {
                lstDepartamentos = ruta.ConsultaDepartamento();
            }
            catch (Exception ex)
            {

            }
            return lstDepartamentos;
        }

        public RutaBE ConsultarRutaPorPlaca(Ruta_VehiculoBE rutaVehiculo)
        {
            RutaDL rut = new RutaDL();
            RutaBE datoRuta = new RutaBE();
            try
            {
                datoRuta = rut.ConsultarRutasPorPlaca(rutaVehiculo);
            }
            catch (Exception ex)
            {

            }
            return datoRuta;
        }

        public long InsertarCiudad(CiudadBE ciud)
        {
            RutaDL regRuta = new RutaDL();
            long respRuta = new long();            
            List<CiudadBE> lstCiudad = new List<CiudadBE>();
            try
            {
                string idDept = ciud.Departamento.Id_Departamento;
                lstCiudad = (regRuta.ConsultaCiudades(idDept));

                foreach (CiudadBE datos in lstCiudad)
                {
                    CiudadBE ciuRuta = new CiudadBE();
                    DepartamentoBE dep = new DepartamentoBE();
                    ciuRuta.Id_Ciudad = datos.Id_Ciudad;
                    dep.Id_Departamento = idDept;
                    ciuRuta.Departamento = dep;
                    respRuta = regRuta.CrearRegCiudad(ciuRuta);
                }
            }
            catch (Exception ex)
            {

            }
            return respRuta;
        }

        #endregion
        #region Metodos privados
        #endregion
    }
}
