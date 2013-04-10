﻿/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Deerechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Conductor
    /// </summary>
    
    class Conductor
    {
        /// <summary>
        /// Identificador de un conductor
        /// </summary>
        public String Id_Conductor { get; set; }

        /// <summary>
        /// nombres de un conductor
        /// </summary>
        public String Nombres { get; set; }

        /// <summary>
        /// Primer apellido de un conductor
        /// </summary>
        public String Apellido_1 { get; set; }

        /// <summary>
        /// Segundo apellido de un conductor
        /// </summary>
        public String Apellido_2 { get; set; }

        /// <summary>
        /// direccion de un conductor
        /// </summary>
        public String Direccion { get; set; }

        /// <summary>
        /// teléfono de un conductor
        /// </summary>
        public String Telefono { get; set; }

    }
}