using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            group_tmp++;
            int pid_tmp = this.processList.Count;
            Process newProces = new Process( ++pid_tmp, name, group_tmp, tableSize );
            processList.Add(newProces);
        }

        public void terminateProcess(int pid)
        {
            int group;
            foreach(Process x in processList)
            {
                group = x.process_group;
                foreach (Process y in processList)
                {
                    if (y.process_group == group)
                    {
                        processList.Remove(y);
                    }
                }
            }
        }

        public Process getProcess(string name)
        {
            Process lookingProcess;
            lookingProcess = processList.Find(x => x.proces_name == name );
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

    }
}
