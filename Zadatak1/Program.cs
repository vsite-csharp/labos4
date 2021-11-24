using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.CSharp.Labos4.Zadatak1
{
    // TODO:03a Definirati klasu koja predstavlja studenta i klasu koja predstavlja ispit.
    // Klasa Ispit sadrži članove Naziv i Ocjena, a klasa Student sadrži članove ImePrezime i listu Ispit[] ispita na koje je student izašao.

    class Program
    {
        static void Main(string[] args)
        {
            // TODO:03b Zadati listu studenata s popisom ispita na koje je izašao.

            string imePredmeta = "Matematika";
            Console.WriteLine("Studenti koji su izašli na ispit iz predmeta {imePredmeta}");
            // TODO:03c Napisati upit koji će vratiti popis svih studenata koji su izašli na ispit iz zadanog predmeta.

            //foreach (var s in studentiNaIspitu)
            //    Console.WriteLine(s.Ime);

            Console.WriteLine($"Studenti koji su pali ispit iz predmeta {imePredmeta}:");
            // TODO:03d Napisati upit koji će rezultata prethodnog upita vratiti sve studente koji su pali ispit iz zadanog predmeta.

            //foreach (var s in studentiPaliIspit)
            //    Console.WriteLine($"{s.student.Ime} je pao {s.ispit.Naziv}");
        }
    }
}
