// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using WhatsNewInCsharpTen;

Console.WriteLine("Hello, World!");

#region Lambda iyileştirmeleri ve anonymous type'lar

Func<int, bool> isEven = (x) => x % 2 == 0;
var isOdd = (int x) => x % 2 == 1;
//List<int> list = new List<int>();
//list.Where(isEven);

object isOddObj = (int x) => x % 2 == 1;
Delegate isOddDelegate = (int x) => x % 2 == 1;

Func<int> read = Console.Read;
Action<string> write = Console.Write;

var readAnonym = Console.Read;
//var writeAnonym = Console.Write; !!! Çalışmaz!! Çünkü, birden fazla overlad'ı var.

var output = object (bool isSuccess) => isSuccess ? 1 : "Başarısız";


#endregion

#region Struct iyileştirmeleri

var comments = new string[2];
ProductRecord productRecord1 = new ProductRecord("Ürün 1", 250, new string[2]);
ProductRecord productRecord2 = new ProductRecord("Ürün 1", 250, new string[2]);

productRecord1.Comments[0] = "Tam bir f/p ürünü";
Console.WriteLine($" productRecord1 == productRecord2: {productRecord1 == productRecord2} ");
Console.WriteLine($" GetHashCode ile karşılaştırılıyor: {productRecord1.GetHashCode() == productRecord2.GetHashCode()} ");
Console.WriteLine($" ReferenceEquals: {ReferenceEquals(productRecord1, productRecord2)} ");

//productRecord1.Comments[0] = "Tam bir f/p ürünü";
Console.WriteLine("Ürün1'in yorumları");
productRecord1.Comments.ToList().ForEach(comment => Console.WriteLine($"{comment}"));
Console.WriteLine("Ürün2'in yorumları");

productRecord2.Comments.ToList().ForEach(comment => Console.WriteLine($" {comment}"));

Address address = new Address("Sümer mh.", "26140", "Eskişehir");

Address sample = new Address("Osmanağa mah.", "34001", "İstanbul");
List<Employee> employees = new List<Employee>()
{
     new(){ Address= new Address("Osmanağa mah.", "34001","İstanbul"), Name="Türkay"},
     new(){ Address= new Address("Atalar cad.", "34001","İstanbul"), Name="İsmail"},

};

var employee = employees.Where(e => e.Address == sample).First();
Console.WriteLine($"Bu adres, {employee.Name} isimli kişiye ait.");


#endregion

#region Property Pattern genişletildi


object anotherEmployee = new Employee
{
    Name = "Ferdi Kaya",
    Address = new Address("", "", "Ankara")
};

if (anotherEmployee is Employee { Address: { City: "Ankara" } })
{
    Console.WriteLine(((Employee)anotherEmployee).Name);
}

if (anotherEmployee is Employee { Address.City: "Ankara" })
{
    Console.WriteLine(((Employee)anotherEmployee).Name);

}

#endregion

#region Caller Expression Attribute
Console.WriteLine("Caller Expression Demo:");
void LogCondition(bool condition, [CallerArgumentExpression("condition")] string? message = null)
{
    Console.WriteLine($"Gönderilen koşul: {message} -> {condition}");
}

LogCondition(true);
int number = 8;
bool isSuccess = true;
LogCondition(number > 4);
LogCondition(number < 7);
LogCondition(isSuccess);

#endregion

#region Methodic exception handling
Console.WriteLine("Ex. Handle demo");

void checkAndUse(Employee employee)
{
    //if (employee is null)
    //{
    //    throw new ArgumentNullException();
    //}
    ArgumentNullException.ThrowIfNull(employee);

}
#endregion

#region Tuple ve deconstruction
Console.WriteLine("Tuple Demo");


Tuple<int, int> divide(int number, int divisor)
{
    var tuple = Tuple.Create<int, int>(number / divisor, divisor % divisor);
    return tuple;
}

var divideResult = divide(15, 2);
Console.WriteLine($"Bölüm sonucu: {divideResult.Item1}");

useTuple.divide(15, 3);

int a;
int b;

(a, b) = (0, 1);
(var q, var w) = (10, 5);
(b, var z) = (-3, 25);

(int, int) divideDcons(int number, int divisor)
{
    return (number / divisor, number % divisor);
}

var (sonuc, kalan) = divideDcons(15, 2);
Console.WriteLine($"Sonuç: {sonuc}, kalan: {kalan}");
#endregion