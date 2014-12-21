using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3.Modul3
{
    public struct Registers
    {
        int RA;
        int RB;
        int RC;
        int RD;
    };

    class Process
    {
       
        /*PCB*/
        public int pid; //ostatni indeks listy + 1 
        public string proces_name; //nazwa uruchamianego programu
        public short proces_state;
        public int process_group; 
        Registers registers; //przy inicjacji zerowane, wczytywanie zaraz po uruchomieniu programu
        public short default_priority; //nie wiem jak to rozwiazac
        public short actual_priority;
        public byte[] page_table; // ??
        public List<string> patchToFiles; //zapisanie path do pliku
        public int counter; //inkrementowane przez procek


        public Process(int pid, string name, int group)
        {
            proces_name = name;
            
            pid = getPid();
            proces_name = name;
            proces_state = 0;
            process_group = group;
            registers = new Registers();
            default_priority = 4;
            actual_priority = 4;
            patchToFiles = new List<string>();
            counter = 0;
        }
       
       // public Process(){ }











    }
}
