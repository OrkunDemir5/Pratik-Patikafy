using Pratik_Patikafy;

// Sanatçı listesini oluşturuyoruz
List<Artist> artists = new List<Artist>
{
    new Artist { Name = "Ajda Pekkan", Genre = "Pop", DebutYear = 1968, AlbumSales = 20000000 },
    new Artist { Name = "Sezen Aksu", Genre = "Türk Halk Müziği / Pop", DebutYear = 1971, AlbumSales = 10000000 },
    new Artist { Name = "Funda Arar", Genre = "Pop", DebutYear = 1999, AlbumSales = 3000000 },
    new Artist { Name = "Sertab Erener", Genre = "Pop", DebutYear = 1994, AlbumSales = 5000000 },
    new Artist { Name = "Sıla", Genre = "Pop", DebutYear = 2009, AlbumSales = 3000000 },
    new Artist { Name = "Serdar Ortaç", Genre = "Pop", DebutYear = 1994, AlbumSales = 10000000 },
    new Artist { Name = "Tarkan", Genre = "Pop", DebutYear = 1992, AlbumSales = 40000000 },
    new Artist { Name = "Hande Yener", Genre = "Pop", DebutYear = 1999, AlbumSales = 7000000 },
    new Artist { Name = "Hadise", Genre = "Pop", DebutYear = 2005, AlbumSales = 5000000 },
    new Artist { Name = "Gülben Ergen", Genre = "Pop / Türk Halk Müziği", DebutYear = 1997, AlbumSales = 10000000 },
    new Artist { Name = "Neşet Ertaş", Genre = "Türk Halk Müziği / Türk Sanat Müziği", DebutYear = 1960, AlbumSales = 2000000 }
};

// 1. Adı 'S' ile başlayan şarkıcılar
var singerWithS = artists.Where(a => a.Name.StartsWith("S")).ToList();
Console.WriteLine("Adı S ile başlayan şarkıcılar");
foreach (var singer in singerWithS)
{
    Console.WriteLine(singer.Name);
}

// 2. Albüm satışları 10 milyon'un üzerinde olan şarkıcılar
var highSalesSinger = artists.Where(a => a.AlbumSales > 10000000).ToList();
Console.WriteLine("\nAlbüm satışları 10 milyonun üzerinde olan şarkıcılar:");
foreach (var singer in highSalesSinger)
{
    Console.WriteLine(singer.Name + " " + singer.AlbumSales);
}

// 3. 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar (Çıkış yıllarına göre gruplanmış, alfabetik sırayla)
var oldPopSingers = artists
                    .Where(a => a.DebutYear < 2000 && a.Genre.Contains("Pop"))
                    //artan sırayla sıralama .OrderBy
                    .OrderBy(a => a.DebutYear)
                    //sıralaması aynı olan sanatçılar için ikinci bir sıralama kriteri ekler .ThenBy
                    .ThenBy(a => a.Name)
                    .ToList();
Console.WriteLine("\n2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar:");
foreach (var singer in oldPopSingers)
{
    Console.WriteLine(singer.Name + " " + singer.DebutYear);
}

// 4. En çok albüm satan şarkıcı
                              //Azalan sırayla .Order.ByDescending
var topSellingSinger = artists.OrderByDescending(a => a.AlbumSales).FirstOrDefault();
Console.WriteLine($"\nEn çok albüm satan şarkıcı: {topSellingSinger.Name} - {topSellingSinger.AlbumSales}");

// 5. En yeni ve en eski çıkış yapan şarkıcı                    
var newestSinger = artists.OrderByDescending (a => a.DebutYear).FirstOrDefault();
                                                    //Sıralanmış ilk öğeyi al .FirstOrDefault
var oldestSinger = artists.OrderBy(a => a.DebutYear).FirstOrDefault();
Console.WriteLine($"\nEn yeni çıkış yapan şarkıcı: {newestSinger.Name} - {newestSinger.DebutYear}");
Console.WriteLine($"En eski çıkış yapan şarkıcı: {oldestSinger.Name} - {oldestSinger.DebutYear}");