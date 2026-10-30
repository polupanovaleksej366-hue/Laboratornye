using лаба_3_с_.Models;
namespace лаба_3_с_.Models;
public class Punctuation : Token
{
    private static readonly char[] Allowed =
    {
        '.', ',', '!', '?', ';', ':', '-', '—',
        '(', ')', '"', '\'', '«', '»', '…'
    };
    private readonly char _value;
    public override string Value => _value.ToString();
    public char Symbol => _value;
    public Punctuation(char value)
    {
        if (Array.IndexOf(Allowed, value) < 0)
            throw new ArgumentException($"'{value}' is not a supported punctuation mark.");
        _value = value;
    }
    public bool IsSentenceEnd => _value == '.' || _value == '!' || _value == '?';
    public override bool Equals(object? obj) => obj is Punctuation p && p._value == _value;
    public override int GetHashCode() => _value.GetHashCode();
}