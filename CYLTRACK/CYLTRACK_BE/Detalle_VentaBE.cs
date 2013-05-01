/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Deerechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;


namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    // <summary>
    /// Clase utilizada para representar la entidad Detalle_Venta
    /// </summary>
    /// 
    public class Detalle_VentaBE
    {
        /// <summary>
        /// Identificador de un detalle de venta
        /// </summary>
        public String Id_Detalle_Venta { get; set; }

        /// <summary>
        /// Código del cilindro actual del cliente
        /// </summary>
        public String Cod_Cil_Actual { get; set; }

        /// <summary>
        /// Código del cilindro nuevo de venta al cliente
        /// </summary>
        public String Cod_Cil_Nuevo { get; set; }

        /// <summary>
        /// Cilindro entregado
        /// </summary>
        public CilindroBE Cilindro { get; set; }

        /// <summary>
        /// Casos especiales
        /// </summary>
        public CasosBE Casos_Especiales { get; set; }

        /// <summary>
        /// Venta
        /// </summary>
        public VentaBE Venta { get; set; }


    }
}
