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

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class VentaBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public string VentaCilindro(VentaBE ventas)
        {
            string resp = "Ok";
            return resp;
        }

        public string ConsultarExistencia(string ventas)
        {
            string resp = "Ok";
            return resp;
        }

        public VentaBE ConsultarVenta(string ventas)
        {
                Random ran = new Random();
                VentaBE datVenta = new VentaBE();
                Detalle_VentaBE detVenta = new Detalle_VentaBE();
                detVenta.Cod_Cil_Actual = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                detVenta.Cod_Cil_Nuevo = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                detVenta.Tamano = "30";
                detVenta.Tipo_Cilindro = "Universal";
                CasosBE casos = new CasosBE();
                Tipo_CasoBE tipCasos = new Tipo_CasoBE();
                tipCasos.Nombre_Caso = "Escape";
                casos.Tipo_Caso = tipCasos;
                casos.Id_Casos = "189238";
                detVenta.Casos_Especiales = casos;
                datVenta.Detalle_Venta = detVenta;
                datVenta.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                ClienteBE cli = new ClienteBE();
                cli.Cedula = "2345678";
                cli.Nombres_Cliente = "Pablo";
                cli.Apellido_1 = "Paez";
                cli.Apellido_2 = "Veloza";
               
                UbicacionBE ubi = new UbicacionBE();
                List<string> lstDireccion = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    lstDireccion.Add("Calle" + i + " N " + i + "0 " + i + "0");
                }
                ubi.Direccion = lstDireccion;
                ubi.Barrio = "Boyacá";
                ubi.Telefono_1 = "7266617";
                cli.Ubicacion = ubi;
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = "Chiquinquirá";
                DepartamentoBE dep = new DepartamentoBE();
                dep.Nombre_Departamento = "Boyacá";
                ciu.Departamento = dep;
                ubi.Ciudad = ciu;
                cli.Ubicacion = ubi;
                datVenta.Observaciones = "error en el codigo del cilindro del cliente";
                datVenta.Cliente = cli;
                //------------------------
                VehiculoBE veh = new VehiculoBE();
                veh.Placa = "XHA940";
                ConductorBE cond = new ConductorBE();
                cond.Nombres_Conductor = "carlos";
                cond.Apellido_1 = "Pineda";
                cond.Apellido_2 = "Poveda";
                veh.Conductor = cond;
                RutaBE ruta = new RutaBE();
                ruta.Nombre_Ruta = "Zona centro";
                veh.Ruta = ruta;
                datVenta.Vehiculo = veh;

                return datVenta;
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
                 casosEspeciales.Venta = datosVenta;
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
