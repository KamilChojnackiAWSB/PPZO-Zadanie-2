using System;

// Kalkulator kalorii – klasy FoodItem, Meal, DailyIntake; dodawanie produktów do posiłków i liczenie całkowitego spożycia kalorii.

class FoodItem
{
    public string nazwa;
    public double kalorie;

    public FoodItem(string nazwaProduktu, double liczbaKalorii)
    {
        nazwa = nazwaProduktu;
        kalorie = liczbaKalorii;
    }
}

class Meal
{
    public string nazwa;
    public List<FoodItem> listaProduktow;

    public Meal(string nazwaPosilku)
    {
        nazwa = nazwaPosilku;
        listaProduktow = new List<FoodItem>();
    }

    public void dodajProdukt(FoodItem produkt)
    {
        listaProduktow.Add(produkt);
    }

    public double policzKalorie()
    {
        double suma = 0;

        foreach (FoodItem produkt in listaProduktow)
        {
            suma += produkt.kalorie;
        }

        return suma;
    }
}

class DailyIntake
{
    public List<Meal> listaPosilkow;

    public DailyIntake()
    {
        listaPosilkow = new List<Meal>();
    }

    public void dodajPosilek(Meal posilek)
    {
        listaPosilkow.Add(posilek);
    }

    public double policzCalkowiteKalorie()
    {
        double suma = 0;

        foreach (Meal posilek in listaPosilkow)
        {
            suma += posilek.policzKalorie();
        }

        return suma;
    }
}

class Program
    {
        static void Main()
        {
            List<FoodItem> produkty = new List<FoodItem>();
            DailyIntake dzien = new DailyIntake();

            while (true)
            {
                Console.Clear();

                Console.WriteLine(" Kamil Chojnacki nr albumu 68261 \n");

                Console.WriteLine(" ** Kalkulator kalorii **\n");
                Console.WriteLine(" Wybierz z listy: ");
                Console.WriteLine("1. Dodaj produkt");
                Console.WriteLine("2. Stwórz posiłek z produktów");
                Console.WriteLine("3. Pokaż całkowite kalorie dnia");
                Console.WriteLine("4. Wyjście");

                Console.Write("--> ");
                int wybor = int.Parse(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        {
                            Console.Clear();

                            Console.Write(" Ile produktów chcesz dodać: ");
                            int ileProduktow = int.Parse(Console.ReadLine());

                            for (int i = 0; i < ileProduktow; i++)
                            {
                                Console.Write("\n Podaj nazwę produktu: ");
                                string nazwa = Console.ReadLine();

                                Console.Write(" Podaj ilość kalorii: ");
                                double kalorie = double.Parse(Console.ReadLine());

                                produkty.Add(new FoodItem(nazwa, kalorie));

                                Console.WriteLine("\n Pomyślnie dodano produkt");
                            }

                            Console.WriteLine("\n Wciśnij dowolny klawisz aby kontynuować ...");
                            Console.ReadKey();
                            break;
                        }

                case 2:
                    {
                        Console.Clear();

                        if (produkty.Count == 0)
                        {
                            Console.WriteLine(" Brak produktów!");
                            Console.WriteLine("\n Wciśnij dowolny klawisz aby kontynuować ...");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("Ile posiłków chcesz dodać: ");
                        int ilePosilkow = int.Parse(Console.ReadLine());

                        for (int p = 0; p < ilePosilkow; p++)
                        {
                            Console.Clear();
                            Console.Write(" Podaj nazwę posiłku: ");
                            string nazwaPosilku = Console.ReadLine();

                            Meal nowyPosilek = new Meal(nazwaPosilku);

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine(" Aktualnie tworzysz " + nowyPosilek.nazwa);

                                Console.WriteLine("\n Dostępne produkty:");
                                for (int i = 0; i < produkty.Count; i++)
                                {
                                    Console.WriteLine(" " + i + ". " + produkty[i].nazwa + " (" + produkty[i].kalorie + " kcal)");
                                }

                                Console.Write("\n Podaj numer produktu: ");
                                int index = int.Parse(Console.ReadLine());

                                if (index == 100)
                                    break;

                                if (index >= 0 && index < produkty.Count)
                                {
                                    nowyPosilek.dodajProdukt(produkty[index]);

                                    Console.WriteLine("\n Dodano produkt!");

                                    Console.WriteLine("\n Aktualne produkty w posiłku:");
                                    foreach (FoodItem f in nowyPosilek.listaProduktow)
                                    {
                                        Console.WriteLine("- " + f.nazwa + " (" + f.kalorie + " kcal)");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(" Błędny numer!");
                                    Console.ReadKey();
                                }

                                Console.Write("\n Czy chcesz dodać kolejny produkt? (Wpisz t lub n): ");
                                string decyzja = Console.ReadLine();

                                if (decyzja.ToLower() != "t")
                                    break;

                            }

                            dzien.dodajPosilek(nowyPosilek);
                            Console.WriteLine("\n Dodano posiłek: " + nowyPosilek.nazwa + " (" + nowyPosilek.policzKalorie() + " kcal)");

                            Console.WriteLine("\n Wciśnij klawisz aby przejść dalej...");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 3:
                    {
                        Console.Clear();

                        if (dzien.listaPosilkow.Count == 0)
                        {
                            Console.WriteLine(" Brak posiłków!");
                        }
                        else
                        {
                            Console.WriteLine(" Podsumowanie dnia:\n");

                            foreach (Meal posilek in dzien.listaPosilkow)
                            {
                                Console.WriteLine("- " + posilek.nazwa + " -> "
                                    + posilek.policzKalorie() + " kcal");
                            }

                            Console.WriteLine("\n----------------------------");
                            Console.WriteLine(" Całkowite kalorie dnia: "
                                + dzien.policzCalkowiteKalorie() + " kcal");
                        }

                        Console.WriteLine("\n Wcisnij dowolny klawisz aby kontynuować ...");
                        Console.ReadKey();
                        break;
                    }

                case 4:
                    return;

                default:
                    {
                        Console.WriteLine(" Podaj liczbe od 1 do 4");
                        break;
                    }
                }
            }
        }
    }
