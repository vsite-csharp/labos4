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
        public string Naziv
        {
            get;
            set;
        }
        public uint Ocjena
        {
            get;
            set;
        }
    }

    class Student
    {
        public string ImePrezime
        {
            get;
            set;
        }
        public Ispit[] Ispiti
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // :03b Zadati listu studenata s popisom ispita na koje je izašao.
            var studenti = new List<Student>
            {
                new Student
                {
                    ImePrezime = "Pero Perić", Ispiti = new Ispit[] {new Ispit {Naziv = "Matematika", Ocjena = 1},}
                },
                new Student
                {
                    ImePrezime = "Pero Kvrgić", Ispiti = new Ispit[]
                    {
                        new Ispit {Naziv = "Fizika", Ocjena = 5},new Ispit { Naziv = "Matematika", Ocjena = 3}
                    }
                },
                new Student
                {
                    ImePrezime = "Lana Jurčević", Ispiti = new Ispit[]
                    {
                        new Ispit {Naziv = "Vjeronauk", Ocjena = 2},new Ispit { Naziv = "Matematika", Ocjena = 3}
                    }
                },
                new Student
                {
                ImePrezime = "Marko Marić", Ispiti = new Ispit[]
                {
                    new Ispit {Naziv = "TZK", Ocjena = 5},new Ispit { Naziv = "Fizika", Ocjena = 5}
                }
            },
                new Student
                {
                ImePrezime = "Andrej Plenković", Ispiti = new Ispit[]
                {
                }
            }
            };

            string imePredmeta = "TZK";
            Console.WriteLine("Studenti koji su izašli na ispit iz predmeta {imePredmeta}");
            // :03c Napisati upit koji će vratiti popis svih studenata koji su izašli na ispit iz zadanog predmeta.
            var studentiNaIspitu = from student in studenti
                from ispit in student.Ispiti
                where ispit.Naziv == imePredmeta
                select student;
       foreach (var s in studentiNaIspitu)
           Console.WriteLine(s.ImePrezime);

       Console.WriteLine($"Studenti koji su pali ispit iz predmeta {imePredmeta}:");
            // :03d Napisati upit koji će rezultata prethodnog upita vratiti sve studente koji su pali ispit iz zadanog predmeta.
            var studentiPaliIspit = from student in studenti
                from ispit in student.Ispiti
                where ispit.Ocjena == 1
                select new {student, ispit};
            foreach (var s in studentiPaliIspit)
                Console.WriteLine($"{s.student.ImePrezime} je pao {s.ispit.Naziv}");
        }
    }
}
