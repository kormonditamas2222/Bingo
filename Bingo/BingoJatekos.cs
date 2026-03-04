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

        public void SorsoltSzamotJelol(string szam)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (this.kartya[i,j] == szam)
                    {
                        this.kartya[i, j] = "X";
                    }
                }
            }
        }
    }
}
