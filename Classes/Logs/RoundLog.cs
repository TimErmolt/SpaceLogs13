using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpaceLogs13.Classes.Logs;

/// <summary>
/// Logs of only a single round, determined by its ID.
/// </summary>
public class RoundLog : Log
{
    public LogFile source;
    public string id;

    public RoundLog(LogFile log_file, string round_id)
    {
        source = log_file;
        lines = source.Search(round_id, true);
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

    public string[] GetAntags(int start_index)
    {
        List<string> antags = [];
        string[] antag_names = ["Traitor", "Changeling", "Cultist", "Vampire", "Thrall", "Xenomorph", "Syndicate", "Mercenary", "Renegade",
                                "Loyalist", "Revolutionary", "NanoTrasen Actor", "Space Wizard", "Ninja", "Servant", "Deity", "Rabid Monkey", "Emergency Responder",
                                "Meme", "Borer", "Death Commando", "Raider", "Zombie"];
        int start_line = -1;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("Antagonists at round end were"))
            {
                start_line = i;
                break;
            }
        }

        if(start_line == -1)
        {
            return ["Antagonist list couldn't be found!"];
        }

        for (int i = start_line; i < lines.Length; i++)
        {
            if (!lines[i].Contains("GAME"))
            {
                break;
            }
            foreach(string name in antag_names)
            {
                if (lines[i].Contains(name))
                {
                    antags.Add(lines[i][start_index..]);
                }
            }
        }

        if (antags.Count == 0)
        {
            return ["There were no antagonists."];
        }

        antags.Insert(0, "The antagonists were:");

        return [.. antags];
    }
}

