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
        /// ubicación de un cliente
        /// </summary>              
        public UbicacionBE Ubicacion { get; set; }

        /// <summary>
        /// ciudad de ubicación de un cliente
        /// </summary>              
        public CiudadBE Ciudad { get; set; }

        /// <summary>
        /// cilindro de un cliente
        /// </summary>              
        public CilindroBE Cilindro { get; set; }

       
    }
}
