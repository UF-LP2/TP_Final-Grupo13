using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tp_final
{

    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            double[,] grafo = new double[24, 24];
            String line;

            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("C:\\Users\\lolyy\\OneDrive\\Documentos\\LP2\\nodos.txt");
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null && line.Length > 0)
            {
                //write the line to console window
                String[] linea = line.Split(',');
                grafo[Convert.ToInt32(linea[0]) - 1, Convert.ToInt32(linea[1]) - 1] = Convert.ToDouble(linea[2]);
                grafo[Convert.ToInt32(linea[1]) - 1, Convert.ToInt32(linea[0]) - 1] = Convert.ToDouble(linea[2]);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            Console.ReadLine();
            int rowLength = grafo.GetLength(0);
            int colLength = grafo.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", grafo[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

        }

        /*cVehiculo furgon = new cFurgon();
        cVehiculo furgoneta = new cFurgoneta();
        cVehiculo camioneta = new cCamioneta();
        List<cVehiculo> vehiculos = new List<cVehiculo>() { furgon, furgoneta, camioneta };


        cElectrodomestico rallador = new cPequenios(20, 7, 5, 500);
        cElectrodomestico tostadora = new cPequenios(14, 15, 6, 1000);
        cElectrodomestico molinillo = new cPequenios(9, 4, 4, 700);
        cElectrodomestico cafetera = new cPequenios(40, 30, 20, 1300);
        cElectrodomestico licuadora = new cPequenios(60, 20, 20, 2000);
        cElectrodomestico calefon = new cLineaBlanca(250, 50, 40, 80000);
        cElectrodomestico lavarropas = new cLineaBlanca(100, 100, 80, 46000);
        cElectrodomestico heladera = new cLineaBlanca(320, 70, 120, 23000);
        cElectrodomestico termotanque = new cLineaBlanca(480, 120, 120, 70500);
        cElectrodomestico secarropas = new cLineaBlanca(100, 100, 90, 54500);
        cElectrodomestico monitor = new cElectronico(40, 50, 10, 400);
        cElectrodomestico cpu = new cElectronico(70, 15, 20, 13500);
        cElectrodomestico impresora = new cElectronico(30, 70, 90, 24000);
        cElectrodomestico mouse = new cElectronico(10, 10, 5, 200);
        // cElectrodomestico plasma1 = new cTelevisor(...)

        List<cElectrodomestico> lista1 = new List<cElectrodomestico>() { 
            molinillo, 
            cafetera,
            lavarropas,
            monitor
        };

        List<cElectrodomestico> lista2 = new List<cElectrodomestico>() { 
            rallador,
            impresora, 
            mouse,
            cpu
        };

        List<cElectrodomestico> lista3 = new List<cElectrodomestico>() {
            tostadora,
            licuadora,
            secarropas
        };

        List<cElectrodomestico> lista4 = new List<cElectrodomestico>() {
            calefon,
            heladera,
            termotanque
        };

        cPedido pedidoA = new cPedido(lista1, eTipo.express, 10, 3);
        cPedido pedidoB = new cPedido(lista2, eTipo.normal, 10, 3);
        cPedido pedidoC = new cPedido(lista3, eTipo.diferido, 10, 3);
        cPedido pedidoD = new cPedido(lista4, eTipo.express, 10, 3);

        List<cPedido> lista_pedidos = new List<cPedido>()
        {
            pedidoA,
            pedidoB,
            pedidoC,
            pedidoD
        };

        cCosiMundo empresa = new cCosiMundo();
        empresa.Inicio_Programa(lista_pedidos, vehiculos);




        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        // ApplicationConfiguration.Initialize();
        // Application.Run(new Form1());*/
    }
}