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
        public bool BingoEll()
        {
            string x = "X";
            if (kartya[0, 0] == x && kartya[1, 0] == x && kartya[2, 0] == x && kartya[3, 0] == x && kartya[4, 0] == x ||
                kartya[0, 1] == x && kartya[1, 1] == x && kartya[2, 1] == x && kartya[3, 1] == x && kartya[4, 1] == x ||
                kartya[0, 2] == x && kartya[1, 2] == x && kartya[2, 2] == x && kartya[3, 2] == x && kartya[4, 2] == x ||
                kartya[0, 3] == x && kartya[1, 3] == x && kartya[2, 3] == x && kartya[3, 3] == x && kartya[4, 3] == x ||
                kartya[0, 4] == x && kartya[1, 4] == x && kartya[2, 4] == x && kartya[3, 4] == x && kartya[4, 4] == x ||
                kartya[0, 0] == x && kartya[0, 1] == x && kartya[0, 2] == x && kartya[0, 3] == x && kartya[0, 4] == x ||
                kartya[1, 0] == x && kartya[1, 1] == x && kartya[1, 2] == x && kartya[1, 3] == x && kartya[1, 4] == x ||
                kartya[2, 0] == x && kartya[2, 1] == x && kartya[2, 2] == x && kartya[2, 3] == x && kartya[2, 4] == x ||
                kartya[3, 0] == x && kartya[3, 1] == x && kartya[3, 2] == x && kartya[3, 3] == x && kartya[3, 4] == x ||
                kartya[4, 0] == x && kartya[4, 1] == x && kartya[4, 2] == x && kartya[4, 3] == x && kartya[4, 4] == x ||
                kartya[0, 0] == x && kartya[1, 1] == x && kartya[2, 2] == x && kartya[3, 3] == x && kartya[4, 4] == x ||
                kartya[4, 0] == x && kartya[3, 1] == x && kartya[2, 2] == x && kartya[1, 3] == x && kartya[0, 4] == x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
