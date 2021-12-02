using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.CSharp.Labos4.Zadatak1
{
    // TODO:03a Definirati klasu koja predstavlja studenta i klasu koja predstavlja ispit.
    // Klasa Ispit sadrži članove Naziv i Ocjena, a klasa Student sadrži članove ImePrezime i listu Ispit[] ispita na koje je student izašao.

    class Ispit
    {
        public string Naziv { get; set; }
        public int Ocjena { get; set; }
    }
    class Student
    {
        public string ImePrezime { get; set; }
        public Ispit[] Ispiti { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 03b Zadati listu studenata s popisom ispita na koje je izašao.
            var studenti = new List<Student>
            {
                new Student{ImePrezime = "Pero Perić", Ispiti = new Ispit[] { new Ispit{Naziv = "Matematika", Ocjena = 1} } },
                new Student{ImePrezime = "Ivo Ivic", Ispiti = new Ispit[] { new Ispit{Naziv = "Fizika", Ocjena = 5}, new Ispit { Naziv = "Povijest", Ocjena = 2 } } },
                new Student{ImePrezime = "Marko Markic", Ispiti = new Ispit[] { new Ispit{Naziv = "Zemljopis", Ocjena = 3}, new Ispit{Naziv = "Matematika", Ocjena = 4}, new Ispit { Naziv = "Povijest", Ocjena = 5 } } },
                new Student{ImePrezime = "Lovro Lovric", Ispiti = new Ispit[] { } }
            };
            string imePredmeta = "Matematika";
            Console.WriteLine("Studenti koji su izašli na ispit iz predmeta {imePredmeta}");
            // 03c Napisati upit koji će vratiti popis svih studenata koji su izašli na ispit iz zadanog predmeta.
            var studentiNaIspitu = from stud in studenti
                                   from ispit in stud.Ispiti
                                   where ispit.Naziv == imePredmeta
                                   select new { stud.ImePrezime };

            foreach (var s in studentiNaIspitu)
                Console.WriteLine(s.ImePrezime);

            Console.WriteLine($"Studenti koji su pali ispit iz predmeta {imePredmeta}:");
            // 03d Napisati upit koji će rezultata prethodnog upita vratiti sve studente koji su pali ispit iz zadanog predmeta.
            var pali = from stud in studenti
                       from ispit in stud.Ispiti
                       where ispit.Naziv == imePredmeta
                       where ispit.Ocjena == 1
                       select new { stud.ImePrezime, ispit.Naziv };

            foreach (var s in pali)
                Console.WriteLine($"{s.ImePrezime} je pao {s.Naziv}");

            Console.ReadLine();
        }
    }
}
