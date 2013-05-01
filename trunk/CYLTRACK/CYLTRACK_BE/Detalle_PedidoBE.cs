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
    /// Clase utilizada para representar la entidad Detalle_Pedido
    /// </summary>

    public class Detalle_PedidoBE
    {
        /// <summary>
        /// Identificador del Detalle del pedido
        /// </summary>
        public String Id_Detalle_Venta { get; set; }

        /// <summary>
        /// Cantidad de cilindros
        /// </summary>
        public String Cantidad { get; set; }

        /// <summary>
        /// Tamaño del cilindro del pedido
        /// </summary>
        public TamanoBE Tamano { get; set; }

    }
}
