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
    public class Pedido
    {
        /// <summary>
        /// Identificador del pedido
        /// </summary>
        public String Id_Pedido { get; set; }

        /// <summary>
        /// Identificador del departamento
        /// </summary>
        public String Id_Departamento { get; set; }

        /// <summary>
        /// Identificador de ciudad
        /// </summary>
        public String Id_Ciudad { get; set; }

        /// <summary>
        /// Identificador de la placa del vehiculo
        /// </summary>
        public String Id_Vehiculo { get; set; }

        /// <summary>
        /// Identificador de la ruta del vehiculo
        /// </summary>
        public String Id_Ruta { get; set; }

        /// <summary>
        /// Direccion del pedido realizado por el cliente
        /// </summary>
        public String Direccion { get; set; }

        /// <summary>
        /// Telefono del pedido realizado por el cliente 
        /// </summary>
        public String Telefono { get; set; }

        /// <summary>
        /// Fecha de la realizacion del pedido 
        /// </summary>
        public String Fecha { get; set; }

        /// <summary>
        /// Observaciones referentes a la entrega del pedido
        /// </summary>
        public String Detalle { get; set; }
    }
}
