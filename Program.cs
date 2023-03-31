using net_ef_videogame;
using System.Diagnostics.Metrics;

using (VideoGameContext db = new VideoGameContext())
{
    SoftwareHouse nuovoSoftwareHouse = new SoftwareHouse
    {
        Name = "Vincenzo",
        TaxId = 1234123412,
        City = "New York",
        Country = "USA",
        Videogame = new List<Videogame>
       {
            new Videogame {Name = "god_of_war", Overview="lorem_ipsum", ReleaseDate=DateTime.Now},
            new Videogame { Name = "gta", Overview = "lorem_ipsum", ReleaseDate = DateTime.Now }
        }
    };
    SoftwareHouse nuovoSoftwareHouse2 = new SoftwareHouse
    {
        Name = "Mario",
        TaxId = 1234123412,
        City = "New York",
        Country = "USA",
        Videogame = new List<Videogame>
       {
            new Videogame {Name = "god_of_war", Overview="lorem_ipsum", ReleaseDate=DateTime.Now},
            new Videogame { Name = "gta", Overview = "lorem_ipsum", ReleaseDate = DateTime.Now }
        }
    };


    db.Add(nuovoSoftwareHouse);
    db.Add(nuovoSoftwareHouse2);

    db.SaveChanges();

    Console.WriteLine("Softwarehouse creata");

    Console.Write("Inserisci ID della SoftwareHouse: ");
    long softwareHouseId = long.Parse(Console.ReadLine());

    SoftwareHouse softwareHouse = db.SoftwareHouse.Find(softwareHouseId);

    if (softwareHouse == null)
    {
        Console.WriteLine("La SoftwareHouse non esiste!");
        return;
    }
    Console.WriteLine("Nome SoftwareHouse: " + softwareHouse.Name);

    Console.WriteLine($"Videogiochi prodotti da {softwareHouse.Name}:");
    foreach (Videogame videogame in  softwareHouse.Videogame)
    {
        Console.WriteLine(videogame.Name);
    }

}

