using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Management;
using System.Diagnostics;

namespace HartwareSysten
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //Primero declaro esta bariable para poder sacar la cantidad de nucleos.
            int coreCount = 0;

            //Obtine la catidad de CPU que tiene la Tarjeta madre.
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                //Imprime la cantidad de CPU que tiene la tarjeta madre.
                Console.WriteLine("La PC tiene: {0} CPU ", item["NumberOfProcessors"]);
            }

            // Obtine la cantidad de nucleos que tiene la CPU.
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }
                //Imprime la cantidad de nucleos que tiene la CPU.
            Console.WriteLine("Cantidad de Nucleos: {0}", coreCount);

            //Obtiene la cantidad de Hilos que tiene la CPU.
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                //Imprime la cantidad de Hilos que tiene la CPU.
                Console.WriteLine("Cantidad de Hilos: {0}", item["NumberOfLogicalProcessors"]);
            }
            //Obtiene la cantida de Memoria Ram que tiene la PC.
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from  Win32_OperatingSystem").Get())
            {
                //Convierte la cantidad de Memoria Ram a numeros.
                 var RAM = Convert.ToDouble(item["TotalVisibleMemorySize"]);
                //Redondea el numero total de Ram que tiene.
                double RAMM = Math.Round((RAM / (1024 * 1024)));
                //Imprimera la cantidad de memoria que tiene la pc.
               Console.WriteLine("Cantidad de RAM: {0}", RAMM + "GB");
            }
            //Obtiene el tipo de sistema operatico que tiene.
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                //Imprime el tipo de sistema operativo que tiene.
                Console.WriteLine("Tipo de Sistema:  {0} ", item["SystemType"]);
            }

            //Obtiene todos los procesos que se estan ejecutando en el computador.
            Process[] localAll = Process.GetProcesses();

            //Imprime la cantidad de procesos que se estan ejecutando en el Computador.
            Console.WriteLine("Procesos: " + localAll.Length);





        }
    }
}
