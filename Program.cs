using System; 

class Program{
    static void Main(){
        Console.Write("Podaj liczbe krokow w jednej probie: ");
        int LiczbaKrokow = int.Parse(Console.ReadLine());
        Console.Write("Podaj liczbe prob do zasymulowania: ");
        int LiczbaProb = int.Parse(Console.ReadLine());
        Random random = new Random();
        int[] PozycjeKońcowe = new int[LiczbaKrokow];
        for(int i = 0; i < LiczbaProb; i++){
            int Pozycja = 0;
            int[] Kroki = new int[LiczbaKrokow];
            for(int j = 0; j < LiczbaKrokow; j++){
                int krok = random.Next(2) == 0 ? -1 : 1;
                Pozycja += krok;
                Kroki[j] = Pozycja;
            }
            PozycjeKońcowe[i] = Pozycja;
            Console.WriteLine($"Proba {i + 1}: {string.Join(", ", Kroki)}");
        }
        Console.WriteLine("\nPozycje koncowe po kazdej probie: ");
        Console.WriteLine(string.Join(", ", PozycjeKońcowe));
    }
}