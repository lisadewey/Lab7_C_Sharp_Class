using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;

namespace Lab7_StarTrek_C_Sharp_Class
{
	class Program
	{
		static string[] aliens = { "Lwaxana Troi", "Ensign Ro Laren", "Lt. Worf", "Toreth", "Mr.Mot", "Nog", "Jedzia Dax", "Mr.Spock", "Dr. Phlox", "Elim Garak", "Weyhoun", "Captain Jen Luc Picard", "Kimara Cretak", "Morn", "Sirella", "Talas", "Rene Echevarria", "Gaila", "Neelix", "Etana Jol" };
		static string[] planets = { "Betazed", "Bajor", "Kronos", "Romulus", "Bolarus IX", "Ferenginar", "Trill", "Vulcan", "Denobula", "Cardassia Prime", "Kurill Prime", "Earth", "Romulus", "Luria", "Kronos", "Andoria", "Aaamazzara", "Orion", "Talaxia", "Ktaris" };
		static string[] drinks = { "Jalara Fire cocktails", "Alva nut tea", "Targ milk", "Romulan ale", "Bolian tonic", "Millipede juice", "Black Hole cocktails", "Vulcan tea", "Saurian brandy", "Rokassa juice", "Kanar", "Earl Grey tea", "Kali-fal", "Aldebaran whiskey", "Bloodwine", "Andorian ale", "Samarian Sunset cocktails", "Mandisa", "Traggle nectar", "Ktarian Merlot" };

		static void Main(string[] args)
		{
			bool again = true;

			while (again)
			{
				int student = SelectNumber("Which alien C# student would you like to know more about? (Enter a number between 1-20.): ");
				Console.Write($"Student {student + 1} is {aliens[student]}. ");

				bool more = true;

				string prompt = $"What would you like to know about {aliens[student]}? (Enter planet or drink.): ";

				while (more)
				{
					string know = SelectString(prompt);

					ShowInfo(know, student);

					more = InputHandlers.Continue("Would you like to know more? (Enter 'y' or 'n'.): ");

					if (more)
					{
						if (know == "planet")
						{
							know = "drink";
						}
						else
						{
							know = "planet";
						}

						ShowInfo(know, student);

						more = false;	// no more info exists, end loop.
					}
				}
				Console.WriteLine();

				again = InputHandlers.Continue("Would you like to know about another student? (Enter 'y' or 'n'.): ");

				Console.WriteLine();
			}

			Console.WriteLine();

			Console.WriteLine("Thanks and have a stellar eon!");

			Console.ReadLine();
		}

		static void ShowInfo(string know, int student)
		{
			if (know == "planet")
			{
				Console.WriteLine();
				Console.WriteLine($"{aliens[student]} is from {planets[student]}. ");
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine($"{aliens[student]} likes to drink {drinks[student]}. ");
				Console.WriteLine();
			}
		}

		static int SelectNumber(string prompt)
		{
			int value = 0;

			bool again = true;

			while (again)
			{
				try
				{
					value = InputHandlers.GetInteger(prompt);
					if (value < 1 || value > 20)
					{
						throw new IndexOutOfRangeException();
					}

					again = false;
				}
				catch (FormatException)
				{
					Console.WriteLine("Say what? Try again.");
					Console.WriteLine();
				}
				catch (IndexOutOfRangeException)
				{
					Console.WriteLine("That student does not exist. Please try again.");
					Console.WriteLine();
				}
			}

			return value - 1; // Realign for array index.
		}

		static string SelectString(string prompt)
		{
			string value = string.Empty;

			bool again = true;

			while (again)
			{
				try
				{
					value = InputHandlers.GetString(prompt);
					if (value != "planet" && value != "drink")
					{
						throw new FormatException();
					}

					again = false;
				}
				catch (FormatException)
				{
					Console.WriteLine("That data does not exist. Please try again.");
				}
			}

			return value;
		}
	}
}
