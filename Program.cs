using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static LinkedList<int> liste = new LinkedList<int>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            YazdirListe();
            Console.WriteLine("\n1- Başa ekle");
            Console.WriteLine("2- Sona ekle");
            Console.WriteLine("3- Belirli indise ekle");
            Console.WriteLine("4- Baştan sil");
            Console.WriteLine("5- Sondan sil");
            Console.WriteLine("6- Belirli indisi sil");
            Console.WriteLine("7- Tersten yazdır");
            Console.WriteLine("0- Programı kapat");
            Console.Write("Seçiminiz: ");

            if (!int.TryParse(Console.ReadLine(), out int secim))
            {
                Console.WriteLine("Geçersiz giriş! Bir sayı girin.");
                Console.ReadKey();
                continue;
            }

            switch (secim)
            {
                case 1: BasaEkle(); break;
                case 2: SonaEkle(); break;
                case 3: IndiseEkle(); break;
                case 4: BastanSil(); break;
                case 5: SondanSil(); break;
                case 6: IndistenSil(); break;
                case 7: TerstenYazdir(); break;
                case 0: return;
                default: Console.WriteLine("Geçersiz seçim!"); break;
            }

            Console.ReadKey();
        }
    }

    static void YazdirListe()
    {
        Console.Write("Liste: ");
        int index = 0;
        foreach (var item in liste)
        {
            Console.Write($"[{index}] {item} -> ");
            index++;
        }
        Console.WriteLine("son.");
    }

    static void BasaEkle()
    {
        Console.Write("Başa eklenecek sayıyı girin: ");
        if (int.TryParse(Console.ReadLine(), out int sayi))
        {
            liste.AddFirst(sayi);
        }
    }

    static void SonaEkle()
    {
        Console.Write("Sona eklenecek sayıyı girin: ");
        if (int.TryParse(Console.ReadLine(), out int sayi))
        {
            liste.AddLast(sayi);
        }
    }

    static void IndiseEkle()
    {
        Console.Write("Eklemek istediğiniz sayıyı girin: ");
        if (int.TryParse(Console.ReadLine(), out int sayi))
        {
            Console.Write("Hangi indekse eklemek istersiniz? ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index <= liste.Count)
            {
                var node = liste.First;
                for (int i = 0; i < index && node != null; i++)
                {
                    node = node.Next;
                }

                if (node != null)
                    liste.AddBefore(node, sayi);
                else
                    liste.AddLast(sayi);
            }
            else
            {
                Console.WriteLine("Geçersiz indeks!");
            }
        }
    }

    static void BastanSil()
    {
        if (liste.Count > 0)
        {
            liste.RemoveFirst();
            Console.WriteLine("Baştaki eleman silindi.");
        }
        else
        {
            Console.WriteLine("Liste boş!");
        }
    }

    static void SondanSil()
    {
        if (liste.Count > 0)
        {
            liste.RemoveLast();
            Console.WriteLine("Sondaki eleman silindi.");
        }
        else
        {
            Console.WriteLine("Liste boş!");
        }
    }

    static void IndistenSil()
    {
        Console.Write("Silmek istediğiniz elemanın indeksini girin: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < liste.Count)
        {
            var node = liste.First;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            liste.Remove(node);
            Console.WriteLine($"[{index}] indeksindeki eleman silindi.");
        }
        else
        {
            Console.WriteLine("Geçersiz indeks!");
        }
    }

    static void TerstenYazdir()
    {
        Console.Write("Ters Liste: ");
        var reversedList = liste.Reverse().ToList();
        for (int i = 0; i < reversedList.Count; i++)
        {
            Console.Write($"[{reversedList.Count - 1 - i}] {reversedList[i]} -> ");
        }
        Console.WriteLine("son.");
    }
}