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
        public String VentaCilindro(VentaBE ventas)
        {
            String resp = "Ok";
            return resp;
        }

        public List<VentaBE> ConsultarVenta(string ventas)
        {
            List<VentaBE> lstVenta = new List<VentaBE>();
           
            VentaBE[] lista = new VentaBE[7];
            Random ran = new Random();
            for (int i = 0; i < 7; i++)
            {
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
                datVenta.Cliente = cli;
                UbicacionBE ubi = new UbicacionBE();
                ubi.Direccion = "Cra 9 N° 8 34";
                ubi.Barrio = "Boyacá";
                ubi.Telefono_1 = "7266617";
                cli.Ubicacion = ubi;
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = "Chiquinquirá";
                DepartamentoBE dep = new DepartamentoBE();
                dep.Nombre_Departamento = "Boyacá";
                ciu.Departamento = dep;
                ubi.Ciudad = ciu;
                datVenta.Observaciones = "error en el codigo del cilindro del cliente";

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
                lista[i] = datVenta;
            }

            lstVenta = lista.ToList();
           
            //---------------------
   
            return lstVenta;
        }

        public List<CasosBE> RevisionCasosEspeciales(CasosBE casos)
        {
            List<CasosBE> lstCaso = new List<CasosBE>();
            string datos;
            CasosBE[] lista = new CasosBE[7];
            Random ran = new Random();
            for (int i = 0; i < 7; i++)
            {
                CasosBE caso = new CasosBE();
                Tipo_CasoBE tipCaso = new Tipo_CasoBE();
                caso.Id_Casos = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                tipCaso.Nombre_Caso = "Escape";
                caso.Tipo_Caso = tipCaso;
                VentaBE venta = new VentaBE();
                Detalle_VentaBE detVenta = new Detalle_VentaBE();
                detVenta.Casos_Especiales = caso;
                venta.Detalle_Venta = detVenta;
                datos = Convert.ToString(venta);
                List<VentaBE> consultaVenta = ConsultarVenta(datos);
                foreach(VentaBE info in consultaVenta)
                {
                    caso.Venta = info;
                }
                lista[i] = caso;
            }

            lstCaso = lista.ToList();           
            return lstCaso;
        }

        public String CasosEspeciales(CasosBE casos)
        {
            String resp = "Ok";
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
