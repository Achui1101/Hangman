using System;
using hangman1;

namespace HangmanCon
{
    class Program
    {
        static void Main(string[] args)
        {
            string zuErratendesWort;
            char[] zuErratendesWortArr;
            char[] bereitsErraten;
            int fehler = 0;
            int fehlerLegal = 7;


            Game_Hangman spiel = new Game_Hangman();
            zuErratendesWort = spiel.getWort().ToLower();
            zuErratendesWortArr = zuErratendesWort.ToCharArray();
            char[] stricheArr = new char[zuErratendesWort.Length];

            for (int i = 0; i < zuErratendesWortArr.Length; i++){
                stricheArr[i] = '_';
            }

            bereitsErraten = stricheArr;
            Console.WriteLine(zuErratendesWort);


            while (!bereitsErraten.Equals( zuErratendesWortArr))
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
    }
}
