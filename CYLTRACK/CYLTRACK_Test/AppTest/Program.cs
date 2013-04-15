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
            long resp = pp.CrearPrueba();
            Console.WriteLine("Codigo creado: " + resp);
            Console.Read();
            
        }

        public long CrearPrueba()
        {
            Cilindro cilindro = new Cilindro();
            cilindro.Tamano = "40";
            cilindro.Tipo_Cilindro = "GPL";
            cilindro.Id_Fabricante = "123455556";
            long resp = 0;
            try{
                Service1Client serv = new Service1Client();
                resp = serv.Prueba(cilindro);
            }
            catch
            {
                resp = -1;
            }
            return resp;
        }
    }
}
