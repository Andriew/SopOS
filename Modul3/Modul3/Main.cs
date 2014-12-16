using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3
{
    class OS
    {
        static void Main(string[] args)
        {
            //utworz processor
            //utworz pamiec operacyjna
            Modul3.ProcessManager procesManager = new Modul3.ProcessManager(); //utworz manager procesow
            //utworz pamiec wirtualna

            string path = "C:\\Users\\Andrzej\\Desktop\\modul3\\Modul3\\Modul3\\program.txt";
            Modul5.LoadProgram loadprogram = new Modul5.LoadProgram(path, procesManager); //zaladuj program i odrazu utworz procesy


        }
    }
}
