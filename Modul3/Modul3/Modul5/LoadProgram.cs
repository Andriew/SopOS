using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Modul3.Modul3;

namespace Modul3.Modul5
{
    class LoadProgram
    {
        private Interpreter interpreter;
        private string filePath;
        private string fileName;
        private ProcessManager processManager;

        public LoadProgram(string path, ProcessManager processManager)
        {
            interpreter = new Interpreter();
            this.filePath = path;
            this.processManager = processManager;
            this.loadProgram();
        }

        public void loadProgram()
        {
            try
            {
                fileName = Path.GetFileName(filePath);
                filePath = Path.GetDirectoryName(filePath);
                string outputAssemblyCode = "";

                StreamReader streamReader = new StreamReader(filePath + fileName);
                string content = streamReader.ReadToEnd();
                streamReader.Close();

                //tutaj startuje interpreter
                Console.WriteLine("W tym momencie startuje interpreter...");
                Console.ReadKey();
                outputAssemblyCode = loadAssemblyInfo(content); //zamienia assembly code na ciag [ bytow (?) ]
                //System.Console.WriteLine(outputAssemblyCode);

                if (outputAssemblyCode.Contains("ERROR"))
                {
                    throw new Exception("Wystapil blad, sekwencje anulowano!");
                }

                System.Console.WriteLine("Ciag rozkazow zinterpretowanych przez interpreter: " + outputAssemblyCode);
                Console.ReadKey();

                //return some address = saveIntoRAM(outputAssemblyCode); //tutaj powinno byc zapisanie do pamieci operacyjnej programu
                System.Console.WriteLine("Tutaj ciag rozkazow powinien zostac zapisany w pamieci operacyjnej\n");
                loadDataToPCB(outputAssemblyCode.Length); //ladowanie danych do PCB
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string loadAssemblyInfo(string text)
        {
            //text = "ADD:A:2"; //jakis test
            string outputAssemblyCode = "";
            string[] splitAll = text.Split('|');
            string[] splitOrder;

            for (int i = 0; i < splitAll.Length; i++)
            {
                splitOrder = splitAll[i].Split(':');
                outputAssemblyCode += interpreter.translateOrder(splitOrder);
            }
            return outputAssemblyCode;
        }

        public void loadDataToPCB(int tableSize)
        {
            processManager.group_tmp ++;
            Process newProcess = new Process(processManager.processList.Count() + 1, fileName, processManager.group_tmp, tableSize); //utworzenie nowego procesu
            Console.WriteLine("Proces jest gotowy");
            
            newProcess.displayPCB();
            Console.ReadKey();
            
            processManager.processList.Add(newProcess); //dodanie procesu do listy procesow
        }





    }
}
