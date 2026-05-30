class FoodItem:
    def __init__(self, nazwaProduktu, liczbaKalorii):
        self.nazwa = nazwaProduktu
        self.kalorie = liczbaKalorii


class Meal:
    def __init__(self, nazwaPosilku):
        self.nazwa = nazwaPosilku
        self.listaProduktow = []

    def dodajProdukt(self, produkt):
        self.listaProduktow.append(produkt)

    def policzKalorie(self):
        suma = 0
        for produkt in self.listaProduktow:
            suma += produkt.kalorie
        return suma


class DailyIntake:
    def __init__(self):
        self.listaPosilkow = []

    def dodajPosilek(self, posilek):
        self.listaPosilkow.append(posilek)

    def policzCalkowiteKalorie(self):
        suma = 0
        for posilek in self.listaPosilkow:
            suma += posilek.policzKalorie()
        return suma


def main():
    produkty = []
    dzien = DailyIntake()

    while True:
        print("\n" + "=" * 40)
        print(" Kamil Chojnacki nr albumu 68261")
        print("=" * 40)

        print("\n ** Kalkulator kalorii **")
        print("1. Dodaj produkt")
        print("2. Stworz posilek z produktow")
        print("3. Pokaz calkowite kalorie dnia")
        print("4. Wyjscie")

        wybor = int(input("\n--> "))

        if wybor == 1:
            print("\n--- Dodawanie produktow ---")

            ileProduktow = int(input(" Ile produktow chcesz dodac: "))

            for i in range(ileProduktow):
                nazwa = input("\n Podaj nazwe produktu: ")
                kalorie = float(input(" Podaj ilosc kalorii: "))

                produkty.append(FoodItem(nazwa, kalorie))
                print(" Pomyœlnie dodano produkt")

        elif wybor == 2:
            print("\n--- Tworzenie posilkow ---")

            if len(produkty) == 0:
                print(" Brak produktow!")
                input("\n Enter...")
                continue

            ilePosilkow = int(input(" Ile posilkow chcesz dodac: "))

            for p in range(ilePosilkow):
                print("\n Nowy posilek")
                nazwaPosilku = input(" Podaj nazwe posilku: ")

                nowyPosilek = Meal(nazwaPosilku)

                while True:
                    print("\n Dostepne produkty:")
                    for i in range(len(produkty)):
                        print(f" {i}. {produkty[i].nazwa} ({produkty[i].kalorie} kcal)")

                    index = int(input("\n Podaj numer produktu: "))

                    if 0 <= index < len(produkty):
                        nowyPosilek.dodajProdukt(produkty[index])

                        print("\n Pomyœlnie dodano produkt ")

                        print(" Aktualne produkty w posilku:")
                        for f in nowyPosilek.listaProduktow:
                            print(f" - {f.nazwa} ({f.kalorie} kcal)")
                    else:
                        print(" Bledny numer!")

                    decyzja = input("\n Dodac kolejny produkt? (Wpisz t lub n): ")

                    if decyzja.lower() != "t":
                        break

                dzien.dodajPosilek(nowyPosilek)
                print(f"\n Dodano posilek: {nowyPosilek.nazwa} ({nowyPosilek.policzKalorie()} kcal)")

        elif wybor == 3:
            print("\n--- Podsumowanie dnia ---")

            if len(dzien.listaPosilkow) == 0:
                print(" Brak posilkow!")
            else:
                for posilek in dzien.listaPosilkow:
                    print(f"- {posilek.nazwa} -> {posilek.policzKalorie()} kcal")

                print("\n----------------------------")
                print(f" Calkowite kalorie: {dzien.policzCalkowiteKalorie()} kcal")

        elif wybor == 4:
            break

        else:
            print(" Podaj liczbe 1-4")

        input("\n Wcisnij Enter aby kontynuowac...")


if __name__ == "__main__":
    main()