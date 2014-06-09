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
using Unisangil.CYLTRACK.CYLTRACK_DL;

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class ReporteBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public List<ReportesBE> HistoricoCilindro(string reporte)
        {
            List<ReportesBE> resp = new List<ReportesBE>();
            ReportesBE report = new ReportesBE();
            CilindroBE cil = new CilindroBE();
            TamanoBE tam = new TamanoBE();
            cil.NTamano = tam;
            report.Cilindro = cil;
            report.Cilindro.Codigo_Cilindro = reporte;
            report.Cilindro.NTamano.Tamano = "30";
            report.Fecha_Reporte = DateTime.Now;
            UbicacionBE ubi = new UbicacionBE();
            Tipo_UbicacionBE tipoUbica = new Tipo_UbicacionBE();
            ubi.Tipo_Ubicacion= tipoUbica;            
            report.Ubicacion = ubi;
            report.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = "Vehiculo";

            resp.Add(report);

            return resp;
        }

        public List<ReportesBE> Inventario(ReportesBE reporte)
        {
            List<ReportesBE> resp= new List<ReportesBE>();
            ReportesBE[] lista = new ReportesBE[7];
            Random ran = new Random();
            for (int i = 0; i < 7; i++)
            {
                ReportesBE datReporte = new ReportesBE();

                CilindroBE cil = new CilindroBE();
                cil.Codigo_Cilindro = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                cil.Tipo_Cilindro = "Marcado";
                TamanoBE tam = new TamanoBE();
                tam.Tamano = "30";
                cil.NTamano = tam;
                datReporte.Cilindro = cil;
                VehiculoBE veh = new VehiculoBE();
                veh.Placa = "UIZ987";
                UbicacionBE ubicacion = new UbicacionBE();
                Tipo_UbicacionBE tipoUbica = new Tipo_UbicacionBE();
                ubicacion.Tipo_Ubicacion = tipoUbica;
                ubicacion.Vehiculo = veh;
                datReporte.Ubicacion = ubicacion;

                if (reporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion == "Vehiculo")
                {
                    datReporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = "XHA940";
                    datReporte.Cilindro.Tipo_Cilindro = "Universal";
                    datReporte.Cilindro.Cantidad = 5;
                }
                else
                {
                    datReporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion = reporte.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion;
                    datReporte.Cilindro.Tipo_Cilindro = reporte.Cilindro.Tipo_Cilindro;
                    datReporte.Cilindro.Cantidad = 5;
                }
            
                lista[i] = datReporte;
            }

            resp = lista.ToList();

            return resp;
        }

        public List<UbicacionBE> ConsultaReporteCiudades(string ciudad, string tipoCil)
        {
            List<UbicacionBE> lstCiudades = new List<UbicacionBE>();
            for (int i = 0; i < 4; i++)
            {
                UbicacionBE ubicacion = new UbicacionBE();
                CiudadBE ciu = new CiudadBE();
                ciu.Nombre_Ciudad = "Chiquinquirá";
                DepartamentoBE dep = new DepartamentoBE();
                dep.Nombre_Departamento = "Boyacá";
                ciu.Departamento = dep;
                ubicacion.Ciudad = ciu;
                Ubicacion_CilindroBE ubiCil = new Ubicacion_CilindroBE();
                CilindroBE cilindro = new CilindroBE();
                TamanoBE tam = new TamanoBE();
                tam.Tamano = "30";
                cilindro.NTamano = tam;
                cilindro.Cantidad = 34;
                ubiCil.Cilindro = cilindro;
                ubicacion.Ubicacion_Cilindro = ubiCil;
                lstCiudades.Add(ubicacion);
            }
            return lstCiudades;
        }

        public List<CilindroBE> ReporteCilindros(string tipoCil)
        {
            List<CilindroBE> lstCilindros = new List<CilindroBE>();
            Random ran = new Random();

            for (int i = 0; i < 7;i++ ) { 
            CilindroBE cil = new CilindroBE();
            cil.Ano = "2012";
            cil.Id_Cilindro = ""+i * 2;
            FabricanteBE fab = new FabricanteBE();
            fab.Nombre_Fabricante = "Cilgas";
            cil.Fabricante = fab;
            cil.Serial_Cilindro = "51954";
            Tipo_UbicacionBE tipoUbi = new Tipo_UbicacionBE();
            tipoUbi.Nombre_Ubicacion = "Cliente";
            TamanoBE tam = new TamanoBE();
            tam.Tamano = "30";
            cil.NTamano = tam;
            cil.Tipo_Cilindro = "Universal";
            cil.Codigo_Cilindro = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
            cil.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            UsuarioBE usuario = new UsuarioBE();
            usuario.Nombre = "Jackys";
            //A que entidad va conectada usuario??
            lstCilindros.Add(cil);
            }
            return lstCilindros;
        }

        public List<UbicacionBE> ReporteporPlacas(string tipoCil)
        {
            List<UbicacionBE> lstConsultaPlacas = new List<UbicacionBE>();

            List<string> lstPlacas = new List<string>();
            string[] letras = new string[] { "A", "R", "J", "L", "P", "V" };
            Random ran = new Random();

             for (int i = 0; i < 4; i++)
            {
                UbicacionBE ubicacion = new UbicacionBE();
                VehiculoBE vehiculo= new VehiculoBE();
                vehiculo.Placa = letras[i] + "" + letras[i] + "" + letras[i] + "" + ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                ubicacion.Vehiculo = vehiculo;
                Ubicacion_CilindroBE ubiCil = new Ubicacion_CilindroBE();
                CilindroBE cilindro = new CilindroBE();
                TamanoBE tam = new TamanoBE();
                tam.Tamano = "30";
                cilindro.NTamano = tam;
                cilindro.Cantidad = 34;
                ubiCil.Cilindro = cilindro;
                ubicacion.Ubicacion_Cilindro = ubiCil;
                lstConsultaPlacas.Add(ubicacion);
            }
            return lstConsultaPlacas;
            
        }

        public List<ClienteBE> ReporteClientes() 
        {
            List<ClienteBE> lstCliente = new List<ClienteBE>();
            Random ran = new Random();
            for (int i = 0; i < 4; i++)
            {
                ClienteBE cliente = new ClienteBE();
                cliente.Id_Cliente = "" + i * 3;
                cliente.Cedula = "56235624";
                cliente.Nombres_Cliente = "Jaime";
                cliente.Apellido_1 = "Poveda";
                cliente.Apellido_2 = "Sanchez";

                UbicacionBE ubicacion = new UbicacionBE();
                //List<string> lstDireccion = new List<string>();
                
                //lstDireccion.Add("Calle" + i + " N " + i + "0 " + i + "0");
              
                //ubicacion.Direccion = lstDireccion;
                ubicacion.Barrio = "Centro";
                ubicacion.Telefono_1 = "3143456789";
                ubicacion.fecha = Convert.ToString(DateTime.Now);
                CiudadBE ciu_cli = new CiudadBE();
                ciu_cli.Nombre_Ciudad = "Chiquinquirá";
                ubicacion.Ciudad = ciu_cli;

                DepartamentoBE dep_cli = new DepartamentoBE();
                dep_cli.Nombre_Departamento = "Boyacá";
                ciu_cli.Departamento = dep_cli;
                cliente.Ubicacion = ubicacion;

                lstCliente.Add(cliente);
            }
            return lstCliente;
        }

        public List<PedidoBE> ReportePedidos() 
        {
            Random ran = new Random();

            List<PedidoBE> lstPedidos = new List<PedidoBE>();
            
            for (int i = 0; i < 5; i++)
            {
                PedidoBE conPedido = new PedidoBE();
                conPedido.Id_Pedido = ""+i*3;
                conPedido.Fecha = DateTime.Now.AddHours(5);

                ClienteBE cliente = new ClienteBE();
                cliente.Cedula = "56235624";

                UbicacionBE ubicacion = new UbicacionBE();

                Ubicacion_CilindroBE ubi_cil = new Ubicacion_CilindroBE();
                ubicacion.Ubicacion_Cilindro = ubi_cil;

                List<CilindroBE> lstCilindros = new List<CilindroBE>();
                CilindroBE cilindro = new CilindroBE();
                TamanoBE tam = new TamanoBE();
                tam.Tamano = "40";
                cilindro.NTamano = tam;

                lstCilindros.Add(cilindro);
                VehiculoBE veh = new VehiculoBE();
                veh.Placa = "XHA940";
                ubicacion.Vehiculo = veh;

               // conPedido.Ubicacion = ubicacion;
                conPedido.Vehiculo = veh;
                conPedido.Cliente = cliente;
                conPedido.Cilindro = lstCilindros;
                lstPedidos.Add(conPedido);
            }
            return lstPedidos;
       
        }

        public List<RutaBE> ReporteRuta()
        {
            List<RutaBE> rutaConsulta = new List<RutaBE>();
            for(int i=0;i<4;i++){
            RutaBE ruta = new RutaBE();
            ruta.Id_Ruta = "" + i * 4;
            CiudadBE ciu = new CiudadBE();
            ciu.Nombre_Ciudad = "Chiquinquirá";
            //ruta.Ciudad = ciu;
            DepartamentoBE dep = new DepartamentoBE();
            dep.Nombre_Departamento = "Boyacá";
            ciu.Departamento = dep;
            Ciudad_RutaBE ciuRuta = new Ciudad_RutaBE();
            //List<CiudadBE> lstCiudades = new List<CiudadBE>();
            //lstCiudades.Add(ciu);
            //ciuRuta.Ciudad = lstCiudades;
            ruta.Nombre_Ruta = "Zona Occidente";
            ruta.Ciudad_Ruta = ciuRuta;
            rutaConsulta.Add(ruta);
            }
            return rutaConsulta;
        }

        public List<UsuarioBE> ReporteUsuario() 
        {
            List<UsuarioBE> lstUsuarios = new List<UsuarioBE>();

            for(int i=0; i<5;i++)
            {
            UsuarioBE usuario = new UsuarioBE();
            usuario.Id_Usuario = "" + i * 5;
            usuario.Usuario = "Jacky";
            PerfilBE perfil = new PerfilBE();
            perfil.Perfil = "Administrador";
            List<PerfilBE> lstPerfil = new List<PerfilBE>();
            lstPerfil.Add(perfil);
            usuario.Perfil = lstPerfil;
            lstUsuarios.Add(usuario);
                       }
            return lstUsuarios;
        }

        public List<VehiculoBE> ReporteVehiculos()
        {
            List<VehiculoBE> lstVehiculo = new List<VehiculoBE>();
            for (int i = 0; i < 5;i++ )
            {
                VehiculoBE vehiculo = new VehiculoBE();
                //vehiculo.Id_Vehiculo = "" + i * 2;
                vehiculo.Placa = "XHA098";
                vehiculo.Marca = "Kia";
                vehiculo.Cilindraje = "2800";
                vehiculo.Modelo = "2010";
                vehiculo.Motor = "ODJGDSJ335252VVDS";
                vehiculo.Chasis = "ODJGDSJ335252VVDS111";
                //--------------------------------
                
                ConductorBE conductor = new ConductorBE();
                conductor.Cedula = "19080347";
                conductor.Nombres_Conductor = "Pablo";
                conductor.Apellido_1 = "Pérez";
                conductor.Apellido_2 = "Pinto";
                vehiculo.Conductor = conductor;

                RutaBE ruta = new RutaBE();
                ruta.Nombre_Ruta = "Chiquinquirá-Boyacá";
                vehiculo.Ruta = ruta;
               
                lstVehiculo.Add(vehiculo);
            }
            return lstVehiculo;
        }

        public IList<Tipo_UbicacionBE> ConsultaTipoUbicacion() 
        {
            ReporteDL reporte = new ReporteDL();
            IList<Tipo_UbicacionBE> lstReport = new List<Tipo_UbicacionBE>();
            try
            {
                lstReport = reporte.ConsultarTipoUbicaciones();
            }
            catch (Exception ex)
            {
                
            }
            return lstReport;
        }
       
        public List<TamanoBE> ConsultaTamanoCilindro() 
        {
            ReporteDL reporte = new ReporteDL();
            List<TamanoBE> lstReport = new List<TamanoBE>();
            try
            {
                lstReport = reporte.ConsultarTamanosCilindros();
            }
            catch (Exception ex)
            {
                
            }
            return lstReport;
        }

        public long consultadeExistencia(string dato)
        {
            ReporteDL rep = new ReporteDL();
            long resp = 0;
            try
            {
                resp = rep.ConsultarExistencias(dato);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }
        public long consultadeExistenciaVarios(string dato)
        {
            ReporteDL rep = new ReporteDL();
            long resp = 0;
            try
            {
                resp = rep.ConsultarExistenciasVarios(dato);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;

        }

        #endregion
        
        #region Metodos privados
        #endregion
    }
}
