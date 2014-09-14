using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using uTank2;

internal static class a8
{
    public static int a()
    {
        MySpell spell = PluginCore.cq.h.b("Heal Self I");
        if (spell == null)
        {
            return 0;
        }
        string name = spell.Name;
        if (name != null)
        {
            int num;
            if (bx.f == null)
            {
                Dictionary<string, int> dictionary1 = new Dictionary<string, int>(8);
                dictionary1.Add("Heal Self I", 0);
                dictionary1.Add("Heal Self II", 1);
                dictionary1.Add("Heal Self III", 2);
                dictionary1.Add("Heal Self IV", 3);
                dictionary1.Add("Heal Self V", 4);
                dictionary1.Add("Heal Self VI", 5);
                dictionary1.Add("Adja's Intervention", 6);
                dictionary1.Add("Incantation of Heal Self", 7);
                bx.f = dictionary1;
            }
            if (bx.f.TryGetValue(name, out num))
            {
                switch (num)
                {
                    case 0:
                        return 0x11;

                    case 1:
                        return 0x19;

                    case 2:
                        return 0x20;

                    case 3:
                        return 0x2d;

                    case 4:
                        return 0x43;

                    case 5:
                        return 0x57;

                    case 6:
                        return 0x73;

                    case 7:
                        return 0x87;
                }
            }
        }
        return 10;
    }

    private static ActionLockType a(eRechargeVital_Single A_0)
    {
        switch (A_0)
        {
            case eRechargeVital_Single.Stamina:
                return ActionLockType.RechargeLevelBoost_Stam;

            case eRechargeVital_Single.Mana:
                return ActionLockType.RechargeLevelBoost_Mana;
        }
        return ActionLockType.RechargeLevelBoost_HP;
    }

    public static void a(eRechargeVital_Single A_0, int A_1)
    {
        ActionLockType type = a(A_0);
        if (!PluginCore.cq.n.a(8, A_1, false))
        {
            PluginCore.cq.n.n.a(type, TimeSpan.FromSeconds(er.h("RechargeBoostTimeSeconds")));
        }
        if (PluginCore.cq.ax.get_Actions().get_CombatMode() == 8)
        {
            PluginCore.cq.n.n.a(type);
            PluginCore.cq.z.a(A_1, PluginCore.cg);
        }
    }

    public static void a(eRechargeVital_Single A_0, MySpell A_1)
    {
        ActionLockType type = a(A_0);
        if (!PluginCore.cq.n.a(8, 0, true))
        {
            PluginCore.cq.n.n.a(type, TimeSpan.FromSeconds(er.h("RechargeBoostTimeSeconds")));
        }
        if (PluginCore.cq.ax.get_Actions().get_CombatMode() == 8)
        {
            PluginCore.cq.n.n.a(type);
            PluginCore.cq.g.a(A_1, PluginCore.cg);
        }
    }

    public static int a(MySpell A_0, eRechargeVital_Single A_1)
    {
        double num = 0.5;
        int num2 = 0x7fffffff;
        int num3 = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(cRechargeManager.eRechargeVital_SingleToHooksType(A_1, true));
        if (A_1 == eRechargeVital_Single.Mana)
        {
            num3 -= 30;
            if (num3 < 0)
            {
                num3 = 0;
            }
        }
        if (A_0.Name.EndsWith(" I"))
        {
            num = 0.9;
            num2 = 50;
        }
        else if (A_0.Name.EndsWith(" II"))
        {
            num = 1.0;
            num2 = 100;
        }
        else if (A_0.Name.EndsWith(" III"))
        {
            num = 1.1;
            num2 = 150;
        }
        else if (A_0.Name.EndsWith(" IV"))
        {
            num = 1.2;
            num2 = 200;
        }
        else if (A_0.Name.EndsWith(" V"))
        {
            num = 1.35;
            num2 = 0x7fffffff;
        }
        else if (A_0.Name.EndsWith(" VI"))
        {
            num = 1.5;
            num2 = 0x7fffffff;
        }
        else if (A_0.Name.StartsWith("Incantation of "))
        {
            num = 1.75;
            num2 = 0x7fffffff;
        }
        else
        {
            num = 1.75;
            num2 = 0x7fffffff;
        }
        int num4 = (int) Math.Floor((double) (num3 * num));
        if (num4 > num2)
        {
            num4 = num2;
        }
        return num4;
    }

    public static void a(MySpell A_0, out MySpell A_1, out int A_2)
    {
        A_1 = null;
        A_2 = 0;
        if (A_0 != null)
        {
            foreach (int num in PluginCore.PC.c1)
            {
                cv cv = PluginCore.cq.p.d(num);
                if ((((cv != null) && (cv.c() == ObjectClass.WandStaffOrb)) && ((PluginCore.cq.p.f(num) == PluginCore.cg) && dh.b(num))) && PluginCore.cq.z.a(num))
                {
                    int i = cv.i;
                    MySpell p = PluginCore.cq.e.b(i);
                    if (((p != null) && A_0.SameCompClass(p)) && ((A_1 == null) || (A_1.Quality < p.Quality)))
                    {
                        A_1 = p;
                        A_2 = num;
                    }
                }
            }
        }
    }
}

