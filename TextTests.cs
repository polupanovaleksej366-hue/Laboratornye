using ConcordanceLab.Models;
using ConcordanceLab.Services;
namespace ConcordanceLab;
public static class TextTests
{
    public static void RunAll()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== ЗАПУСК ТЕСТОВ ===\n");
        TestConcordance();
        Console.WriteLine("\n=== ТЕСТЫ ЗАВЕРШЕНЫ ===");
        Console.ReadKey();
    }
    private static void TestConcordance()
    {
        Console.WriteLine("--- ТЕСТ: Конкорданс ---");
        var parser = new RegexTextParser();
        string input =
            "Peter Piper picked a peck of pickled peppers. " +
            "A peck of pickled peppers Peter Piper picked. " +
            "If Peter Piper picked a peck of pickled peppers, " +
            "where is the peck that Peter Piper picked?";
        Text text = parser.Parse(input);
        var conc = text.BuildConcordance();
        Console.WriteLine($"Найдено предложений: {text.Sentences.Count} (ожидалось 3)");
        Console.WriteLine($"Уникальных слов: {conc.Count} (ожидалось 13)\n");
        bool allOk = true;
        void Check(string word, int expectedFreq, int[] expectedLines)
        {
            if (!conc.TryGetValue(word, out var info))
            {
                Console.WriteLine($"  [FAIL] Слово '{word}' вообще не найдено!");
                allOk = false;
                return;
            }
            bool freqOk = info.Frequency == expectedFreq;
            bool linesOk = info.LineNumbers.SetEquals(expectedLines);
            if (freqOk && linesOk)
            {
                Console.WriteLine($"  {word,-10} : {info.Frequency} [{string.Join(" ", info.LineNumbers)}]  -> OK");
            }
            else
            {
                allOk = false;
                string actual = $"{info.Frequency} [{string.Join(" ", info.LineNumbers)}]";
                string expected = $"{expectedFreq} [{string.Join(" ", expectedLines)}]";
                Console.WriteLine($"  {word,-10} : {actual}  -> FAIL (ожидалось {expected})");
            }
        }
        Check("a", 3, new[] { 1, 2, 3 });        
        Check("if", 1, new[] { 3 });             
        Check("is", 1, new[] { 3 });
        Check("of", 3, new[] { 1, 2, 3 });
        Check("peck", 4, new[] { 1, 2, 3 });
        Check("peppers", 3, new[] { 1, 2, 3 });
        Check("peter", 4, new[] { 1, 2, 3 });
        Check("picked", 4, new[] { 1, 2, 3 });
        Check("pickled", 3, new[] { 1, 2, 3 }); 
        Check("piper", 4, new[] { 1, 2, 3 });
        Check("that", 1, new[] { 3 });
        Check("the", 1, new[] { 3 });
        Check("where", 1, new[] { 3 });
        if (allOk)
            Console.WriteLine("\n[УСПЕХ] Все проверки конкорданса пройдены верно!");
        else
            Console.WriteLine("\n[ОШИБКА] В конкордансе есть расхождения!");
        Console.WriteLine("\nПолный вывод конкорданса:");
        text.PrintConcordance();
        Console.WriteLine();
    }
}