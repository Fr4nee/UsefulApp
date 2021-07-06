using System;
using System.Linq;

namespace UsefulApp
{
    class Program
    {
        static int op = 0;


        static string[,] Calendar = new string[7, 7]
        {
            {"Monday","Tuesday","Wednesday", "Thursday", "Friday", "Saturday", "Sunday"},
            { null,null,null,null,null,null,"1)"},
            { "2)","3)","4)","5)","6)","7)","8)"},
            { "9)","10)","11)","12)","13)","14)","15)"},
            { "16)","17)","18)","19)","20)","21)","22)"},
            { "23)","24)","25)","26)","27)","28)","29)"},
            { "30)","31)",null,null,null,null,null},
        };



        static void Main(string[] args)
        {
            App();
        }     
        static void App()
        {
            do         
                MainMenu();
            while (op != 5);
        }
        static void MainMenu()
        {
            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║           ***Usefull App***             ║");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("║  1) Prog. Orientada a Objetos (Backend) ║");
            Console.WriteLine("║  2) Prog. Visual (Frontend)             ║");
            Console.WriteLine("║  3) Sistemas Operativos                 ║");
            Console.WriteLine("║  4) Teleinformatica                     ║");
            Console.WriteLine("╚═════════════════════════════════════════╝\n");
            Console.Write("Select your subjet: ");
            Options(op);

        }
        static int Options(int op)
        {
            int.TryParse(Console.ReadLine(), out op);

            switch (op)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("entro 1");
                    Test();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("entro 2");
                    IntroduceData();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("entro 3");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("entro 4");
                    break;
                case 5:
                    Console.Clear();
                    ExitApp();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Select the correct option...");
                    break;
            }
            return op;
        }
        public static int ExitApp()
        {
            string exit;
            Console.WriteLine("Are you sure to Exit ? y/n");
            exit = Console.ReadLine().ToLower().Trim();
            if (exit == "y")
                op = 5;
            else if (exit == "n")
                op = 0;

            return op;
        }


        static void Test()
        {         
            Console.WriteLine();
            for (int fi = 0; fi < Calendar.GetLength(0); fi++)
            {
                Console.Write("|");
                for (int ci = 0; ci < Calendar.GetLength(1); ci++)
                {
                    Console.Write($"{Calendar[fi, ci],-13}|");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }


        static void IntroduceData()
        {

            string dato;

            string dayWeek;
            string day;

            Test();

            for (int f = 0; f < Calendar.GetLength(0); f++)
            {
                Console.WriteLine("Ingrese dia de la semana:");
                dayWeek = Console.ReadLine();
                if (Calendar[0, f] == dayWeek)
                {
                    for (int c = 0; c < Calendar.GetLength(1); c++)
                    {
                        Console.WriteLine("Ingrese dia:");
                        day = Console.ReadLine();

                        if (Calendar[f, c] == day)
                        {
                            dato = Console.ReadLine();
                            Calendar[f, c] = dato;
                        }
                        break;
                    }
                }
            }


            
            







        }

    }
}
