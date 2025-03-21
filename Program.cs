using System; 
using System.Collections.Generic;
using System.Linq;

class Program{
    static void Main(){
        Console.Write("Podaj liczbe krokow w jednej probie: ");
        int LiczbaKrokow = int.Parse(Console.ReadLine());
        Console.Write("Podaj liczbe prob do zasymulowania: ");
        int LiczbaProb = int.Parse(Console.ReadLine());
        Random random = new Random();
        int[] PozycjeKońcowe = new int[LiczbaProb];
        Dictionary<int, int> Statystyki = new Dictionary<int, int>();

        for(int i = 0; i < LiczbaProb; i++){
            int Pozycja = 0;
            int[] Kroki = new int[LiczbaKrokow];

            for(int j = 0; j < LiczbaKrokow; j++){
                int krok = random.Next(2) == 0 ? -1 : 1;
                Pozycja += krok;
                Kroki[j] = Pozycja;
            }

            PozycjeKońcowe[i] = Pozycja;
            if(Statystyki.ContainsKey(Pozycja))Statystyki[Pozycja]++;
            else Statystyki[Pozycja] = 1;
            Console.WriteLine($"Proba {i + 1}: {string.Join(", ", Kroki)}");
        }

        Console.WriteLine("\nPozycje koncowe po kazdej probie: ");
        Console.WriteLine(string.Join(", ", PozycjeKońcowe));
        Console.WriteLine("\nPodsumowanie wystapien poszczegolnych pozycji koncowych: ");
        foreach (var kvp in Statystyki){
            Console.WriteLine($"Pozycja {kvp.Key}: {kvp.Value} razy");
        }

        Console.WriteLine("\nStatystyki i wykres:");
        int wszystkieProby = LiczbaProb;
        int minPoz = Statystyki.Keys.Min();
        int maxPoz = Statystyki.Keys.Max();

        for (int i = minPoz; i <= maxPoz; i++)
        {
            if (Statystyki.ContainsKey(i))
            {
                int licz = Statystyki[i];
                double procent = (double)licz / wszystkieProby * 100;
                int dlugosc = (int)(procent / 2); // Szerokość wykresu w "kreskach"
                Console.WriteLine($"{i}: {licz} ({procent:F2}%) = {new string('|', dlugosc)}");
            }
            else
            {
                Console.WriteLine($"{i}: 0 (0%)");
            }
        }   
    }
}