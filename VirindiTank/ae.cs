using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

internal static class ae
{
    private static List<e3> a = new List<e3>();
    private static List<ae.a> b = new List<ae.a>();
    private static List<ulong> c = new List<ulong>();
    private static e3 d;

    private static bool a(e3 A_0)
    {
        return (A_0 == d);
    }

    public static void a(ae.a A_0, int A_1)
    {
        e3 item = new e3();
        a.Add(item);
        b.Add(A_0);
        c.Add(e3.b());
        item.a(A_1);
        item.a(new EventHandler(ae.a));
        item.d();
    }

    private static void a(object A_0, EventArgs A_1)
    {
        d = (e3) A_0;
        int index = a.FindIndex(new Predicate<e3>(ae.a));
        if (c[index] != e3.b())
        {
            d.f();
            b[index]();
            d.e();
            a.RemoveAt(index);
            b.RemoveAt(index);
            c.RemoveAt(index);
        }
    }

    public delegate void a();
}

