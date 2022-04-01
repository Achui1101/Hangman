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
        ArrayList underscores = new ArrayList();

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

        public NeuesSpiel()
        {
            this.wort = setWortAusDB();
            this.anzahlFehler = 0;
            this.anzahlLegalFehler = 5;
            this.underscores.Clear();
            this.errateneBuchstaben = createUnderscores().ToCharArray();


        }

        private string setWortAusDB()
        {
            int random;

            Random randomObj = new Random();
            random = randomObj.Next(0, 6);

            string[] wortListe = { "Hallo", "Welt", "Idesis", "Christian", "Noah", "Nina" };

            return wortListe[random];
        }

        private string createUnderscores()
        {
            
            for (int i = 0; i <= this.wort.Length; i++)
            {
                underscores.Add('_');
            }


            return underscores.ToString();
        }


    }
}
