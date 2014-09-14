using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal static class ej
{
    private static Regex a = new Regex(@"\<[^\>]*\>(?<msg>[^\<]*)\<[^\>]*\>");

    public static string a(string A_0)
    {
        string input = A_0;
        MatchCollection matchs = a.Matches(input);
        List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
        foreach (Match match in matchs)
        {
            if (match.Success)
            {
                list.Add(new KeyValuePair<string, string>(match.Value, match.Groups["msg"].Value));
            }
        }
        foreach (KeyValuePair<string, string> pair in list)
        {
            input = input.Replace(pair.Key, pair.Value);
        }
        return input;
    }
}

