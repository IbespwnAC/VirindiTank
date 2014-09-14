using System;
using System.Collections.Generic;
using uTank2;

internal class fj
{
    private static Dictionary<string, d9> a = new Dictionary<string, d9>();

    public static void a(string A_0)
    {
        if (a.ContainsKey(A_0))
        {
            PluginCore.cq.n.a(Math.Round(d9.a(d9.a(), a[A_0]), 2).ToString() + "ms   Timer \"" + A_0 + "\"", e8.h);
        }
    }

    public static void a(string A_0, double A_1)
    {
        if (a.ContainsKey(A_0))
        {
            double num = Math.Round(d9.a(d9.a(), a[A_0]), 2);
            if (num >= A_1)
            {
                PluginCore.cq.n.a(num.ToString() + "ms   Timer \"" + A_0 + "\"", e8.h);
            }
        }
    }

    public static void b(string A_0)
    {
        a[A_0] = d9.a();
    }
}

