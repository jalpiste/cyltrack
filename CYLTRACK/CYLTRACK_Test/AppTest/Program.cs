using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using Unisangil.CYLTRACK.AppTest;
using AppTest.PruebaService;

namespace Unisangil.CYLTRACK.AppTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program pp = new Program();
            //pp.CrearPrueba();
            pp.ConsultarPruebas();
            //pp.ConsultarPrueba(5);
            //pp.ModificarPrueba(2);
            Console.Read();
        }

        public void CrearPrueba()
        {
            PruebaBE prueba = new PruebaBE();
            prueba.Descripción = "Hola mundo 1";
            long resp = 0;
            string descripcion = "";
            Service1Client serv = new Service1Client();
            try
            {
                resp = serv.CrearPrueba(prueba);
            }
            catch
            {
                resp = -1;
            }

            serv.Close();
            if (resp <= 0)
                descripcion = "No fue posible crear prueba";
            else
                descripcion = "Prueba creada, codigo: " + resp;

            Console.WriteLine(descripcion);

        }

        public void ConsultarPruebas()
        {
            Service1Client serv = new Service1Client();
            List<PruebaBE> pruebas = new List<PruebaBE>(serv.ConsultarPruebas(0));
            try
            {
                if (pruebas.Count > 0)
                    foreach (PruebaBE pru in pruebas)
                    {
                        Console.WriteLine("*** Id Prueba: " + pru.IdPrueba + " - Descripción: " + pru.Descripción + " - Fecha: " + pru.Fecha + " ***\n");
                    }
                else
                    Console.WriteLine("No se encontraron pruebas");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta");
            }
            serv.Close();
        }

        public int ConsultarPrueba(int idPrueba)
        {
            Service1Client serv = new Service1Client();
            PruebaBE prueba = serv.ConsultarPruebas(idPrueba).Count == 0 ? null : serv.ConsultarPruebas(idPrueba)[0];
            int id = -1;
            try
            {
                if (prueba != null)
                {
                    Console.WriteLine("*** Id Prueba: " + prueba.IdPrueba + " - Descripción: " + prueba.Descripción + " - Fecha: " + prueba.Fecha + " ***\n");
                    id = prueba.IdPrueba;
                }
                else
                    Console.WriteLine("No se encontraron pruebas para el id: " + idPrueba);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta");
                id = -1;
            }
            serv.Close();
            return id;
        }

        public void ModificarPrueba(int idPrueba)
        {
            int resp = 0, id = 0;
            string descripcion = "";
            Service1Client serv = new Service1Client();
            PruebaBE prueba = new PruebaBE();
            try
            {
                id = this.ConsultarPrueba(idPrueba);
                if (id > 0)
                {
                    prueba.IdPrueba = id;
                    Console.WriteLine("Dígite la nueva descripción: ");
                    prueba.Descripción = Console.ReadLine();
                    resp = serv.ModificarPrueba(prueba);
                }
            }
            catch(Exception ex)
            {
                resp = -1;
            }

            serv.Close();
            if (resp <= 0)
                descripcion = "No se puedo actualizar la prueba";
            else
                descripcion = "Prueba modificada, codigo: " + id;

            Console.WriteLine(descripcion);
        }
    }
}
