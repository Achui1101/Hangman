using System;
using System.Collections;
using System.Linq;

namespace hangman1.Controller
{
    public class NeuesSpiel
    {
        #region Felder
        private string wort;
        int anzahlFehler;
        int anzahlLegalFehler;
        char[] errateneBuchstaben;
        #endregion

        #region Get und Set-Properties
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

        #endregion

        #region Konstruktoren
        public NeuesSpiel()
        {
            wort = WortAusDB().ToLower();
            anzahlFehler = 0;
            anzahlLegalFehler = 5;

        }

        public NeuesSpiel(string wortIn)
        {
            wort = wortIn.ToLower();
            anzahlFehler = 0;
            anzahlLegalFehler = 5;

        }
        #endregion

        public void sucheBuchstaben(char buchstabe)
        {
            for (int i = 0; i < Wort.Length; i++)
            {
                if (buchstabe == Wort[i])
                {
                    ErrateneBuchstaben[i] = buchstabe;

                }
            }
        }


        public void erhöheFehlerZaehler(char[] berreitsErraten)
        {
            if (berreitsErraten.SequenceEqual(ErrateneBuchstaben))
            {
                anzahlFehler++;
            }

        }

        public char[] erzeugeUnterstriche()
        {
            char[] stricheArr = new char[Wort.Length];
            for (int i = 0; i < Wort.Length; i++)

            {
                stricheArr[i] = '_';
            }
            ErrateneBuchstaben = stricheArr;

            AnzahlFehler = 0;

            return stricheArr;
        }

        #region DB-Connection

        private string WortAusDB()
        {
            string[] wortListe = { "Hallo", "Welt", "Idesis", "Christian", "Noah", "Nina" };
            Random randomObj = new Random();
            return wortListe[randomObj.Next(0, wortListe.Length)];
        }

        #endregion


    }
}
