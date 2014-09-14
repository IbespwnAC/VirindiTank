using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uTank2;

internal static class er
{
    private static bool a;
    [CompilerGenerated]
    private static Comparison<v> b;

    public static void a()
    {
        if (!a)
        {
            a = true;
            PluginCore.cq.ay.av();
            PluginCore.cq.ay.y();
            PluginCore.cq.ay.ac();
            PluginCore.cq.ay.n();
            PluginCore.cq.ay.ad();
            PluginCore.cq.ay.x();
            PluginCore.cq.ay.v();
            PluginCore.cq.ac.d();
            a = false;
        }
    }

    public static eSettingCategories a(string A_0)
    {
        eSettingCategories categories;
        try
        {
            categories = (eSettingCategories) k.e(PluginCore.cq.l.b["SettingsCategories"].a(0, k.a(A_0))[1]);
        }
        catch (Exception exception)
        {
            throw new Exception("Error getting setting from database", exception);
        }
        return categories;
    }

    public static string a(eDamageElement A_0)
    {
        switch (A_0)
        {
            case eDamageElement.Pierce:
                return "Pierce";

            case eDamageElement.Bludgeon:
                return "Bludgeon";

            case eDamageElement.Slash:
                return "Slash";

            case eDamageElement.Acid:
                return "Acid";

            case eDamageElement.Lightning:
                return "Lightning";

            case eDamageElement.Cold:
                return "Cold";

            case eDamageElement.Fire:
                return "Fire";

            case eDamageElement.Harm:
                return "Harm";

            case eDamageElement.Auto:
                return "Auto";

            case eDamageElement.Void:
                return "Void Basic";

            case eDamageElement.DrainAuto:
                return "Drain Auto";

            case eDamageElement.Prismatic:
                return "Prismatic";

            case eDamageElement.Random:
                return "Random";

            case eDamageElement.Fists:
                return "Fists";

            case eDamageElement.None:
                return "None";

            case eDamageElement.Physical:
                return "Physical";
        }
        return "?";
    }

    public static List<string> a(eSettingCategories A_0)
    {
        List<string> list = new List<string>();
        foreach (v v in PluginCore.cq.l.b["SettingsCategories"].d())
        {
            if ((k.e(v[1]) & A_0) > 0)
            {
                list.Add(k.b(v[0]));
            }
        }
        return list;
    }

    public static void a(string A_0, k A_1)
    {
        try
        {
            v v = PluginCore.cq.l.c["Settings"].a(0, k.a(A_0));
            if (v == null)
            {
                v v2 = new v(PluginCore.cq.l.c["Settings"]);
                v2[0] = k.a(A_0);
                v2[1] = A_1;
                PluginCore.cq.l.c["Settings"].c(v2);
            }
            else
            {
                v[1] = A_1;
            }
        }
        catch (Exception exception)
        {
            throw new Exception("Error applying setting to database", exception);
        }
    }

    public static int a(string A_0, int A_1)
    {
        int num3;
        try
        {
            MyList<v> list = PluginCore.cq.l.b["SettingsEnumInfo"].b(0, k.a(A_0));
            if (b == null)
            {
                b = new Comparison<v>(er.a);
            }
            list.Sort(b);
            int num = -1;
            int num2 = 0;
            foreach (v v in list)
            {
                if (k.e(v[1]) == A_1)
                {
                    num = num2;
                    break;
                }
                num2++;
            }
            num++;
            if (num >= list.Count)
            {
                num = 0;
            }
            num3 = k.e(list[num][1]);
        }
        catch (Exception exception)
        {
            throw new Exception("Error getting setting from database", exception);
        }
        return num3;
    }

    public static int a(string A_0, string A_1)
    {
        int num;
        try
        {
            foreach (v v in PluginCore.cq.l.b["SettingsEnumInfo"].d())
            {
                if ((k.b(v[0]) == A_0) && (k.b(v[2]) == A_1))
                {
                    return k.e(v[1]);
                }
            }
            throw new Exception();
        }
        catch (Exception exception)
        {
            throw new Exception("Error getting setting from database", exception);
        }
        return num;
    }

    [CompilerGenerated]
    private static int a(v A_0, v A_1)
    {
        return k.e(A_0[1]).CompareTo(k.e(A_1[1]));
    }

    public static eSettingValueType b(string A_0)
    {
        eSettingValueType type;
        try
        {
            v v = PluginCore.cq.l.b["Settings"].a(0, k.a(A_0));
            if (v == null)
            {
                throw new Exception("Setting not found in default database");
            }
            type = (eSettingValueType) k.e(v[3]);
        }
        catch (Exception exception)
        {
            throw new Exception("Error getting setting from database", exception);
        }
        return type;
    }

    public static void b(string A_0, k A_1)
    {
        try
        {
            v v = PluginCore.cq.l.c["Settings"].a(0, k.a(A_0));
            if (v == null)
            {
                v v2 = new v(PluginCore.cq.l.c["Settings"]);
                v2[0] = k.a(A_0);
                v2[1] = A_1;
                PluginCore.cq.l.c["Settings"].c(v2);
            }
            else
            {
                v[1] = A_1;
            }
            PluginCore.cq.l.d();
            a();
        }
        catch (Exception exception)
        {
            throw new Exception("Error applying setting to database", exception);
        }
    }

    public static string b(string A_0, int A_1)
    {
        string str;
        try
        {
            foreach (v v in PluginCore.cq.l.b["SettingsEnumInfo"].d())
            {
                if ((k.b(v[0]) == A_0) && (k.e(v[1]) == A_1))
                {
                    return k.b(v[2]);
                }
            }
            str = "???";
        }
        catch (Exception exception)
        {
            throw new Exception("Error getting setting from database", exception);
        }
        return str;
    }

    public static bool b(string A_0, string A_1)
    {
        return (e(A_0) == a(A_0, A_1));
    }

    public static string c(string A_0)
    {
        string str;
        try
        {
            v v = PluginCore.cq.l.b["Settings"].a(0, k.a(A_0));
            if (v == null)
            {
                throw new Exception("Setting not found in default database");
            }
            str = k.b(v[2]);
        }
        catch (Exception exception)
        {
            throw new Exception("Error getting setting from database", exception);
        }
        return str;
    }

    public static k d(string A_0)
    {
        k k;
        try
        {
            v v = PluginCore.cq.l.c["Settings"].a(0, k.a(A_0));
            if (v == null)
            {
                v = PluginCore.cq.l.b["Settings"].a(0, k.a(A_0));
                if (v == null)
                {
                    throw new Exception("Setting not found in default database");
                }
            }
            k = v[1];
        }
        catch (Exception exception)
        {
            throw new Exception("Error getting setting from database", exception);
        }
        return k;
    }

    public static int e(string A_0)
    {
        return k.e(d(A_0));
    }

    public static string f(string A_0)
    {
        return k.b(d(A_0));
    }

    public static float g(string A_0)
    {
        return k.c(d(A_0));
    }

    public static double h(string A_0)
    {
        return k.f(d(A_0));
    }

    public static int i(string A_0)
    {
        return k.e(d(A_0));
    }

    public static bool j(string A_0)
    {
        return k.a(d(A_0));
    }
}

