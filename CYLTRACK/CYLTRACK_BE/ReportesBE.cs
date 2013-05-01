using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    public class ReportesBE
    {
        /// <summary>
        /// Mes del reporte
        /// </summary>
        public String Mes_Reporte { get; set; }

        /// <summary>
        /// Ubiación del Cilindro
        /// </summary>
        public Ubicacion_CilindroBE Ubicacion_Cilindro { get; set; }

        /// <summary>
        /// Vehículo
        /// </summary>
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Vehículo
        /// </summary>
        public DateTime Fecha_Reporte { get; set; }

        /// <summary>
        /// Cilindro
        /// </summary>
        public CilindroBE Cilindro { get; set; }
    }
}
