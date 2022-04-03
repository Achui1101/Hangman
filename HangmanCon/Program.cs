using System;
using hangman1;

namespace HangmanCon
{
	class Program
	{
		static void Main(string[] args)
		{
			MainMK(args);
		}
		static void MainCE(string[] args)
		{
			//
			//  MK: Variablen-Deklarationen, wenn möglich gleich mit einer Zuweisung verbinden:
			//      string zuErratendesWort = spiel.getWort().ToLower();
			//      char[] zuErratendesWortArr = zuErratendesWort.ToCharArray();
			//      ... 
			//      char[] bereitsErraten = stricheArr;
			//  Das geht, weil Variablen an beliebiger Stelle deklariert werden können.
			//
			string zuErratendesWort;
			char[] zuErratendesWortArr;
			char[] bereitsErraten;
			//
			//  MK: Die beiden Variablen werden nicht gebraucht, 
			//  diese können gelöscht werden.
			//
			int fehler = 0;
			int fehlerLegal = 7;

			Game_Hangman spiel = new Game_Hangman();
			zuErratendesWort = spiel.getWort().ToLower();
			zuErratendesWortArr = zuErratendesWort.ToCharArray();
			char[] stricheArr = new char[zuErratendesWort.Length];

			for (int i = 0; i < zuErratendesWortArr.Length; i++)
			{
				stricheArr[i] = '_';
			}

			bereitsErraten = stricheArr;
			Console.WriteLine(zuErratendesWort);

			while (!bereitsErraten.Equals(zuErratendesWortArr))
			{
				Console.WriteLine(bereitsErraten);

				Console.WriteLine("Gebe deinen Buchstaben ein:");
				string buchstabe = Console.ReadLine().ToLower();

				for (int i = 0; i < zuErratendesWortArr.Length; i++)
				{
					if (buchstabe[0] == zuErratendesWortArr[i])
					{
						bereitsErraten[i] = buchstabe[0];
					}
				}
			}
			Console.WriteLine("Sie haben gewonnen!");
		}

		static void MainMK(string[] args)
		{
        	hangman1.Controller.HangmanSpiel spiel = new(7);
            while (!spiel.Okay)
            {
				Console.WriteLine($"Dein Stand: {spiel.Stand}.");
				Console.WriteLine($"\tDu hast {spiel.AnzahlRichtig} richtig und leider noch {spiel.AnzahlFalsch} Zeichen falsch.");
				Console.WriteLine($"\tDu hast noch {spiel.AnzahlVersuche} frei.");


				Console.Write("Gebe deinen Buchstaben ein:");
				string buchstabe = Console.ReadLine();

                _ = spiel.Versuch(buchstabe[0]);
            }
		}
	}
}
