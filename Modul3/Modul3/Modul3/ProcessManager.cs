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

        public void addProcess()
        {
            Process newProces = new Process();
            processList.Add(newProces);
        }

        public void killProcess(int pid)
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

        /*
         bool dodajProces(string nazwa, int t_przewidywany_next, unsigned short rozmiar);	//XC
	    ^void usunProces(string nazwa);	//XD
	    void stop(string nazwa);//XH
	    void dodajPCB(Proces* nowy, bool zewnetrzny);//XI
	    void usunPCB(Proces* doKasacji);	//XJ
	    Proces* znajdzProces(string nazwa);	//XN
	    string czytajKomunikat(string nazwa);	//XR
	    void wyslijKomunikat(string nazwa, string text);// XS
	    void uruchomProces(string nazwa);	// XY
	    void zatrzymajProces(string nazwa);	// XZ
         
         */
    }
}
