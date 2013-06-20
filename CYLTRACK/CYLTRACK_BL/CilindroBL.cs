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
        public String CrearCilindro(CilindroBE cilindro)
        {
            String resp = "Ok";
            return resp;
        }

        public List<CilindroBE> ConsultarCilindro(CilindroBE cilindro)
        {
            List<CilindroBE> lstCil = new List<CilindroBE>();
            CilindroBE cil = new CilindroBE();
            cil.Ano = "2012";
            FabricanteBE fab = new FabricanteBE();
            fab.Nombre_Fabricante = "Cilgas";
            cil.Fabricante = fab;
            cil.Serial_Cilindro = "51954";
            Tipo_UbicacionBE tipoUbi = new Tipo_UbicacionBE();
            tipoUbi.Nombre_Ubicacion = "Cliente";
            cil.Tipo_Ubicacion = tipoUbi;
            TamanoBE tam = new TamanoBE();
            tam.Tamano = "30";
            cil.NTamano = tam;
            cil.Codigo_Cilindro = cilindro.Codigo_Cilindro;
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
            cil.Cliente = cli;
            cil.Ubicacion = ubi;
            cil.Ciudad = ciu;
            //-----------------------------
            VehiculoBE veh = new VehiculoBE();
            veh.Placa = "XHA940";
            RutaBE ruta = new RutaBE();
            ruta.Nombre_Ruta= "Chiquinquirá-Ubaté";
            ConductorBE cond = new ConductorBE();
            cond.Nombres_Conductor= "Juanito perez";
            cil.Vehiculo = veh;
            cil.Vehiculo.Ruta = ruta;
            cil.Vehiculo.Conductor = cond;
            
            lstCil.Add(cil);
            return lstCil;
        }

        public List<CilindroBE> AsignarUbicacion(CilindroBE cilindro)
        {
            List<CilindroBE> lstAsig = new List<CilindroBE>();
            CilindroBE cil = new CilindroBE();

            Tipo_UbicacionBE tipUbi = new Tipo_UbicacionBE();
            tipUbi.Nombre_Ubicacion = "Vehiculo";
            cil.Tipo_Ubicacion = tipUbi;
            ConductorBE cond = new ConductorBE();
            cond.Nombres_Conductor = "Jaime Niño";
            VehiculoBE veh = new VehiculoBE();
            veh.Conductor = cond;
            cil.Vehiculo = veh;            
            cil.Vehiculo.Placa = "CHE987";
            RutaBE ruta = new RutaBE();
            ruta.Nombre_Ruta = "Chiqqrá-Ubate";
            cil.Vehiculo.Ruta = ruta;
            lstAsig.Add(cil);
           

            return lstAsig;
        }

        public List<CilindroBE> CargueyDescargueCilindro(CilindroBE cilindro)
        {

            List<CilindroBE> lstCod = new List<CilindroBE>();
            CilindroBE cil = new CilindroBE();
            
            //cargue de cilindros
            
            VehiculoBE vehiculo = new VehiculoBE();
            vehiculo.Placa = "xha769";
            cil.Vehiculo = vehiculo;
            
            CilindroBE resp = cilindro;
            //UbicacionBE ubi = new UbicacionBE();
            //Tipo_UbicacionBE tip = new Tipo_UbicacionBE();
            //ubi.Tipo_Ubicacion = tip;
            //resp.Ubicacion = ubi;
           
                if (resp.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion == "Plataforma")
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
                        datCil.Vehiculo = veh;
                        lista[i] = datCil;

                    }

                    lstCod = lista.ToList();
            }
                if (resp.Ubicacion.Tipo_Ubicacion.Nombre_Ubicacion == "Vehiculo")
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
                        datCil.Vehiculo = veh;
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
