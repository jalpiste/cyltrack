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

        public List<VentaBE> ConsultarVenta(VentaBE ventas)
        {
            List<VentaBE> lstVenta = new List<VentaBE>();
            VentaBE venta = new VentaBE();
            venta.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            ClienteBE cli = new ClienteBE();
            cli.Cedula = "7302834";
            cli.Nombres_Cliente = "Pablo";
            cli.Apellido_1 = "Paez";
            cli.Apellido_2 = "Veloza";
            venta.Cliente = cli;
            UbicacionBE ubi = new UbicacionBE();
            ubi.Direccion= "Cra 9 N° 8 34";
            ubi.Barrio = "Boyacá";
            ubi.Telefono_1 = "7266617";
            venta.Ubicacion = ubi;
            DepartamentoBE dep = new DepartamentoBE();
            dep.Nombre_Departamento = "Boyacá";
            venta.Departamento = dep;
            CiudadBE ciu = new CiudadBE();
            ciu.Nombre_Ciudad = "Chiquinquirá";
            venta.Ciudad = ciu;
            CilindroBE cil = new CilindroBE();
            cil.Codigo_Cilindro = "67865675678";
            venta.Cilindro = cil;
            TamanoBE tam = new TamanoBE();
            tam.Tamano = "40";
            venta.Tamano = tam;
            venta.Observaciones = "error en el codigo del cilindro del cliente";

            //------------------------
            ConductorBE cond = new ConductorBE();
            cond.Nombres_Conductor = "carlos";
            cond.Apellido_1 = "Pineda";
            cond.Apellido_2 = "Poveda";
            venta.Conductor = cond;
            VehiculoBE veh = new VehiculoBE();
            veh.Placa = "XHA940";
            venta.Vehiculo = veh;
            RutaBE ruta = new RutaBE();
            ruta.Nombre_Ruta = "Zona centro";
            venta.Ruta = ruta;
            Tipo_CasoBE tipCasos = new Tipo_CasoBE();
            tipCasos.Nombre_Caso = "Escape de Cilindro";
            tipCasos.Nombre_Caso = "Terminacion contrato";
            tipCasos.Nombre_Caso = "Error en el codigo entregado";
            venta.Tipo_Casos = tipCasos;
            lstVenta.Add(venta);
            return lstVenta;
        }

        public List<CasosBE> RevisionCasosEspeciales(CasosBE casos)
        {
            List<CasosBE> lstCaso = new List<CasosBE>();
            CasosBE caso = new CasosBE();
            caso.Id_Casos="98989";
            caso.Tipo_Caso.Nombre_Caso = "Escape";
            lstCaso.Add(caso);

            return lstCaso;
        }

        public String CasosEspeciales(VentaBE ventas)
        {
            String resp = "Ok";
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
