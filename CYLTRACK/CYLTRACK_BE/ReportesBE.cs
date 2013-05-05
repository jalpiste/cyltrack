using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    [DataContract]
    public class ReportesBE
    {
        /// <summary>
        /// Mes del reporte
        /// </summary>
        [DataMember]
        public String Mes_Reporte { get; set; }

        /// <summary>
        /// Ubiación del Cilindro
        /// </summary>
        [DataMember]
        public Ubicacion_CilindroBE Ubicacion_Cilindro { get; set; }

        /// <summary>
        /// Vehículo
        /// </summary>
        [DataMember]
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Vehículo
        /// </summary>
        [DataMember]
        public DateTime Fecha_Reporte { get; set; }

        /// <summary>
        /// Cilindro
        /// </summary>
        [DataMember]
        public CilindroBE Cilindro { get; set; }
    }
}
