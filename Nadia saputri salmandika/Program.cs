using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadia_pesanan_makanan
{

}
class Program
{
    static void Main()
    {
        // Daftar menu makanan dan harga
        string[] makanan = { "Nasi Goreng", "Nasi Uduk", "Nasi Kucing", "Mie Rebus", "Mie Goreng", "Mie Ayam" };
        double[] hargaMakanan = { 12000, 9000, 6000, 7000, 8000, 13000 };

        // Daftar menu minuman dan harga
        string[] minuman = { "Teh Botol", "Teh Pucuk", "Susu Jahe", "Kopi Jahe", "Kopi Susu", "Tea Jus" };
        double[] hargaMinuman = { 5000, 4000, 3000, 3000, 5000, 0 }; // Tea Jus gratis

        double totalHarga = 0;

        bool lanjutPesan = true;

        // Proses pemesanan
        while (lanjutPesan)
        {
            // Menampilkan menu makanan
            Console.WriteLine("1. Makanan");
            for (int i = 0; i < makanan.Length; i++)
            {
                Console.WriteLine($"{(char)('a' + i)}. {makanan[i]} - Rp {hargaMakanan[i]:N0}");
            }

            // Menampilkan menu minuman
            Console.WriteLine("\n2. Minuman");
            for (int i = 0; i < minuman.Length; i++)
            {
                string hargaStr = hargaMinuman[i] == 0 ? "FREE" : $"Rp {hargaMinuman[i]:N0}";
                Console.WriteLine($"{(char)('a' + i)}. {minuman[i]} - {hargaStr}");
            }

            // Input pesanan
            Console.Write("\nPesanan = ");
            string pesanan = Console.ReadLine();

            // Validasi kode menu dan tipe pesanan (makanan atau minuman)
            char tipePesanan = pesanan[0]; // 1 atau 2
            char kodeMenu = pesanan[1]; // a, b, c, dst.

            // Konversi kodeMenu dari karakter ke indeks array
            int index = kodeMenu - 'a';

            // Mengambil harga berdasarkan tipe pesanan
            double harga = 0;
            string namaPesanan = "";

            if (tipePesanan == '1' && index >= 0 && index < makanan.Length)
            {
                // Jika memilih makanan
                harga = hargaMakanan[index];
                namaPesanan = makanan[index];
            }
            else if (tipePesanan == '2' && index >= 0 && index < minuman.Length)
            {
                // Jika memilih minuman
                harga = hargaMinuman[index];
                namaPesanan = minuman[index];
            }
            else
            {
                Console.WriteLine("Kode menu tidak valid.");
                continue;
            }

            // Input jumlah pesanan
            Console.Write("\nBerapa Banyak yang dipesan: ");
            int jumlah = int.Parse(Console.ReadLine());

            // Menghitung total harga untuk item ini
            double hargaPesanan = harga * jumlah;

            // Jika gratis, harga tetap 0
            if (harga == 0)
            {
                Console.WriteLine($"\nAnda memesan {jumlah} {namaPesanan} dan total harga adalah FREE");
            }
            else
            {
                Console.WriteLine($"\nAnda memesan {jumlah} {namaPesanan} dengan total harga Rp {hargaPesanan:N0}");
                totalHarga += hargaPesanan;
            }

            // Tanya apakah ingin memesan lagi
            Console.Write("\nApakah Anda ingin memesan lagi? (y/n): ");
            string lanjut = Console.ReadLine().ToLower();
            lanjutPesan = lanjut == "y";
        }

        // Menampilkan total harga semua pesanan
        Console.WriteLine($"\nTotal semua pesanan adalah Rp {totalHarga:N0} Thank you for buying in my store.");
        Console.ReadKey();
    }
}