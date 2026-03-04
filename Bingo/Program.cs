namespace Bingo
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            List<BingoJatekos> jatekosok = Beolvasas();
            Console.WriteLine($"4. feladat: Játékosok száma: {jatekosok.Count}");
            Console.WriteLine("7. feladat: Kihúzott számok:");
            Huzas(jatekosok);
        }
        static List<BingoJatekos> Beolvasas()
        {
            List<BingoJatekos> jatekosok = [];
            string[] fajlok = File.ReadAllLines("nevek.text");
            foreach (string fajlnev in fajlok)
            {
                string nev = fajlnev.Split(".")[0];
                string[,] kartya = new string[5, 5];
                string[] sorok = File.ReadAllLines(fajlnev);
                for (int i = 0; i < sorok.Length; i++)
                {
                    string[] szamok = sorok[i].Split(";");
                    for (int j = 0; j < szamok.Length; j++)
                    {
                        kartya[i, j] = szamok[j];
                    }
                }
                jatekosok.Add(new BingoJatekos(nev, kartya));
            }
            return jatekosok;
        }
        static void Huzas(List<BingoJatekos> jatekosok)
        {
            List<string> huzottSzamok = [];
            bool game = true;
            int counter = 1;
            do
            {
                string huzottSzam = random.Next(1, 76).ToString();
                if (!huzottSzamok.Contains(huzottSzam))
                {
                    Console.Write($"{counter}.->{huzottSzam}  ");
                    counter++;
                    huzottSzamok.Add(huzottSzam);
                    foreach (BingoJatekos jatekos in jatekosok)
                    {
                        jatekos.SorsoltSzamotJelol(huzottSzam);
                        if (jatekos.BingoEll())
                        {
                            game = false;
                        }
                    }
                }
            } while (game);
        }
    }
}
