using System;
using Modul3.Modul3;
using Modul3.Modul5;

namespace Modul3
{
    class OS
    {
        static void Main(string[] args)
        {
            ProcessManager processManager;
            try
            {
                //utworz processor
                Console.WriteLine("Tutaj powinna byc inicjacja procesora");
                //utworz pamiec operacyjna
                Console.WriteLine("Tutaj powinna byc inicjacja pamieci operacyjnej");
                //utworz dysk
                Console.WriteLine("Tutaj powinna byc inicjacja dysku twardego");
                //inicjacja proces managera
                Console.WriteLine("Proces manager utworzony");
                Console.ReadKey();
                processManager = new ProcessManager(); //utworz manager procesow

                
                string path = "I:\\program.exe";
                Console.WriteLine("Na sztywno przypisana sciezka do programu: " + path);

                Console.WriteLine("Nastepuje wczytajnie programu...");
                LoadProgram loadprogram = new LoadProgram(path, processManager); //zaladuj program i odrazu utworz procesy
                Console.WriteLine("Proces zostal utworzony, zmiana stanu na ready\n");
                Process p = processManager.getProcess("program.exe");
                processManager.setProcessState(1, p);
                p.displayPCB();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }


        }
    }
}
