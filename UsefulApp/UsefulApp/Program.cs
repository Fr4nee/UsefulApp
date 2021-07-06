using System;
using System.Linq;

namespace UsefulApp
{
	class Program
	{
		static int op = 0;
		static string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
		static string[,] August = new string[6, 7]
		{
			{ null,null,null,null,null,null,"1"},
			{ "2","3","4","5","6","7","8"},
			{ "9","10","11","12","13","14","15"},
			{ "16","17","18","19","20","21","22"},
			{ "23","24","25","26","27","28","29"},
			{ "30","31",null,null,null,null,null},
		};
		static string[,] September = new string[5, 7]
		{
			{ null,null,"1","2","3","4","5"},
			{ "6","7","8","9","10","11","12"},
			{ "13","14","15","16","17","18","19"},
			{ "20","21","22","23","24","25","26"},
			{ "27","28","29","30",null,null,null}
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
			Console.Clear();
			Console.WriteLine("╔═════════════════════════════════════════╗");
			Console.WriteLine("║           ***Usefull App***             ║");
			Console.WriteLine("║                                         ║");
			Console.WriteLine("║  1) Calendar                            ║");
			Console.WriteLine("║  2) Add Events                          ║");
			Console.WriteLine("║  3) ****                                ║");
			Console.WriteLine("║  4) ****                                ║");
			Console.WriteLine("║  5) Exit                                ║");
			Console.WriteLine("╚═════════════════════════════════════════╝\n");
			Console.Write("Select an option: ");
			Options(op);
		}
		static int Options(int op)
		{
			int.TryParse(Console.ReadLine(), out op);
			switch (op)
			{
				case 1:
					Console.Clear();
					CalendarMenu();
					break;
				case 2:
					Console.Clear();
					IntroduceData();
					break;
				case 3:
					Console.Clear();
					break;
				case 4:
					Console.Clear();
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
		static void CalendarMenu()
        {
			Console.Clear();
			Console.WriteLine("╔═════════════════════════════════════════╗");
			Console.WriteLine("║           ***Usefull App***             ║");
			Console.WriteLine("║               *Calendar*                ║");
			Console.WriteLine("║                                         ║");
			Console.WriteLine("║  1) August                              ║");
			Console.WriteLine("║  2) September                           ║");
			Console.WriteLine("║  3) Back                                ║");
			Console.WriteLine("╚═════════════════════════════════════════╝\n");
			Console.Write("Select an option: ");
			Calendar(op);
			// hola soy facu
			// hola soy fran
		}
		static int Calendar(int op)
		{
			int.TryParse(Console.ReadLine(), out op);
			switch (op)
			{
				case 1:
					Console.Clear();
					ShowAugust();
					break;
				case 2:
					Console.Clear();
					ShowSeptember();
					break;
				case 3:
					break;

				default:
					Console.Clear();
					Console.WriteLine("Select the correct option...");
					break;
			}
			return op;
		}
		static void ShowAugust()
		{
			for (int c = 0; c < days.Length; c++)
				Console.Write($"|{days[c],-13}");
			Console.WriteLine();
			for (int fi = 0; fi < August.GetLength(0); fi++)
			{
				Console.Write("|");
				for (int ci = 0; ci < August.GetLength(1); ci++)
					Console.Write($"{August[fi, ci],-13}|");
				Console.WriteLine();
			}
			Console.ReadKey();
		}
		static void ShowSeptember()
		{
			for (int c = 0; c < days.Length; c++)
				Console.Write($"|{days[c],-13}");
			Console.WriteLine();
			for (int fi = 0; fi < September.GetLength(0); fi++)
			{
				Console.Write("|");
				for (int ci = 0; ci < September.GetLength(1); ci++)
					Console.Write($"{September[fi, ci],-13}|");
				Console.WriteLine();
			}
			Console.ReadKey();
		}
		static void IntroduceData()
		{
			string dato;
			string day;
			ShowAugust();
			Console.Write("Enter the day:");
			day = Console.ReadLine();
			for (int f = 0; f < August.GetLength(0); f++)
			{
				for (int c = 0; c < August.GetLength(1); c++)
				{
					if (August[f, c] == day)
					{
						Console.WriteLine("Enter the day again and the event");
						dato = Console.ReadLine();
						August[f, c] = dato;
					}
				}
			}
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
	}
}
