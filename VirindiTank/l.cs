using System;
using uTank2;
using uTank2.Logic;

internal static class l
{
    private static int a;
    private static int b;

    public static void a()
    {
        dm.b("VTank", "Macro Running", PluginCore.cq.n.b.ToString());
    }

    public static void a(bool A_0)
    {
        if (A_0)
        {
            dm.b("VTank", "Macro Target", PluginCore.cq.o.a.c);
        }
        else
        {
            dm.b("VTank", "Macro Target", "[None]");
        }
    }

    public static void a(int A_0)
    {
        dm.b("VTank", "Total Targets", A_0.ToString());
    }

    public static void a(string A_0)
    {
        dm.b("VTank", "Meta State", A_0);
    }

    public static void a(ILogicRule A_0)
    {
        if (A_0 != null)
        {
            dm.b("VTank", "Macro Action", A_0.FriendlyName);
        }
        else
        {
            dm.b("VTank", "Macro Action", "[None]");
        }
    }

    public static void b()
    {
        dm.b("VTank", "Meta Profile", PluginCore.cq.@as.j());
    }

    public static void b(int A_0)
    {
        dm.b("VTank", "Ring Targets", A_0.ToString());
    }

    public static void c()
    {
        dm.b("VTank", "Loot Profile", PluginCore.cq.l.l);
    }

    public static void c(int A_0)
    {
        dm.b("VTank", "Possible Targets", A_0.ToString());
    }

    public static void d()
    {
        dm.b("VTank", "Nav. Profile", PluginCore.cq.l.n);
    }

    public static void e()
    {
        dm.b("VTank", "Macro Profile", PluginCore.PC.h(PluginCore.cq.l.m));
    }

    public static void f()
    {
        b++;
        dm.b("VTank", "Macro Kills", b.ToString());
        h();
    }

    public static void g()
    {
        a++;
        dm.b("VTank", "Macro Attack Spells Used", a.ToString());
        h();
    }

    private static void h()
    {
        double positiveInfinity;
        if (b == 0)
        {
            positiveInfinity = double.PositiveInfinity;
        }
        else
        {
            positiveInfinity = ((double) a) / ((double) b);
        }
        dm.b("VTank", "Macro Attack Spells Per Mage Kill", positiveInfinity.ToString("#.000"));
    }

    public static void i()
    {
        dm.b("VTank", "IDQueue Len.", PluginCore.cq.u.b().ToString());
    }

    public static void j()
    {
        dm.b();
        b = 0;
        a = 0;
    }
}

