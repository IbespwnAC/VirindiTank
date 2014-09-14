using System;
using System.Reflection;
using VirindiHotkeySystem;

internal static class cy
{
    private static bool a()
    {
        return VHotkeySystem.get_Running();
    }

    public static bool b()
    {
        try
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            bool flag = false;
            foreach (Assembly assembly in assemblies)
            {
                AssemblyName name = assembly.GetName();
                if ((name.Name == "VirindiHotkeySystem") && (name.Version >= new Version("1.0.0.0")))
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
}

