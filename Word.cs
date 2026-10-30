using лаба_3_с_.Models;
namespace лаба_3_с_.Models;
public class Word : Token
{
    private readonly string _value;
    public override string Value => _value;
    public Word(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Word cannot be empty.", nameof(value));
        _value = value;
    }
    public int Length => _value.Length;
    public bool StartsWithConsonant()
    {
        char c = char.ToLowerInvariant(_value[0]);
        if (!char.IsLetter(c)) return false;
        const string vowels = "аеёиоуыэюяaeiouy";
        return !vowels.Contains(c);
    }
    public bool HasLength(int length) => _value.Length == length;
}