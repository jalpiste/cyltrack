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
            String resp = "Venta registrada";
            return resp;
        }

        public List<VentaBE> ConsultarVenta(VentaBE ventas)
        {
            List<VentaBE> lstVenta = new List<VentaBE>();
            VentaBE venta = new VentaBE();
            venta.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            venta.Cliente.Cedula = "7302834";
            venta.Cliente.Nombres_Cliente = "Pablo";
            venta.Cliente.Apellido_1 = "Paez";
            venta.Cliente.Apellido_2 = "Veloza";
            venta.Ubicacion.Direccion = "Cra 9 N° 8 34";
            venta.Ubicacion.Barrio = "Boyacá";
            venta.Ubicacion.Ciudad.Departamento.Nombre_Departamento = "Boyacá";
            venta.Ubicacion.Ciudad.Nombre_Ciudad = "Chiquinquirá";
            venta.Ubicacion.Telefono_1 = "7266617";
            venta.Cilindro.Codigo_Cilindro = "67865675678";
            venta.Cilindro.NTamano.Tamano = "40";
            venta.Observaciones = "error en el codigo del cilindro del cliente";
            //------------------------
            venta.Vehiculo.Conductor_Vehiculo.Conductor.Nombres_Conductor = "carlos";
            venta.Vehiculo.Conductor_Vehiculo.Conductor.Apellido_1 = "Pineda";
            venta.Vehiculo.Conductor_Vehiculo.Conductor.Apellido_2 = "Poveda";
            venta.Vehiculo.Placa = "XHA940";
            venta.Vehiculo.Ruta.Nombre_Ruta = "Zona centro";

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
            List<VentaBE> consulta = ConsultarVenta(ventas);
            String resp = "caso especial registrado";
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
