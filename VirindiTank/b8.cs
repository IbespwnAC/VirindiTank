using System;
using uTank2;

internal static class b8
{
    private static MyList<e3> a = new MyList<e3>(0x10);
    private static MyList<PluginCore.EmptyDelegate> b = new MyList<PluginCore.EmptyDelegate>(0x11);
    private static e3 c;

    private static bool a(e3 A_0)
    {
        return (A_0 == c);
    }

    private static void a(object A_0, EventArgs A_1)
    {
        c = (e3) A_0;
        int index = a.FindIndex(new Predicate<e3>(b8.a));
        c.f();
        b[index]();
        a.RemoveAt(index);
        b.RemoveAt(index);
    }

    public static void a(PluginCore.EmptyDelegate A_0, int A_1)
    {
        e3 item = new e3();
        a.Add(item);
        b.Add(A_0);
        item.a(A_1);
        item.a(new EventHandler(b8.a));
        item.d();
    }
}

