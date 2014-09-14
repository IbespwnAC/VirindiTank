using Decal.Adapter;
using System;
using System.Drawing;
using System.Reflection;
using VirindiHUDs.UIs;

internal static class dm
{
    private static bool a;
    private static bool b;
    private static bool c;

    public static bool a()
    {
        if (a)
        {
            return b;
        }
        try
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                AssemblyName name = assembly.GetName();
                if ((name.Name == "VirindiHUDs") && (name.Version >= new Version("1.0.0.5")))
                {
                    a = true;
                    b = true;
                    return true;
                }
            }
        }
        catch
        {
        }
        a = true;
        b = false;
        return false;
    }

    private static void a(object A_0, EventArgs A_1)
    {
        if (c)
        {
            CoreManager.get_Current().remove_PluginInitComplete(new EventHandler<EventArgs>(dm.a));
        }
        c();
    }

    private static void a(string A_0, string A_1, string A_2)
    {
        StatusModel.UpdateEntry(A_0, A_1, A_2);
    }

    private static void a(string A_0, string A_1, string A_2, Color A_3)
    {
        StatusModel.UpdateEntry(A_0, A_1, A_2, A_3);
    }

    public static void b()
    {
        if (!c)
        {
            c = true;
            CoreManager.get_Current().add_PluginInitComplete(new EventHandler<EventArgs>(dm.a));
        }
    }

    public static void b(string A_0, string A_1, string A_2)
    {
        if (a())
        {
            a(A_0, A_1, A_2);
        }
    }

    public static void b(string A_0, string A_1, string A_2, Color A_3)
    {
        if (a())
        {
            a(A_0, A_1, A_2, A_3);
        }
    }

    public static void c()
    {
        b = false;
        a = false;
    }
}

