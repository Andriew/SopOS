using System;
using System.Collections.Generic;
using System.Linq;

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
        public int group_tmp;

        //w przypadku gdy proces tworzy nowy proces [brak procesora]
        public void addProcess(string name, int tableSize)
        {
            Process p = getProcess(name);
            if (p != null)
            {
                Console.WriteLine("Proces o podanej nawie juz istnieje!");
            }
            else
            {
                group_tmp++;
                int pid_tmp = this.processList.Count;
                Process newProces = new Process(++pid_tmp, name, group_tmp, tableSize);
                processList.Add(newProces);
            }
        }

        public void addProcess(string name, int tableSize, int priority)
        {
            Process p = getProcess(name);
            if (p != null)
            {
                Console.WriteLine("Proces o podanej nawie juz istnieje!");
            }
            else
            {
                group_tmp++;
                int pid_tmp = this.processList.Count;
                Process newProces = new Process(++pid_tmp, name, group_tmp, tableSize, priority);
                processList.Add(newProces);
            }
        }

        public void terminateProcess(int pid)
        {
            Process p = getProcess(pid);
            int group = p.process_group;

            foreach (Process y in processList)
            {
                if (y.process_group == group)
                {
                    processList.Remove(y);
                }
            }
        }

        public void terminateProcess(string name)
        {
            Process p = getProcess(name);
            int group = p.process_group;

            foreach (Process y in processList)
            {
                if (y.process_group == group)
                {
                    processList.Remove(y);
                }
            }
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
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setPriority(int pid, short priority)
        {
            Process lookingProcess = processList.Find(x => x.pid == pid);
            lookingProcess.actual_priority = priority;
        }

        public void setProcessState(short state, int pid)
        {
            Process lookingProcess = processList.Find(x => x.pid == pid);
            lookingProcess.proces_state = state;
        }

        public void setProcessState(short state, Process p)
        {
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
            p.displayPCB();
        }

        public void displayProcess(int pid)
        {
            Process p = getProcess(pid);
            p.displayPCB();
        }





    }
}
