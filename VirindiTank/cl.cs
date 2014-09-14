using System;
using System.Collections.Generic;

internal static class cl
{
    public static Dictionary<c3, fl> a = new Dictionary<c3, fl>();
    public static Dictionary<ep, b3> b = new Dictionary<ep, b3>();

    static cl()
    {
        a(c3.a, new b4());
        a(c3.b, new au());
        a(c3.d, new ah());
        a(c3.c, new br());
        a(c3.e, new ct());
        a(c3.f, new fg());
        a(c3.g, new et());
        a(c3.h, new c5());
        a(c3.i, new f1());
        a(c3.j, new eh());
        a(c3.k, new cm());
        a(c3.l, new ax());
        a(c3.m, new eu());
        a(c3.n, new f0());
        a(c3.o, new d3());
        a(c3.p, new e4());
        a(c3.q, new fe());
        a(c3.r, new fb());
        a(c3.s, new p());
        a(c3.t, new fh());
        a(c3.u, new fw());
        a(c3.v, new b6());
        a(c3.w, new db());
        a(c3.x, new ch());
        a(ep.a, new w());
        a(ep.b, new ed());
        a(ep.c, new fk());
        a(ep.d, new bl());
        a(ep.e, new e9());
        a(ep.f, new fm());
        a(ep.g, new c7());
    }

    public static fl a(c3 A_0)
    {
        if (!a.ContainsKey(A_0))
        {
            return null;
        }
        try
        {
            return (fl) a[A_0].GetType().GetConstructor(new Type[0]).Invoke(new object[0]);
        }
        catch
        {
            return null;
        }
    }

    public static b3 a(ep A_0)
    {
        if (!b.ContainsKey(A_0))
        {
            return null;
        }
        try
        {
            return (b3) b[A_0].GetType().GetConstructor(new Type[0]).Invoke(new object[0]);
        }
        catch
        {
            return null;
        }
    }

    private static void a(c3 A_0, fl A_1)
    {
        a[A_0] = A_1;
    }

    private static void a(ep A_0, b3 A_1)
    {
        b[A_0] = A_1;
    }

    public static T Create<T>(int v) where T: b1
    {
        if (typeof(T) == typeof(fl))
        {
            return (T) a((c3) v);
        }
        if (typeof(T) == typeof(b3))
        {
            return (T) a((ep) v);
        }
        return default(T);
    }

    public static int GetTypeIDForClass<T>(T v) where T: b1
    {
        if (typeof(T) == typeof(fl))
        {
            return (int) ((fl) v).f();
        }
        if (typeof(T) == typeof(b3))
        {
            return (int) ((b3) v).d();
        }
        return 0;
    }

    public static List<int> GetTypeIDs<T>() where T: b1
    {
        List<int> list = new List<int>();
        if (typeof(T) == typeof(fl))
        {
            foreach (KeyValuePair<c3, fl> pair in a)
            {
                list.Add(pair.Key);
            }
            return list;
        }
        if (typeof(T) == typeof(b3))
        {
            foreach (KeyValuePair<ep, b3> pair2 in b)
            {
                list.Add(pair2.Key);
            }
        }
        return list;
    }
}

