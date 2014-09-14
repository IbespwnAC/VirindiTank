using System;
using System.Collections.Generic;
using uTank2;

internal static class ai
{
    private static Dictionary<string, byte> a = new Dictionary<string, byte>();

    public static void a()
    {
        a.Clear();
    }

    public static void a(string A_0)
    {
        if (!a.ContainsKey(A_0))
        {
            a.Add(A_0, 0);
            a5.a(eChatType.Warnings, A_0);
        }
    }
}

