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
            Huzas(jatekosok, Beolvasas());
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
        static void Huzas(List<BingoJatekos> jatekosok1, List<BingoJatekos> jatekosok2)
        {
            List<string> huzottSzamok = [];
            List<string> nyertesNeve = [];
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
                    foreach (BingoJatekos jatekos in jatekosok1)
                    {
                        jatekos.SorsoltSzamotJelol(huzottSzam);
                        if (jatekos.BingoEll())
                        {
                            nyertesNeve.Add(jatekos.Nev);
                            game = false;
                        }
                    }
                }
            } while (game);
            Console.WriteLine("8. feladat: Lehetséges nyertesek: ");
            for (int i = 0; i < jatekosok2.Count; i++)
            {
                if (!nyertesNeve.Contains(jatekosok2[i].Nev))
                {
                    jatekosok2.Remove(jatekosok2[i]);
                    i--;
                }
            }
            foreach (BingoJatekos jatekos in jatekosok2)
            { 
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; i < 5; i++)
                    {
                        if (!huzottSzamok.Contains(jatekos.Kartya[i, j]) && jatekos.Kartya[i, j] != "X")
                        {
                            jatekos.Kartya[i, j] = "0";
                        }
                    }
                }
            }
            foreach (BingoJatekos jatekos in jatekosok2)
            {
                Console.WriteLine(jatekos.Nev);
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write($"{jatekos.Kartya[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
