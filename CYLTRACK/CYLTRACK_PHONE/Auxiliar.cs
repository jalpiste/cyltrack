using System;
using System.Collections.Generic;
using System.Linq;

namespace Unisangil.CYLTRACK.CYLTRACK_PHONE
{
    public static class Auxiliar
    {

        public static List<string> ConsultarMeses()
        {
            List<string> meses = new List<string>();
            meses.Add(Enum.GetName(typeof(Meses), 1));
            return meses;
        }

        public static Dias[] ConsultarDias()
        {
            Dias[] dias = new Dias[32];
            for (int i = 1; i < 32; i++)
            {
                dias[i] += i;
            }
            return dias;
        }

        public static Anos[] ConsultarAnos()
        {
            int aux = (DateTime.Now.Year) - 91;
            Anos[] Ano = new Anos[92];
            for (int i = 1; i < 92; i++)
            {
                Ano[i] += aux + i;
            }
            return Ano;
        }

        public static List<string> ConsultarSexo()
        {
            List<string> sexo = new List<string>();
            sexo.Add(Enum.GetName(typeof(Sexo), 1));
            return sexo;
        }

        public static List<string> ConsultarTipoCaso()
        {
            List<string> tipoCaso = new List<string>();
            tipoCaso.Add(Enum.GetName(typeof(Tipo_Casos),1));
            return tipoCaso;
        }

        public static List<string> ConsultarUbicacion()
        {
            List<string> Ubicacion = new List<string>();
            Ubicacion.Add(Enum.GetName(typeof(Ubicacion),1));
            return Ubicacion;
        }

        public static List<string> ConsultarTipoReporte()
        {
            List<string> TipoReporte = new List<string>();
            TipoReporte.Add(Enum.GetName(typeof(Tipo_Reporte),1));
            return TipoReporte;
        }

        public static List<string> ConsultaTipoCilindro()
        {
            List<String> tipoCil = new List<string>();
            tipoCil.Add(Enum.GetName(typeof(Tipo_Cilindro),1));
            return tipoCil;
        }
        public static List<string> ConsultarTamanos()
        {
            List<String> tam = new List<string>();
            tam.Add(Enum.GetName(typeof(Tamanos),1));
            return tam;
        }
        public static List<string> ConsultaTipo_Autenticacion()
        {
            List<string> autenticacion = new List<string>();
            autenticacion.Add(Enum.GetName(typeof(Tipo_Autenticacion),1));
            return autenticacion;
        }
    }
        public enum Tipo_Cilindro
        {
            Universal = 1,
            Marcado = 2,
        }
        public enum Meses
        {
            Enero = 1,
            Febrero = 2,
            Marzo = 3,
            Abril = 4,
            Mayo = 5,
            Junio = 6,
            Julio = 7,
            Agosto = 8,
            Septiembre = 9,
            Octubre = 10,
            Noviembre = 11,
            Diciembre = 12
        }
        public enum Dias
        {
            Dia
        }
        public enum Anos
        {
            Ano
        }
        public enum Sexo
        {
            Mujer = 1,
            Hombre = 2,
            Indefinido = 3
        }
        public enum Tipo_Casos
        {
            Escape = 1,
            Terminacion_Contrato = 2,
            Codigo_Errado = 3,
        }
        public enum Ubicacion
        {
            Cliente = 1,
            Vehiculo = 2,
            Mantenimiento = 3,
            Chatarra = 4,
            Bodega = 5,
            Plataforma = 6
        }
        public enum Tamanos
        {
            Cil30 = 1,
            Cil40 = 2,
            Cil80 = 3,
            Cil100 = 4,

        }
        public enum Tipo_Reporte
        {
            Clientes=1,
            Pedidos= 2,
            Rutas=3,
            Usuarios=4,
            Ventas=5,
            Ciudad = 6,
            Cilindros = 7,
            Vehiculos = 8,
            
        }
        public enum Tipo_Autenticacion
        {
            PrimeraVez = 1,
            SegundaVez = 2,
            Erroneo = 3
        }

}