using Decal.Adapter.Wrappers;
using Decal.Interop.Filters;
using System;
using System.Runtime.InteropServices;
using uTank2;

internal static class c8
{
    private static bool a;
    private static int b;
    private static int c;
    private static string d;

    public static void a()
    {
        if (dh.d() != 1)
        {
            dh.a(1);
        }
        else if (a)
        {
            PluginCore.cq.y.a(b, c, d);
        }
        else
        {
            PluginCore.cq.av.a(b, e5.a, false);
        }
    }

    public static bool a(a1 A_0, eDamageElement A_1, int A_2, ePrismaticDamageBehavior A_3)
    {
        int num;
        SkillInfo info;
        b = 0;
        c = 0;
        a = false;
        if (PluginCore.cq.x.e())
        {
            num = 0;
            switch (A_0)
            {
                case a1.e:
                    num = 0x2f;
                    goto Label_0057;

                case a1.f:
                    num = 0x2f;
                    goto Label_0057;

                case a1.g:
                    num = 0x2f;
                    goto Label_0057;
            }
            b();
        }
        return false;
    Label_0057:
        info = null;
        eTrainingType type = 1;
        int num2 = 0;
        try
        {
            info = PluginCore.cq.aw.get_CharacterFilter().get_Underlying().get_Skill((eSkillID) num);
            type = info.get_Training();
            num2 = info.get_Base();
        }
        finally
        {
            if (info != null)
            {
                Marshal.ReleaseComObject(info);
            }
        }
        string str = "";
        if ((PluginCore.cq.av.g() != 0) && (PluginCore.cq.aw.get_WorldFilter().get_Item(PluginCore.cq.av.g()).Values(0xd000006, 0) > A_2))
        {
            str = PluginCore.cq.aw.get_WorldFilter().get_Item(PluginCore.cq.av.g()).get_Name();
        }
        int num3 = er.e("UseSpecialAmmo");
        int num4 = -2147483648;
        bool flag = true;
        foreach (v v in PluginCore.cq.x.c["AmmunitionOptions"].d())
        {
            eDamageElement prismatic = (eDamageElement) k.e(v.a("Element"));
            if (prismatic == eDamageElement.PrismaticDatabaseEntryOld)
            {
                prismatic = eDamageElement.Prismatic;
            }
            if (k.e(v.a("LauncherType")) == A_0)
            {
                int num5 = k.e(v.a("Quality"));
                if ((A_3 == ePrismaticDamageBehavior.ForcePrismatic) && (prismatic != eDamageElement.Prismatic))
                {
                    num5 -= 0x3e8;
                }
                if (prismatic != A_1)
                {
                    if (prismatic != eDamageElement.Prismatic)
                    {
                        continue;
                    }
                    bool flag2 = true;
                    switch (A_3)
                    {
                        case ePrismaticDamageBehavior.Any:
                            flag2 = true;
                            break;

                        case ePrismaticDamageBehavior.NoPrismatic:
                            flag2 = false;
                            break;

                        case ePrismaticDamageBehavior.ForcePrismatic:
                            flag2 = true;
                            break;
                    }
                    if (!flag2)
                    {
                        num5 -= 0x3e8;
                    }
                }
                if (num5 >= num4)
                {
                    string str2 = k.b(v.a("AmmoName"));
                    int num6 = k.e(v.a("WieldReq"));
                    if ((num6 <= 0) || (((type != 1) && (type != null)) && (num2 >= num6)))
                    {
                        int num7 = k.e(v.a("WieldReq2Skill"));
                        int num8 = k.e(v.a("WieldReq2Value"));
                        if ((num7 != 0) && (num8 != 0))
                        {
                            SkillType type2 = (SkillType) (num7 + 50);
                            if ((PluginCore.cq.ax.get_Actions().get_SkillTrainLevel().get_Item(type2) == 0) || (PluginCore.cq.ax.get_Actions().get_Skill().get_Item(type2) < num8))
                            {
                                continue;
                            }
                        }
                        int num9 = k.e(v.a("Special"));
                        if ((num9 == 0) || ((num9 & num3) != 0))
                        {
                            if (str == str2)
                            {
                                b = 1;
                                flag = true;
                                num4 = num5;
                            }
                            else
                            {
                                int num10 = A_2;
                                if (num10 < 1)
                                {
                                    num10 = 1;
                                }
                                if (dh.a(str2) >= num10)
                                {
                                    num4 = num5;
                                    a = false;
                                    flag = false;
                                    b = dh.c(str2);
                                }
                                else
                                {
                                    MyPair<int, int> pair = PluginCore.cq.y.a(str2, num10);
                                    if (pair != null)
                                    {
                                        num4 = num5;
                                        flag = false;
                                        a = true;
                                        d = str2;
                                        b = pair.a;
                                        c = pair.b;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return !flag;
    }

    private static void b()
    {
        b = 0;
        c = 0;
        a = false;
    }

    public static bool b(a1 A_0, eDamageElement A_1, int A_2, ePrismaticDamageBehavior A_3)
    {
        return (a(A_0, A_1, A_2, A_3) || (b != 0));
    }
}

