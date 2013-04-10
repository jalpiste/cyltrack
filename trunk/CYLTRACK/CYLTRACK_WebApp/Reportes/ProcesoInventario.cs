using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Reportes
{
    /// <summary>
    /// Clase utilizada para identificar los datos de la ubicación y cantidades a imprimir 
    /// </summary>
    public class ProcesoInventario
    {
        public String NombreUbicacion { get; set; }
        public String CilMar30 { get; set; }
        public String CilMar40 { get; set; }
        public String CilMar80 { get; set; }
        public String CilMar100 { get; set; }
        public String CilUni30 { get; set; }
        public String CilUni40 { get; set; }
        public String CilUni80 { get; set; }
        public String CilUni100 { get; set; }
        public String Total30 { get; set; }
        public String Total40 { get; set; }
        public String Total80 { get; set; }
        public String Total100 { get; set; }
        public String ResumenMarca { get; set; }
        public String ResumenUniv { get; set; }
        public String SumResumenTotal { get; set; }
        public String TotalCilMarca { get; set; }
        public String TotalCilUniv { get; set; }
        public String TotalPlanta { get; set; }
        public String Placa { get; set; }


        /// <summary>
        /// Constructor de la clase ProcesoInventario
        /// </summary>
        /// <param name="Ubicacion"></param>
        public ProcesoInventario(String ubicacion) {

            NombreUbicacion = ubicacion;

            switch (ubicacion)
            {
                case "Plataforma":
                    this.CilMar30 = "Consulta";
                    this.CilMar40 = "Consulta";
                    this.CilMar80 = "Consulta";
                    this.CilMar100 = "Consulta";
                    this.CilUni30 = "Consulta";
                    this.CilUni40 = "Consulta";
                    this.CilUni80 = "Consulta";
                    this.CilUni100 = "Consulta";
                    this.Total30 = "Consulta";
                    this.Total40 = "Consulta";
                    this.Total80 = "Consulta";
                    this.Total100 = "Consulta";
                    this.ResumenMarca = "Consulta";
                    this.ResumenUniv = "Consulta";
                    this.SumResumenTotal = "Consulta";
                    break;
                case "Bodega":
                    this.CilMar30 = "Consulta";
                    this.CilMar40 = "Consulta";
                    this.CilMar80 = "Consulta";
                    this.CilMar100 = "Consulta";
                    this.CilUni30 = "Consulta";
                    this.CilUni40 = "Consulta";
                    this.CilUni80 = "Consulta";
                    this.CilUni100 = "Consulta";
                    this.Total30 = "Consulta";
                    this.Total40 = "Consulta";
                    this.Total80 = "Consulta";
                    this.Total100 = "Consulta";
                    this.ResumenMarca = "Consulta";
                    this.ResumenUniv = "Consulta";
                    this.SumResumenTotal = "Consulta";
                    break;
                case "Mantenimiento":
                    this.CilMar30 = "Consulta";
                    this.CilMar40 = "Consulta";
                    this.CilMar80 = "Consulta";
                    this.CilMar100 = "Consulta";
                    this.CilUni30 = "Consulta";
                    this.CilUni40 = "Consulta";
                    this.CilUni80 = "Consulta";
                    this.CilUni100 = "Consulta";
                    this.Total30 = "Consulta";
                    this.Total40 = "Consulta";
                    this.Total80 = "Consulta";
                    this.Total100 = "Consulta";
                    this.ResumenMarca = "Consulta";
                    this.ResumenUniv = "Consulta";
                    this.SumResumenTotal = "Consulta";
                    break;

                case "Chatarra":
                    this.CilMar30 = "Consulta";
                    this.CilMar40 = "Consulta";
                    this.CilMar80 = "Consulta";
                    this.CilMar100 = "Consulta";
                    this.CilUni30 = "Consulta";
                    this.CilUni40 = "Consulta";
                    this.CilUni80 = "Consulta";
                    this.CilUni100 = "Consulta";
                    this.Total30 = "Consulta";
                    this.Total40 = "Consulta";
                    this.Total80 = "Consulta";
                    this.Total100 = "Consulta";
                    this.ResumenMarca = "Consulta";
                    this.ResumenUniv = "Consulta";
                    this.SumResumenTotal = "Consulta";
                    break;

                case "Vehiculo":
                    this.Placa = "Consulta";
                    this.CilMar30 = "Consulta";
                    this.CilMar40 = "Consulta";
                    this.CilMar80 = "Consulta";
                    this.CilMar100 = "Consulta";
                    this.CilUni30 = "Consulta";
                    this.CilUni40 = "Consulta";
                    this.CilUni80 = "Consulta";
                    this.CilUni100 = "Consulta";
                    this.Total30 = "Consulta";
                    this.Total40 = "Consulta";
                    this.Total80 = "Consulta";
                    this.Total100 = "Consulta";
                    this.ResumenMarca = "Consulta";
                    this.ResumenUniv = "Consulta";
                    this.SumResumenTotal = "Consulta";
                    break;
            }
        
        }
        

    }
}