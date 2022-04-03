using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace hangman1.Controller
{
	public class NeuesSpiel
	{
		//
		//  MK: In c# gibt es sogenannte Properties, damit können Getter und Setter
		//  deutlich vereinfacht werden, das spart eine Menge Code und ist deutlich 
		//  übersichtlicher.
		//  Beispiel:
		public string Beispiel { get; set; }
		//
		//  Oder auch für öffentlich eingeschränkte Properties in einer Variante mit 
		//  einem private Setter:
		//
		public int PrivateSetter
		{
			get; private set;
		}
		//
		//  Einen reinen Getter kann man auch in der folgenden Variante implementieren:
		//
		public bool HatFehler => anzahlFehler == 0;
		//
		//  Man kann den Getter und Setter auch implementieren:
		//  Es folgt ein Beispiel nur mit Getter (im set kann auf den "Übergabe-Parameter"
		//  mit value " zugegriffen werden) 
		//
		public string WortAusDB
		{
			get
			{
				string[] wortListe = { "Hallo", "Welt", "Idesis", "Christian", "Noah", "Nina" };
				Random randomObj = new Random();
				int random = randomObj.Next(0, 6);
				return wortListe[random];
			}
		}

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
			//
			//  MK: Du verwendest Deine Setter-Methoden selbst nicht.
			//  Wenn Du auf Properties umstellst, kannst Du die set-Anweisung 
			//  auf private setzen und dann das folgende schreiben:
			//      AnzahlFehler = 0;
			//
			this.wort = setWortAusDB();
			this.anzahlFehler = 0;
			this.anzahlLegalFehler = 5;
			//
			//	MK: Das braucht es eigentlich nicht, da mit dem Konstruktor auch
			//	die underscores neu angelegt werden.
			//
			this.underscores.Clear();
			//
			//  MK: Die Methode createUnderscores wird nur hier aufgerufen,
			//  sie könnte gleich ein char[] zurückliefern.
			//
			this.errateneBuchstaben = createUnderscores().ToCharArray();
		}

		private string setWortAusDB()
		{
			//
			//  MK: Variablen-Deklarationen, wenn möglich gleich mit einer Zuweisung verbinden:
			//      int random = randomObj.Next(0, 6);
			//  Das geht, weil Variablen an beliebiger Stelle deklariert werden können.
			//
			int random;

			Random randomObj = new Random();
			random = randomObj.Next(0, 6);

			string[] wortListe = { "Hallo", "Welt", "Idesis", "Christian", "Noah", "Nina" };

			return wortListe[random];
		}

		private string createUnderscores()
		{
			//
			//  MK: Vereinfachter Aufruf: 
			//      string x = new('_', wort.Length +1);
			//
			for (int i = 0; i <= this.wort.Length; i++)
			{
				underscores.Add('_');
			}
			//
			//  MK: Wie oben angemerkt, gleich .ToCharArray()
			//  anhängen und den Rückgabe-Typ auf char[]
			//  setzen.
			//
			return underscores.ToString();
		}
	}
	//
	//	So würde ich das wahrscheinlich umsetzen, damit die Klasse
	//	HangmanSpiel bzw. Spiel abgeschlossen ist und nur Informationen nach
	//	außen gibt.
	//
	public class HangmanSpiel
	{
		#region Private Members
		//
		//	Die internen Member, auf diese kann nicht von außen zugegriffen
		//	werden.
		//
		private string LösungsWort;
		//
		//	Der StringBuilder wird benötigt, da wir die Zeichenkette immer wieder 
		//	verändern.
		//
		private StringBuilder ErgebnisWort;
		//
		//	Anzahl der Versuche, bis das Spiel abgebrochen wird
		//
		public int AnzahlVersuche { get; private set; }
		#endregion
		#region Ctors
		//
		//	Der Default-Konstruktor erzeugt gleich ein neues Lösungswort
		//	über die "DB".
		//
		public HangmanSpiel(int anzahlVersuche = 10)
		{
			AnzahlVersuche = anzahlVersuche;
			LösungsWort = WortAusDB();
			ErgebnisWort = new StringBuilder(new string('_', LösungsWort.Length));
		}
		//
		//	Ein Konstruktor mit übergebenen Lösungswort.
		//
		public HangmanSpiel(string lösungWort, int anzahlVersuche = 10)
		{
			AnzahlVersuche = anzahlVersuche;
			LösungsWort = lösungWort.ToLower();
			ErgebnisWort = new StringBuilder(new string('_', LösungsWort.Length));
		}
		#endregion

		#region Public Interface
		//
		//	Liefert den aktuellen Stand, als String
		//
		public string Stand => ErgebnisWort.ToString();
		public int AnzahlFalsch => ErgebnisWort.ToString().Count((x) => x == '_');
		public int AnzahlRichtig => ErgebnisWort.ToString().Count((x) => x != '_');
		public bool Okay => ErgebnisWort.ToString() == LösungsWort || AnzahlVersuche == 0;
		//
		//	Für ein neues Zeichen, wird das Ergebnis neu berechnet und
		//	der Stand des Ergebnisses als String zurückgeliefert.
		//
		public string Versuch(char newChar)
		{
			--AnzahlVersuche;
			for (int i = 0; i != LösungsWort.Length; ++i)
			{
				if (LösungsWort[i] == Char.ToLower(newChar))
				{
					ErgebnisWort[i] = newChar;
				}
			}
			return ErgebnisWort.ToString();
		}
		#endregion

		#region Private Helpers
		//
		//	Die Liste ist über alle Instanzen des Spiels gleich.
		//	daher kann diese als static deklariert werden.
		//
		private static readonly string[] wortListe = { "Hallo", "Welt", "Idesis", "Christian", "Noah", "Nina" };
		private string WortAusDB()
		{
			Random randomObj = new Random();
			int random = randomObj.Next(0, 6);
			return wortListe[random].ToLower();
		}
		#endregion
	}
}
