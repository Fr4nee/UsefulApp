using UsefulApp.Dal;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;


namespace UsefulApp
{
	class Program
	{

		private static IConfiguration _iconfiguration;
		static void Main(string[] args)
		{
			GetAppSettingsFile();
			var eventsDAL = new EventsDAL(_iconfiguration);
			var listEventsModels = eventsDAL.AddEvents("Droga", "Facu");
			PrintEvents();
		}
		static void GetAppSettingsFile()
		{
			var builder = new ConfigurationBuilder()
								 .SetBasePath(Directory.GetCurrentDirectory())
								 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
			_iconfiguration = builder.Build();
		}
		static void PrintEvents()
		{		
			var eventsDAL = new EventsDAL(_iconfiguration);
			var listEventsModels = eventsDAL.GetList(); 
			
			listEventsModels.ForEach(item =>
			{
				Console.WriteLine(item.id_event);
				Console.WriteLine(item.nameEvent);
				Console.WriteLine(item.id_user);
				Console.WriteLine(item.eventDate);
			});
			Console.WriteLine("Press any key to stop.");
			Console.ReadKey();
		}


















		//	string cadena = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Facu\Desktop\UsefulApp\UsefulApp\UsefulApp\Database1.mdf;Integrated Security=True";
		//	public SqlConnection Conectarbd = new SqlConnection();
		/*
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
			static string[,] October = new string[6, 7]
			{
				{ null,null,null,null,null,"1","2"},
				{ "3","4","5","6","7","8","9"},
				{ "10","11","12","13","14","15","16"},
				{ "17","18","19","20","21","22","23"},
				{ "24","25","26","27","28","29","30"},
				{ "31",null,null,null,null,null,null}
			};
			static string[,] AugustEvent = new string[6, 7]
			{
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null}
			};
			static string[,] SeptemberEvent = new string[5, 7]
			{
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null}
			};
			static string[,] OctoberEvent = new string[6, 7]
			{
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null},
				{ null,null,null,null,null,null,null}
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
				OptionsMainMenu(op);
			}
			static int OptionsMainMenu(int op)
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
						AddEventsMenu();
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
				Console.WriteLine("║              *Calendar*                 ║");
				Console.WriteLine("║                                         ║");
				Console.WriteLine("║  1) August                              ║");
				Console.WriteLine("║  2) September                           ║");
				Console.WriteLine("║  3) October                             ║");
				Console.WriteLine("║  4) Back                                ║");
				Console.WriteLine("╚═════════════════════════════════════════╝\n");
				Console.Write("Select an option: ");
				OptionsCalendar(op);
			}
			static int OptionsCalendar(int op)
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
						Console.Clear();
						ShowOctober();
						break;
					case 4:
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
					Console.Write($"|{days[c],-12}");
				Console.WriteLine();
				for (int fi = 0; fi < August.GetLength(0); fi++)
				{
					Console.Write("|");
					for (int ci = 0; ci < August.GetLength(1); ci++)
					{
						Console.Write($"{August[fi, ci],-2}-");
						Console.Write($"{AugustEvent[fi, ci],-8}|");
					}
					Console.WriteLine();
				}
				Console.ReadKey();
			}
			static void ShowSeptember()
			{
				for (int c = 0; c < days.Length; c++)
					Console.Write($"|{days[c],-12}");
				Console.WriteLine();
				for (int fi = 0; fi < September.GetLength(0); fi++)
				{
					Console.Write("|");
					for (int ci = 0; ci < September.GetLength(1); ci++)
					{
						Console.Write($"{September[fi, ci],-2}-");
						Console.Write($"{SeptemberEvent[fi, ci],-8}|");
					}
					Console.WriteLine();
				}
				Console.ReadKey();
			}
			static void ShowOctober()
			{
				for (int c = 0; c < days.Length; c++)
					Console.Write($"|{days[c],-12}");
				Console.WriteLine();
				for (int fi = 0; fi < October.GetLength(0); fi++)
				{
					Console.Write("|");
					for (int ci = 0; ci < October.GetLength(1); ci++)
					{
						Console.Write($"{October[fi, ci],-2}-");
						Console.Write($"{OctoberEvent[fi, ci],-8}|");
					}
					Console.WriteLine();
				}
				Console.ReadKey();
			}
			static void AddEventsMenu()
			{
				Console.Clear();
				Console.WriteLine("╔═════════════════════════════════════════╗");
				Console.WriteLine("║           ***Usefull App***             ║");
				Console.WriteLine("║             *Add Events*                ║");
				Console.WriteLine("║                                         ║");
				Console.WriteLine("║  1) August                              ║");
				Console.WriteLine("║  2) September                           ║");
				Console.WriteLine("║  3) October                             ║");
				Console.WriteLine("║  4) Back                                ║");
				Console.WriteLine("╚═════════════════════════════════════════╝\n");
				Console.Write("Select a month: ");
				OptionsAddEvents(op);
			}
			static int OptionsAddEvents(int op)
			{
				int.TryParse(Console.ReadLine(), out op);
				switch (op)
				{
					case 1:
						Console.Clear();
						AEAugust();
						break;
					case 2:
						Console.Clear();
						AESeptember();
						break;
					case 3:
						Console.Clear();
						AEOctober();
						break;
					case 4:
						break;

					default:
						Console.Clear();
						Console.WriteLine("Select the correct option...");
						break;
				}
				return op;
			}
			static void AEAugust()
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
							Console.WriteLine("Enter the event");
							dato = Console.ReadLine();
							AugustEvent[f, c] = dato;
						}
					}
				}
				ShowAugust();
			}
			static void AESeptember()
			{
				string dato;
				string day;
				ShowSeptember();
				Console.Write("Enter the day:");
				day = Console.ReadLine();
				for (int f = 0; f < September.GetLength(0); f++)
				{
					for (int c = 0; c < September.GetLength(1); c++)
					{
						if (September[f, c] == day)
						{
							Console.WriteLine("Enter the event");
							dato = Console.ReadLine();
							SeptemberEvent[f, c] = dato;
						}
					}
				}
				ShowSeptember();
			}
			static void AEOctober()
			{
				string dato;
				string day;
				ShowOctober();
				Console.Write("Enter the day:");
				day = Console.ReadLine();
				for (int f = 0; f < October.GetLength(0); f++)
				{
					for (int c = 0; c < October.GetLength(1); c++)
					{
						if (October[f, c] == day)
						{
							Console.WriteLine("Enter the event");
							dato = Console.ReadLine();
							OctoberEvent[f, c] = dato;
						}
					}
				}
				ShowOctober();
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


			}*/
	}
}

