﻿using System;
using hangman1.Controller;
using System.Linq;


namespace hangman1
{
    public class Game_Hangman
    {
        #region Felder
        NeuesSpiel neuesSpiel = new NeuesSpiel();
        bool erstesmal = true;

        #endregion

        #region Get und Set-Properties

        #endregion

        #region Konstruktoren

        #endregion

        #region Spiele Logik
        public void starteSpiel()
        {

            #region logo
            if (erstesmal == true)
            {
                Console.WriteLine("|    | ______ |\\       ____  |\\    /| ______ |\\     ");
                Console.WriteLine("|    | |    | | \\   | |    | | \\  / | |    | | \\   |");
                Console.WriteLine("|----| |----| |  \\  | |  __  |  \\/  | |----| |  \\  | ");
                Console.WriteLine("|    | |    | |   \\ | | |  | |      | |    | |   \\ |");
                Console.WriteLine("|    | |    | |    \\| |____| |      | |    | |    \\|");


                System.Threading.Thread.Sleep(3000);
                erstesmal = false;

            }
            #endregion

            #region modiauswahl
            Console.Clear();
            Console.WriteLine("Welchen Modi möchtest du Spielen?");
            Console.WriteLine("1 : vorgegebenes Wort");
            Console.WriteLine("2 : eigenes Wort");

            switch (Console.ReadLine())
            {
                case "1":
                    spiel();
                    break;
                case "2":
                    eigenesWort();
                    spiel();
                    break;
                default:
                    Console.WriteLine("Wähle einen Modi aus!");
                    System.Threading.Thread.Sleep(3000);
                    starteSpiel();
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

                //suche Buchstaben im Wort
                try
                {
                    neuesSpiel.sucheBuchstaben(Console.ReadLine().ToLower()[0]);
                }
                catch
                {
                    Console.WriteLine("Gebeden Buchstaben nochmal ein");
                }

                //erhöhe Fehlerzähler
                neuesSpiel.erhöheFehlerZaehler(bereitsErratenVergl);
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
                Console.WriteLine($"Game Over! Das Wort war {neuesSpiel.Wort}");
                System.Threading.Thread.Sleep(3000);
                starteSpiel();
            }
            else
            {
                Console.WriteLine("fehler");
            }
        }
        #endregion
    }
}
