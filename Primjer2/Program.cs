using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.CSharp.Labos4.Primjer2
{
    class Učenik
    {
        public string ImePrezimeUčenika
        {
            get;
            set;
        }
        public string RazredUčenika
        {
            get;
            set;
        }
    }
    class Profesor
    {
        public string ImePrezimeProfesora
        {
            get;
            set;
        }
        public string JeRazrednikRazredu
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Profesor> listaProfesora = new List<Profesor> {
                new Profesor{ ImePrezimeProfesora = "Dubravka Milić",JeRazrednikRazredu="3.b"},
                new Profesor{ ImePrezimeProfesora = "Dragica Pribić", JeRazrednikRazredu="4.h"},
                new Profesor{ ImePrezimeProfesora = "Miroslav Šašić", JeRazrednikRazredu="4.k"}
            };
            List<Učenik> popisNajboljihUčenika = new List<Učenik> {
                new Učenik{ ImePrezimeUčenika="Ana Anić", RazredUčenika="1.a"},
                new Učenik{ ImePrezimeUčenika="Ivo Matić", RazredUčenika="3.h"},
                new Učenik{ ImePrezimeUčenika="Petra Petrić", RazredUčenika="4.h"}
            };

            //  Napisati upit koji će iz popisa najboljih učenika prikazati samo one za koje u listi profesora naveden razrednik

            var upit = from profesor in listaProfesora
                from ucenik in popisNajboljihUčenika
                where ucenik.RazredUčenika.Equals(profesor.JeRazrednikRazredu)
                select new
                {
                    ImePrezimeUčenika = ucenik.ImePrezimeUčenika, RazredUčenika = profesor.JeRazrednikRazredu,
                    ImePrezimeProfesora = profesor.ImePrezimeProfesora
                };

            var upit2 = listaProfesora.Join(popisNajboljihUčenika, profesor => profesor.JeRazrednikRazredu,
                ucenik => ucenik.RazredUčenika, (profesor, ucenik) => new
                {
                    ImePrezimeUčenika = ucenik.ImePrezimeUčenika,
                    RazredUčenika = profesor.JeRazrednikRazredu,
                    ImePrezimeProfesora = profesor.ImePrezimeProfesora
                });

            foreach (var s in upit)
                Console.WriteLine("Učeniku {0} iz razreda {1} razrednik je {2}", s.ImePrezimeUčenika, s.RazredUčenika, s.ImePrezimeProfesora);

            Console.WriteLine();

            foreach (var s in upit2)
                Console.WriteLine("Učeniku {0} iz razreda {1} razrednik je {2}", s.ImePrezimeUčenika, s.RazredUčenika, s.ImePrezimeProfesora);


            Console.ReadKey(false);
        }
    }
}
