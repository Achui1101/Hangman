using System;
using System.Linq;
using hangman1;

namespace HangmanCon
{
    class Program
    {

        //________________Main_________________
        static void Main(string[] args)
        {
            starteSpiel();
        }

        //_____________________________________

        public static void starteSpiel()
        {
            string zuErratendesWort;
            char[] zuErratendesWortArr;
            char[] bereitsErraten;
            int fehler = 0;
            int fehlerLegal = 4;


            Game_Hangman spiel = new Game_Hangman();
            zuErratendesWort = spiel.getWort().ToLower();
            zuErratendesWortArr = zuErratendesWort.ToCharArray();
            char[] stricheArr = new char[zuErratendesWort.Length];

            for (int i = 0; i < zuErratendesWortArr.Length; i++)
            {
                stricheArr[i] = '_';
            }

            bereitsErraten = stricheArr;

            while ((bereitsErraten.SequenceEqual(zuErratendesWortArr)==false) && !(fehler > fehlerLegal))// Warum geht nicht "|| (fehler < fehlerLegal)"??
            {

                char[] bereitsErratenVergl = new char[bereitsErraten.Length]; 

                Array.Copy(bereitsErraten, bereitsErratenVergl, bereitsErraten.Length );
                Console.WriteLine(bereitsErraten);

                Console.WriteLine("Versuche: " + (fehlerLegal - fehler + 1));

                Console.WriteLine("Gebe deinen Buchstaben ein:");
                string buchstabe = Console.ReadLine().ToLower();

                for (int i = 0; i < zuErratendesWortArr.Length; i++)
                {
                    if (buchstabe[0] == zuErratendesWortArr[i])
                    {
                        bereitsErraten[i] = buchstabe[0];

                    }
                }

                //__________Fehleriteration____________

              


                if (bereitsErratenVergl.SequenceEqual(bereitsErraten))
                {
                    fehler++;
                }


            }

            if (bereitsErraten.SequenceEqual(zuErratendesWortArr))
            {
                Console.WriteLine("Sie haben gewonnen!");
            }
            else if (fehler >= fehlerLegal)
            {
                Console.WriteLine("Sie haben verloren!");
            }
            else
            {
                Console.WriteLine("fehler");
            }
        }
    }
}
