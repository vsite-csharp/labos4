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
        public byte Ocijena { get; set; }
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
            // TODO:03b Zadati listu studenata s popisom ispita na koje je izašao.
            var listaStudenti = new Student[]
            {
                new Student()
                {
                    ImePrezime = "Pero Peric",
                    Ispiti = new Ispit[]
                    {
                        new Ispit()
                        {
                            Naziv = "Matematika",
                            Ocijena = 1
                        },
                        new Ispit()
                        {
                            Naziv = "Engleski",
                            Ocijena = 5
                        },
                        new Ispit()
                        {
                            Naziv = "Biologija",
                            Ocijena = 3
                        },
                    }
                },
                new Student()
                {
                    ImePrezime = "Marko Maric",
                    Ispiti = new Ispit[]
                    {
                        new Ispit()
                        {
                            Naziv = "Matematika",
                            Ocijena = 5
                        },
                        new Ispit()
                        {
                            Naziv = "Engleski",
                            Ocijena = 1
                        },
                        new Ispit()
                        {
                            Naziv = "Fizika",
                            Ocijena = 4
                        },
                    }
                }
                ,
                new Student()
                {
                    ImePrezime = "Ivo Maric",
                    Ispiti = new Ispit[]
                    {
                        new Ispit()
                        {
                            Naziv = "Tjelesni",
                            Ocijena = 5
                        },
                        new Ispit()
                        {
                            Naziv = "Hrvatski",
                            Ocijena = 1
                        },
                        new Ispit()
                        {
                            Naziv = "Fizika",
                            Ocijena = 4
                        },
                    }
                }

            }
            ;
        
            

            string imePredmeta = "Matematika";
            Console.WriteLine("Studenti koji su izašli na ispit iz predmeta {imePredmeta}");
            var studentiNaIspitu = listaStudenti.Where(stud => stud.Ispiti.Any(isp => isp.Naziv.Equals(imePredmeta)));
            // Napisati upit koji će vratiti popis svih studenata koji su izašli na ispit iz zadanog predmeta.

            foreach (var s in studentiNaIspitu)
                Console.WriteLine(s.ImePrezime);

            Console.WriteLine($"Studenti koji su pali ispit iz predmeta {imePredmeta}:");
            // Napisati upit koji će rezultata prethodnog upita vratiti sve studente koji su pali ispit iz zadanog predmeta.
            var studentiPaliIspit = listaStudenti.Select(stud => new { student = stud, ispit = stud.Ispiti.Where(isp => isp.Naziv.Equals(imePredmeta)).FirstOrDefault()}).Where(tr => tr.ispit?.Ocijena == 1);
            foreach (var s in studentiPaliIspit)
                Console.WriteLine($"{s.student.ImePrezime} je pao {s.ispit.Naziv}");
        }
    }
}
