using System.Globalization;
using Lab5.Constants;
using Lab5.Container;
using Lab5.IO;
using Lab5.Models;
using Lab5.Tests;
var gift = new Gift();
var dataPath = Path.Combine(AppContext.BaseDirectory, AppConstants.DataFileName);
foreach (var s in GiftFileReader.Read(dataPath))
    gift.Add(s);
bool run = true;
while (run)
{
    Console.WriteLine("""
        ===== Gift Builder =====
        1. Показать подарок
        2. Общий вес и сахар
        3. Сортировать по сахару
        4. Найти по диапазону сахара
        5. Запустить тесты
        0. Выход
        """);
    Console.Write("> ");
    var cmd = Console.ReadLine()?.Trim();
    switch (cmd)
    {
        case "1":
            gift.PrintAll();
            break;
        case "2":
            Console.WriteLine($"Общий вес:  {gift.TotalWeight:F1} g");
            Console.WriteLine($"Общий сахар:{gift.TotalSugar:F1} g");
            break;
        case "3":
            gift.Sort(Comparer<Sweet>.Create((a, b) => a.Sugar.CompareTo(b.Sugar)));
            Console.WriteLine("Отсортировано по сахару:");
            gift.PrintAll();
            break;
        case "4":
            Console.Write("min sugar: ");
            var min = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            Console.Write("max sugar: ");
            var max = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            var found = gift.Find(s => s.Sugar >= min && s.Sugar <= max);
            if (found.Count == 0)
                Console.WriteLine("Ничего не найдено.");
            else
                foreach (var s in found) Console.WriteLine(s);
            break;
        case "5":
            SelfTests.RunAll();
            break;
        case "0":
            run = false;
            break;
        default:
            Console.WriteLine("Неизвестная команда.");
            break;
    }
}
Console.WriteLine("Готово.");