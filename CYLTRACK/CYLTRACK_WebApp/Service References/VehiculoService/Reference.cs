﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.235
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CYLTRACK_WebApp.VehiculoService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://servicios.cyltrack.com.co/cyltrack/", ConfigurationName="VehiculoService.IVehiculoService")]
    public interface IVehiculoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Registrar_Vehiculo", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Registrar_VehiculoResp" +
            "onse")]
        string Registrar_Vehiculo(Unisangil.CYLTRACK.CYLTRACK_BE.VehiculoBE vehiculo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Consultar_Vehiculo", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Consultar_VehiculoResp" +
            "onse")]
        Unisangil.CYLTRACK.CYLTRACK_BE.VehiculoBE Consultar_Vehiculo(string vehiculo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Consultar_Existencia", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Consultar_ExistenciaRe" +
            "sponse")]
        string Consultar_Existencia([System.ServiceModel.MessageParameterAttribute(Name="consultar_existencia")] string consultar_existencia1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Modificar_Vehiculo", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Modificar_VehiculoResp" +
            "onse")]
        string Modificar_Vehiculo(string vehiculo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Consultar_Conductor", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/Consultar_ConductorRes" +
            "ponse")]
        Unisangil.CYLTRACK.CYLTRACK_BE.VehiculoBE Consultar_Conductor(string conductor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/ConsultarPlacaSinParam" +
            "etro", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/ConsultarPlacaSinParam" +
            "etroResponse")]
        string[] ConsultarPlacaSinParametro();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/ConsultarPlaca", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IVehiculoService/ConsultarPlacaResponse" +
            "")]
        string[] ConsultarPlaca(string ciudad);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVehiculoServiceChannel : CYLTRACK_WebApp.VehiculoService.IVehiculoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VehiculoServiceClient : System.ServiceModel.ClientBase<CYLTRACK_WebApp.VehiculoService.IVehiculoService>, CYLTRACK_WebApp.VehiculoService.IVehiculoService {
        
        public VehiculoServiceClient() {
        }
        
        public VehiculoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VehiculoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VehiculoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VehiculoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Registrar_Vehiculo(Unisangil.CYLTRACK.CYLTRACK_BE.VehiculoBE vehiculo) {
            return base.Channel.Registrar_Vehiculo(vehiculo);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.VehiculoBE Consultar_Vehiculo(string vehiculo) {
            return base.Channel.Consultar_Vehiculo(vehiculo);
        }
        
        public string Consultar_Existencia(string consultar_existencia1) {
            return base.Channel.Consultar_Existencia(consultar_existencia1);
        }
        
        public string Modificar_Vehiculo(string vehiculo) {
            return base.Channel.Modificar_Vehiculo(vehiculo);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.VehiculoBE Consultar_Conductor(string conductor) {
            return base.Channel.Consultar_Conductor(conductor);
        }
        
        public string[] ConsultarPlacaSinParametro() {
            return base.Channel.ConsultarPlacaSinParametro();
        }
        
        public string[] ConsultarPlaca(string ciudad) {
            return base.Channel.ConsultarPlaca(ciudad);
        }
    }
}
