using Course;
using System.Text;

List<Resztvevok> resztvevoks = new List<Resztvevok>();

using (StreamReader sr = new StreamReader(@"..\..\..\src\course.txt", Encoding.UTF8))
{
    while (!sr.EndOfStream)
    {
        resztvevoks.Add(new Resztvevok(sr.ReadLine()));
    }


    Console.WriteLine($"A file {resztvevoks.Count()} adatot tartalmaz.");

    Console.WriteLine($"A hallgatók átlaga backend modulból {resztvevoks.Average(x => x.Eredmenyek[3])}");

    //3. feladat

    var f3 = resztvevoks.OrderByDescending(x => x.Eredmenyek.Sum()).First();
    Console.WriteLine($"Az osztályelső: {f3.Nev}");


   //4. feladat
    int ferfiakSzama = 0;
    int nokSzama = 0;

    foreach (var resztvevo in resztvevoks)
    {
        if (resztvevo.Nem == "Férfi")
        {
            ferfiakSzama++;
        }
        else if (resztvevo.Nem == "Nő")
        {
            nokSzama++;
        }
    }

    double f4 = (double)ferfiakSzama / (ferfiakSzama + nokSzama) * 100;

    Console.WriteLine($"A férfiak aránya a képzésen: {f4}%");

    //5. feladat
    
    var f5 = resztvevoks
        .Where(x => x.Nem == "Nő")
        .OrderByDescending(x => x.Eredmenyek[2] + x.Eredmenyek[3])
        .First();

    Console.WriteLine($"A legjobb webfejlesztésből: {f5.Nev}");

    //6. feladat
    var f6 = resztvevoks.Where(x => x.Befizetes >= 2600).ToList();
    Console.Write($"A 2600 Ft-nál többet befizetők száma: ");
    foreach (var item in f6)
    {
        Console.Write($"{item.Nev}, ");
    }
    Console.WriteLine();
    //7. feladat
    Console.Write("Adjon meg egy nevet: ");
    string name = Console.ReadLine().ToLower();

    var f7 = resztvevoks.Where(x => x.Nev.ToLower() == name).FirstOrDefault();
    if ( f7 != null)
    {
        foreach (var item in f7.Eredmenyek)
        {
            if (item < 51)
            {
                Console.WriteLine($"Javítóvizsgát kell tennie!");
            }
            else
            {
                Console.WriteLine($"Nem kell javítóviszgát tennie!");
            }
        }
    }
    else
    {
        Console.WriteLine("Nincs ilyen hallgató!");
    }

    //8. feladat
    var f8 = resztvevoks.Where(x => x.Eredmenyek.Any(e => e == 100) && x.Eredmenyek.All(e => e >= 51)).Count();
    Console.WriteLine($"Azon hallgatók száma, akik legalább egy modulból 100%-ot teljesítettek és egyik modulból sem kell javítóvizsgát tenniük: {f8}");

    //9. feladat
    for (int i = 0; i < resztvevoks[0].Eredmenyek.Count(); i++)
    {
        int javitoVizsgaSzam = resztvevoks.Count(x => x.Eredmenyek[i] < 51);
        Console.WriteLine($"A(z) {i + 1}. modulból {javitoVizsgaSzam} tanulónak kell javítóvizsgát tennie.");
    }

    //10. feladat
    var hallgatok = resztvevoks.OrderBy(x => x.Nev.Split(' ')[1]).ToList();

    using (StreamWriter sw = new StreamWriter(@"..\..\..\src\hallgatok.txt"))
    {
        foreach (var resztvevo in hallgatok)
        {
            sw.WriteLine($"{resztvevo.Nev}: {resztvevo.Eredmenyek.Average()}");
        }
    }



}