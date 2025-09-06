using System.Text.RegularExpressions;

namespace SpaceLogs13.Classes.Logs;

/// <summary>
/// A currently selected log file (typically .log or .txt). Contains methods for working with text inside it.
/// </summary>
public class LogFile : Log
{
    public string path;
    public string filename;

    public LogFile(string _path)
    {
        if(!File.Exists(_path) || _path == null)
        {
            throw new FileNotFoundException(path);
        }

        path = _path;
        filename = Path.GetFileName(path);

        lines = StaticRegexes.SanitizeLogs(File.ReadAllLines(path));
    }

    public bool Exists()
    {
        return File.Exists(path);
    }

    public string Filename()
    {
        return filename;
    }

    public string[] GetRounds()
    {
        string[] round_ids = Search("Starting up round", true);
        for (int i = 0; i < round_ids.Length; i++)
        {
            round_ids[i] = round_ids[i].Substring(21, 8);
        }
        return round_ids;
    }
}
