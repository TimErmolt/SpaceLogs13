using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpaceLogs13.Classes;

/// <summary>
/// Logs of only a single round, determined by its ID.
/// </summary>
public class RoundLog
{
    public string id;
    public string[] lines;

    public RoundLog(LogFile log_file, string round_id)
    {
        lines = log_file.Search(round_id, true);
        if (lines == null || lines.Length == 0)
        {
            throw new Exception("Incorrect round ID provided!");
        }

        id = round_id;
    }

    public string RoundID()
    {
        return id;
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

        for (int i = 0; i < found_lines.Count; i++)
        {
            found_lines[i] = Regex.Replace(found_lines[i], "[]", "");
        }

        return [.. found_lines];
    }

    private int CountLines(string keyword)
    {
        return Search(keyword, true).Length;
    }

    private string[] GetAntags()
    {
        List<string> antags = [];
        string[] antag_names = ["Traitor", "Changeling", "Cultist", "Vampire", "Thrall", "Xenomorph", "Syndicate", "Mercenary", "Renegade",
                                "Loyalist", "Revolutionary", "NanoTrasen Actor", "Wizard", "Ninja", "Servant", "Deity", "Rabid Monkey", "Emergency Responder",
                                "Meme", "Borer", "Death Commando", "Raider"];
        int start_index = -1;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("Antagonists at round end were"))
            {
                start_index = i;
                break;
            }
        }

        if(start_index == -1)
        {
            return ["Antagonist list couldn't be found!"];
        }

        for (int i = start_index; i < lines.Length; i++)
        {
            if (!lines[i].Contains("GAME"))
            {
                break;
            }
            foreach(string name in antag_names)
            {
                if (lines[i].Contains(name))
                {
                    antags.Add(lines[i].Substring(26));
                }
            }
        }

        return [.. antags];
    }

    public string[] GetStats()
    {
        List<string> stats = [];

        stats.Add(CountLines("Explosion in").ToString());
        // stats.Add(CountLines("has died in").ToString()); // Uncomment this when OnyxBay merges death notices ~04.09.2025

        stats.AddRange(GetAntags());

        return [.. stats];
    }
}

