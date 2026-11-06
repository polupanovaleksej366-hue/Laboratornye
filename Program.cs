using ConcordanceLab.Models;
using ConcordanceLab.Services;
namespace ConcordanceLab;
internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var parser = new RegexTextParser();
        Text? text = null;
        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА 4: КОНКОРДАНС ===");
                if (text == null)
                {
                    Console.WriteLine("1. Загрузить текст из файла input.txt");
                    Console.WriteLine("2. Ввести текст вручную");
                    Console.WriteLine("5. Запустить тест конкорданса");
                    Console.WriteLine("0. Выход");
                    Console.Write("\nВыберите пункт: ");
                    string? choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "0":
                            return;
                        case "1":
                            text = LoadFromFile(parser);
                            break;
                        case "2":
                            text = LoadFromConsole(parser);
                            break;
                        case "5":
                            TextTests.RunAll();
                            break;
                        default:
                            Console.WriteLine("\nНеизвестный пункт меню.");
                            break;
                    }
                    Pause();
                    continue;
                }
                Console.WriteLine("1. Перезагрузить текст из файла input.txt");
                Console.WriteLine("2. Ввести новый текст вручную");
                Console.WriteLine("3. Показать текст");
                Console.WriteLine("4. ПОСТРОИТЬ КОНКОРДАНС");
                Console.WriteLine("5. Запустить тест конкорданса");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите пункт: ");
                string? choice2 = Console.ReadLine();
                switch (choice2)
                {
                    case "0":
                        return;
                    case "1":
                        text = LoadFromFile(parser);
                        break;
                    case "2":
                        text = LoadFromConsole(parser);
                        break;
                    case "3":
                        Console.WriteLine("\n" + text.Value);
                        break;
                    case "4":
                        Console.WriteLine("\n=== КОНКОРДАНС ===");
                        text.PrintConcordance();
                        break;
                    case "5":
                        TextTests.RunAll();
                        break;
                    default:
                        Console.WriteLine("\nНеизвестный пункт меню.");
                        break;
                }
                Pause();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ОШИБКА] {ex.Message}");
                Console.WriteLine("Нажмите клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
    private static Text LoadFromFile(RegexTextParser parser)
    {
        const string path = "input.txt";
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"Файл '{path}' не найден рядом с программой. " +
                $"Положите его в папку с исполняемым файлом или в корень проекта " +
                $"и настройте CopyToOutputDirectory в .csproj.");
        }
        var text = parser.ParseFile(path);
        Console.WriteLine($"\nТекст загружен! Предложений: {text.Sentences.Count}");
        return text;
    }
    private static Text LoadFromConsole(RegexTextParser parser)
    {
        Console.WriteLine("\nВведите текст (пустая строка — завершить):");
        var sb = new System.Text.StringBuilder();
        string? line;
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            sb.AppendLine(line);
        if (sb.Length == 0)
            throw new InvalidOperationException("Текст не введён.");
        var text = parser.Parse(sb.ToString());
        Console.WriteLine($"\nТекст загружен! Предложений: {text.Sentences.Count}");
        return text;
    }
    private static void Pause()
    {
        Console.WriteLine("\nНажмите клавишу для продолжения...");
        Console.ReadKey();
    }
}