using System.Text.RegularExpressions;

namespace SpaceLogs13.Classes;

/// <summary>
/// Contains regexes which do not depend on different configs, e.g. IPs and HTML tags.
/// </summary>
public static partial class StaticRegexes
{
    [GeneratedRegex("\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}-\\d{1,10}")]
    public static partial Regex IP_CID();

    [GeneratedRegex("[^]+")]
    public static partial Regex IP_CID_Onyx();

    [GeneratedRegex("<br>|<b>|</b>|<i>|</i>|<span class='[^']*'>|</span>|<div class='[^']*'>|</div>|<font color='[^']*'>|</font>|<font size = [^']*>|<img class='[^']*' src=\"[^']*\">")]
    public static partial Regex HTML();

    [GeneratedRegex("<\\s*a\\s+HREF\\s*=\\s*(?:\"[^\"]*\"|'[^']*'|[^'\">\\s]+)*\\s*>.*?<\\s*/\\s*a\\s*>")]
    public static partial Regex HREF();

    public static string[] SanitizeLogs(string[] logs)
    {
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
        */
        for (int i = 0; i < logs.Length; i++)
        {
            logs[i] = IP_CID_Onyx().Replace(logs[i], "IP-HWID");
            logs[i] = IP_CID().Replace(logs[i], "IP-HWID");
            logs[i] = HREF().Replace(logs[i], "");
            logs[i] = HTML().Replace(logs[i], "");
            logs[i] = logs[i].Replace("&#34;", "\"");
            logs[i] = logs[i].Replace("&#39;", "'");
            logs[i] = logs[i].Replace("() ()", "");
        }

        return logs;
    }
}
