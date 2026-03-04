using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    internal class BingoJatekos
    {
        string nev;
        string[,] kartya;

        public BingoJatekos(string nev, string[,] kartya)
        {
            this.nev = nev;
            this.kartya = kartya;
        }
        public string[,] Kartya { get => kartya; }

        
    }
}
