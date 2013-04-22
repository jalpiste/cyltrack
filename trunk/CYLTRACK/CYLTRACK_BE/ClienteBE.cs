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
    /// Clase utilizada para representar la entidad Cliente
    /// </summary>
    
    public class ClienteBE
    {
        /// <summary>
        /// Identificador de un cliente
        /// </summary>
        public String Id_Cliente { get; set; }
        
        /// <summary>
        /// Número de documento de un cliente
        /// </summary>
        public String Cedula { get; set; }

        /// <summary>
        /// Nombres de un cliente
        /// </summary>
        public String Nombres { get; set; }

        /// <summary>
        /// Primer apellido de un cliente
        /// </summary>
        public String Apellido_1 { get; set; }

        /// <summary>
        /// Segundo apellido de un cliente
        /// </summary>
        public String Apellido_2 { get; set; }

        /// <summary>
        /// Primera dirección de un cliente
        /// </summary>
        public String Direccion_1 { get; set; }

        /// <summary>
        /// Segunda dirección de un cliente
        /// </summary>
        public String Direccion_2 { get; set; }

        /// <summary>
        /// Primer número de teléfono de un cliente
        /// </summary>
        public String Telefono_1 { get; set; }

        /// <summary>
        /// Segundo número de teléfono de un cliente
        /// </summary>
        public String Telefono_2 { get; set; }
        
    }
}
