using System;
using System.IO;
using System.Reflection;
using uTank2;

internal static class e1
{
    private const string a = "los";
    private const string b = "gf";

    private static bool a()
    {
        foreach (dy dy in PluginCore.cq.ag.c)
        {
            if (dy.b.a.Equals("gf", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    private static void a(string[] A_0)
    {
        string str;
        string[] files = Directory.GetFiles(PluginCore.ci, "*.los");
        if (files.Length == 0)
        {
            str = "alinco.los";
        }
        else
        {
            string[] strArray2 = files[0].Split(new char[] { '\\' });
            str = strArray2[strArray2.Length - 1];
        }
        PluginCore.cq.l.l = str;
        PluginCore.cq.l.r();
        PluginCore.cq.l.l();
    }

    private static bool a(string A_0, Version A_1)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            AssemblyName name = assembly.GetName();
            if (string.Equals(name.Name, A_0, StringComparison.OrdinalIgnoreCase) && (name.Version >= A_1))
            {
                return true;
            }
        }
        return false;
    }

    private static bool b()
    {
        foreach (dy dy in PluginCore.cq.ag.c)
        {
            if (dy.b.a.Equals("los", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    private static void b(string[] A_0)
    {
        string str;
        string[] files = Directory.GetFiles(PluginCore.ci, "*.gf");
        if (files.Length == 0)
        {
            str = "gearfoundry.gf";
        }
        else
        {
            string[] strArray2 = files[0].Split(new char[] { '\\' });
            str = strArray2[strArray2.Length - 1];
        }
        PluginCore.cq.l.l = str;
        PluginCore.cq.l.r();
        PluginCore.cq.l.l();
    }

    private static void c()
    {
        if (((string.IsNullOrEmpty(PluginCore.cq.l.l) && a("Alinco", new Version("1.0.1.4"))) && a("VTLooter", new Version("0.0.0.0"))) && b())
        {
            a.a("setalinco", new a.c(e1.a));
            a5.a(eChatType.Warnings, "WARNING: No loot profile set. To use Alinco with Virindi Tank, " + a.a("click here", new string[] { "setalinco" }) + ".");
        }
    }

    private static void d()
    {
        if (((string.IsNullOrEmpty(PluginCore.cq.l.l) && a("gearfoundry", new Version("0.0.1.10"))) && a("GFVTInterOp", new Version("0.0.0.0"))) && a())
        {
            a.a("setgearf", new a.c(e1.b));
            a5.a(eChatType.Warnings, "WARNING: No loot profile set. To use GearFoundry with Virindi Tank, " + a.a("click here", new string[] { "setgearf" }) + ".");
        }
    }

    public static void e()
    {
        c();
        d();
    }
}

