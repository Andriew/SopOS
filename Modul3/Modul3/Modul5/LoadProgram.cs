using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modul3.Modul5
{
    class LoadProgram
    {
        public ProgramAssemlbyInfo info;
        public Interpreter interpreter;
        public string path;

        public LoadProgram(string path)
        {
            info = new ProgramAssemlbyInfo();
            interpreter = new Interpreter();
            this.path = path;

            this.loadProgram();
        }

        public void loadProgram()
        {
            //info.paths[0] = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            StreamReader streamReader = new StreamReader(path);
            string content = streamReader.ReadToEnd();
            streamReader.Close();

            //tutaj startuje interpreter
            loadAssemblyInfo(content); //zamienia assembly code na ciag [ bytow (?) ]

            //saveIntoRAM(); //tutaj powinno byc zapisanie do pamieci operacyjnej programu
            //loadDataToPCB(); //ladowanie danych do process control block
        }

        public void loadAssemblyInfo(string text)
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
        }







    }
}
