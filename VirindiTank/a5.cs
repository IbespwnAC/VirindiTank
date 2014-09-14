using Decal.Adapter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using uTank2;

internal static class a5
{
    private static Dictionary<eChatType, a5.a> a;
    private static string b = "";
    internal static bool c = false;
    private static bool d = false;

    public static void a()
    {
        if (d)
        {
            d = false;
            a.Clear();
            CoreManager.get_Current().remove_PluginInitComplete(new EventHandler<EventArgs>(a5.a));
        }
    }

    private static void a(object A_0, EventArgs A_1)
    {
        b = "[VTank] ";
        a(eChatType.CommandLine, "Generic plugin text", 7, new int[] { 1 });
        a(eChatType.Logging, "/vt log messages", 2, new int[] { 5 });
        a(eChatType.Warnings, "Non-fatal warnings", 6, new int[] { 1 });
        a(eChatType.Errors, "Errors which stop operation", 6, new int[] { 1, 2, 3, 4, 5 });
    }

    public static void a(eChatType A_0, string A_1)
    {
        if (a != null)
        {
            string str = b + A_1;
            if (c)
            {
                Console.WriteLine(str);
                Debug.Print(str);
            }
            if (a.ContainsKey(A_0))
            {
                ap.b(a[A_0].a, str, a[A_0].b, a[A_0].c);
            }
        }
    }

    private static void a(eChatType A_0, string A_1, int A_2, params int[] A_3)
    {
        a5.a a = new a5.a {
            a = A_0.ToString(),
            b = A_2,
            c = A_3
        };
        a5.a[A_0] = a;
        ap.b(a.a, A_1);
    }

    public static void b()
    {
        if (!d)
        {
            d = true;
            a = new Dictionary<eChatType, a5.a>();
            try
            {
                if (string.Compare(Process.GetCurrentProcess().ProcessName, "Direct3D9_Container", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    c = true;
                }
            }
            catch
            {
            }
            CoreManager.get_Current().add_PluginInitComplete(new EventHandler<EventArgs>(a5.a));
        }
    }

    private class a
    {
        public string a;
        public int b;
        public int[] c;
    }
}

