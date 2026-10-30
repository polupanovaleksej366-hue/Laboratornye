namespace TextLab.Services;
public class StopWordsProvider
{
    public ISet<string> Load(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException(path);
        return new HashSet<string>(
            File.ReadAllLines(path)
                .Select(l => l.Trim())
                .Where(l => l.Length > 0),
            StringComparer.OrdinalIgnoreCase);
    }
}