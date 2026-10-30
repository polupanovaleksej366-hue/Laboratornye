using System;
using System.Linq;
using TextLab.Models;
using TextLab.Services;
namespace TextLab;
public class ParserTest
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string source =
            "Объектно-ориентированное программирование (ООП) — это методология программирования, " +
            "основанная на представлении программы в виде совокупности объектов. " +
            "Каждый объект является экземпляром определённого класса. " +
            "А что такое класс? Класс — это шаблон, описывающий поведение и состояние объектов. " +
            "Знаете ли вы, что такое инкапсуляция? " +
            "Инкапсуляция скрывает внутреннее состояние объекта и предоставляет методы для работы с ним! " +
            "Наследование позволяет создавать новые классы на основе существующих, " +
            "а полиморфизм — изменять поведение методов базового класса.";
        Console.WriteLine("=== ТЕСТ ПАРСЕРА  ===");
        Console.WriteLine("Исходный текст:\n" + source);
        Console.WriteLine("\n--------------------------------------------------\n");
        var parser = new RegexTextParser();
        var text = parser.Parse(source);
        Console.WriteLine($"Всего предложений: {text.Sentences.Count}\n");
        int i = 1;
        foreach (var s in text.Sentences)
        {
            var words = string.Join(" ", s.Words.Select(w => w.Value));
            var puncts = string.Join(" ", s.Punctuations.Select(p => p.Value));
            Console.WriteLine($"[{i}] \"{s.Value}\"");
            Console.WriteLine($"    Слов: {s.WordCount}");
            Console.WriteLine($"    Слова: {words}");
            Console.WriteLine($"    Знаки: {puncts}");
            Console.WriteLine($"    Вопрос: {(s.IsQuestion ? "Да" : "Нет")}");
            Console.WriteLine();
            i++;
        }
    }
}