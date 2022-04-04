using System;
using System.Collections;

namespace hangman1.Controller
{
    public class NeuesSpiel
    {
        private string wort;
        int anzahlFehler;
        int anzahlLegalFehler;
        char[] errateneBuchstaben;


        public string Wort {
            get { return wort; }
            set { wort = value; }
        }

        public int AnzahlFehler {
            get { return anzahlFehler; }
            set { anzahlFehler = 0; }
        }


        public int AnzahlLegalFehler {
            get { return anzahlLegalFehler; }
            set { anzahlLegalFehler = 6; }
        }
        
        public char[] ErrateneBuchstaben {
            get { return errateneBuchstaben; }
            set { errateneBuchstaben = value; }
        }

       
        public NeuesSpiel()
        {
            wort = WortAusDB();
            anzahlFehler = 0;
            anzahlLegalFehler = 5;

        }

        private string WortAusDB()
        {
            string[] wortListe = { "Hallo", "Welt", "Idesis", "Christian", "Noah", "Nina" };
            Random randomObj = new Random();
            return wortListe[randomObj.Next(0, wortListe.Length)];
        }

    }
}
