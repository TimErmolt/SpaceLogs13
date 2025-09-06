using SpaceLogs13.Classes.Logs;

namespace SpaceLogs13.Classes.Stats;

public abstract class Stats : IStatMethods
{
    public RoundLog source_round;
    public LogFile source_file;
    public string[] stats_raw = [];
    public string stats_formatted = "";

    public Stats(LogFile file, RoundLog round, bool check_mismatch = true)
    {
        source_round = round;
        source_file = file;

        if(check_mismatch && !ReferenceEquals(source_round.source, file))
        {
            throw new ArgumentException("The provided round log does not belong to the provided log file!");
        }
    }

    public string[] GetRaw()
    {
        return stats_raw;
    }

    public string GetFormatted()
    {
        return stats_formatted;
    }
}

public class RoundStats : Stats
{
    public RoundStats(RoundLog log) : base(log.source, log)
    {
        stats_raw = CollectStats();
        stats_formatted = FormatStats(stats_raw, $"Round {source_round.id}:{System.Environment.NewLine}{System.Environment.NewLine}");
    }

    private string[] CollectStats()
    {
        List<string> stats = [];
        string[] lines = source_round.lines;

        int players_at_start = 0;
        for (int i = 28; i < int.Min(lines.Length, 100); i++)
        {
            if (lines[i].Contains("ACCESS: Login:"))
            {
                players_at_start++;
            }
        }

        stats.Add(players_at_start.ToString());

        stats.Add(source_round.CountLines("Explosion with").ToString());
        // stats.Add(CountLines("has died in").ToString()); // Uncomment this when OnyxBay merges death notices ~04.09.2025

        stats.AddRange(source_round.GetAntags(26));

        return [.. stats];
    }

    private string FormatStats(string[] raw_stats, string header)
    {
        List<string> formatted_stats = [];
        for (int i = 0; i < raw_stats.Length; i++)
        {
            switch (i)
            {
                case 0:
                    formatted_stats.Add($"There were {raw_stats[i]} players at world boot;");
                    break;
                /*
                case 1: // Uncomment this when OnyxBay merges death notices ~05.09.2025
                    formatted_stats.Add($"{raw_stats[i]} players have died;");
                    break;
                */
                case 1:
                    formatted_stats.Add($"There were {raw_stats[i]} explosions;");
                    break;
                default:
                    formatted_stats.Add(raw_stats[i]);
                    break;
            }
        }

        return header + string.Join(System.Environment.NewLine, formatted_stats);
    }
}

/// <summary>
/// Do not use `source_round` from here if getting whole log stats.
/// </summary>
public class CkeyStats : Stats
{
    public string ckey;

    public CkeyStats(LogFile file, RoundLog? round, string key) : base(file, round == null ? new RoundLog(file, file.GetRounds()[0]) : round, false)
    {
        ckey = key;
        Log source = round == null ? file : round;
        stats_raw = CollectStats(file);
    }

    private string[] CollectStats(Log source)
    {
        List<string> stats = [];
        //string[] lines = source.Lines();

        stats.Add(source.CountLines("SAY").ToString());
        stats.Add(source.CountLines("ATTACK").ToString());
        /*
        int players_at_start = 0;
        for (int i = 28; i < int.Min(lines.Length, 100); i++)
        {
            if (lines[i].Contains("ACCESS: Login:"))
            {
                players_at_start++;
            }
        }

        stats.Add(players_at_start.ToString());

        stats.Add(source_round.CountLines("Explosion with").ToString());

        stats.AddRange(source_round.GetAntags(26));
        */

        return [.. stats];
    }
}