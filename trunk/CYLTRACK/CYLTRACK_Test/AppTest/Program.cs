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
            string resp = pp.CrearPrueba();
            Console.WriteLine(resp);
            Console.Read();

        }

        public string CrearPrueba()
        {
            PruebaBE prueba = new PruebaBE();
            prueba.Descripción = "Hola mundo 1";
            long resp = 0;
            try
            {
                Service1Client serv = new Service1Client();
                resp = serv.CrearPrueba(prueba);
            }
            catch
            {
                resp = -1;
            }
            if (resp <= 0)
                return "No fue posible crear prueba";
            else
                return "Prueba creada, codigo: " + resp;

        }
    }
}
