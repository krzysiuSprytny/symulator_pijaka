using System; 

class Program{
    static void Main(){
        Console.Write("Podaj liczbe krokow w jednej probie: ");
        int LiczbaKrokow = int.Parse(Console.ReadLine());
        Console.Write("Podaj liczbe prob do zasymulowania: ");
        int LiczbaProb = int.Parse(Console.ReadLine());
        Random random = new Random();
        int[] PozycjeKońcowe = new int[LiczbaKrokow];
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
    }
}