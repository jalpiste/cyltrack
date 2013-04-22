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

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad venta
    /// </summary>
    public class VentaBE
    {
        /// <summary>
        /// Identificador de venta
        /// </summary>
        public String Id_Venta { get; set; }

        /// <summary>
        /// Identificador de detalle de venta
        /// </summary>
        public String Id_Detalle_Venta { get; set; }

        /// <summary>
        /// identificador de conductor vehiculo
        /// </summary>
        public String Id_Conductor_Vehiculo { get; set; }

        /// <summary>
        /// Fecha de la venta
        /// </summary>
        public String Fecha { get; set; }
    }
}
