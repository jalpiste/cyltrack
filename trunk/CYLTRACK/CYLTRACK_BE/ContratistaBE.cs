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
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Contratista
    /// </summary>
     [DataContract]
    public class ContratistaBE
    {
        /// <summary>
        /// Identificador del Contratista
        /// </summary>
        [DataMember]
         public String Id_Contratista { get; set; }

        /// <summary>
        /// Número de cédula del contratista
        /// </summary>
         [DataMember]
         public String Cedula { get; set; }

        /// <summary>
        /// Nombres del Contratista
        /// </summary>
         [DataMember]
         public String Nombres { get; set; }

        /// <summary>
        /// Apellidos del Contratista
        /// </summary>
         [DataMember]
         public String Apellidos { get; set; }

        /// <summary>
        /// Dirección del Contratista
        /// </summary>
         [DataMember]
         public String Direccion { get; set; }

        /// <summary>
        /// Telefono del Contratista
        /// </summary>
         [DataMember]
         public String Telefono { get; set; }



    }
}
