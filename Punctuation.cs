namespace ConcordanceLab.Models;
public class Punctuation : Token
{
    private readonly char _value;
    public override string Value => _value.ToString();
    public Punctuation(char value)
    {
        if (Array.IndexOf(Constants.AllowedPunctuations, value) < 0)
            throw new ArgumentException($"'{value}' is not a supported punctuation mark.");
        _value = value;
    }
    public bool IsSentenceEnd => _value == '.' || _value == '!' || _value == '?';
}