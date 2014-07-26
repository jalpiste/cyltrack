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
                if(venta.Observaciones=="")
                {
                    venta.Observaciones = "0";
                }
                respVenta = ven.RegistrarVenta(venta);
                venta.Id_Venta= respVenta.ToString();

                foreach(Detalle_VentaBE datos in venta.Lista_Detalle_Venta)
                {
                    Detalle_VentaBE det = new Detalle_VentaBE();
                    det.Id_Cilindro_Entrada = datos.Id_Cilindro_Entrada;
                    det.Id_Cilindro_Salida = datos.Id_Cilindro_Salida;
                    det.Tipo_Cilindro = datos.Tipo_Cilindro;
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

        public List<CilindroBE> ConsultarCarguePlaca() 
        {
            List<CilindroBE> lstCod = new List<CilindroBE>();
            Random ran = new Random();
                for (int i = 0; i < 7; i++)
                {
                    CilindroBE datCil = new CilindroBE();
                    datCil.Codigo_Cilindro = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                    datCil.Tipo_Cilindro = "Universal";
                    TamanoBE tam = new TamanoBE();
                    tam.Tamano = "40";
                    datCil.NTamano = tam;                    
                    lstCod.Add(datCil);
                 }

            return lstCod;
        }

        public List<CasosBE> RevisionCasosEspeciales(string casos)
        {
            List<CasosBE> lstCaso = new List<CasosBE>();
            Random ran = new Random();
            for (int i = 0; i < 7; i++)
            {
                 VentaBE datosVenta= new VentaBE();
                 datosVenta = ConsultarVenta(casos);
                 CasosBE casosEspeciales = new CasosBE();
                 //casosEspeciales.Id_Detalle_Venta = datosVenta;
                 casosEspeciales.Id_Casos = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                 Tipo_CasoBE tipCaso = new Tipo_CasoBE();
                 tipCaso.Nombre_Caso = "Escape";
                 casosEspeciales.Tipo_Caso = tipCaso;
                 lstCaso.Add(casosEspeciales);
            }
                      
            return lstCaso;
        }

        public string CasosEspeciales(CasosBE casos)
        {
            string resp = "Ok";
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
