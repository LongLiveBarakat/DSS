#nullable disable


int size, minSup;
string item;


Console.WriteLine("Input database size");
size = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Input Minimum Supply");
minSup = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Entry Database Records");
List<Record> database = new List<Record>();

for (int i = 0; i < size; i++)
{
    item = Console.ReadLine()!;
    string[] seperated = item.Split(',');

    Record record = new Record();
    record.FillList(seperated);
    database.Add(record);
}

var solved = AproriAlgorithm.Solve(minSup, database);


foreach (var key in solved.Keys)
    foreach (var k in key) Console.Write($"{k}, ");

Console.Write(solved.Values.First());

Console.ReadKey();