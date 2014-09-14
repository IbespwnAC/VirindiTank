using Decal.Adapter.Wrappers;
using MetaViewWrappers;
using MetaViewWrappers.DecalControls;
using MetaViewWrappers.VirindiViewServiceHudControls;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using VirindiViewService;
using VirindiViewService.Controls;

internal static class ff
{
    private static bool a()
    {
        return ((HudView.get_FocusControl() != null) && (HudView.get_FocusControl().GetType() == typeof(HudTextBox)));
    }

    public static bool a(PluginHost A_0)
    {
        return ((a(A_0, ff.b.b) && a()) || A_0.get_Actions().get_ChatState());
    }

    public static bool a(PluginHost A_0, ff.b A_1)
    {
        switch (A_1)
        {
            case ff.b.a:
                return true;

            case ff.b.b:
                return b(A_0);
        }
        return false;
    }

    private static IView a(PluginHost A_0, string A_1)
    {
        IView view = new View();
        view.InitializeRawXML(A_0, A_1);
        return view;
    }

    public static bool a(PluginHost A_0, Version A_1)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            AssemblyName name = assembly.GetName();
            if ((name.Name == "VirindiViewService") && (name.Version >= A_1))
            {
                try
                {
                    return b();
                }
                catch
                {
                    return false;
                }
            }
        }
        return false;
    }

    public static IView a(PluginHost A_0, string A_1, ff.b A_2)
    {
        if (a(A_0, A_2))
        {
            switch (A_2)
            {
                case ff.b.a:
                    return b(A_0, A_1);

                case ff.b.b:
                    return a(A_0, A_1);
            }
        }
        return null;
    }

    public static void a(IView A_0, ff.a A_1, ff.a A_2, object A_3)
    {
        Type type = A_0.GetType();
        if ((type == typeof(View)) && (A_2 != null))
        {
            A_2(A_3);
        }
        if ((type == typeof(View)) && (A_1 != null))
        {
            A_1(A_3);
        }
    }

    private static bool b()
    {
        return Service.get_Running();
    }

    private static bool b(PluginHost A_0)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            AssemblyName name = assembly.GetName();
            if ((name.Name == "VirindiViewService") && (name.Version >= new Version("1.0.0.37")))
            {
                try
                {
                    return b();
                }
                catch
                {
                    return false;
                }
            }
        }
        return false;
    }

    private static IView b(PluginHost A_0, string A_1)
    {
        IView view = new View();
        view.InitializeRawXML(A_0, A_1);
        return view;
    }

    public static IView b(PluginHost A_0, string A_1, ff.b A_2)
    {
        if (a(A_0, A_2))
        {
            switch (A_2)
            {
                case ff.b.a:
                    return e(A_0, A_1);

                case ff.b.b:
                    return d(A_0, A_1);
            }
        }
        return null;
    }

    public static IView c(PluginHost A_0, string A_1)
    {
        if (a(A_0, ff.b.b))
        {
            return a(A_0, A_1, ff.b.b);
        }
        return a(A_0, A_1, ff.b.a);
    }

    private static IView d(PluginHost A_0, string A_1)
    {
        IView view = new View();
        view.Initialize(A_0, A_1);
        return view;
    }

    private static IView e(PluginHost A_0, string A_1)
    {
        IView view = new View();
        view.Initialize(A_0, A_1);
        return view;
    }

    public static IView f(PluginHost A_0, string A_1)
    {
        if (a(A_0, ff.b.b))
        {
            return b(A_0, A_1, ff.b.b);
        }
        return b(A_0, A_1, ff.b.a);
    }

    public delegate void a(object A_0);

    public enum b
    {
        a,
        b
    }
}

