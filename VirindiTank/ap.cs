using Decal.Adapter.Wrappers;
using System;
using System.Reflection;
using VCS5;
using VirindiViewService;
using VirindiViewService.Controls;

internal static class ap
{
    public static string a = "???";
    public static PluginHost b = null;

    private static bool a()
    {
        return Service.get_Running();
    }

    public static bool a(PluginHost A_0)
    {
        try
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            bool flag = false;
            foreach (Assembly assembly in assemblies)
            {
                AssemblyName name = assembly.GetName();
                if ((name.Name == "VirindiViewService") && (name.Version >= new Version("1.0.0.14")))
                {
                    flag = true;
                    break;
                }
            }
            if (flag && a())
            {
                return true;
            }
        }
        catch
        {
        }
        return false;
    }

    private static void a(string A_0, string A_1)
    {
        Presets.RegisterPreset(a, A_0, A_1);
    }

    private static void a(string A_0, int A_1, int A_2)
    {
        HudChatbox.SendChatText(A_0, (HudConsole.eACTextColor) A_1, (eConsoleColorClass) A_2);
    }

    private static void a(string A_0, string A_1, int A_2, params int[] A_3)
    {
        Presets.FilterOutputPreset(a, A_0, A_1, A_2, A_3);
    }

    public static void a(PluginHost A_0, string A_1, int A_2, int A_3, ap.a A_4)
    {
        if (b(A_0))
        {
            b(A_1, A_2, A_3);
        }
        else
        {
            A_0.get_Actions().AddChatTextRaw(A_1, A_2, A_3);
        }
        if (a(A_0))
        {
            a(A_1, A_2, (int) A_4);
        }
    }

    private static bool b()
    {
        return PluginCore.get_Running();
    }

    public static bool b(PluginHost A_0)
    {
        try
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            bool flag = false;
            foreach (Assembly assembly in assemblies)
            {
                AssemblyName name = assembly.GetName();
                if ((name.Name == "VCS5") && (name.Version >= new Version("5.0.0.5")))
                {
                    flag = true;
                    break;
                }
            }
            if (flag && b())
            {
                return true;
            }
        }
        catch
        {
        }
        return false;
    }

    public static void b(string A_0, string A_1)
    {
        if (b(b))
        {
            a(A_0, A_1);
        }
    }

    private static void b(string A_0, int A_1, int A_2)
    {
        PluginCore.Instance.FilterOutputText(A_0, A_2, A_1);
    }

    public static void b(string A_0, string A_1, int A_2, params int[] A_3)
    {
        if (b(b))
        {
            a(A_0, A_1, A_2, A_3);
        }
        else
        {
            foreach (int num in A_3)
            {
                b.get_Actions().AddChatText(A_1, A_2, num);
            }
        }
        if (a(b))
        {
            a(A_1, A_2, 0x60);
        }
    }

    public enum a
    {
        a = 0,
        b = 1,
        c = 2,
        d = 3,
        e = 4,
        f = 5,
        g = 6,
        h = 7,
        i = 8,
        j = 9,
        k = 10,
        l = 11,
        m = 12,
        n = 13,
        o = 0x60,
        p = 0x61,
        q = 0x62,
        r = 0x63
    }
}

