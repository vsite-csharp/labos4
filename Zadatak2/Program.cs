using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Vsite.CSharp.Labos4.Zadatak2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            Table<student> studenti = dc.GetTable<student>();
            var studentići = from s in studenti
                             select new
                             {
                                 sID = s.stud_ID,
                                 Ime = s.ime + " " + s.prezime
                             };

            Console.WriteLine("Popis svih studenata:");
            foreach (var v in studentići)
                Console.WriteLine("ID:{0} Ime:{1}", v.sID, v.Ime);

            Table<ispit> ispiti = dc.GetTable<ispit>();
            var ispitići = from i in ispiti
                           select new
                           {
                               sID = i.stud_ID,
                               dat = i.dat_ispit,
                               pID = i.pred_ID,
                               ocjena = i.ocjena
                           };

            //foreach (var v in ispitići)
            //    Console.WriteLine("ID:{0} Datum:{1} predmetID:{2} ocjena:{3}", v.sID, v.dat, v.pID, v.ocjena);

            Table<predmet> predmeti = dc.GetTable<predmet>();
            //foreach (var v in predmeti)
            //    Console.WriteLine("pID:{0} naziv:{1}", v.pred_ID, v.naziv_pred);

            string imePredmeta = "Matematika";
            Console.WriteLine($"Studenti koji su izašli na ispit iz predmeta {imePredmeta}:");

            var zadaniPredmet = from p in predmeti
                                where p.naziv_pred == imePredmeta
                                select new
                                {
                                    pID = p.pred_ID,
                                    naziv = p.naziv_pred
                                };
            //foreach (var v in zadaniPredmet)
            //    Console.WriteLine("pID:{0} naziv:{1}", v.pID, v.naziv);

            var studentiNaIspitu = from s in studentići
                                   from i in ispiti
                                   where (i.stud_ID == s.sID) && (i.pred_ID == zadaniPredmet.FirstOrDefault().pID)
                                   select new
                                   {
                                       sID = s.sID,
                                       Ime = s.Ime,
                                       ocjena = i.ocjena
                                   };

            foreach (var s in studentiNaIspitu)
                Console.WriteLine("ID:{0} Ime:{1} ocjena:{2}", s.sID, s.Ime, s.ocjena);


            Console.WriteLine($"Studenti koji su pali ispit iz predmeta {imePredmeta}:");
            // Napisati upit koji će rezultata prethodnog upita vratiti sve studente koji su pali ispit iz zadanog predmeta.
            var jedinice = from i in ispiti
                           where i.ocjena == 1
                           select i;


            var studentiPaliIspit = from s in studentići
                                    from i in jedinice
                                    from p in predmeti
                                    where (s.sID == i.stud_ID) && (i.pred_ID == p.pred_ID)
                                    select new
                                    {
                                        sID = s.sID,
                                        Ime = s.Ime,
                                        naziv = p.naziv_pred
                                    };


            foreach (var s in studentiPaliIspit)
                Console.WriteLine($"{s.Ime} je pao/la predmet {s.naziv}.");

            Console.ReadKey(false);
        }
    }
}
