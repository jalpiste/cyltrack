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

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Pedido
    /// </summary>
    public class PedidoBE
    {
        /// <summary>
        /// Identificador del pedido
        /// </summary>
        public String Id_Pedido { get; set; }

        /// <summary>
        /// Fecha de la realizacion del pedido 
        /// </summary>
        public String Fecha { get; set; }

        /// <summary>
        /// Observaciones referentes a la entrega del pedido
        /// </summary>
        public String Detalle { get; set; }

        /// <summary>
        /// Motivo de cancelación de un pedido
        /// </summary>
        public String Motivo_Cancel { get; set; }
    }
}
