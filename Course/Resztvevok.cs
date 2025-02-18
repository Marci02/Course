using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    internal class Resztvevok
    {
        public string Nev { get; set; }
        public string Nem { get; set; }
        public int Befizetes { get; set; }
        public int[] Eredmenyek = new int[4];

        public Resztvevok(string sor)
        {
            var v = sor.Split(';');
            Nev = v[0];
            Nem = v[1] == "m" ? "Férfi" : "Nő";
            Befizetes = int.Parse(v[2]);
            for (int i = 0; i < 4; i++) {
                Eredmenyek[i] = int.Parse(v[i + 3]);   
            }
        }
    }
}
