using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3.Modul3
{
    
    class Process
    {
        public struct Registers
        {
            public int RA;
            public int RB;
            public int RC;
            public int RD;
        };

        /*PCB*/
        public int pid; //ostatni indeks listy + 1 
        public string proces_name; //nazwa uruchamianego programu
        public short proces_state;
        public int process_group; 
        Registers registers; //przy inicjacji zerowane, wczytywanie zaraz po uruchomieniu programu
        public short default_priority; //nie wiem jak to rozwiazac
        public short actual_priority;
        public int pageTableSize; // rozmiar tablicy z programem
        public int firstElementPageTable; //adres pierwszego elementu tablicy
        public List<string> patchToFiles; //zapisanie path do pliku
        public int counter; //inkrementowane przez procek


        public Process(int pid, string name, int group, int tableSize)
        {
            proces_name = name;
            
            this.pid = pid;
            proces_name = name;
            proces_state = 0;
            process_group = group;
            registers = new Registers();
            default_priority = 4;
            actual_priority = 4;
            pageTableSize = tableSize;
            patchToFiles = new List<string>();
            counter = 0;
        }

        public Process(int pid, string name, int group, int tableSize, int priority)
        {
            proces_name = name;

            this.pid = pid;
            proces_name = name;
            proces_state = 0;
            process_group = group;
            registers = new Registers();
            default_priority = (short)priority;
            actual_priority = (short)priority;
            pageTableSize = tableSize;
            patchToFiles = new List<string>();
            counter = 0;
        }

        public string displayRegisters()
        {
            string reg = "";

            reg += "RA: " + this.registers.RA + "; ";
            reg += "RB: " + this.registers.RB + "; ";
            reg += "RC: " + this.registers.RC + "; ";
            reg += "RD: " + this.registers.RD + "; ";

            return reg;
        }

        public void displayPCB()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("PID: " + this.pid);
            System.Console.WriteLine("Name: " + this.proces_name);
            System.Console.WriteLine("Process state: " + this.proces_state);
            System.Console.WriteLine("Process group: " + this.process_group);
            System.Console.WriteLine("Registers: " + this.displayRegisters() );
            System.Console.WriteLine("Default priority: " + this.default_priority);
            System.Console.WriteLine("Actual priority: " + this.actual_priority);
            System.Console.WriteLine("Program size: " + this.pageTableSize);
            System.Console.WriteLine("Memory adress : -"); //brak
            System.Console.WriteLine("Files : -"); //brak
            System.Console.WriteLine("Counter: " + this.counter);
            System.Console.WriteLine();
        }









    }
}
