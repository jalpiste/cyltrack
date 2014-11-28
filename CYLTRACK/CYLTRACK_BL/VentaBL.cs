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
    public class VentaBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public long RegistarVenta(VentaBE venta)
        {
            VentaDL ven = new VentaDL();
            long respVenta = 0;
            long respDetalleVenta = 0;
            try
            {
                if (venta.Observaciones == "")
                {
                    venta.Observaciones = "0";
                }

                respVenta = ven.RegistrarVenta(venta);
                venta.Id_Venta = respVenta.ToString();

                foreach (Detalle_VentaBE datos in venta.Lista_Detalle_Venta)
                {
                    Detalle_VentaBE det = new Detalle_VentaBE();
                    det.Id_Cilindro_Entrada = datos.Id_Cilindro_Entrada;
                    det.Id_Cilindro_Salida = datos.Id_Cilindro_Salida;
                    det.Tipo_Cilindro = datos.Tipo_Cilindro;
                    det.Tamano = datos.Tamano;
                    if (datos.Tipo_Venta == "Prestamo")
                    {
                        det.Tipo_Venta = "3";
                    }
                    if (datos.Tipo_Venta == "Intercambio")
                    {
                        det.Tipo_Venta = "2";
                    }
                    else
                    {
                        det.Tipo_Venta = "1";
                    }
                    venta.Detalle_Venta = det;
                    respDetalleVenta = ven.RegistrarDetalleVenta(venta);
                }

            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                respVenta = -1;
            }
            return respVenta;
        }

        public long ConsultarExistenciasVenta(string venta)
        {
            VentaDL ven = new VentaDL();

            long resp = 0;
            try
            {
                resp = ven.ConsultarExistenciasVenta(venta);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }

        public VentaBE ConsultarVenta(string datoConsulta)
        {
            VentaDL ven = new VentaDL();
            VentaBE resp = new VentaBE();

            try
            {
                resp = ven.ConsultarVenta(datoConsulta);
            }
            catch (Exception ex)
            {

            }

            return resp;
        }

        public List<CasosBE> RevisionCasosEspeciales(string casos)
        {
            VentaDL CasosDL = new VentaDL();
            List<CasosBE> lstCasos = new List<CasosBE>();

            try
            {
                lstCasos = CasosDL.ConsultarCaso(casos);
            }
            catch (Exception ex)
            {

            }

            return lstCasos;
        }

        public long CasosEspeciales(CasosBE casos)
        {
            VentaDL ven = new VentaDL();
            CilindroDL cil = new CilindroDL();

            long respRegCaso;
            long respRegModV;
            long respRegModUbica;
            try
            {
                if (casos.Observaciones == "")
                {
                    casos.Observaciones = "0";
                }
                casos.EstadoCaso = "1";
                if (casos.Tipo_Caso.Nombre_Caso == "ESCAPE" || casos.Tipo_Caso.Nombre_Caso == "CODIGO ERRADO")
                {
                    respRegModV = ModificarVenta(casos.Detalle_Venta);
                }
                else
                {
                    CilindroBE objCil = new CilindroBE();
                    objCil.Codigo_Cilindro = casos.Detalle_Venta.Id_Cilindro_Entrada;
                    Tipo_UbicacionBE tipUbica = new Tipo_UbicacionBE();
                    tipUbica.Nombre_Ubicacion = "VEHICULO";
                    objCil.Tipo_Ubicacion = tipUbica;
                    VehiculoBE veh = new VehiculoBE();
                    veh.Id_Vehiculo = casos.Detalle_Venta.Id_Vehiculo;
                    objCil.Vehiculo = veh;

                    respRegModUbica = cil.ModificarUbicacionCilindro(objCil);
                }
                respRegCaso = ven.RegistrarCasoEspecial(casos);

            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                respRegCaso = -1;
            }
            return respRegCaso;
        }

        public long ModificarVenta(Detalle_VentaBE detVenta)
        {
            VentaDL ven = new VentaDL();

            long resp = 0;
            try
            {
                resp = ven.ModificarVenta(detVenta);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }
            return resp;
        }

        public Detalle_VentaBE ConsultarDetalleVenta(string datoConsulta)
        {
            VentaDL ven = new VentaDL();
            Detalle_VentaBE resp = new Detalle_VentaBE();

            try
            {
                resp = ven.ConsultarDetalleVenta(datoConsulta);
            }
            catch (Exception ex)
            {

            }

            return resp;
        }

        #endregion
        #region Metodos privados
        #endregion
    }
}
