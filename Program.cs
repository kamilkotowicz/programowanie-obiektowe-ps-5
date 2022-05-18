using System;
using Kartoteka = kartoteka.impl.Kartoteka;
namespace kartoteka 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IKartoteka k = new Kartoteka();
            int tryb = 1;
            string imie, nazwisko,s;
            int rozmiar, indeks;
            while (tryb!=0)
            {
                Console.WriteLine("Podaj co chcesz zrobic:");
                Console.WriteLine("0 - zakoncz program");
                Console.WriteLine("1 - dodaj osobe");
                Console.WriteLine("2 - usun osobe");
                Console.WriteLine("3 - podaj rozmiar");
                Console.WriteLine("4 - sprawdz czy dana osoba jest w kartotece");
                Console.WriteLine("5 - pobierz osobe o indeksie");
                s = Console.ReadLine();
                tryb = Convert.ToInt32(s);
                switch (tryb)
                {
                    case 1:
                        Console.WriteLine("Podaj imie i nazwisko");
                        imie = Console.ReadLine();
                        nazwisko = Console.ReadLine();
                        k.dodaj(new Osoba(imie, nazwisko));
                        Console.WriteLine("Dodano osobe");
                        break;
                    case 2:
                        Console.WriteLine("Podaj imie i nazwisko");
                        imie = Console.ReadLine();
                        nazwisko = Console.ReadLine();
                        k.usun(new Osoba(imie, nazwisko));
                        Console.WriteLine("Usunieto osobe");
                        break;
                    case 3:
                        Console.Write("Rozmiar kartoteki wynosi ");
                        rozmiar = k.rozmiar();
                        Console.WriteLine(rozmiar);
                        break;
                    case 4:
                        Console.WriteLine("Podaj imie i nazwisko");
                        imie = Console.ReadLine();
                        nazwisko = Console.ReadLine();
                        if (k.czyZawiera(new Osoba(imie,nazwisko))==true)
                        {
                            Console.WriteLine("Osoba jest w kartotece");
                        }
                        else
                        {
                            Console.WriteLine("Osoby nie ma w kartotece");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Podaj numer indeksu");
                        s = Console.ReadLine();
                        indeks = Convert.ToInt32(s);
                        Osoba szukana_osoba = k.pobierz(indeks);
                        Console.WriteLine("Znaleziona osoba to ");
                        Console.WriteLine(szukana_osoba.ToString());
                        break;
                    default:
                        Console.WriteLine("Zakonczono program");
                        break;
                }
            }

        }
    }
    public class Osoba : IEquatable<Osoba>
    {
        private string imie;
        private string nazwisko;

        public Osoba(string im, string nazw)
        {
            imie = im;
            nazwisko = nazw;
        }
        public string getImie()
        {
            return imie;
        }
        public string getNazwisko()
        {
            return nazwisko;
        }
        public bool Equals(Osoba other)
        {
            if (other == null)
                return false;

            if ((this.imie == other.imie) && (this.nazwisko==other.nazwisko))
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Osoba personObj = obj as Osoba;
            if (personObj == null)
                return false;
            else
                return Equals(personObj);
        }
        public string ToString()
        {
            return imie + " " + nazwisko;
        }
    }
    interface IKartoteka
    {
        public void dodaj(Osoba o);
        public void usun(Osoba o);
        public int rozmiar();
        public bool czyZawiera(Osoba o);
        public Osoba pobierz(int indeks);

    }
    namespace mockup
    {
        class Kartoteka : IKartoteka
        {
            public void dodaj(Osoba o)
            {

            }
            public void usun(Osoba o)
            {

            }
            public int rozmiar()
            {
                return 1;
            }
            public bool czyZawiera(Osoba o)
            {
                return true;
            }
            public Osoba pobierz(int indeks)
            {
                return new Osoba("Gall", "Anonim");
            }
        }
    }

    namespace impl
    {
        class Kartoteka : IKartoteka
        {
            private List<Osoba> osoby = new List<Osoba>();
            public void dodaj(Osoba o)
            {
                osoby.Add(o);
            }
            public void usun(Osoba o)
            {
                osoby.Remove(o);
            }
            public int rozmiar()
            {
                return osoby.Count;
            }
            public bool czyZawiera(Osoba o)
            {
                return osoby.Contains(o);
            }
            public Osoba pobierz(int indeks)
            {
                return osoby[indeks];
            }
        }
    }



}