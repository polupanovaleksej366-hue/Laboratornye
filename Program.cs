using System;
using System.Collections.Generic;
using System.Linq;
using TextLab.Models;
using TextLab.Services;
namespace TextLab;
internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //ParserTest.Run();
        //Console.ReadKey();
        //return;
        var parser = new RegexTextParser();
        Text text = null;
        try
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА: ТОКЕНИЗАЦИЯ ТЕКСТА ===");
                if (text == null)
                {
                    Console.WriteLine("1. Загрузить текст из файла input.txt");
                    Console.WriteLine("0. Выход");
                    Console.Write("\nВыберите пункт: ");
                    string choice = Console.ReadLine();
                    if (choice == "0") break;
                    if (choice == "1")
                    {
                        text = parser.ParseFile("input.txt");
                        Console.WriteLine($"\nТекст загружен! Предложений: {text.Sentences.Count}");
                        Console.ReadKey();
                    }
                    continue;
                }
                Console.WriteLine("1. Перезагрузить текст");
                Console.WriteLine("2. Показать текст");
                Console.WriteLine("3. Пункт 1: По возрастанию количества слов");
                Console.WriteLine("4. Пункт 2: По возрастанию длины");
                Console.WriteLine("5. Пункт 3: Слова заданной длины в вопросах");
                Console.WriteLine("6. Пункт 4: Удалить слова на согласную");
                Console.WriteLine("7. Пункт 5: Заменить слова в предложении");
                Console.WriteLine("8. Пункт 6: Удалить стоп-слова");
                Console.WriteLine("9. Пункт 7: Экспорт в XML");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите пункт: ");
                string choice2 = Console.ReadLine();
                if (choice2 == "0") break;
                switch (choice2)
                {
                    case "1":
                        text = parser.ParseFile("input.txt");
                        Console.WriteLine($"\nТекст перезагружен! Предложений: {text.Sentences.Count}");
                        break;
                    case "2":
                        Console.WriteLine("\n" + text.Value);
                        break;
                    case "3":
                        Console.WriteLine("\nПо возрастанию количества слов:");
                        foreach (var s in text.OrderByWordCount())
                            Console.WriteLine($"  [{s.WordCount} сл.] {s.Value}");
                        break;
                    case "4":
                        Console.WriteLine("\nПо возрастанию длины:");
                        foreach (var s in text.OrderByLength())
                            Console.WriteLine($"  [{s.Length} симв.] {s.Value}");
                        break;
                    case "5":
                        Console.Write("Введите длину слова: ");
                        if (int.TryParse(Console.ReadLine(), out int len3))
                        {
                            var found = text.FindWordsInQuestions(len3).ToList();
                            if (found.Count == 0) Console.WriteLine("Слова не найдены.");
                            else foreach (var w in found) Console.WriteLine($"  {w.Value}");
                        }
                        break;
                    case "6":
                        Console.Write("Введите длину слова: ");
                        if (int.TryParse(Console.ReadLine(), out int len4))
                        {
                            text.RemoveConsonantWordsOfLength(len4);
                            Console.WriteLine("\nТекст после удаления:");
                            Console.WriteLine(text.Value);
                        }
                        break;
                    case "7":
                        Console.Write("Номер предложения: ");
                        int idx = int.Parse(Console.ReadLine());
                        Console.Write("Длина слова: ");
                        int len5 = int.Parse(Console.ReadLine());
                        Console.Write("Новое слово: ");
                        string repl = Console.ReadLine();
                        text.ReplaceInSentence(idx - 1, len5, repl);
                        Console.WriteLine("\nРезультат:");
                        Console.WriteLine(text.Sentences[idx - 1].Value);
                        break;
                    case "8":
                        var stopWords = new StopWordsProvider().Load("stopwords_ru.txt");
                        text.RemoveStopWords(stopWords);
                        Console.WriteLine("\nТекст после удаления стоп-слов:");
                        Console.WriteLine(text.Value);
                        break;
                    case "9":
                        TextXmlSerializer.Save(text, "output.xml");
                        Console.WriteLine("\nСохранено в output.xml");
                        break;
                }
                Console.WriteLine("\nНажмите клавишу для продолжения...");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n[ОШИБКА] " + ex.Message);
            Console.ReadKey();
        }
    }
}