using Dbits.Table;

internal class Program
{
    private static void Main(string[] args)
    {
        List<MyDataType> data = [
            new MyDataType{
                Age = 1, Color = "One",
            },
            new MyDataType{
                Age = 2, Color = "Two",
            },
            new MyDataType{
                Age = 3, Color = "Three",
            }
        ];

        var table = data.AsTable(options =>
        {
            options.HasHeader = true;
            options.BorderStyle = BorderStyle.Single;
        },
        x => x.Age,
        x => x.Color);

        var stringTable = table.ToUnicodeTable();

        Console.WriteLine(stringTable);
    }
}