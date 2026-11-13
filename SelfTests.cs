using Lab5.Container;
using Lab5.Models;
namespace Lab5.Tests;
public static class SelfTests
{
    private static int _passed;
    private static int _failed;
    public static void RunAll()
    {
        _passed = 0;
        _failed = 0;
        Console.WriteLine("===== Запуск тестов =====");
        Test_Chocolate_Properties();
        Test_Candy_ToString();
        Test_Marmalade_InheritsSweet();
        Test_CompareTo_SortsBySugar();
        Test_Gift_Add();
        Test_Gift_TotalWeight();
        Test_Gift_TotalSugar();
        Test_Gift_SortBySugar();
        Test_Gift_FindInRange();
        Test_Gift_Find_Empty();
        Test_Gift_EmptyTotals();
        Console.WriteLine("=========================");
        Console.WriteLine($"Пройдено: {_passed}, Провалено: {_failed}");
    }
    private static void Check(string name, bool condition)
    {
        if (condition)
        {
            _passed++;
            Console.WriteLine($"[ OK ] {name}");
        }
        else
        {
            _failed++;
            Console.WriteLine($"[FAIL] {name}");
        }
    }
    private static void CheckEqual<T>(string name, T expected, T actual)
    {
        var ok = EqualityComparer<T>.Default.Equals(expected, actual);
        if (ok)
        {
            _passed++;
            Console.WriteLine($"[ OK ] {name}");
        }
        else
        {
            _failed++;
            Console.WriteLine($"[FAIL] {name}: expected={expected}, actual={actual}");
        }
    }
    private static Gift CreateSampleGift()
    {
        var gift = new Gift();
        gift.Add(new Chocolate("Milka", 100, 55, 40));
        gift.Add(new Candy("ChupaChups", 15, 12, "strawberry"));
        gift.Add(new Marmalade("Haribo", 60, 40, "bear"));
        return gift;
    }
    private static void Test_Chocolate_Properties()
    {
        var ch = new Chocolate("Milka", 100, 55, 40);
        Check("Chocolate.Name", ch.Name == "Milka");
        Check("Chocolate.Weight", ch.Weight == 100);
        Check("Chocolate.Sugar", ch.Sugar == 55);
        Check("Chocolate.CocoaPercent", ch.CocoaPercent == 40);
    }
    private static void Test_Candy_ToString()
    {
        var candy = new Candy("ChupaChups", 15, 12, "strawberry");
        var text = candy.ToString();
        Check("Candy.ToString содержит имя", text.Contains("ChupaChups"));
        Check("Candy.ToString содержит вкус", text.Contains("strawberry"));
    }
    private static void Test_Marmalade_InheritsSweet()
    {
        Sweet m = new Marmalade("Haribo", 60, 40, "bear");
        Check("Marmalade is Sweet", m is Marmalade);
        Check("Marmalade.Sugar", m.Sugar == 40);
    }
    private static void Test_CompareTo_SortsBySugar()
    {
        var a = new Candy("A", 10, 30, "x");
        var b = new Candy("B", 10, 10, "y");
        var c = new Candy("C", 10, 20, "z");
        var list = new List<Sweet> { a, b, c };
        list.Sort();
        Check("CompareTo сортирует по сахару",
            list[0].Name == "B" && list[1].Name == "C" && list[2].Name == "A");
    }
    private static void Test_Gift_Add()
    {
        var gift = new Gift();
        gift.Add(new Candy("A", 10, 5, "x"));
        gift.Add(new Candy("B", 20, 10, "y"));
        CheckEqual("Gift.Add увеличивает Items.Count", 2, gift.Items.Count);
    }
    private static void Test_Gift_TotalWeight()
    {
        var gift = CreateSampleGift();
        Check("Gift.TotalWeight == 175", gift.TotalWeight == 175);
    }
    private static void Test_Gift_TotalSugar()
    {
        var gift = CreateSampleGift();
        Check("Gift.TotalSugar == 107", gift.TotalSugar == 107);
    }
    private static void Test_Gift_SortBySugar()
    {
        var gift = CreateSampleGift();
        gift.Sort(Comparer<Sweet>.Create((a, b) => a.Sugar.CompareTo(b.Sugar)));
        var sugars = gift.Items.Select(s => s.Sugar).ToArray();
        Check("Gift.Sort по сахару",
            sugars.Length == 3 &&
            sugars[0] == 12 &&
            sugars[1] == 40 &&
            sugars[2] == 55);
    }
    private static void Test_Gift_FindInRange()
    {
        var gift = CreateSampleGift();
        var found = gift.Find(s => s.Sugar >= 30 && s.Sugar <= 50);
        CheckEqual("Gift.Find в диапазоне [30;50] даёт 1 элемент", 1, found.Count);
        Check("Gift.Find все попадают в диапазон",
            found.All(s => s.Sugar >= 30 && s.Sugar <= 50));
    }
    private static void Test_Gift_Find_Empty()
    {
        var gift = CreateSampleGift();
        var found = gift.Find(s => s.Sugar > 1000);
        Check("Gift.Find без совпадений возвращает пустой список", found.Count == 0);
    }
    private static void Test_Gift_EmptyTotals()
    {
        var gift = new Gift();
        Check("Пустой Gift.TotalWeight == 0", gift.TotalWeight == 0);
        Check("Пустой Gift.TotalSugar == 0", gift.TotalSugar == 0);
    }
}