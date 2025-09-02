using Microsoft.VisualBasic.FileIO;
using System;

namespace SpaceLogs13
{
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
            if(!File.Exists(path) || path == null)
            {
                throw new FileNotFoundException(path);
            }

            path = _path;
            filename = Path.GetFileName(path);
            lines = File.ReadAllLines(path);
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
                    if (line.ToLower().Contains(keyword.ToLower()))
                    {
                        found_lines.Add(line);
                    }
                }
            }
            
            return [.. found_lines];
        }
    }
}
