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
        /// Identificador Vehículo
        /// </summary>
        [DataMember]
        public String IdVehiculo { get; set; }

        /// <summary>
        /// Identificador Ubicacion
        /// </summary>
        [DataMember]
        public String IdUbicacion { get; set; }

        /// <summary>
        /// Tipo de Cilindro
        /// </summary>
        [DataMember]
        public String Tipo_Cilindro { get; set; }

        /// <summary>
        /// Fecha Inicial del Reporte 
        /// </summary>
        [DataMember]
        public DateTime Fecha_Inicial { get; set; }

        /// <summary>
        /// Fecha Final Reporte 
        /// </summary>
        [DataMember]
        public DateTime Fecha_Final { get; set; }

        /// <summary>
        ///Sumatoria de Cilindros de 30 Libras
        /// </summary> 
        [DataMember]
        public Int32 SumCil30 { get; set; }

        /// <summary>
        ///Sumatoria de Cilindros de 40 Libras
        /// </summary> 
        [DataMember]
        public Int32 SumCil40 { get; set; }

        /// <summary>
        ///Sumatoria de Cilindros de 80 Libras
        /// </summary> 
        [DataMember]
        public Int32 SumCil80 { get; set; }

        /// <summary>
        ///Sumatoria de Cilindros de 100 Libras
        /// </summary> 
        [DataMember]
        public Int32 SumCil100 { get; set; }

    }
}
