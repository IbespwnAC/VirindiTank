using Decal.Adapter;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal static class cn
{
    private static bool a = false;
    private static List<object> b = new List<object>();
    private static Dictionary<string, object> c = new Dictionary<string, object>();
    private static Dictionary<object, GCHandle> d = new Dictionary<object, GCHandle>();
    private static Dictionary<object, cn.a> e = new Dictionary<object, cn.a>();

    public static void a()
    {
        List<cn.a> list = new List<cn.a>();
        foreach (KeyValuePair<object, cn.a> pair in e)
        {
            list.Add(pair.Value);
        }
        foreach (cn.a a in list)
        {
            if (a != null)
            {
                a();
            }
        }
    }

    public static bool a(string A_0)
    {
        if (A_0 == "")
        {
            return false;
        }
        return c.ContainsKey(A_0);
    }

    private static void a(object A_0, EventArgs A_1)
    {
        CoreManager.get_Current().remove_PluginTermComplete(new EventHandler<EventArgs>(cn.a));
        a();
        a = false;
    }

    public static void a(string A_0, object A_1)
    {
        if (b.Contains(A_1))
        {
            b.Remove(A_1);
        }
        if (c.ContainsKey(A_0))
        {
            c.Remove(A_0);
        }
        if (d.ContainsKey(A_1))
        {
            d.Remove(A_1);
        }
        if (e.ContainsKey(A_1))
        {
            e.Remove(A_1);
        }
    }

    public static void a(string A_0, object A_1, cn.a A_2)
    {
        if (A_0 == "")
        {
            b.Add(A_1);
            d[A_1] = GCHandle.Alloc(A_1, GCHandleType.Normal);
            e[A_1] = A_2;
        }
        else
        {
            if (c.ContainsKey(A_0))
            {
                c.Remove(A_0);
                d.Remove(A_1);
                e.Remove(A_1);
            }
            c[A_0] = A_1;
            d[A_1] = GCHandle.Alloc(A_1, GCHandleType.Normal);
            e[A_1] = A_2;
        }
    }

    public static void b()
    {
        if (!a)
        {
            CoreManager.get_Current().add_PluginTermComplete(new EventHandler<EventArgs>(cn.a));
        }
    }

    public delegate void a();
}

