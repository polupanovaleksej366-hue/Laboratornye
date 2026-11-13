using System.Globalization;
using Lab5.Constants;
using Lab5.Models;
namespace Lab5.IO;
public static class GiftFileReader
{
    public static List<Sweet> Read(string path)
    {
        var list = new List<Sweet>();
        foreach (var raw in File.ReadAllLines(path))
        {
            var line = raw.Trim();
            if (line.Length == 0)
                continue;
            var p = line.Split(AppConstants.FileDelimiter);
            var type = p[0].Trim();
            var name = p[1].Trim();
            var weight = double.Parse(p[2], CultureInfo.InvariantCulture);
            var sugar = double.Parse(p[3], CultureInfo.InvariantCulture);
            var extra = p[4].Trim();
            Sweet sweet = type switch
            {
                AppConstants.TypeChocolate => new Chocolate(name, weight, sugar, int.Parse(extra, CultureInfo.InvariantCulture)),
                AppConstants.TypeCandy => new Candy(name, weight, sugar, extra),
                AppConstants.TypeMarmalade => new Marmalade(name, weight, sugar, extra),
                _ => throw new InvalidDataException($"Unknown type: {type}")
            };
            list.Add(sweet);
        }
        return list;
    }
}