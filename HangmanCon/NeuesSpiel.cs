using System;
using System.Linq;


namespace hangman1.Controller
{
    public class NeuesSpiel
    {
        #region Felder
        private string wort;
        int anzahlFehler = 0;
        int anzahlLegalFehler = 6;
        char[] errateneBuchstaben;
        #endregion

        #region Get und Set
        public string Wort {
            get { return wort; }
            set { wort = value; }
        }

        public int AnzahlFehler {
            get { return anzahlFehler; }
            private set { anzahlFehler = value ; }
        }


        public int AnzahlLegalFehler {
            get { return anzahlLegalFehler; }
            private set { anzahlLegalFehler = value; }
        }
        
        public char[] ErrateneBuchstaben {
            get { return errateneBuchstaben; }
            set { errateneBuchstaben = value; }
        }

        #endregion

        #region Konstruktoren
        public NeuesSpiel()
        {
            Wort = WortAusDB().ToLower();
        }

        #endregion

        #region Spielelogik
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

        public void erhoeheFehlerZaehler(char[] berreitsErraten)
        {
            if (berreitsErraten.SequenceEqual(ErrateneBuchstaben))
            {
                AnzahlFehler++;
            }

        }

        public void erzeugeUnterstriche()
        {

            string stricheArr = new('_', wort.Length);
            ErrateneBuchstaben = stricheArr.ToCharArray();

            AnzahlFehler = 0;
        }
        #endregion

        #region DB-Connection

        public string WortAusDB()
        {
            string[] wortListe = { "Hallo", "Welt", "Idesis", "Christian", "Noah", "Nina", "Macbook", "Urlaub", "Lego", "Programmieren", "Fernbedienung", "Gürtel" };
            Random randomObj = new Random();
            return wortListe[randomObj.Next(0, wortListe.Length)].ToLower();
        }

        #endregion

    }
}
