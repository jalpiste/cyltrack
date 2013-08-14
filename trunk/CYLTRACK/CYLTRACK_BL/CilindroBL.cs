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

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class CilindroBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        /// <summary>
        /// Método para el registro de cilindros en el sistema
        /// </summary>
        /// <param name="cilindro"></param>
        /// <returns></returns>
        public string CrearCilindro(CilindroBE cilindro)
        {
            string resp = "Ok";
            return resp;
        }

        public string consultadeExistencia(string cilindro)
        {
            string resp = "Ok";
            return resp;
        }

         public CilindroBE ConsultarCilindro(string cilindro)
        {
            CilindroBE cil = new CilindroBE();
            cil.Ano = "2012";
            FabricanteBE fab = new FabricanteBE();
            fab.Nombre_Fabricante = "Cilgas";
            cil.Fabricante = fab;
            cil.Serial_Cilindro = "51954";
            Tipo_UbicacionBE tipoUbi = new Tipo_UbicacionBE();
            tipoUbi.Nombre_Ubicacion = "Cliente";
            TamanoBE tam = new TamanoBE();
            tam.Tamano = "30";
            cil.NTamano = tam;
            cil.Codigo_Cilindro = "88091751954";
            cil.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //--------------------------------
            ClienteBE cli = new ClienteBE();
            cli.Cedula= "7309877";
            cli.Nombres_Cliente = "Jaime Andres";
            cli.Apellido_1 = "Ortiz";
            cli.Apellido_2 = "León";
            UbicacionBE ubi = new UbicacionBE();
            ubi.Direccion= "Calle 3 N 2-49";
            ubi.Barrio = "El Bosque";
            CiudadBE ciu = new CiudadBE();
            ciu.Nombre_Ciudad = "Chiquinquirá";
            DepartamentoBE dep = new DepartamentoBE();
            dep.Nombre_Departamento = "Boyacá";
            ciu.Departamento = dep;
            ubi.Telefono_1 = "7266530";
            cil.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            ubi.Ciudad = ciu;
            ubi.Cliente = cli;
            ubi.Tipo_Ubicacion = tipoUbi;
            
        
            //-----------------------------
            VehiculoBE veh = new VehiculoBE();
            veh.Placa = "XHA940";
            RutaBE ruta = new RutaBE();
            ruta.Nombre_Ruta= "Chiquinquirá-Ubaté";
            ConductorBE cond = new ConductorBE();
            cond.Nombres_Conductor= "Juanito perez";
            veh.Ruta = ruta;
            veh.Conductor = cond;
            ubi.Vehiculo = veh;
            cil.Ubicacion = ubi;
            
            return cil;
        }

        public string AsignarUbicacion(CilindroBE cilindro)
        {
            string resp;
            resp = "Ok";
            return resp;
        }

        public List<CilindroBE> CargueyDescargueCilindro(string cilindro)
        {

            List<CilindroBE> lstCod = new List<CilindroBE>();
            CilindroBE cil = new CilindroBE();
            
            //cargue de cilindros
            
            VehiculoBE vehiculo = new VehiculoBE();
            //vehiculo.Placa = "xha769";
            UbicacionBE ubi= new UbicacionBE();
            ubi.Vehiculo= vehiculo;
            cil.Ubicacion = ubi;
            string resp = cilindro;
           
                if (resp == "Plataforma")
                {
                    CilindroBE[] lista = new CilindroBE[7];
                    Random ran = new Random();
                    for (int i = 0; i < 7; i++)
                    {
                        CilindroBE datCil= new CilindroBE();
                        
                        datCil.Codigo_Cilindro=((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                        datCil.Tipo_Cilindro = "Universal";
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = "40";
                        datCil.NTamano = tam;
                        VehiculoBE veh = new VehiculoBE();
                        veh.Placa = "CAD678";
                        UbicacionBE ubicacion = new UbicacionBE();
                        ubicacion.Vehiculo = veh;
                        datCil.Ubicacion = ubicacion;
                        lista[i] = datCil;

                    }

                    lstCod = lista.ToList();
            }
                if (resp == "Vehiculo")
                {
                    CilindroBE[] lista = new CilindroBE[7];
                    Random ran = new Random();
                    for (int i = 0; i < 7; i++)
                    {
                        CilindroBE datCil= new CilindroBE();
                        
                        datCil.Codigo_Cilindro=((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
                        datCil.Tipo_Cilindro = "Marcado";
                        TamanoBE tam = new TamanoBE();
                        tam.Tamano = "30";
                        datCil.NTamano = tam;
                        VehiculoBE veh = new VehiculoBE();
                        veh.Placa = "UIZ987";
                        UbicacionBE ubicacion = new UbicacionBE();
                        ubicacion.Vehiculo = veh;
                        datCil.Ubicacion = ubicacion;
                        lista[i] = datCil;
                    }
                    lstCod = lista.ToList();
            }
            
            return lstCod;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
