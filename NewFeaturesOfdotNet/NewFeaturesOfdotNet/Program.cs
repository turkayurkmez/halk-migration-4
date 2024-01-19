// See https://aka.ms/new-console-template for more information

#region JsonSerializer IAsyncEnumerable interface'ini destekliyor 
using NewFeaturesOfdotNet;
using System.Text;
using System.Text.Json;

Console.WriteLine("JSonSeriallzer sınıfı, artık IAsyncEnumerable interface'ini destekliyor");

async IAsyncEnumerable<int> Show(int x)
{
    for (int i = 0; i < x; i++)
    {
        yield return i;
    }
}

using Stream stream = Console.OpenStandardOutput();
var data = new { ItemNo = Show(3) };
await JsonSerializer.SerializeAsync(stream, data);
Console.WriteLine();
Console.WriteLine(".....");
var readableStream = new MemoryStream(Encoding.UTF8.GetBytes("[1,2,3,4,5,6,7,8]"));
await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<int>(readableStream))
{
    Console.Write(item + " ");
}
#endregion
#region System.Linq çok güzel oldu :)

#region bir enumerable collection içerisindeki eleman sayısını bellekte enum etmeden sayabilirsiniz.
var collection = Enumerable.Range(0, 10);
List<int> numbers = collection.TryGetNonEnumeratedCount(out int count) ? new List<int>(capacity: count) :
                                                                         new List<int>();
Console.WriteLine();
Console.WriteLine("Yeni fonksiyon: TryGetNonEnumeratedCount -> enum'a çevirmeden say:");
Console.WriteLine($"Oluşan koleksiyon: {numbers.Capacity}");
#endregion

#region ...By Yeni Metotları
var countries = new CustomerService().GetCustomers().DistinctBy(x => x.Country);
countries.ToList().ForEach(c => Console.Write(c.Country + ", "));
Console.WriteLine();
Console.WriteLine("MaxBy ve MinBy");
var maxBudgetCustomer = new CustomerService().GetCustomers().MaxBy(x => x.Budget);
Console.WriteLine($"{maxBudgetCustomer.Name}: ${maxBudgetCustomer.Budget}");



#endregion

var chunks = collection.Chunk(size: 3);
foreach (var item in chunks)
{
    Console.WriteLine(string.Join(",", item));
}


#region Index ve Range objeleri geldi:
var lastSecond = collection.ElementAt(^2);
Console.WriteLine(lastSecond);

Console.WriteLine($"ilk üç eleman:{string.Join(",", collection.Take(..3))}");
Console.WriteLine($"4. elemandan sondan 2. elemana:{string.Join(",", collection.Take(4..^2))}");
Console.WriteLine($"son 4. elemandan son elemana:{string.Join(",", collection.Take(^4..))}");

var firstOrNegative = collection.FirstOrDefault(x => x > 5, -1);
Console.WriteLine($"sonuç: {firstOrNegative}");
var singleOrNegative = collection.SingleOrDefault(x => x == 12, -1);
Console.WriteLine($"sonuç: {singleOrNegative}");



#endregion   
#endregion

