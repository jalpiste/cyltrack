﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.235
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CYLTRACK_WebApp.UsuarioService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://servicios.cyltrack.com.co/cyltrack/", ConfigurationName="UsuarioService.IUsuarioService")]
    public interface IUsuarioService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/RegistrarUsuario", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/RegistrarUsuarioRespons" +
            "e")]
        string RegistrarUsuario(Unisangil.CYLTRACK.CYLTRACK_BE.UsuarioBE usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/ConsultarCargos", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/ConsultarCargosResponse" +
            "")]
        Unisangil.CYLTRACK.CYLTRACK_BE.PerfilBE[] ConsultarCargos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/ConsultarExistencia", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/ConsultarExistenciaResp" +
            "onse")]
        string ConsultarExistencia(string usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/Autenticacion", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/AutenticacionResponse")]
        bool Autenticacion(Unisangil.CYLTRACK.CYLTRACK_BE.UsuarioBE usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/RecuperarContrasena", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IUsuarioService/RecuperarContrasenaResp" +
            "onse")]
        string RecuperarContrasena(string usuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsuarioServiceChannel : CYLTRACK_WebApp.UsuarioService.IUsuarioService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuarioServiceClient : System.ServiceModel.ClientBase<CYLTRACK_WebApp.UsuarioService.IUsuarioService>, CYLTRACK_WebApp.UsuarioService.IUsuarioService {
        
        public UsuarioServiceClient() {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string RegistrarUsuario(Unisangil.CYLTRACK.CYLTRACK_BE.UsuarioBE usuario) {
            return base.Channel.RegistrarUsuario(usuario);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.PerfilBE[] ConsultarCargos() {
            return base.Channel.ConsultarCargos();
        }
        
        public string ConsultarExistencia(string usuario) {
            return base.Channel.ConsultarExistencia(usuario);
        }
        
        public bool Autenticacion(Unisangil.CYLTRACK.CYLTRACK_BE.UsuarioBE usuario) {
            return base.Channel.Autenticacion(usuario);
        }
        
        public string RecuperarContrasena(string usuario) {
            return base.Channel.RecuperarContrasena(usuario);
        }
    }
}