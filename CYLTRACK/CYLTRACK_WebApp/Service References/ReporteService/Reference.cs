﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CYLTRACK_WebApp.ReporteService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://servicios.cyltrack.com.co/cyltrack/", ConfigurationName="ReporteService.IReporteService")]
    public interface IReporteService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/HistoricoCilindro", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/HistoricoCilindroRespon" +
            "se")]
        Unisangil.CYLTRACK.CYLTRACK_BE.ReportesBE[] HistoricoCilindro(string reporte);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/Inventario", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/InventarioResponse")]
        Unisangil.CYLTRACK.CYLTRACK_BE.ReportesBE[] Inventario(Unisangil.CYLTRACK.CYLTRACK_BE.ReportesBE reporte);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ConsultaReporteCiudades" +
            "", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ConsultaReporteCiudades" +
            "Response")]
        Unisangil.CYLTRACK.CYLTRACK_BE.UbicacionBE[] ConsultaReporteCiudades(string ciudad, string tipoCil);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReporteCilindro", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReporteCilindroResponse" +
            "")]
        Unisangil.CYLTRACK.CYLTRACK_BE.CilindroBE[] ReporteCilindro(string tipoCil);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReporteporPlacas", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReporteporPlacasRespons" +
            "e")]
        Unisangil.CYLTRACK.CYLTRACK_BE.UbicacionBE[] ReporteporPlacas(string tipoCil);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReporteClientes", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReporteClientesResponse" +
            "")]
        Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE[] ReporteClientes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReportePedidos", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReportePedidosResponse")]
        Unisangil.CYLTRACK.CYLTRACK_BE.PedidoBE[] ReportePedidos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ConsultarRuta", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ConsultarRutaResponse")]
        Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE[] ConsultarRuta();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReporteUsuario", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ReporteUsuarioResponse")]
        Unisangil.CYLTRACK.CYLTRACK_BE.UsuarioBE[] ReporteUsuario();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ConsultaTipoUbicacion", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ConsultaTipoUbicacionRe" +
            "sponse")]
        Unisangil.CYLTRACK.CYLTRACK_BE.Tipo_UbicacionBE[] ConsultaTipoUbicacion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ConsultaTamanoCilindro", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/ConsultaTamanoCilindroR" +
            "esponse")]
        Unisangil.CYLTRACK.CYLTRACK_BE.TamanoBE[] ConsultaTamanoCilindro();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/consultadeExistencia", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/consultadeExistenciaRes" +
            "ponse")]
        long consultadeExistencia(string dato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.cyltrack.com.co/cyltrack/IReporteService/consultadeExistenciaVar" +
            "ios", ReplyAction="http://servicios.cyltrack.com.co/cyltrack/IReporteService/consultadeExistenciaVar" +
            "iosResponse")]
        long consultadeExistenciaVarios(string dato);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReporteServiceChannel : CYLTRACK_WebApp.ReporteService.IReporteService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReporteServiceClient : System.ServiceModel.ClientBase<CYLTRACK_WebApp.ReporteService.IReporteService>, CYLTRACK_WebApp.ReporteService.IReporteService {
        
        public ReporteServiceClient() {
        }
        
        public ReporteServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReporteServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReporteServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReporteServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.ReportesBE[] HistoricoCilindro(string reporte) {
            return base.Channel.HistoricoCilindro(reporte);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.ReportesBE[] Inventario(Unisangil.CYLTRACK.CYLTRACK_BE.ReportesBE reporte) {
            return base.Channel.Inventario(reporte);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.UbicacionBE[] ConsultaReporteCiudades(string ciudad, string tipoCil) {
            return base.Channel.ConsultaReporteCiudades(ciudad, tipoCil);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.CilindroBE[] ReporteCilindro(string tipoCil) {
            return base.Channel.ReporteCilindro(tipoCil);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.UbicacionBE[] ReporteporPlacas(string tipoCil) {
            return base.Channel.ReporteporPlacas(tipoCil);
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.ClienteBE[] ReporteClientes() {
            return base.Channel.ReporteClientes();
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.PedidoBE[] ReportePedidos() {
            return base.Channel.ReportePedidos();
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.RutaBE[] ConsultarRuta() {
            return base.Channel.ConsultarRuta();
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.UsuarioBE[] ReporteUsuario() {
            return base.Channel.ReporteUsuario();
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.Tipo_UbicacionBE[] ConsultaTipoUbicacion() {
            return base.Channel.ConsultaTipoUbicacion();
        }
        
        public Unisangil.CYLTRACK.CYLTRACK_BE.TamanoBE[] ConsultaTamanoCilindro() {
            return base.Channel.ConsultaTamanoCilindro();
        }
        
        public long consultadeExistencia(string dato) {
            return base.Channel.consultadeExistencia(dato);
        }
        
        public long consultadeExistenciaVarios(string dato) {
            return base.Channel.consultadeExistenciaVarios(dato);
        }
    }
}
