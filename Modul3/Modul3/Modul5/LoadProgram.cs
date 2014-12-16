using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modul3.Modul5
{
    class LoadProgram
    {
        private Interpreter interpreter;
        private string filepath;
        private string fileName;
        private Modul3.ProcessManager processManager;

        public LoadProgram(string path, Modul3.ProcessManager processManager)
        {
            interpreter = new Interpreter();
            this.path = path;
            this.procesManager = processManager;

            this.loadProgram();
        }

        public void loadProgram()
        {
            filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            fileName = Path.GetFileName(Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location));
            string outputAssemblyCode = "";

            StreamReader streamReader = new StreamReader(path);
            string content = streamReader.ReadToEnd();
            streamReader.Close();

            //tutaj startuje interpreter
            outputAssemblyCode = loadAssemblyInfo(content); //zamienia assembly code na ciag [ bytow (?) ]

            //return some address = saveIntoRAM(outputAssemblyCode); //tutaj powinno byc zapisanie do pamieci operacyjnej programu
            loadDataToPCB(); //ladowanie danych do process control block
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

        public void loadDataToPCB()
        {
            Modul3.Process newProcess = new Modul3.Process(processManager.processList.Count() + 1, fileName, 1); //utworzenie nowego procesu
            processManager.processList.Add(newProcess); //dodanie procesu do listy procesow

        }





    }
}
