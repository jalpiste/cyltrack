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
    /// Clase utilizada para representar la entidad Cilindro
    /// </summary>
    [DataContract]
    public class CilindroBE
    {
        /// <summary>
        /// Identificador del cilindro
        /// </summary>
        [DataMember]
        public String Id_Cilindro { get; set; }

        /// <summary>
        /// Año de fabricación del cilindro
        /// </summary>
        [DataMember]
        public String Ano { get; set; }

        /// <summary>
        /// Identificador fabricante de cilindro, 3 o 4 digitos
        /// </summary>
        [DataMember]
        public FabricanteBE Fabricante { get; set; }

        /// <summary>
        /// Código de 12 digitos
        /// </summary>
        [DataMember]
        public String Codigo_Cilindro { get; set; }

        /// <summary>
        /// Tamaño del cilindro
        /// </summary>
        [DataMember]
        public TamanoBE NTamano { get; set; }

        /// <summary>
        /// Estado actual del cilindro, en uso o chatarra
        /// </summary>
        [DataMember]
        public String Estado { get; set; }

        /// <summary>
        /// Tipo de cilindro, universal o de marca
        /// </summary>
        [DataMember]
        public String Tipo_Cilindro { get; set; }

        /// <summary>
        /// Código de 4 digitos restantes
        /// </summary>
        [DataMember]
        public String Serial_Cilindro { get; set; }

        /// <summary>
        /// Nombre de la ubicación del cilindro
        /// </summary>
        [DataMember]
        public Tipo_UbicacionBE Tipo_Ubicacion { get; set; }

        /// <summary>
        /// Fecha de la creación del cilindro
        /// </summary>
        [DataMember]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Vehículo
        /// </summary>
        [DataMember]
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        [DataMember]
        public ClienteBE Cliente { get; set; }

        /// <summary>
        /// Ubicación del cilindro
        /// </summary>
        [DataMember]
        public UbicacionBE Ubicacion { get; set; }

        /// <summary>
        /// Ciudad del cliente
        /// </summary>
        [DataMember]
        public CiudadBE Ciudad { get; set; }



    }
}
