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

namespace CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Cilindro_Historial
    /// </summary>
    class Cilindro_Historial
    {
        /// <summary>
        /// Identificador del historico
        /// </summary>
        public String Id_Historico { get; set; }
       
        /// <summary>
        /// fecha de registro
        /// </summary>
        public DateTime Fecha { get; set; }
       
        /// <summary>
        /// Usuario que realiza el movimiento
        /// </summary>
        public String Usuario { get; set; }
       
        /// <summary>
        /// Identificador de ubicación del cilindro
        /// </summary>
        public String Id_Ubicación { get; set; }
        
        /// <summary>
        /// Observaciones del movimiento del cilindro
        /// </summary>
        public String Observacion { get; set; }
     
    }
}
