﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CYLTRACK_WebApp.ClienteService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://servicios.cyltrack.com.co/cyltrack/", ConfigurationName="ClienteService.IClienteService")]
    public interface IClienteService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IClienteService/Registrar_Cliente", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IClienteService/Registrar_ClienteRespon" +
            "se")]
        long Registrar_Cliente(Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IClienteService/Agregar_Ubicacion", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IClienteService/Agregar_UbicacionRespon" +
            "se")]
        long Agregar_Ubicacion(Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IClienteService/Consultar_Cliente", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IClienteService/Consultar_ClienteRespon" +
            "se")]
        Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE Consultar_Cliente(string cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IClienteService/Modificar_Cliente", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IClienteService/Modificar_ClienteRespon" +
            "se")]
        long Modificar_Cliente(Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IClienteService/ConsultarExistenciasCli" +
            "entes", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IClienteService/ConsultarExistenciasCli" +
            "entesResponse")]
        long ConsultarExistenciasClientes(string cliente);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClienteServiceChannel : CYLTRACK_WebApp.ClienteService.IClienteService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClienteServiceClient : System.ServiceModel.ClientBase<CYLTRACK_WebApp.ClienteService.IClienteService>, CYLTRACK_WebApp.ClienteService.IClienteService {
        
        public ClienteServiceClient() {
        }
        
        public ClienteServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public long Registrar_Cliente(Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE cliente) {
            return base.Channel.Registrar_Cliente(cliente);
        }
        
        public long Agregar_Ubicacion(Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE cliente) {
            return base.Channel.Agregar_Ubicacion(cliente);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE Consultar_Cliente(string cliente) {
            return base.Channel.Consultar_Cliente(cliente);
        }
        
        public long Modificar_Cliente(Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE cliente) {
            return base.Channel.Modificar_Cliente(cliente);
        }
        
        public long ConsultarExistenciasClientes(string cliente) {
            return base.Channel.ConsultarExistenciasClientes(cliente);
        }
    }
}
