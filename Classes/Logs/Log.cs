using System.Text.RegularExpressions;

namespace SpaceLogs13.Classes.Logs;

public abstract class Log : ILogMethods
{
    public string[] lines;
    public Log()
    {
        lines = ["Well, this is awkward."];
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
    public int CountLines(string keyword)
    {
        return Search(keyword, true).Length;
    }
}
