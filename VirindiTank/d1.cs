using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

internal static class d1
{
    private static List<d1.a> a = new List<d1.a>();
    private static List<ulong> b = new List<ulong>();
    private static List<bool> c = new List<bool>();
    private static List<string> d = new List<string>();
    private static bool e = false;

    private static void a()
    {
        for (int i = c.Count - 1; i >= 0; i--)
        {
            if (c[i])
            {
                a(a[i], d[i]);
            }
        }
    }

    public static void a(d1.a A_0, string A_1)
    {
        if (!d.Contains(A_1))
        {
            a.Add(A_0);
            b.Add(0L);
            c.Add(false);
            d.Add(A_1);
        }
        int index = d.IndexOf(A_1);
        if (b[index] < e3.b())
        {
            b[index] = e3.b();
            c[index] = false;
            A_0();
        }
        else
        {
            if (!e)
            {
                ae.a(new ae.a(d1.a), 1);
            }
            c[index] = true;
        }
    }

    public delegate void a();
}

