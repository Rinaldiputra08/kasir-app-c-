using System;
using System.Collections.Generic;

class Minuman
{
    public string Nama { get; set; }
    public int Harga { get; set; }

    public Minuman(string nama, int harga)
    {
        Nama = nama;
        Harga = harga;
    }

    public virtual void TampilkanInfo()
    {
        Console.WriteLine($"{Nama} - Rp{Harga}");
    }
}

class Kopi : Minuman
{
    public string JenisKopi { get; set; }

    public Kopi(string nama, int harga, string jenisKopi)
        : base(nama, harga)
    {
        JenisKopi = jenisKopi;
    }

    public override void TampilkanInfo()
    {
        Console.WriteLine($"{Nama} ({JenisKopi}) - Rp{Harga}");
    }
}

class Pembeli
{
    public string Nama { get; set; }
    public List<Minuman> Pesanan { get; set; }

    public Pembeli(string nama)
    {
        Nama = nama;
        Pesanan = new List<Minuman>();
    }

    public void TambahPesanan(Minuman item)
    {
        Pesanan.Add(item);
    }

    public void TampilkanPesanan()
    {
        Console.WriteLine($"Pesanan {Nama}:");
        foreach (var item in Pesanan)
        {
            item.TampilkanInfo();
        }
    }

    public int HitungTotal()
    {
        int total = 0;
        foreach (var item in Pesanan)
        {
            total += item.Harga;
        }
        return total;
    }
}

class KasirApp
{
    static void Main()
    {
        Console.WriteLine("Selamat datang di KasirApp!");

        Console.Write("Masukkan nama pembeli: ");
        string namaPembeli = Console.ReadLine();

        Minuman[] menuMinuman = {
            new Kopi("Kopi Hitam", 10000, "Robusta"),
            new Kopi("Cappuccino", 15000, "Arabica"),
            new Kopi("Latte", 12000, "Arabica"),
            new Minuman("Espresso", 12000),
            new Minuman("Air Mineral", 5000)
        };

        Pembeli pembeli = new Pembeli(namaPembeli);

        Console.WriteLine("Menu Minuman:");
        for (int i = 0; i < menuMinuman.Length; i++)
        {
            Console.WriteLine($"{i + 1}. ");
            menuMinuman[i].TampilkanInfo();
        }

        int jumlahPesanan = 0;
        while (jumlahPesanan < 3)
        {
            Console.Write($"Pilih menu ke-{jumlahPesanan + 1} (0 untuk selesai): ");
            int pilihanMenu;
            while (!int.TryParse(Console.ReadLine(), out pilihanMenu) || pilihanMenu < 0 || pilihanMenu > menuMinuman.Length)
            {
                Console.WriteLine("Pilihan tidak valid. Harap masukkan nomor menu yang benar.");
                Console.Write($"Pilih menu ke-{jumlahPesanan + 1} (0 untuk selesai): ");
            }

            if (pilihanMenu == 0)
            {
                break;
            }

            pembeli.TambahPesanan(menuMinuman[pilihanMenu - 1]);
            jumlahPesanan++;
        }

        pembeli.TampilkanPesanan();
        Console.WriteLine($"Total pembelian: Rp{pembeli.HitungTotal()}");
    }
}
