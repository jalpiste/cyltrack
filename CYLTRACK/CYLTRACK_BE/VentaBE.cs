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
    /// Clase utilizada para representar la entidad venta
    /// </summary>
    [DataContract]
    public class VentaBE
    {
        /// <summary>
        /// Identificador de venta
        /// </summary>
        [DataMember]
        public String Id_Venta { get; set; }

        /// <summary>
        /// Observaciones de la venta
        /// </summary>
        [DataMember]
        public String Observaciones { get; set; }

        /// <summary>
        /// Fecha de la venta
        /// </summary>
        [DataMember]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Detalle de la venta
        /// </summary>
        [DataMember]
        public Detalle_VentaBE Detalle_Venta { get; set; }

        /// <summary>
        /// Datos del vehículo 
        /// </summary>
        [DataMember]
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Cliente 
        /// </summary>
        [DataMember]
        public ClienteBE Cliente { get; set; }

        /// <summary>
        /// Contratista
        /// </summary>
        [DataMember]
        public ContratistaBE Contratista { get; set; }

        /// <summary>
        /// Ubicación
        /// </summary>
        [DataMember]
        public UbicacionBE Ubicacion { get; set; }

        /// <summary>
        /// Cilindro
        /// </summary>
        [DataMember]
        public CilindroBE Cilindro { get; set; }

        /// <summary>
        /// Pedido
        /// </summary>
        [DataMember]
        public PedidoBE Pedido { get; set; }

        /// <summary>
        /// Casos Especiales
        /// </summary>
        [DataMember]
        public CasosBE Casos_Especiales { get; set; }

        /// <summary>
        /// Reportes
        /// </summary>
        [DataMember]
        public ReportesBE Reportes { get; set; }

        /// <summary>
        /// Departamento
        /// </summary>
        [DataMember]
        public DepartamentoBE Departamento { get; set; }

        /// <summary>
        /// Ciudad
        /// </summary>
        [DataMember]
        public CiudadBE Ciudad { get; set; }

        /// <summary>
        /// Tamaño del cilindro
        /// </summary>
        [DataMember]
        public TamanoBE Tamano { get; set; }

        /// <summary>
        /// Conductor
        /// </summary>
        [DataMember]
        public ConductorBE Conductor { get; set; }

        /// <summary>
        /// Ruta
        /// </summary>
        [DataMember]
        public RutaBE Ruta { get; set; }

        /// <summary>
        /// Tipo de Casos
        /// </summary>
        [DataMember]
        public Tipo_CasoBE Tipo_Casos { get; set; }

    }
}
