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
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Tamaño
    /// </summary>
    [DataContract]
    public class TamanoBE
    {
        /// <summary>
        /// Identificador del tamaño del cilindro
        /// </summary>
        [DataMember]
        public String Id_Tamano { get; set; }

        /// <summary>
        /// Valor del tamaño del cilindro
        /// </summary>
        [DataMember]
        public String Tamano { get; set; }

        /// <summary>
        /// Descripcion del tamano del cilindro
        /// </summary>
        [DataMember]
        public String Descripcion { get; set; }

        /// <summary>
        /// Cantidad de Cilindros
        /// </summary>
        [DataMember]
        public int Cantidad { get; set; }
    }
}
