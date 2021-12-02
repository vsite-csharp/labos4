using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.CSharp.Labos4.Zadatak2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            Table<student> studenti = dc.GetTable<student>();
            var upit = from s in studenti
                       select new
                       {
                           sID = s.stud_ID,
                           Ime = s.ime + " " + s.prezime
                       };
            Console.WriteLine("Popis svih studenata:");
            foreach (var v in upit)
                Console.WriteLine("ID:{0} Ime:{1}", v.sID, v.Ime);
        }
    }
}
