using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

internal static class bt
{
    private static List<e3> a = new List<e3>();
    private static List<bt.a> b = new List<bt.a>();
    private static List<ulong> c = new List<ulong>();
    private static List<object> d = new List<object>();
    private static e3 e;

    private static bool a(e3 A_0)
    {
        return (A_0 == e);
    }

    private static void a(object A_0, EventArgs A_1)
    {
        e = (e3) A_0;
        int index = a.FindIndex(new Predicate<e3>(bt.a));
        if (c[index] != e3.b())
        {
            e.f();
            b[index](d[index]);
            e.e();
            a.RemoveAt(index);
            b.RemoveAt(index);
            c.RemoveAt(index);
            d.RemoveAt(index);
        }
    }

    public static void a(bt.a A_0, int A_1, object A_2)
    {
        e3 item = new e3();
        a.Add(item);
        b.Add(A_0);
        c.Add(e3.b());
        d.Add(A_2);
        item.a(A_1);
        item.a(new EventHandler(bt.a));
        item.d();
    }

    public delegate void a(object A_0);
}

