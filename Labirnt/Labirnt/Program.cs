using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static char[,] labirynt;
    static int iloscWierszy, iloscKolumn;

    static void Main()
    {
        Console.WriteLine("Podaj ilość wierszy:");
        iloscWierszy = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Podaj ilość kolumn:");
        iloscKolumn = Convert.ToInt32(Console.ReadLine());

        InicjalizujLabirynt();

        while (true)
        {
            WyswietlLabirynt();

            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Modyfikuj element");
            Console.WriteLine("2. Zapisz labirynt");
            Console.WriteLine("3. Wczytaj labirynt");
            Console.WriteLine("4. Wyjście");

            int wybor = Convert.ToInt32(Console.ReadLine());

            switch (wybor)
            {
                case 1:
                    ModyfikujElement();
                    break;
                case 2:
                    ZapiszLabirynt();
                    break;
                case 3:
                    OdczytajLabirynt();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }
        }
    }

    static void InicjalizujLabirynt()
    {
        labirynt = new char[iloscWierszy, iloscKolumn];

        for (int i = 0; i < iloscWierszy; i++)
        {
            for (int j = 0; j < iloscKolumn; j++)
            {
                labirynt[i, j] = '?';
            }
        }
    }

    static void WyswietlLabirynt()
    {
        Console.Clear();

        for (int i = 0; i < iloscWierszy; i++)
        {
            for (int j = 0; j < iloscKolumn; j++)
            {
                Console.Write(labirynt[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void ModyfikujElement()
    {
        Console.WriteLine("Podaj wiersz:");
        int wiersz = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Podaj kolumnę:");
        int kolumna = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Wybierz stan:");
        Console.WriteLine("1. Brak");
        Console.WriteLine("2. Ściana");
        Console.WriteLine("3. Ścieżka");

        int stan = Convert.ToInt32(Console.ReadLine());

        switch (stan)
        {
            case 1:
                labirynt[wiersz, kolumna] = '.';
                break;
            case 2:
                labirynt[wiersz, kolumna] = '#';
                break;
            case 3:
                labirynt[wiersz, kolumna] = ' ';
                break;
            default:
                Console.WriteLine("Nieprawidłowy stan.");
                break;
        }
    }

    static void ZapiszLabirynt()
    {
        using (StreamWriter sw = new StreamWriter("labirynt.txt"))
        {
            sw.WriteLine(iloscWierszy);
            sw.WriteLine(iloscKolumn);

            for (int i = 0; i < iloscWierszy; i++)
            {
                for (int j = 0; j < iloscKolumn; j++)
                {
                    sw.Write(labirynt[i, j]);
                }
                sw.WriteLine();
            }
        }

        Console.WriteLine("Labirynt został zapisany do pliku.");
    }

    static void OdczytajLabirynt()
    {
        try
        {
            using (StreamReader sr = new StreamReader("labirynt.txt"))
            {
                iloscWierszy = Convert.ToInt32(sr.ReadLine());
                iloscKolumn = Convert.ToInt32(sr.ReadLine());

                InicjalizujLabirynt();

                for (int i = 0; i < iloscWierszy; i++)
                {
                    string linia = sr.ReadLine();
                    for (int j = 0; j < iloscKolumn; j++)
                    {
                        labirynt[i, j] = linia[j];
                    }
                }
            }

            Console.WriteLine("Labirynt został wczytany z pliku.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik z labiryntem nie istnieje.");
        }
    }
}
