using System;
using Modul3.Modul3;
using Modul3.Modul5;

namespace Modul3
{
    class OS
    {
        static void Main(string[] args)
        {
            ProcessManager processManager;
            try
            {
                int choice;
                processManager = new ProcessManager(); //utworz manager procesow
                
                        //do zastanowenia:
                        //kolejki priorytetowe i scheuler
                do
                {
                    Console.WriteLine("1. Wyswietl liste wszystkich procesow");
                    Console.WriteLine("2. Wyswietl PCB danego procesu (po nazwie)");
                    Console.WriteLine("3. Wyswietl PCB danego procesu (po PID)");
                    Console.WriteLine("4. Sprawdz czy dany proces istnieje");
                    Console.WriteLine("5. Wczytaj program z dysku");
                    Console.WriteLine("6. Utworz recznie proces");
                    Console.WriteLine("7. Zmien priorytet procesu");
                    Console.WriteLine("8. Zmien stan procesu");
                    Console.WriteLine("9. Usun proces (po PID)");
                    Console.WriteLine("10. Usun proces (po nazwie)");
                    Console.WriteLine("11. Usun wszystkie procesy");

                    choice = int.Parse( Console.ReadLine() );
                    
                    switch (choice)
                    {
                        case 1:
                        {
                            processManager.displayAllProcess();
                            break;
                        }

                        case 2:
                        {
                            Console.Write("Podaj nazwe procesu: ");
                            string name = Console.ReadLine();
                            processManager.displayProcess(name);
                            break;
                        }

                        case 3:
                        {
                            Console.Write("Podaj PID procesu: ");
                            int pid = int.Parse( Console.ReadLine() );
                            processManager.displayProcess(pid);
                            break;
                        }

                        case 4:
                        {
                            Console.Write("Podaj PID procesu: ");
                            int pid = int.Parse(Console.ReadLine());
                            bool check = processManager.existProcess(pid);
                            if(check)
                                processManager.displayProcess(pid);
                            else
                                Console.WriteLine("Proces o tym PID nie istnieje!");

                            break;
                        }

                        case 5:
                        {
                            LoadProgram loadprogram;
                            string path;

                            Console.WriteLine("1. Wczytaj program");
                            Console.WriteLine("2. Wczytaj program1");
                            Console.WriteLine("3. Wczytaj program2");
                            Console.WriteLine("4. Wczytaj program3");

                            int program = int.Parse(Console.ReadLine());

                            switch (program)
                            {
                                case 1:
                                {
                                    path = "program.exe";
                                    loadprogram = new LoadProgram(path, processManager); //zaladuj program i odrazu utworz procesy
                                    Console.WriteLine("Ilosc procesow w kolejce: " + processManager.processList.Count);
                                    Process p = processManager.getProcess("program.exe");
                                    processManager.setProcessState(1, p);
                                    p.displayPCB();

                                    break;
                                }

                                case 2:
                                {
                                    path = "program1.exe";
                                    loadprogram = new LoadProgram(path, processManager); //zaladuj program i odrazu utworz procesy
                                    Console.WriteLine("Ilosc procesow w kolejce: " + processManager.processList.Count);
                                    Process p = processManager.getProcess("program1.exe");
                                    processManager.setProcessState(1, p);
                                    p.displayPCB();

                                    break;
                                }
                                case 3:
                                {
                                    path = "program2.exe";
                                    loadprogram = new LoadProgram(path, processManager); //zaladuj program i odrazu utworz procesy
                                    Console.WriteLine("Ilosc procesow w kolejce: " + processManager.processList.Count);
                                    Process p = processManager.getProcess("program2.exe");
                                    processManager.setProcessState(1, p);
                                    p.displayPCB();

                                    break;
                                }
                                case 4:
                                {
                                    path = "program3.exe";
                                    loadprogram = new LoadProgram(path, processManager); //zaladuj program i odrazu utworz procesy
                                    Console.WriteLine("Ilosc procesow w kolejce: " + processManager.processList.Count);
                                    Process p = processManager.getProcess("program3.exe");
                                    processManager.setProcessState(1, p);
                                    p.displayPCB();
                                    break;
                                }


                                default:
                                {
                                  Console.WriteLine("Podales zly numer");
                                  break;  
                                }
                            };
                            break;
                        }

                        case 6:
                        {
                            Console.WriteLine("Podaj nazwe procesu: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("Podaj wielkosc tablicy: ");
                            int tabSize = int.Parse(Console.ReadLine());

                            Console.WriteLine("Podaj priorytet: ");
                            int priority = int.Parse(Console.ReadLine());

                            processManager.addProcess(name, tabSize, priority);
                            
                            break;
                        }

                        case 7:
                        {
                            Console.WriteLine("Podaj PID procesu");
                            int pid = int.Parse(Console.ReadLine());
                            Process p = processManager.getProcess(pid);

                            if (p == null)
                            {
                                Console.WriteLine("Proces o podanym PID nie istnieje!");
                            }
                            else
                            {
                                Console.WriteLine("Podaj priorytet: ");
                                short priority = short.Parse(Console.ReadLine());
                                if (priority > 8 || priority < 1)
                                {
                                    Console.WriteLine("Prioryet musi byc wartoscia od 1 do 8!");
                                    break;
                                }
                                p.actual_priority = priority;
                                Console.WriteLine("Prioryet procesu zostal zmieniony");
                            }

                            break;
                        }

                        case 8:
                        {
                            Console.WriteLine("Podaj pid procesu: ");
                            int pid = int.Parse(Console.ReadLine());
                            Process p = processManager.getProcess(pid);

                            Console.WriteLine("Podaj stan: ");
                            short state = short.Parse(Console.ReadLine());

                            processManager.setProcessState(state, p);
                            Console.WriteLine("Stan procesu zostal zmieniony: ");

                            break;
                        }

                        case 9:
                        {
                            Console.WriteLine("Podaj PID procesu: ");
                            int pid = int.Parse(Console.ReadLine());
                            processManager.terminateProcess(pid);
                            break;
                        }

                        case 10:
                        {
                            Console.WriteLine("Podaj nazwe procesu: ");
                            string name = Console.ReadLine();
                            processManager.terminateProcess(name);
                            break;
                        }

                        case 11:
                        {
                            processManager.processList.Clear();
                            Console.WriteLine("Lista procesow zostala wyczyszczona");
                            break;
                        }

                        ///////////////

                        case 0:
                        {
                            choice = 0;
                            break;
                        }

                        default:
                        {
                            Console.WriteLine("Podales zly numer");
                            break;
                        }

                    }
                
                } while (choice != 0);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
   
        }

    }
}
