using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Modul3.Modul3
{
    class ProcessManager
    {
        /*
            0 – inicjowany (w trakcie tworzenia procesu)
            1 – gotowy (oczekuje na przydział procka)
            2 – wykonywany 
            3 – czuwający (wybrany do przetworzenia jako następny)
            4 – zakończony
            5 – oczekujący (czekający na jakieś zdarzenie)	
         */

        public List<Process> processList = new List<Process>();

        //w przypadku gdy proces tworzy nowy proces [brak procesora]
        public void addProcess(string name, int tableSize, int father)
        {
            Process p = getProcess(name);
            if (p != null)
            {
                Console.WriteLine("Proces o podanej nawie juz istnieje!");
            }
            else
            {
                bool tmp = this.existProcess(father);

                if (father == 0 || tmp == true)
                {
                    int pid_tmp = this.processList.Count;
                    Process newProces = new Process(++pid_tmp, name, father, tableSize);
                    processList.Add(newProces);
                    Console.WriteLine("Proces zostal utworzony");
                }
                else
                {
                    Console.WriteLine("Nie istnieje proces o PID: " + father + "! Podaj innego ojca albo wpisz 0");
                }
            }
        }

        public void addProcess(string name, int tableSize, int priority, int father)
        {
            Process p = getProcess(name);
            if (p != null)
            {
                Console.WriteLine("Proces o podanej nawie juz istnieje!");
            }
            else
            {
                bool tmp = this.existProcess(father);

                if (father == 0 || tmp == true)
                {
                    int pid_tmp = this.processList.Count;
                    Process newProces = new Process(++pid_tmp, name, father, tableSize, priority);
                    processList.Add(newProces);
                    Console.WriteLine("Proces zostal utworzony");
                }
                else
                {
                    Console.WriteLine("Nie istnieje proces o PID: " + father + "! Podaj innego ojca albo wpisz 0");
                }
            }
        }

        public void terminateProcess(int pid)
        {
            if (this.existProcess(pid))
            {
                Process p = getProcess(pid);
                processList.RemoveAll(x => x.process_parent == pid);
                processList.Remove(processList.Find(x => x.pid == pid));
                Console.WriteLine("Proces zostal usuniety");
            }
            else
                Console.WriteLine("Nie istnieje taki proces");
        }

        public void terminateProcess(string name)
        {

            if (this.existProcess(name))
            {
                Process p = getProcess(name);
                int pid = p.pid;

                processList.RemoveAll(x => x.process_parent == pid);
                processList.Remove(processList.Find(x => x.pid == pid));
                Console.WriteLine("Proces zostal usuniety");
            }
            else
                Console.WriteLine("Nie istnieje taki proces");
        }

        public Process getProcess(string name)
        {
            Process lookingProcess = processList.Find(x => x.proces_name == name);
            return lookingProcess;
        }

        public Process getProcess(int pid)
        {
            Process lookingProcess = processList.Find(x => x.pid == pid);
            return lookingProcess;
        }

        public bool existProcess(int pid)
        {
            Process lookingProcess;
            lookingProcess = processList.Find(x => x.pid == pid);

            if (lookingProcess != null)
                return true;
            else
                return false;

        }

        public bool existProcess(string name)
        {
            Process lookingProcess;
            lookingProcess = processList.Find(x => x.proces_name == name);

            if (lookingProcess != null)
                return true;
            else
                return false;

        }

        public void setPriority(int pid, short priority)
        {
            Process lookingProcess = processList.Find(x => x.pid == pid);
            lookingProcess.actual_priority = priority;
        }

        public void setProcessState(short state, int pid)
        {
            if (state < 0 || state > 5)
                Console.WriteLine("Proces musi byc z przedzialu 0 - 5!");
            else
            {
                Process lookingProcess = processList.Find(x => x.pid == pid);
                lookingProcess.proces_state = state;
            }
        }

        public void setProcessState(short state, Process p)
        {
            if (state < 0 || state > 5)
                Console.WriteLine("Proces musi byc z przedzialu 0 - 5!");
            else
                p.proces_state = state;
        }

        public void displayAllProcess()
        {
            if (!processList.Any())
            {
                Console.WriteLine("Nie ma zadnych procesow na liscie");
            }
            else
            {
                foreach (var x in processList)
                {
                    Console.WriteLine("Nazwa procesu: " + x.proces_name + " ; PID: " + x.pid);
                }
            }
        }

        public void displayProcess(string name)
        {
            Process p = getProcess(name);
            if (p == null)
            {
                Console.WriteLine("Nie ma takiego procesu");
            }
            else
            {
                p.displayPCB();
            }
        }

        public void displayProcess(int pid)
        {
            Process p = getProcess(pid);
            if (p == null)
                Console.WriteLine("Nie ma takiego procesu");
            else
                p.displayPCB();

        }






    }
}
