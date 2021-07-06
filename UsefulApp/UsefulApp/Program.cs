using System;

namespace UsefulApp
{
    class Program
    {
        static int op = 0;
        static void Main(string[] args)
        {
            App();
        }
        static void App()
        {
            do
            {
                MainMenu();
            }
            while (op == 5);
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
            Console.Write("Select your subjet:");
            Options(op);

        }
        static int Options(int op)
        {
            int.TryParse(Console.ReadLine(), out op);

            switch (op)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("entro1");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("entro2");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("entro1");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("entro1");
                    break;

                default:
                    break;
            }
            return op;
        }
    }
}
