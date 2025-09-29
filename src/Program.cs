using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontrolni26092025_AleksejJuzin_III3
{

    // made by @yxzhin with <3 ^^
    /*
        1. a)
        2. a)
        3. a)
        4. a)
        5. a)
        6. a)
        7. a)
    */

    internal class Program
    {

        public static void greska(Int16 type = -1, string param = "")
        {

            switch (type)
            {

                case -1: Console.WriteLine("unesite validne vrednosti"); break;
                case -2: Console.WriteLine($"parametar {param} mora biti veci od nule"); break;
                case -3: Console.WriteLine($"parametar {param} ne sme biti veci od ukupnoPrimeraka"); break;
                case -4: Console.WriteLine($"parametar {param} ne sme biti veci od dostupnoPrimeraka"); break;

            }

        }

        class Knjiga
        {

            private string naslov;
            private string autor;
            private int godinaIzdanja;
            private int ukupnoPrimeraka;
            private int dostupnoPrimeraka;

            public int GodinaIzdanja
            {
                get
                {
                    return this.godinaIzdanja;
                }
                set
                {
                    if (value <= 0) greska(-2, $"{this.naslov}.godinaIzdanja");
                }
            }

            public int UkupnoPrimeraka
            {

                get
                {
                    return this.ukupnoPrimeraka;
                }
                set
                {
                    if (value < 0) greska(-2, $"{this.naslov}.ukupnoPrimeraka");
                }

            }

            public int DostupnoPrimeraka
            {

                get
                {
                    return this.dostupnoPrimeraka;
                }
                set
                {
                    if (value < 0) greska(-2, $"{this.naslov}.dostupnoPrimeraka");
                    if (value > this.ukupnoPrimeraka) greska(-3, $"{this.naslov}.dostupnoPrimeraka");
                }

            }

            public Knjiga(string naslov, string autor, int godinaIzdanja, int ukupnoPrimeraka, int dostupnoPrimeraka)
            {

                this.naslov = naslov;
                this.autor = autor;
                this.godinaIzdanja = godinaIzdanja;
                this.ukupnoPrimeraka = ukupnoPrimeraka;
                this.dostupnoPrimeraka = dostupnoPrimeraka;

            }

            public Int16 ispisiDetalje()
            {

                Console.WriteLine($"naslov: {this.naslov}");
                Console.WriteLine($"autor: {this.autor}");
                Console.WriteLine($"godinaIzdanja: {this.godinaIzdanja}");
                Console.WriteLine($"ukupnoPrimeraka: {this.ukupnoPrimeraka}");
                Console.WriteLine($"dostupnoPrimeraka: {this.dostupnoPrimeraka}");

                return 1;

            }

            public Int16 pozajmiPrimerak(int broj)
            {

                if(this.dostupnoPrimeraka < broj)
                {

                    greska(-4, $"{this.naslov}.pozajmiPrimerak.broj");
                    return -1;

                }

                this.dostupnoPrimeraka -= broj;

                return 1;

            }

            public Int16 vratiPrimerak(int broj)
            {

                if (broj > this.ukupnoPrimeraka) broj = this.ukupnoPrimeraka;

                return 1;

            }

            public int proveriStarost()
            {

                int starost = DateTime.Now.Year - this.godinaIzdanja;

                if (starost > 50) Console.WriteLine($"knjiga {this.naslov} spada u arhivu");

                return starost;

            }

        }

        static void Main(string[] args)
        {

            List<Knjiga> knjige = new List<Knjiga>();

            for(Int16 i = 0; i < 3; i++)
            {

                string naslov, autor;
                int godinaIzdanja, ukupnoPrimeraka, dostupnoPrimeraka;

                Console.WriteLine($"unos podataka za knjigu #{i + 1}");
                Console.WriteLine("unesite naslov:");
                naslov = Console.ReadLine();
                Console.WriteLine("unesite autora:");
                autor = Console.ReadLine();

                Console.WriteLine("unesite godinu izdanja:");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out int result))
                    {
                        greska(-1);
                        continue;
                    }
                    godinaIzdanja = result;
                    break;
                }

                Console.WriteLine("unesite ukupno primeraka:");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out int result))
                    {
                        greska(-1);
                        continue;
                    }
                    ukupnoPrimeraka = result;
                    break;
                }

                Console.WriteLine("unesite dostupno primeraka:");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out int result))
                    {
                        greska(-1);
                        continue;
                    }
                    dostupnoPrimeraka = result;
                    break;
                }

                Knjiga knjiga = new Knjiga(naslov, autor, godinaIzdanja, ukupnoPrimeraka, dostupnoPrimeraka);

                knjige.Add(knjiga);

            }

            foreach(Knjiga knjiga in knjige)
            {

                int n = knjige.IndexOf(knjiga)+1;

                Console.WriteLine($"unesite kolicinu primeraka za pozajmiti za knjigu #{n}:");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out int result))
                    {
                        greska(-1);
                        continue;
                    }
                    knjiga.pozajmiPrimerak(result);
                    break;
                }

                Console.WriteLine($"unesite kolicinu primeraka za vratiti za knjigu #{n}:");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out int result))
                    {
                        greska(-1);
                        continue;
                    }
                    knjiga.vratiPrimerak(result);
                    break;
                }

                knjiga.proveriStarost();

            }

            foreach (Knjiga knjiga in knjige)
            {

                Console.WriteLine($"ispis detalja za knjigu #{knjige.IndexOf(knjiga)+1}");

                knjiga.ispisiDetalje();

            }

            Console.ReadLine();

        }
    }
}
