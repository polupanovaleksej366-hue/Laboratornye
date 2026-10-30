using System.Xml.Serialization;
using лаба_3_с_.Models;
using TextLab.Models;
namespace TextLab.Services;
[XmlRoot("text")]
public class TextDto
{
    [XmlElement("sentence")]
    public List<SentenceDto> Sentences { get; set; } = new();
    public static TextDto FromModel(Text text)
    {
        var dto = new TextDto();
        foreach (var s in text.Sentences)
        {
            var sd = new SentenceDto();
            foreach (var t in s.Tokens)
            {
                if (t is Word w) sd.Words.Add(w.Value);
                else if (t is Punctuation p) sd.Punctuations.Add(p.Value);
            }
            dto.Sentences.Add(sd);
        }
        return dto;
    }
}
public class SentenceDto
{
    [XmlElement("word")]
    public List<string> Words { get; set; } = new();
    [XmlElement("punctuation")]
    public List<string> Punctuations { get; set; } = new();
}
public static class TextXmlSerializer
{
    public static void Save(Text text, string path)
    {
        var dto = TextDto.FromModel(text);
        var serializer = new XmlSerializer(typeof(TextDto));
        using var fs = new FileStream(path, FileMode.Create);
        serializer.Serialize(fs, dto);
    }
}