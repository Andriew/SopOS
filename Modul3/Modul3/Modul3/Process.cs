using System;
using System.Collections.Generic;

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
        public int process_parent; //pid procesu ktory jest procesem nadrzednym, jesli nie ma ojcoa, to == 0
        public bool is_parent; //bool ktory mowi czy proces ma dzieci
        Registers registers; //przy inicjacji zerowane, wczytywanie zaraz po uruchomieniu programu
        public short default_priority; //nie wiem jak to rozwiazac
        public short actual_priority;
        public int pageTableSize; // rozmiar tablicy z programem
        public int firstElementPageTable; //adres pierwszego elementu tablicy
        public List<string> patchToFiles; //zapisanie path do pliku
        public int counter; //inkrementowane przez procek


        public Process(int pid, string name, int parent, int tableSize)
        {
            proces_name = name;
            
            this.pid = pid;
            proces_name = name;
            proces_state = 0;
            process_parent = parent;
            registers = new Registers();
            default_priority = 4;
            actual_priority = 4;
            pageTableSize = tableSize;
            patchToFiles = new List<string>();
            counter = 0;
        }

        public Process(int pid, string name, int parent, int tableSize, int priority)
        {
            proces_name = name;

            this.pid = pid;
            proces_name = name;
            proces_state = 0;
            process_parent = parent;
            registers = new Registers();
            default_priority = (short)priority;
            actual_priority = (short)priority;
            pageTableSize = tableSize;
            patchToFiles = new List<string>();
            counter = 0;

            is_parent = parent != 0;
            
        }

        public string displayRegisters()
        {
            string reg = "";

            reg += "RA: " + registers.RA + "; ";
            reg += "RB: " + registers.RB + "; ";
            reg += "RC: " + registers.RC + "; ";
            reg += "RD: " + registers.RD + "; ";

            return reg;
        }

        public void displayPCB()
        {
            Console.WriteLine();
            Console.WriteLine("PID: " + pid);
            Console.WriteLine("Name: " + proces_name);
            Console.WriteLine("Process state: " + proces_state);
            Console.WriteLine("Process parent (if not exist then = 0): " + process_parent);
            Console.WriteLine("This process has child/children: " + is_parent);
            Console.WriteLine("Registers: " + displayRegisters() );
            Console.WriteLine("Default priority: " + default_priority);
            Console.WriteLine("Actual priority: " + actual_priority);
            Console.WriteLine("Program size: " + pageTableSize);
            Console.WriteLine("Memory address : -"); //brak
            Console.WriteLine("Files : -"); //brak
            Console.WriteLine("Counter: " + counter);
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }









    }
}
