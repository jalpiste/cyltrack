﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.296
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CYLTRACK_WebApp.RutaService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://servicios.cyltrack.com.co/cyltrack/", ConfigurationName="RutaService.IRutaServices")]
    public interface IRutaServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IRutaServices/RegistrarRuta", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IRutaServices/RegistrarRutaResponse")]
        string RegistrarRuta(Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE ruta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IRutaServices/ModificarRuta", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IRutaServices/ModificarRutaResponse")]
        string ModificarRuta(Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE ruta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IRutaServices/ConsultarRuta", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IRutaServices/ConsultarRutaResponse")]
        Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE[] ConsultarRuta(Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE ruta);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRutaServicesChannel : CYLTRACK_WebApp.RutaService.IRutaServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RutaServicesClient : System.ServiceModel.ClientBase<CYLTRACK_WebApp.RutaService.IRutaServices>, CYLTRACK_WebApp.RutaService.IRutaServices {
        
        public RutaServicesClient() {
        }
        
        public RutaServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RutaServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RutaServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RutaServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string RegistrarRuta(Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE ruta) {
            return base.Channel.RegistrarRuta(ruta);
        }
        
        public string ModificarRuta(Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE ruta) {
            return base.Channel.ModificarRuta(ruta);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE[] ConsultarRuta(Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE ruta) {
            return base.Channel.ConsultarRuta(ruta);
        }
    }
}
