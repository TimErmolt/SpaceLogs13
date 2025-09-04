using System.Text.RegularExpressions;

namespace SpaceLogs13.Classes;

/// <summary>
/// Contains regexes which do not depend on different configs, e.g. IPs and HTML tags.
/// </summary>
public static partial class StaticRegexes
{
    [GeneratedRegex("\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}-\\d{1,10}")]
    public static partial Regex IP_CID();

    [GeneratedRegex("<br>|<b>|</b>|<i>|</i>|<span class='[^']*'>|</span>|<div class='[^']*'>|</div>|<font color='[^']*'>|</font>|<font size = [^']*>|<img class='[^']*' src=\"[^']*\">")]
    public static partial Regex HTML();

    [GeneratedRegex("<\\s*a\\s+HREF\\s*=\\s*(?:\"[^\"]*\"|'[^']*'|[^'\">\\s]+)*\\s*>.*?<\\s*/\\s*a\\s*>")]
    public static partial Regex HREF();
}
