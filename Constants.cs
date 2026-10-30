namespace TextLab.Models;

public static class Constants
{
   
    public const string PunctuationChars = ".,!?;:()\"'«»…—-";

    public static readonly char[] AllowedPunctuations = PunctuationChars.ToCharArray();

    public const string Vowels = "аеёиоуыэюяaeiouy";

    public const string TokenRegexPattern = @"[\p{L}\p{Nd}]+(?:[-'][\p{L}\p{Nd}]+)*|" +
                                            @"[.,!?;:()""'«»…—]";
}