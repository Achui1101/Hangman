using System;
using hangman1.Controller;
using System.Linq;

namespace hangman1
{
    public class Game_Hangman
    {
        #region Felder
        NeuesSpiel neuesSpiel = new NeuesSpiel();
        bool erstesmal = true;

        private const string logo = @"
|    | ______ |\       ____  |\    /| ______ |\     ____
|    | |    | | \   | |    | | \  / | |    | | \   |    |
|----| |----| |  \  | |  __  |  \/  | |----| |  \  |     o
|    | |    | |   \ | | |  | |      | |    | |   \ |    /|\
|    | |    | |    \| |____| |      | |    | |    \|    /\
-----------------------------------------------------------";


        #region animation
        private const string hangman6 = @"
 ____
|    |
|     o
|    /|\
|    /\
";

        private const string hangman5 = @"
 ____
|    |
|     o
|    /|\
|    
";
        private const string hangman4 = @"
 ____
|    |
|     o
|    
|    
";
        private const string hangman3 = @"
 ____
|    |
|     
|    
|    
";
        private const string hangman2 = @"
 ____
|   
|     
|    
|    
";
        private const string hangman1 = @"

|   
|     
|    
|    
";
        private const string hangman0 = @"



   
";
        #endregion


        #endregion

        #region Get und Set

        #endregion

        #region Konstruktoren

        #endregion

        #region Spieleumgebung
        public void starteSpiel()
        {

            zeigeLogo();

            #region modiauswahl
            Console.Clear();
            Console.WriteLine("Welchen Modi möchtest du Spielen?");
            Console.WriteLine("1 : vorgegebenes Wort");
            Console.WriteLine("2 : eigenes Wort");
            Console.WriteLine("_________________");
            Console.WriteLine("quit : Beenden");

            switch (Console.ReadLine())
            {
                case "1":
                    neuesSpiel.Wort = neuesSpiel.WortAusDB();
                    spiel();
                    break;
                case "2":
                    eigenesWort();
                    spiel();
                    break;
                case "quit":
                    Console.Clear();
                    Console.WriteLine("BYE");
                    Environment.Exit(420);
                    break;
                default:
                    Console.WriteLine("Wähle einen Modi aus!");
                    System.Threading.Thread.Sleep(3000);
                    starteSpiel();//<-------rekursiv
                    break;
            }
            #endregion

            auswertung();
        }

        public void eigenesWort()
        {
            Console.Clear();
            Console.WriteLine("Was ist dein Wort?");
            neuesSpiel.Wort = Console.ReadLine();

        }

        public void spiel()
        {
            neuesSpiel.erzeugeUnterstriche();

            while ((neuesSpiel.ErrateneBuchstaben.SequenceEqual(neuesSpiel.Wort) == false) && !(neuesSpiel.AnzahlFehler > neuesSpiel.AnzahlLegalFehler))
            {

                char[] bereitsErratenVergl = new char[neuesSpiel.ErrateneBuchstaben.Length];
                Array.Copy(neuesSpiel.ErrateneBuchstaben, bereitsErratenVergl, neuesSpiel.ErrateneBuchstaben.Length);

                Console.Clear();
                Console.WriteLine(neuesSpiel.ErrateneBuchstaben);
                Console.WriteLine($"Versuche: {(neuesSpiel.AnzahlLegalFehler - neuesSpiel.AnzahlFehler + 1)}");
                Console.WriteLine("Gebe deinen Buchstaben ein:");

                try
                {
                    neuesSpiel.sucheBuchstaben(Console.ReadLine().ToLower()[0]);
                }
                catch
                {
                    Console.WriteLine("Gebeden Buchstaben nochmal ein");
                }

                neuesSpiel.erhoeheFehlerZaehler(bereitsErratenVergl);
                zeigeAnimation(neuesSpiel.AnzahlFehler);
            }
        }

        private void auswertung()
        {
            if (neuesSpiel.ErrateneBuchstaben.SequenceEqual(neuesSpiel.Wort.ToLower().ToCharArray()))
            {
                Console.Clear();
                Console.WriteLine($"Win! Das Wort ist {neuesSpiel.Wort}! :)");
                System.Threading.Thread.Sleep(3000);
                starteSpiel();
            }
            else if (neuesSpiel.AnzahlFehler >= neuesSpiel.AnzahlLegalFehler)
            {
                Console.Clear();
                Console.WriteLine($"Game Over! Das Wort war {neuesSpiel.Wort} {hangman6}");
                System.Threading.Thread.Sleep(3000);
                starteSpiel();
            }
            else
            {
                Console.WriteLine("fehler");
            }
        }
        #endregion

        #region lade Logo
        private void zeigeLogo()
        {
            if (erstesmal)
            {
                Console.WriteLine(logo);
                System.Threading.Thread.Sleep(3000);
                erstesmal = false;

            }
        }
        #endregion

        private void zeigeAnimation(int fehler)
        {
            switch (fehler)
            {
                case 0:
                    Console.WriteLine(hangman0);
                    System.Threading.Thread.Sleep(2000);
                    break;
                case 1:
                    Console.WriteLine(hangman1);
                    System.Threading.Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine(hangman2);
                    System.Threading.Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine(hangman3);
                    System.Threading.Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine(hangman4);
                    System.Threading.Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine(hangman5);
                    System.Threading.Thread.Sleep(2000);
                    break;
                case 6:
                    Console.WriteLine(hangman6);
                    System.Threading.Thread.Sleep(2000);
                    break;
            }
        }
    }
}
