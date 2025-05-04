using TextLib;

class Program
{
    static void Main()
    {
        var txt = new Text();
        txt.AddRow(new Row("  Hello,    world!  "));
        txt.AddRow(new Row("C#  is  awesome"));
        txt.AddRow(new Row("  Fly  high in  NAU   "));

        Console.WriteLine($"Shortest row: {txt.ShortestRowLength()}");
        Console.WriteLine($"Consonant % : {txt.ConsonantPercentage():F2}");

        string cleaned = txt.NormalizeSpaces(
            txt.Trim("  Hello,    world!  "));
        Console.WriteLine($"Cleaned: [{cleaned}]");
    }
}