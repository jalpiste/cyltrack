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
    /// Clase utilizada para identificar la entidad Ubicacion_Cilindro
    /// </summary>
    [DataContract]
    public class Ubicacion_CilindroBE
    {
        /// <summary>
        /// Identificador de la Ubicacion del Cilindro
        /// </summary> 
        [DataMember]
        public String Id_Ubicacion_Cilindro { get; set; }

        /// <summary>
        /// Fecha inicial
        /// </summary> 
        [DataMember]
        public DateTime Fecha_Inicial { get; set; }

        /// <summary>
        /// fecha final
        /// </summary> 
        [DataMember]
        public DateTime Fecha_Final { get; set; }

        /// <summary>
        /// Observaciones
        /// </summary> 
        [DataMember]
        public String Observaciones { get; set; }

        /// <summary>
        ///Flag que indica si esta es la ubicación actual del cilindro. Uno (1) Actual y Cero (0) No Actual
        /// </summary> 
        [DataMember]
        public String Actual { get; set; }

        /// <summary>
        ///Entidad Cilindro
        /// </summary> 
        [DataMember]
        public CilindroBE Cilindro { get; set; }

        /// <summary>
        ///Entidad Ubicación
        /// </summary> 
        [DataMember]
        public UbicacionBE Ubicacion { get; set; }

    }
}

