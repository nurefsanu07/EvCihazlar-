using System;
using System.Collections.Generic;

enum CihazTurleri
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

class Cihaz
{
    private string kimlik;
    private string ad;
    private CihazTurleri tur;
    private bool acikMi;

    public Cihaz(string Kimlik, string Ad, CihazTurleri Tur)
    {
        kimlik = Kimlik;
        ad = Ad;
        tur = Tur;
        acikMi = false;
    }

    public Ac()
    {
        if (acikMi == false)
        {
            acikMi = true;
            Console.WriteLine($"{ad} açıldı.");
        }
        else
        {
            Console.WriteLine($"{ad} zaten açık.");
        }
    }

    public Kapat()
    {
        if (acikMi == true)
        {
            acikMi = false;
            Console.WriteLine($"{ad} kapatıldı");
        }
        else
        {
            Console.WriteLine($"{ad} zaten kapalı.");
        }
    }

    public BilgileriGoster()
    {
        Console.WriteLine($"Cihaz Kimliği: {kimlik}");
        Console.WriteLine($"Cihaz Adı: {ad}");
        Console.WriteLine($"Cihaz Türü: {tur}");
        Console.WriteLine($"Durum: {(acikMi ? "Açık" : "Kapalı")}");
    }
}

class Program
{
    static void Main()
    {
        List<Cihaz> cihazlar = new List<Cihaz>();

        while (true)
        {
            Console.WriteLine("1. Cihaz Ekle");
            Console.WriteLine("2. Cihaz Aç");
            Console.WriteLine("3. Cihaz Kapat");
            Console.WriteLine("4. Cihaz Bilgilerini Göster");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            int secim = Console.ReadLine();

            switch (secim)
            {
                case 1:
                    Console.Write("Cihaz Kimliği: ");
                    string kimlik = Console.ReadLine();
                    foreach (var cihaz in cihazlar)
                    {
                        if (cihaz.Kimlik == kimlik)
                        {
                            throw new InvalidOperationException("İki cihaz aynı kimliğe sahip olamaz.");
                        }
                    }
                    Console.Write("Cihaz Adı: ");
                    string ad = Console.ReadLine();
                    Console.WriteLine("Cihaz Türü (0: Lamba, 1: Klima, 2: GuvenlikSistemi): ");
                    int turSecim = Convert.ToInt32(Console.ReadLine());
                    CihazTurleri tur = (CihazTurleri)turSecim;

                    Cihaz yeniCihaz = new Cihaz(kimlik, ad, tur);
                    cihazlar.Add(yeniCihaz);
                    Console.WriteLine("Cihaz eklendi.");
                    break;
                case 2:
                    Console.Write("Açmak istediğiniz cihazın kimliğini girin: ");
                    string acilacakKimlik = Console.ReadLine();
                    foreach (var cihaz in cihazlar)
                    {
                        if (cihaz.Kimlik == acilacakKimlik)
                        {
                            cihaz.Ac();
                            Console.WriteLine("Cihaz açıldı.");
                            break;
                        }
                    }
                    break;
                case 3:
                    Console.Write("Kapatmak istediğiniz cihazın kimliğini girin: ");
                    string kapatilacakKimlik = Console.ReadLine();
                    foreach (var cihaz in cihazlar)
                    {
                        if (cihaz.Kimlik == kapatilacakKimlik)
                        {
                            cihaz.Kapat();
                            Console.WriteLine("Cihaz kapatıldı.");
                            break;
                        }
                    }
                    break;
                case 4:
                    int index = 1;
                    foreach (var cihaz in cihazlar)
                    {
                        Console.WriteLine($"Cihaz {index}:");
                        cihaz.BilgileriGoster();
                        index++;
                    }
                    break;
                case 5:
                    return;
                  

            }
        }
    }
}