using System;
using hangman1.Controller;

namespace hangman1
{
    //  
    //  MK: Dein Design gefällt mir hier nicht besonders gut:
    //      Ich verstehe die Trennung zwischen Game_Hangman und NeuesSpiel.
    //      Allerdings werden die gleichen Eigenschaften von NeuesSpiel hier
    //      wiederholt. Das muss nicht sein.
    //  Versuche mal bitte, auf ein Spiel in Game_Hangman zu referenzieren.
    //
    //  Darüber hinaus wird im Program.Main noch zu viel von den Details verwendet.
    //  Aber das sollten wir besprechen.
    //
    public class Game_Hangman
    {
        //
        //  MK: Zu Properties vergleiche bitte NeuesSpiel
        //
        public string wort;
        int anzahlFehler;
        int anzahlLegalFehler;
        char[] errateneBuchstaben;

        public string getWort()
        {
            return this.wort;
        }

        public void setWort(string wortIn)
        {
            this.wort = wortIn;
        }

        public int getAnzahlFehler()
        {
            return this.anzahlFehler;
        }

        public void setAnzahlFehler(int anzahlFehlerIn)
        {
            this.anzahlFehler = anzahlFehlerIn;
        }

        public int getAnzahlLegalFehler()
        {
            return this.anzahlLegalFehler;
        }

        public void setAnzahlLegalFehler(int anzahlLegalFehlerIn)
        {
            this.anzahlLegalFehler = anzahlLegalFehlerIn;
        }

        public char[] getErrateneBuchstaben()
        {
            return this.errateneBuchstaben;
        }

        public void setErrateneBuchstaben(string errateneBuchstabenIn)
        {
            this.errateneBuchstaben = errateneBuchstabenIn.ToCharArray();
        }

        public Game_Hangman()
        {
            NeuesSpiel neuesSpiel = new NeuesSpiel();
            this.wort = neuesSpiel.getWort();
            this.anzahlFehler = neuesSpiel.getAnzahlFehler();
            this.anzahlLegalFehler = neuesSpiel.getAnzahlLegalFehler();
            this.errateneBuchstaben = neuesSpiel.getErrateneBuchstaben();
        }
    }
}
