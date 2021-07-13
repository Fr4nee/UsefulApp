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
		static void PrintMonthEvents()
		{
			var eventsDAL = new EventsDAL(_iconfiguration);
			string monthEvent = SelectMonth();
			var listEventsModels = eventsDAL.GetListEventMonth(monthEvent);

			for (int i = 0; i < listEventsModels.Count; i++)
			{
				Console.Write($"{listEventsModels[i].id_user,-10}|");
				Console.Write($"|{listEventsModels[i].id_event,-10}|");
				Console.Write($"{listEventsModels[i].nameEvent,-10}|");
				Console.Write($"{listEventsModels[i].id_user,-10}|");
				Console.Write($"{listEventsModels[i].eventDate,-10}|");
				Console.WriteLine();
			}
			Console.ReadKey();
		}
        private static string SelectMonth()
        {
			int aux;
			string monthEvent;
			Console.WriteLine("1. Enero");
			Console.WriteLine("2. Febrero");
			Console.WriteLine("3. Marzo");
			Console.WriteLine("4. Abril");
			Console.WriteLine("5. Mayo");
			Console.WriteLine("6. Junio");
			Console.WriteLine("7. Julio");
			Console.WriteLine("8. Agosto");
			Console.WriteLine("9. Septiembre");
			Console.WriteLine("10. Octubre");
			Console.WriteLine("11. Noviembre");
			Console.WriteLine("12. Diciembre");
			Console.WriteLine();
			Console.Write("Month to show: ");
			int.TryParse(Console.ReadLine(), out aux);
			monthEvent = SetMonth(aux);
			return monthEvent;
        }

        private static string SetMonth(int aux)
        {
			string monthToReturn;
            switch (aux)
            {
				case 1:
					monthToReturn = "Enero";
					break;
				case 2:
					monthToReturn = "Febrero";
					break;
				case 3:
					monthToReturn = "Marzo";
					break;
				case 4:
					monthToReturn = "Abril";
					break;
				case 5:
					monthToReturn = "Mayo";
					break;
				case 6:
					monthToReturn = "Junio";
					break;
				case 7:
					monthToReturn = "Julio";
					break;
				case 8:
					monthToReturn = "Agosto";
					break;
				case 9:
					monthToReturn = "Septiembre";
					break;
				case 10:
					monthToReturn = "Octubre";
					break;
				case 11:
					monthToReturn = "Noviembre";
					break;
				case 12:
					monthToReturn = "Diciembre";
					break;
				default:
					monthToReturn = null;
					break;
			}
			return monthToReturn;
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
				Console.WriteLine("2) Show All Events");
				Console.WriteLine("3) Show Months Events");
				Console.WriteLine("4) Delete Events");
				Console.WriteLine("5) Exit\n");
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
					PrintMonthEvents();
					break;
				case 4:
					Console.Clear();
					DeleteEvents();
					break;
				case 5:
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

