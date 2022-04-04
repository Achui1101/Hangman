using System;
using hangman1.Controller;
using System.Linq;


namespace hangman1
{
    public class Game_Hangman
    {
        private string wort;
        string zuErratendesWort;
        private int anzahlFehler;
        private int anzahlLegalFehler;
        private char[] errateneBuchstaben;
        char[] zuErratendesWortArr;
        char[] bereitsErraten;


        public string ZuErratendesWort
        {
            get { return zuErratendesWort; }
            set { wort = zuErratendesWort; }
        }

        public string Wort
        {
            get { return wort; }
            set { wort = value; }
        }

        public int AnzahlFehler {
            get { return anzahlFehler; }
            set { anzahlFehler = value; }
        }

        public int AnzahlLegalFehler {
            get { return anzahlLegalFehler; }
            set { anzahlLegalFehler = value; }
        }
        public char[] ErrateneBuchstaben {
            get { return errateneBuchstaben; }
            set { errateneBuchstaben = value; }
        }

        public char[] ZuErratendesWortArr
        {
            get { return zuErratendesWortArr; }
            set { zuErratendesWortArr = value; }
        }

        public char[] BereitsErraten
        {
            get { return bereitsErraten; }
            set { bereitsErraten = value; }
        }

        public Game_Hangman()
        {
            NeuesSpiel neuesSpiel = new NeuesSpiel();
            wort = neuesSpiel.Wort;
            anzahlFehler = neuesSpiel.AnzahlFehler;
            anzahlLegalFehler = neuesSpiel.AnzahlLegalFehler;
            zuErratendesWort = Wort.ToLower();
            zuErratendesWortArr = ZuErratendesWort.ToCharArray();
        }

        public void starteSpiel()
        {
            char[] stricheArr = new char[zuErratendesWort.Length];
            for (int i = 0; i < zuErratendesWortArr.Length; i++)

            {
                stricheArr[i] = '_';
            }

            bereitsErraten = stricheArr;

            while ((bereitsErraten.SequenceEqual(zuErratendesWortArr) == false) && !(anzahlFehler > anzahlLegalFehler))
            {
                Console.Clear();
                char[] bereitsErratenVergl = new char[bereitsErraten.Length];

                Array.Copy(bereitsErraten, bereitsErratenVergl, bereitsErraten.Length);
                Console.WriteLine(bereitsErraten);

                Console.WriteLine($"Versuche: {(anzahlLegalFehler - anzahlFehler + 1)}");

                Console.WriteLine("Gebe deinen Buchstaben ein:");
                string buchstabe = Console.ReadLine().ToLower();

                for (int i = 0; i < zuErratendesWortArr.Length; i++)
                {
                    if (buchstabe[0] == zuErratendesWortArr[i])
                    {
                        bereitsErraten[i] = buchstabe[0];

                    }
                }

                if (bereitsErratenVergl.SequenceEqual(bereitsErraten))
                {
                    anzahlFehler++;
                }
            }
            auswertung();
        }



        private void auswertung()
        {
            if (bereitsErraten.SequenceEqual(zuErratendesWortArr))
            {
                Console.Clear();
                Console.WriteLine($"Win! Das Wort ist {Wort}! :)");
            }
            else if (anzahlFehler >= anzahlLegalFehler)
            {
                Console.Clear();
                Console.WriteLine($"Game Over! Das Wort war {Wort}");
            }
            else
            {
                Console.WriteLine("fehler");
            }
        }
    }
}
