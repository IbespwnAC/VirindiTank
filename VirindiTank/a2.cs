using Decal.Adapter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using uTank2;

internal static class a2
{
    private static List<a2.a> a = new List<a2.a>();
    private static bool b = false;
    private static bool c = false;
    private static bool d = false;

    public static ReadOnlyCollection<a2.a> a()
    {
        return a.AsReadOnly();
    }

    public static void a(bool A_0)
    {
        d = A_0;
    }

    private static void a(object A_0, ChatTextInterceptEventArgs A_1)
    {
        try
        {
            if (((PluginCore.cq != null) && PluginCore.cq.n.b) && er.j("EnableMeta"))
            {
                a2.a item = new a2.a {
                    b = A_1.get_Color(),
                    c = A_1.get_Target(),
                    a = A_1.get_Text()
                };
                a.Add(item);
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public static bool b()
    {
        return d;
    }

    public static void b(bool A_0)
    {
        c = A_0;
    }

    public static bool c()
    {
        return c;
    }

    public static void c(bool A_0)
    {
        b = A_0;
    }

    public static bool d()
    {
        return b;
    }

    public static void e()
    {
        a.Clear();
        b = false;
        c = false;
        d = false;
    }

    public static void f()
    {
        CoreManager.get_Current().remove_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(a2.a));
        a.Clear();
    }

    public static void g()
    {
        CoreManager.get_Current().add_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(a2.a));
    }

    public class a
    {
        public string a;
        public int b;
        public int c;
    }
}

