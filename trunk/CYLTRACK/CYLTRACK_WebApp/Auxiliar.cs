using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp
{
    public static class Auxiliar
    {

        public static List<string> ConsultarMeses()
        {
            List<string> meses = new List<string>();
            meses = Enum.GetNames(typeof(Meses)).ToList();
            return meses;
        }

        public static Dias[] ConsultarDias()
        {
            Dias[] dias = new Dias[32];
            for (int i = 1; i < 32; i++) 
            {
                dias[i]+=i;
            }
                return dias;
        }

        public static Anos[] ConsultarAnos()
        {
            int aux=(DateTime.Now.Year)-91;
            Anos[] Ano = new Anos[77];
            for (int i = 1; i < 77; i++)
            {
                Ano[i]+= aux+i;
            }
            return Ano;
        }

        public static List<string> ConsultarSexo()
        {
            List<string> sexo = new List<string>();
            sexo = Enum.GetNames(typeof(Sexo)).ToList();
            return sexo;
        }

        public static List<string> ConsultarTipoCaso()
        {
            List<string> tipoCaso = new List<string>();
            tipoCaso = Enum.GetNames(typeof(Tipo_Casos)).ToList();
            return tipoCaso;
        }

        public static List<string> ConsultarUbicacion()
        {
            List<string> Ubicacion = new List<string>();
            Ubicacion = Enum.GetNames(typeof(Ubicacion)).ToList();
            return Ubicacion;
        }
        public static List<string> ConsultaTipoCilindro ()
        {
            List<String> tipoCil = new List<string>();
            tipoCil = Enum.GetNames(typeof(Tipo_Cilindro)).ToList();
            return tipoCil;
        }
        public static List<string> ConsultarTamanos()
        {
            List<String> tam = new List<string>();
            tam = Enum.GetNames(typeof(Tamanos)).ToList();
            return tam;
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
        Plataforma= 1,
        Bodega =2,
        Mantenimiento= 3,
        Chatarra= 4,
        Vehiculo=5,
        Cliente = 6
    }

    public enum Tamanos 
    {
    Cil30  = 1,
    Cil40  = 2,
    Cil80  = 3,
    Cil100 = 4,
    
    }
    
    
}