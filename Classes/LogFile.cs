using System.Text.RegularExpressions;

namespace SpaceLogs13.Classes;

/// <summary>
/// A currently selected log file (typically .log or .txt). Contains methods for working with text inside it.
/// </summary>
public class LogFile
{
    public string path;
    public string filename;
    public string[] lines;

    public LogFile(string _path)
    {
        if(!File.Exists(_path) || _path == null)
        {
            throw new FileNotFoundException(path);
        }

        path = _path;
        filename = Path.GetFileName(path);

        lines = StaticRegexes.SanitizeLogs(File.ReadAllLines(path));

        /* 02.09.2025
         * Sanitize read lines:
         * 1. REGEX: Remove IP addresses (logs may still contain them);
         * 1.1 Try removing them with the OnyxBay method via emojis;
         * 1.2 In case that doesn't work, also try the normal way;
         * 2. REGEX: Remove HREF artifacts, as they serve no purpose;
         * 3. REGEX: Remove leftover HTML tags, ditto;
         * 4. Replace broken quote symbols with normal ones;
         * 5. Remove leftover HREF brackets.
         
         Thank you Poromoks for the guide to manual log sanitization, which has been used to automate it here, including the regular expressions.
        
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = Regex.Replace(lines[i], "[^]+", "IP-HWID");
            lines[i] = StaticRegexes.IP_CID().Replace(lines[i], "IP-HWID");
            lines[i] = StaticRegexes.HREF().Replace(lines[i], "");
            lines[i] = StaticRegexes.HTML().Replace(lines[i], "");
            lines[i] = lines[i].Replace("&#34;", "\"");
            lines[i] = lines[i].Replace("&#39;", "'");
            lines[i] = lines[i].Replace("() ()", "");
        }
        */
    }

    public bool Exists()
    {
        return File.Exists(path);
    }

    public string Filename()
    {
        return filename;
    }

    public string[] Lines()
    {
        return lines;
    }

    public string[] Search(string keyword, bool case_sensitive = false)
    {
        List<string> found_lines = [];

        if (case_sensitive)
        {
            foreach (string line in lines)
            {
                if (line.Contains(keyword))
                {
                    found_lines.Add(line);
                }
            }
        }
        else
        {
            foreach (string line in lines)
            {
                if (line.Contains(keyword, StringComparison.CurrentCultureIgnoreCase))
                {
                    found_lines.Add(line);
                }
            }
        }

        // These emojis are handy for getting stats from logs, but the user doesn't need to see them. ~02.09.2025
        for (int i = 0; i < found_lines.Count; i++)
        {
            found_lines[i] = Regex.Replace(found_lines[i], "[]", "");
        }

        return [.. found_lines];
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
