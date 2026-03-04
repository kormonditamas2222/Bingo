namespace Bingo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BingoJatekos> jatekosok = Beolvasas();
            Console.WriteLine($"4. feladat: Játékosok száma: {jatekosok.Count}");
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
    }
}
