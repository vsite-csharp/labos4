using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.InteropServices;
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
            Table<ispit> ispiti = dc.GetTable<ispit>();
            Table<predmet> predmeti = dc.GetTable<predmet>();
            var upit = from s in studenti
                       select new
                       {
                           sID = s.stud_ID,
                           Ime = s.ime + " " + s.prezime
                       };
            Console.WriteLine("Popis svih studenata:");
            foreach (var v in upit)
                Console.WriteLine("ID:{0} Ime:{1}", v.sID, v.Ime);

            var studentIIspiti = studenti.Join(ispiti, stud => stud.stud_ID, ispit => ispit.stud_ID,
                (stud, ispit) => new { student = stud, ispit = ispit });

            Console.WriteLine("Svi studenti i ispiti");
            foreach (var studIIspit in studentIIspiti)
            {
                Console.WriteLine("Student " + studIIspit.student.ime + " " + studIIspit.student.prezime + " " + predmeti.Where(pred => pred.pred_ID == studIIspit.ispit.pred_ID).Select(pred => pred.naziv_pred).FirstOrDefault());
            }

            Console.WriteLine("");
            Console.WriteLine("Studenti koji su pali ispit");
            var paliStudenti = studentIIspiti.Where(stud => stud.ispit.ocjena == 1);
            foreach (var studIIspit in paliStudenti)
            {
                Console.WriteLine("Student " + studIIspit.student.ime + " " + studIIspit.student.prezime + " " + predmeti.Where(pred => pred.pred_ID == studIIspit.ispit.pred_ID).Select(pred => pred.naziv_pred).FirstOrDefault());
            }

            Console.WriteLine();
            Console.WriteLine("Izvrsni studenti ");
            var excelentStudents = dc.AllExcelentStudentsGet();

            foreach (var excelentStudent in excelentStudents)
            {
                Console.WriteLine(excelentStudent.ime + " " + excelentStudent.prezime + " prosjek " + excelentStudent.prosjek);
            }
        }
    }
}
