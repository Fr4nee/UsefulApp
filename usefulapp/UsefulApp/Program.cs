﻿using UsefulApp.Dal;
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
			Menu();
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

			string[] eventsBanner = { "Id Event", "Person", "Event", "Date" };

            for (int i = 0; i < eventsBanner.Length; i++)
            {
				Console.Write($"|{eventsBanner[i],-10}");
            }
			Console.WriteLine();
            for (int i = 0; i < listEventsModels.Count; i++)
            {
				Console.Write($"|{listEventsModels[i].id_event,-10}|");
				Console.Write($"{listEventsModels[i].userName,-10}|");
				Console.Write($"{listEventsModels[i].nameEvent,-10}|");
				Console.Write($"{listEventsModels[i].eventDate,-10}|");
				Console.WriteLine();
			}
			Console.ReadKey();
		}
		public static void FillAddEvents()
        {
			string eventName;
			string userName;

			Console.Write("Person: ");
			userName = Console.ReadLine();
			Console.Write("Describe the event: ");
            eventName = Console.ReadLine();
            
			var eventsDAL = new EventsDAL(_iconfiguration);
			var listEventsModels = eventsDAL.AddEvents(eventName, userName);
		}

		static void Menu()
        {
            do
            {
				Console.Clear();
				Console.WriteLine("***Useful App***");
				Console.WriteLine("1) Add Events");
				Console.WriteLine("2) Show Events");
				Console.WriteLine("3) Delete Events");
				Console.WriteLine("4) Exit\n");
				Console.Write("select an option: ");

			} while (ControlMenu() != 4);
		}
		static int ControlMenu()
        {
			int op;
			int.TryParse(Console.ReadLine(), out op);

			switch (op)
            {
				case 1:
					Console.Clear();
					FillAddEvents();
					break;
				case 2:
					Console.Clear();
					PrintEvents();
					break;
				case 3:
					Console.Clear();
					DeleteEvents();
					break;
				case 4:
					break;

                default:
                    break;
            }
			return op;
		}

		static void DeleteEvents()
        {
			int eventid;

			PrintEvents();
			Console.Write("Select Id Events: ");
			int.TryParse(Console.ReadLine(), out eventid);

			var eventsDAL = new EventsDAL(_iconfiguration);
			var listEventsModels = eventsDAL.DeleteEvents(eventid);

			PrintEvents();
		}

	}
}
