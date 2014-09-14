using Decal.Adapter;
using Decal.Adapter.Wrappers;
using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using uTank2;

internal class fn : IDisposable
{
    public bool a;
    public bool b;
    public int c;
    public int d;
    public MyList<int> e = new MyList<int>(0x41);
    public MyDictionary<int, cf> f = new MyDictionary<int, cf>(0x42);
    public MyDictionary<int, eLootAction> g = new MyDictionary<int, eLootAction>(0x44);
    public MySortedList<int, int> h = new MySortedList<int, int>(0x45);
    public MyList<int> i = new MyList<int>(70);
    public TimeSpan j = TimeSpan.FromSeconds(0.75);
    public bool k;
    public int l;
    public bool m;
    public as n = new as();
    public e8 o;
    public double p = 0.25;
    public int q;
    public int r;
    public MyDictionary<int, fn.a> s = new MyDictionary<int, fn.a>(0x47);
    private Dictionary<a1, Dictionary<eDamageElement, bool>> t = new Dictionary<a1, Dictionary<eDamageElement, bool>>();
    private ulong u;
    private WorldFilter v;
    private CharacterFilter w;
    private bool x;

    public fn(CoreManager A_0, cj A_1)
    {
        this.v = A_0.get_WorldFilter();
        this.w = A_0.get_CharacterFilter();
        A_1.f(new cj.c(this.c));
        A_1.d(new cj.c(this.a));
        A_1.g(new cj.c(this.b));
        this.w.add_ChangeVital(new EventHandler<ChangeVitalEventArgs>(this.a));
    }

    private int a()
    {
        foreach (int num in PluginCore.cq.j.e())
        {
            if ((dh.b(num) && (dh.c(num) == PluginCore.cg)) && (this.c(num) == a1.b))
            {
                return num;
            }
        }
        return 0;
    }

    private void a(cv A_0)
    {
        try
        {
            if ((((A_0.c() == ObjectClass.WandStaffOrb) || (A_0.c() == ObjectClass.MeleeWeapon)) || ((A_0.c() == ObjectClass.MissileWeapon) || (A_0.c() == ObjectClass.Armor))) && PluginCore.cq.j.e().Contains(A_0.k))
            {
                er.a();
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public bool a(CharFilterVitalType A_0)
    {
        TrainingType type = PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(0x15).get_Training();
        bool flag = (type == 3) || (type == 2);
        int num = 0;
        int num2 = 0;
        int num3 = 0x7fffffff;
        int num4 = 0x7fffffff;
        foreach (KeyValuePair<string, fz> pair in PluginCore.cq.l.h)
        {
            if (this.a(pair.Value, A_0))
            {
                MyList<int> list = dh.d(pair.Key);
                if (this.a(pair.Value))
                {
                    foreach (int num5 in list)
                    {
                        int num6 = PluginCore.cq.aw.get_WorldFilter().get_Item(num5).Values(0x5c);
                        if (num6 < num3)
                        {
                            num = num5;
                            num3 = num6;
                        }
                    }
                }
                else
                {
                    foreach (int num7 in list)
                    {
                        int num8 = PluginCore.cq.aw.get_WorldFilter().get_Item(num7).Values(0xd000006);
                        if (num8 < num4)
                        {
                            num2 = num7;
                            num4 = num8;
                        }
                    }
                }
            }
        }
        if ((flag && (num != 0)) && (ao.a(A_0) > 0x21))
        {
            int num9 = PluginCore.cq.ax.get_Actions().get_CurrentSelection();
            PluginCore.cq.ax.get_Actions().SelectItem(PluginCore.cq.aw.get_CharacterFilter().get_Id());
            PluginCore.cq.ax.get_Actions().UseItem(num, 1);
            PluginCore.cq.ax.get_Actions().SelectItem(num9);
            return true;
        }
        if (num2 != 0)
        {
            PluginCore.cq.ax.get_Actions().UseItem(num2, 0);
            return true;
        }
        return false;
    }

    public CombatState a(ObjectClass A_0)
    {
        CombatState state = 8;
        ObjectClass class2 = A_0;
        if (class2 != 1)
        {
            if (class2 != 9)
            {
                if (class2 != 0x1f)
                {
                    return state;
                }
                return 8;
            }
        }
        else
        {
            return 2;
        }
        return 4;
    }

    public static bool a(WorldObject A_0)
    {
        if (A_0 == null)
        {
            return false;
        }
        string str = A_0.Values(0x19, "");
        cv cv = PluginCore.cq.p.d(PluginCore.cg);
        if ((!string.IsNullOrEmpty(str) && (cv != null)) && !string.Equals(str, cv.g()))
        {
            return false;
        }
        int num = A_0.Values(0x9e, 0);
        int num2 = A_0.Values(0x9f, 0);
        int num3 = A_0.Values(160, 0);
        return a(num, num2, num3, A_0.get_Name());
    }

    private bool a(fz A_0)
    {
        switch (A_0)
        {
            case fz.a:
                return true;

            case fz.b:
                return false;

            case fz.c:
                return true;

            case fz.d:
                return false;

            case fz.e:
                return true;

            case fz.f:
                return false;
        }
        return false;
    }

    public CombatState a(ObjectClass A_0)
    {
        return this.a((ObjectClass) A_0);
    }

    public static bool a(int A_0)
    {
        WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0);
        if (obj2 == null)
        {
            return false;
        }
        return c(obj2);
    }

    public bool a(a1 A_0, eDamageElement A_1)
    {
        if (this.u != e3.b())
        {
            this.t.Clear();
            this.u = e3.b();
        }
        if (((A_0 == a1.e) || (A_0 == a1.f)) || (A_0 == a1.g))
        {
            bool flag;
            if (!this.t.ContainsKey(A_0))
            {
                this.t.Add(A_0, new Dictionary<eDamageElement, bool>());
            }
            if (this.t[A_0].ContainsKey(A_1))
            {
                flag = this.t[A_0][A_1];
            }
            else
            {
                flag = c8.b(A_0, A_1, 1, ePrismaticDamageBehavior.Any);
                this.t[A_0][A_1] = flag;
            }
            if (!flag)
            {
                ai.a("Warning: bow with element " + A_1.ToString() + " ignored because ammunition is not available.");
                return false;
            }
        }
        return true;
    }

    public static SkillType a(CharFilterSkillType A_0, bool A_1)
    {
        if (A_1)
        {
            return A_0;
        }
        return (A_0 + 50);
    }

    private bool a(fz A_0, CharFilterVitalType A_1)
    {
        switch (A_0)
        {
            case fz.a:
                if (A_1 != 2)
                {
                    return false;
                }
                return true;

            case fz.b:
                if (A_1 != 2)
                {
                    return false;
                }
                return true;

            case fz.c:
                if (A_1 != 4)
                {
                    return false;
                }
                return true;

            case fz.d:
                if (A_1 != 4)
                {
                    return false;
                }
                return true;

            case fz.e:
                if (A_1 != 6)
                {
                    return false;
                }
                return true;

            case fz.f:
                if (A_1 != 6)
                {
                    return false;
                }
                return true;
        }
        return false;
    }

    public void a(int A_0, bool A_1)
    {
        if (!A_1 || !dh.b(A_0))
        {
            return;
        }
        fn.a a = new fn.a();
        WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0);
        a.b = (eImbueType) obj2.Values(0xb3, 0);
        a.c = (eCleaveType) obj2.Values(0x107, 0);
        a.a = obj2.Values(0xa6, 0);
        a.e = obj2.Values(0xd000020, 0);
        if (PluginCore.cq.p.d(A_0) != null)
        {
            a.i = PluginCore.cq.p.d(A_0).a(dt.cd, 0);
        }
        a.h = obj2.Values(0x6a, 0);
        a.g = null;
        if (obj2.get_ObjectClass() == 0x1f)
        {
            a.g = PluginCore.cq.e.b(obj2.Values(0xd000008, 0));
        }
        else if (((obj2.get_ObjectClass() == 1) || (obj2.get_ObjectClass() == 9)) && (obj2.get_SpellCount() > 0))
        {
            MySpell spell = PluginCore.cq.e.b(obj2.Spell(0));
            if ((((spell != null) && !spell.isUntargetted) && ((spell.School.SkillId != 0x20) && (spell.School.SkillId != 0x22))) && spell.isOffensive)
            {
                a.g = spell;
            }
        }
        a.d = (obj2.get_ObjectClass() == 1) && (obj2.Values(0xd000021, 0) == 3);
        a.f = (obj2.Values(0x2f, 0) & 0x40) > 0;
        ObjectClass class2 = obj2.get_ObjectClass();
        if ((class2 != 1) && (class2 != 9))
        {
            if (class2 != 0x1f)
            {
                a.j = eProtocolDamageType.None;
            }
            else
            {
                a.j = (eProtocolDamageType) obj2.Values(0x2d, 0);
            }
        }
        else
        {
            a.j = (eProtocolDamageType) obj2.Values(0xd000021, 0);
        }
        if (obj2.get_ObjectClass() == 1)
        {
            a.k = obj2.Values(0x124, 1);
        }
        else
        {
            a.k = 1;
        }
        if (e(obj2))
        {
            a.l = obj2.Values(0x171, 0);
            a.m = obj2.Values(0x16f, 0);
            switch (obj2.Values(0xd000010, 0))
            {
                case 0x40:
                    a.n = eDamageElement.Lightning;
                    goto Label_029A;

                case 0x80:
                    a.n = eDamageElement.Cold;
                    goto Label_029A;

                case 0x100:
                    a.n = eDamageElement.Acid;
                    goto Label_029A;

                case 1:
                    a.n = eDamageElement.Bludgeon;
                    goto Label_029A;

                case 0x20:
                    a.n = eDamageElement.Fire;
                    goto Label_029A;
            }
            a.n = eDamageElement.Bludgeon;
        }
    Label_029A:
        this.s[A_0] = a;
    }

    private void a(object A_0, ChangeVitalEventArgs A_1)
    {
        try
        {
            PluginCore.cq.c.SchedulePoke();
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void a(string A_0, e8 A_1)
    {
        if ((PluginCore.cq.n.o & A_1) > e8.a)
        {
            a5.a(eChatType.Logging, A_0);
        }
    }

    public bool a(CombatState A_0, int A_1, bool A_2)
    {
        return this.a(A_0, A_1, A_2, eDamageElement.None, ePrismaticDamageBehavior.Any);
    }

    public eDamageElement a(eImbueType A_0, eCleaveType A_1, eProtocolDamageType A_2)
    {
        switch ((A_0 & (eImbueType.FireRend | eImbueType.LightningRend | eImbueType.ColdRend | eImbueType.AcidRend | eImbueType.BludgeonRend | eImbueType.PierceRend | eImbueType.SlashRend | eImbueType.ArmorRend | eImbueType.CripplingBlow | eImbueType.CriticalStrike)))
        {
            case eImbueType.SlashRend:
                return eDamageElement.Slash;

            case eImbueType.PierceRend:
                return eDamageElement.Pierce;

            case eImbueType.BludgeonRend:
                return eDamageElement.Bludgeon;

            case eImbueType.AcidRend:
                return eDamageElement.Acid;

            case eImbueType.ColdRend:
                return eDamageElement.Cold;

            case eImbueType.LightningRend:
                return eDamageElement.Lightning;

            case eImbueType.FireRend:
                return eDamageElement.Fire;
        }
        if ((A_1 & eCleaveType.AcidCleaving) > 0)
        {
            return eDamageElement.Acid;
        }
        if ((A_1 & eCleaveType.BludgeCleaving) > 0)
        {
            return eDamageElement.Bludgeon;
        }
        if ((A_1 & eCleaveType.ColdCleaving) > 0)
        {
            return eDamageElement.Cold;
        }
        if ((A_1 & eCleaveType.FireCleaving) > 0)
        {
            return eDamageElement.Fire;
        }
        if ((A_1 & eCleaveType.LightningCleaving) > 0)
        {
            return eDamageElement.Lightning;
        }
        if ((A_1 & eCleaveType.PierceCleaving) > 0)
        {
            return eDamageElement.Pierce;
        }
        if ((A_1 & eCleaveType.SlashCleaving) > 0)
        {
            return eDamageElement.Slash;
        }
        if ((A_2 & eProtocolDamageType.Acid) > eProtocolDamageType.None)
        {
            return eDamageElement.Acid;
        }
        if ((A_2 & eProtocolDamageType.Bludge) > eProtocolDamageType.None)
        {
            return eDamageElement.Bludgeon;
        }
        if ((A_2 & eProtocolDamageType.Cold) > eProtocolDamageType.None)
        {
            return eDamageElement.Cold;
        }
        if ((A_2 & eProtocolDamageType.Fire) > eProtocolDamageType.None)
        {
            return eDamageElement.Fire;
        }
        if ((A_2 & eProtocolDamageType.Lightning) > eProtocolDamageType.None)
        {
            return eDamageElement.Lightning;
        }
        if ((A_2 & eProtocolDamageType.Pierce) > eProtocolDamageType.None)
        {
            return eDamageElement.Pierce;
        }
        if ((A_2 & eProtocolDamageType.Slash) > eProtocolDamageType.None)
        {
            return eDamageElement.Slash;
        }
        if ((A_2 & eProtocolDamageType.Nether) > eProtocolDamageType.None)
        {
            return eDamageElement.Void;
        }
        return eDamageElement.None;
    }

    private int a(int A_0, an A_1, aj.c A_2, int A_3)
    {
        int num = 0;
        if (!dh.a(A_0))
        {
            return num;
        }
        cv cv = PluginCore.cq.p.d(A_0);
        a1 a = PluginCore.cq.n.c(A_0);
        if ((a != a1.h) && (a != a1.c))
        {
            return num;
        }
        bool flag = false;
        if ((cv.a(dt.c1, 0) & 0x2000000) > 0)
        {
            flag = true;
        }
        if (flag)
        {
            return num;
        }
        switch (A_2.d)
        {
            case eSecondaryEquipTypeOrObjectID.Auto:
            {
                bool flag2 = dh.b(eGameSkillID.Shield);
                bool flag3 = dh.b(eGameSkillID.DualWield);
                if (!flag2 || flag3)
                {
                    if (!flag2 && flag3)
                    {
                        return this.a(A_0, A_1, A_3, true);
                    }
                    if (!flag2 && !flag3)
                    {
                        num = this.b();
                        if (num == 0)
                        {
                            num = this.a(A_0, A_1, A_3, true);
                        }
                        return num;
                    }
                    num = this.b();
                    if (num == 0)
                    {
                        num = this.a(A_0, A_1, A_3, true);
                    }
                    return num;
                }
                return this.b();
            }
            case eSecondaryEquipTypeOrObjectID.AutoShield:
                return this.b();

            case eSecondaryEquipTypeOrObjectID.AutoWeapon:
                return this.a(A_0, A_1, A_3, true);

            case eSecondaryEquipTypeOrObjectID.None:
                return 0;
        }
        return (int) A_2.d;
    }

    private int a(int A_0, an A_1, int A_2, bool A_3)
    {
        MyDictionary<eDamageElement, int> dictionary = new MyDictionary<eDamageElement, int>(0x3f);
        MyDictionary<eDamageElement, int> dictionary2 = new MyDictionary<eDamageElement, int>(0x3f);
        MyDictionary<eDamageElement, int> dictionary3 = new MyDictionary<eDamageElement, int>(0x3f);
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        an an = new an();
        an an2 = new an();
        an an3 = new an();
        int num4 = 0;
        foreach (int num5 in PluginCore.cq.j.e())
        {
            if (((num5 != A_0) && dh.b(num5)) && (dh.c(num5) == PluginCore.cg))
            {
                if (b(PluginCore.cq.aw.get_WorldFilter().get_Item(num5)))
                {
                    a1 a = PluginCore.cq.n.c(num5);
                    if (a != a1.i)
                    {
                        eItemUseSpecifier specifier = this.e(num5);
                        if (((!A_3 || ((specifier & eItemUseSpecifier.WEAP_LeftHand) != eItemUseSpecifier.WEAP_DONOTUSE)) && (A_3 || ((specifier & eItemUseSpecifier.WEAP_RightHand) != eItemUseSpecifier.WEAP_DONOTUSE))) && (!A_3 || ((a == a1.c) && ((PluginCore.cq.aw.get_WorldFilter().get_Item(num5).Values(0xd00000e, 0) & 0x2000000) <= 0))))
                        {
                            fn.a a2 = this.d(num5);
                            if (a == a1.b)
                            {
                                num4 = num5;
                                if ((dh.b(eGameSkillID.WarMagic) || dh.b(eGameSkillID.VoidMagic)) && (a2.a == A_2))
                                {
                                    num = num5;
                                }
                                if ((a2.j & eProtocolDamageType.Nether) > eProtocolDamageType.None)
                                {
                                    if (!dh.b(eGameSkillID.VoidMagic))
                                    {
                                        continue;
                                    }
                                    dictionary[eDamageElement.Void] = num5;
                                    an.Add(eDamageElement.Void);
                                }
                                else if (!dh.b(eGameSkillID.WarMagic))
                                {
                                    continue;
                                }
                            }
                            switch (a)
                            {
                                case a1.e:
                                case a1.f:
                                case a1.g:
                                    num3 = num5;
                                    break;
                            }
                            if (((a == a1.c) || (a == a1.e)) || (((a == a1.f) || (a == a1.g)) || (a == a1.b)))
                            {
                                if (a2.a == A_2)
                                {
                                    num = num5;
                                }
                                eDamageElement element = this.a(a2.b, a2.c, eProtocolDamageType.None);
                                if ((element != eDamageElement.None) && this.a(a, element))
                                {
                                    dictionary[element] = num5;
                                    an.Add(element);
                                }
                                element = this.a(a2.b, a2.c, a2.j);
                                if ((element != eDamageElement.None) && this.a(a, element))
                                {
                                    dictionary3[element] = num5;
                                    an3.Add(element);
                                }
                                if (((a2.b == eImbueType.ArmorRend) || (a2.b == eImbueType.CriticalStrike)) || (a2.b == eImbueType.CripplingBlow))
                                {
                                    if (this.a(a, element))
                                    {
                                        dictionary2[element] = num5;
                                        an2.Add(element);
                                    }
                                    num2 = num5;
                                }
                                num4 = num5;
                            }
                        }
                    }
                }
                else
                {
                    ai.a("Warning: GFDI ignoring item " + PluginCore.cq.aw.get_WorldFilter().get_Item(num5).get_Name() + " because it cannot currently be wielded.");
                }
            }
        }
        if (num != 0)
        {
            return num;
        }
        eDamageElement element2 = A_1.b(an);
        if (element2 != eDamageElement.None)
        {
            return dictionary[element2];
        }
        if (an.Contains(eDamageElement.Void))
        {
            return dictionary[eDamageElement.Void];
        }
        element2 = A_1.b(an2);
        if (element2 != eDamageElement.None)
        {
            return dictionary2[element2];
        }
        if (num2 != 0)
        {
            return num2;
        }
        element2 = A_1.b(an3);
        if (element2 != eDamageElement.None)
        {
            return dictionary3[element2];
        }
        if (num3 != 0)
        {
            return num3;
        }
        ai.a("Warning: no weapons found that can be autoselected for current target. Add some weapons to the items list!");
        return num4;
    }

    public static bool a(int A_0, int A_1, int A_2, string A_3)
    {
        return c(A_0, A_1, A_2, A_3);
    }

    public bool a(CombatState A_0, int A_1, bool A_2, eDamageElement A_3, ePrismaticDamageBehavior A_4)
    {
        return this.a(A_0, A_1, A_2, A_3, A_4, this.b());
    }

    public bool a(CombatState A_0, int A_1, bool A_2, eDamageElement A_3, ePrismaticDamageBehavior A_4, int A_5)
    {
        try
        {
            bool flag2;
            if (PluginCore.cq.ax.get_Actions().get_BusyState() != 0)
            {
                return false;
            }
            int num = A_1;
            if (!dh.b(num) || (dh.c(num) != PluginCore.cg))
            {
                num = 0;
            }
            else if (!b(PluginCore.cq.aw.get_WorldFilter().get_Item(num)))
            {
                ai.a("Warning: FCM ignoring item " + PluginCore.cq.aw.get_WorldFilter().get_Item(num).get_Name() + " because it cannot currently be wielded.");
                num = 0;
            }
            if ((A_2 || (A_1 == 0)) && ((PluginCore.cq.av.d() != 0) && (this.a(PluginCore.cq.aw.get_WorldFilter().get_Item(PluginCore.cq.av.d()).get_ObjectClass()) == A_0)))
            {
                num = PluginCore.cq.av.d();
            }
            if (num == 0)
            {
                num = this.a();
                if (num == 0)
                {
                    a5.a(eChatType.Errors, "You must add at least one wand to your profile.");
                    PluginCore.cq.c.StopMacro();
                    return false;
                }
            }
            bool flag = dh.a(A_5);
            int num2 = A_5;
            if (num2 == num)
            {
                flag = false;
                num2 = 0;
            }
            else if (dh.a(num))
            {
                cv cv = PluginCore.cq.p.d(num);
                switch (PluginCore.cq.n.c(num))
                {
                    case a1.h:
                    case a1.c:
                        if ((cv.a(dt.c1, 0) & 0x2000000) > 0)
                        {
                            flag = false;
                            num2 = 0;
                        }
                        goto Label_0175;
                }
                flag = false;
                num2 = 0;
            }
        Label_0175:
            flag2 = c8.a(this.c(num), A_3, 0, A_4);
            if ((flag2 || (PluginCore.cq.av.d() != num)) || (flag && (PluginCore.cq.av.e() != num2)))
            {
                if (!PluginCore.cq.v.d())
                {
                    return false;
                }
                if (dh.d() != 1)
                {
                    this.r++;
                    if (this.r >= er.i("DropToPeaceModeRetryCount"))
                    {
                        this.n.a(ActionLockType.ItemUse, this.j);
                        int num3 = this.a();
                        if (num3 == 0)
                        {
                            a5.a(eChatType.Errors, "You must add at least one wand to your profile.");
                            PluginCore.cq.c.StopMacro();
                            return false;
                        }
                        PluginCore.cq.ax.get_Actions().UseItem(num3, 0);
                        a5.a(eChatType.Warnings, "Warning: Macro detected bugged combat state. Attempting to wield an item to clear it.");
                        this.r = 0;
                        return false;
                    }
                    dh.a(1);
                    return false;
                }
                this.r = 0;
                if (((PluginCore.cq.n.c(num) == a1.h) && flag) && (PluginCore.cq.av.e() != num2))
                {
                    if (PluginCore.cq.av.d() != 0)
                    {
                        PluginCore.cq.ax.get_Actions().MoveItem(PluginCore.cq.av.d(), PluginCore.cg);
                        return false;
                    }
                    PluginCore.cq.av.a(num2, e5.c);
                    return false;
                }
                if (PluginCore.cq.av.d() != num)
                {
                    PluginCore.cq.av.a(num, e5.b);
                    return false;
                }
                if (flag && (PluginCore.cq.av.e() != num2))
                {
                    PluginCore.cq.av.a(num2, e5.c);
                    return false;
                }
                if (flag2)
                {
                    c8.a();
                    return false;
                }
            }
            CombatState state = this.a(PluginCore.cq.aw.get_WorldFilter().get_Item(PluginCore.cq.av.d()).get_ObjectClass());
            if (PluginCore.cq.ax.get_Actions().get_CombatMode() != state)
            {
                if (PluginCore.cq.v.d())
                {
                    dh.a(state);
                }
                return false;
            }
            return true;
        }
        catch (Exception exception)
        {
            ad.a(exception);
            return false;
        }
    }

    private int b()
    {
        foreach (int num2 in PluginCore.cq.j.e())
        {
            if (dh.b(num2) && (dh.c(num2) == PluginCore.cg))
            {
                if (b(PluginCore.cq.aw.get_WorldFilter().get_Item(num2)))
                {
                    if (this.c(num2) == a1.d)
                    {
                        return num2;
                    }
                }
                else
                {
                    ai.a("Warning: FCM ignoring item " + PluginCore.cq.aw.get_WorldFilter().get_Item(num2).get_Name() + " because it cannot currently be wielded.");
                }
            }
        }
        return 0;
    }

    private void b(cv A_0)
    {
        try
        {
            if (A_0.c() == ObjectClass.Monster)
            {
                if (this.f.ContainsKey(A_0.k))
                {
                    this.f.Remove(A_0.k);
                }
            }
            else if ((((A_0.c() == ObjectClass.WandStaffOrb) || (A_0.c() == ObjectClass.MeleeWeapon)) || ((A_0.c() == ObjectClass.MissileWeapon) || (A_0.c() == ObjectClass.Armor))) && PluginCore.cq.j.e().Contains(A_0.k))
            {
                er.a();
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public static bool b(WorldObject A_0)
    {
        if (A_0 == null)
        {
            return false;
        }
        return true;
    }

    public void b(int A_0)
    {
        if (dh.b(A_0))
        {
            WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0);
            if (((obj2.get_ObjectClass() == 0x1f) || (obj2.get_ObjectClass() == 1)) || ((obj2.get_ObjectClass() == 9) || e(obj2)))
            {
                if (obj2.get_HasIdData())
                {
                    this.a(A_0, true);
                }
                else
                {
                    PluginCore.cq.u.b(A_0, new b0.b(this.a));
                }
            }
        }
    }

    public static bool b(int A_0, int A_1, int A_2, string A_3)
    {
        return true;
    }

    public void c()
    {
        PluginCore.cq.ay.ao();
        if (PluginCore.cq.l.k.c != eNavType.Target)
        {
            if (PluginCore.cq.l.k.c == eNavType.Once)
            {
                PluginCore.cq.n.l = 0;
            }
            else
            {
                int num = 0;
                double maxValue = double.MaxValue;
                for (int i = 0; i < PluginCore.cq.l.k.b.Count; i++)
                {
                    PluginCore.cq.ay.bl[i][1][0] = "";
                    if (PluginCore.cq.l.k.b[i].c())
                    {
                        double num4 = dh.a(dh.a(PluginCore.cg, PluginCore.cq.ax.get_Actions()), PluginCore.cq.l.k.b[i].e());
                        if (num4 < maxValue)
                        {
                            maxValue = num4;
                            num = i;
                        }
                    }
                }
                PluginCore.cq.n.l = num;
            }
            if (PluginCore.cq.l.k.b.Count > 0)
            {
                PluginCore.cq.l.k.b[this.l].i();
                PluginCore.cq.ay.bl[PluginCore.cq.n.l][1][0] = "<<";
            }
            PluginCore.cq.ay.ae();
        }
    }

    private void c(cv A_0)
    {
        try
        {
            if (this.s.ContainsKey(A_0.k))
            {
                this.b(A_0.k);
            }
            if (A_0.c() == ObjectClass.Monster)
            {
                if (!this.f.ContainsKey(A_0.k))
                {
                    this.f.Add(A_0.k, new cf(A_0.g()));
                }
                PluginCore.cq.c.SchedulePoke();
            }
            else if ((((A_0.c() == ObjectClass.WandStaffOrb) || (A_0.c() == ObjectClass.MeleeWeapon)) || ((A_0.c() == ObjectClass.MissileWeapon) || (A_0.c() == ObjectClass.Armor))) && PluginCore.cq.j.e().Contains(A_0.k))
            {
                er.a();
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public static bool c(WorldObject A_0)
    {
        if (A_0 == null)
        {
            return false;
        }
        if (!A_0.get_HasIdData())
        {
            PluginCore.cq.u.c(A_0.get_Id());
            PluginCore.cq.n.a("Activate test failed [ID needed] (" + A_0.get_Name() + ")", e8.j);
            return false;
        }
        int num = A_0.Values(0x9e, 0);
        int num2 = A_0.Values(0x9f, 0);
        int num3 = A_0.Values(160, 0);
        if (!c(num, num2, num3, A_0.get_Name()))
        {
            PluginCore.cq.n.a("Activate test failed [unwieldable] (" + A_0.get_Name() + ")", e8.j);
            return false;
        }
        int num4 = A_0.Values(0xb0, 0);
        int num5 = A_0.Values(0x73, 0);
        int num6 = A_0.Values(0xbc, 0);
        int num7 = A_0.Values(0x6d, 0);
        int num8 = A_0.Values(110, 0);
        try
        {
            if (num4 != 0)
            {
                int num9 = PluginCore.cq.ax.get_Actions().get_Skill().get_Item(a((CharFilterSkillType) num4, true));
                if ((num5 != 0) && (num9 < num5))
                {
                    PluginCore.cq.n.a("Activate test failed [act skill] (" + A_0.get_Name() + "), ar=" + num4.ToString() + ", av=" + num5.ToString() + ", my=" + num9.ToString(), e8.j);
                    return false;
                }
            }
        }
        catch (Exception exception)
        {
            PluginCore.cq.n.a("Activate test failed [act skill] (" + A_0.get_Name() + "), Exception " + exception.ToString(), e8.j);
            return false;
        }
        try
        {
            int num10 = PluginCore.cq.a1;
            if ((num6 != 0) && (num10 != num6))
            {
                PluginCore.cq.n.a("Activate test failed [act race] (" + A_0.get_Name() + "), rr=" + num6.ToString() + ", my=" + num10.ToString(), e8.j);
                return false;
            }
        }
        catch (Exception exception2)
        {
            PluginCore.cq.n.a("Activate test failed [act race] (" + A_0.get_Name() + "), Exception " + exception2.ToString(), e8.j);
            return false;
        }
        try
        {
            int num11 = PluginCore.cq.ax.get_Actions().get_Skill().get_Item(14);
            if ((num7 != 0) && (num11 < num7))
            {
                PluginCore.cq.n.a("Activate test failed [act lore] (" + A_0.get_Name() + "), lr=" + num7.ToString() + ", my=" + num11.ToString(), e8.j);
                return false;
            }
        }
        catch (Exception exception3)
        {
            PluginCore.cq.n.a("Activate test failed [act lore] (" + A_0.get_Name() + "), Exception " + exception3.ToString(), e8.j);
            return false;
        }
        if ((num8 != 0) && (PluginCore.cq.aw.get_CharacterFilter().get_Rank() < num8))
        {
            PluginCore.cq.n.a("Activate test failed [act rank] (" + A_0.get_Name() + "), ar=" + num8.ToString() + ", my=" + PluginCore.cq.aw.get_CharacterFilter().get_Rank().ToString(), e8.j);
            return false;
        }
        PluginCore.cq.n.a("Activate test passed (" + A_0.get_Name() + ")", e8.j);
        return true;
    }

    public a1 c(int A_0)
    {
        WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0);
        if (obj2 != null)
        {
            if (obj2.get_ObjectClass() == 0x1f)
            {
                return a1.b;
            }
            if (obj2.get_ObjectClass() == 1)
            {
                return a1.c;
            }
            if (obj2.get_ObjectClass() != 9)
            {
                if (obj2.Values(0xd00000e, 0) == 0x200000)
                {
                    return a1.d;
                }
                if (e(obj2))
                {
                    return a1.i;
                }
                return a1.a;
            }
            switch (obj2.Values(0xd000011, 0))
            {
                case 0:
                    return a1.h;

                case 1:
                    return a1.e;

                case 2:
                    return a1.f;

                case 4:
                    return a1.g;
            }
        }
        return a1.a;
    }

    private static bool c(int A_0, int A_1, int A_2, string A_3)
    {
        switch (A_0)
        {
            case 1:
                if ((A_1 != 0) && (A_2 != 0))
                {
                    int num = dh.a((eGameSkillID) A_1, true);
                    if (num >= A_2)
                    {
                        break;
                    }
                    PluginCore.cq.n.a("Wield test failed [Test 4] (" + A_3 + "), wrt=" + A_0.ToString() + ", wra=" + A_1.ToString() + ", wrv=" + A_2.ToString() + ", base=" + num.ToString(), e8.j);
                    return false;
                }
                PluginCore.cq.n.a("Wield test failed [Test 1] (" + A_3 + "), wrt=" + A_0.ToString() + ", wra=" + A_1.ToString() + ", wrv=" + A_2.ToString(), e8.j);
                return false;

            case 2:
                if ((A_1 != 0) && (A_2 != 0))
                {
                    int num2 = dh.a((eGameSkillID) A_1, false);
                    if (num2 < A_2)
                    {
                        PluginCore.cq.n.a("Wield test failed [Test 4] (" + A_3 + "), wrt=" + A_0.ToString() + ", wra=" + A_1.ToString() + ", wrv=" + A_2.ToString() + ", base=" + num2.ToString(), e8.j);
                        return false;
                    }
                    break;
                }
                PluginCore.cq.n.a("Wield test failed [Test 3] (" + A_3 + "), wrt=" + A_0.ToString() + ", wra=" + A_1.ToString() + ", wrv=" + A_2.ToString(), e8.j);
                return false;

            case 7:
                if (PluginCore.cq.aw.get_CharacterFilter().get_Level() < A_2)
                {
                    PluginCore.cq.n.a("Wield test failed [Test 5] (" + A_3 + "), wrt=" + A_0.ToString() + ", wra=" + A_1.ToString() + ", wrv=" + A_2.ToString() + ", lv=" + PluginCore.cq.aw.get_CharacterFilter().get_Level().ToString(), e8.j);
                    return false;
                }
                break;
        }
        return true;
    }

    public int d()
    {
        c c = null;
        double num2;
        double maxValue = double.MaxValue;
        switch (er.e("PetRangeMode"))
        {
            case 1:
                num2 = er.h("PetCustomRange");
                break;

            default:
                num2 = er.h("AttackDistance");
                break;
        }
        foreach (cv cv in PluginCore.cq.p.a(ObjectClass.Monster))
        {
            c c2 = new c();
            c2.a(cv, num2, 0.0, false);
            if (c2.m && (c2.e < maxValue))
            {
                c = c2;
                maxValue = c2.e;
            }
        }
        if (c == null)
        {
            return 0;
        }
        MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> quad = c.a();
        an an = PluginCore.cq.x.c(c.c);
        int num4 = 0;
        int num5 = 0x7fffffff;
        int l = 0;
        foreach (int num7 in PluginCore.PC.c1)
        {
            if (!dh.b(num7) || (dh.c(num7) != PluginCore.cq.aw.get_CharacterFilter().get_Id()))
            {
                continue;
            }
            cv cv2 = PluginCore.cq.p.d(num7);
            if (((cv2 != null) && e(PluginCore.cq.aw.get_WorldFilter().get_Item(num7))) && this.e(cv2))
            {
                fn.a a = this.d(num7);
                if (a.n != eDamageElement.None)
                {
                    int num8 = 0x7fffffff;
                    if (((eDamageElement) quad.b) == a.n)
                    {
                        num8 = 0;
                    }
                    else
                    {
                        for (int i = 0; i < an.Count; i++)
                        {
                            if (a.n == ((eDamageElement) an[i]))
                            {
                                num8 = i + 1;
                                break;
                            }
                        }
                    }
                    if (((num4 == 0) || (num8 < num5)) || ((a.l > l) && (num8 == num5)))
                    {
                        l = a.l;
                        num5 = num8;
                        num4 = num7;
                    }
                }
            }
        }
        return num4;
    }

    public MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> d(cv A_0)
    {
        bool flag2;
        MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> quad = new MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int>(0, eDamageElement.Pierce, ePrismaticDamageBehavior.Any, 0);
        string str = A_0.g();
        aj.c c = PluginCore.cq.d.a(A_0);
        bool flag = false;
        if (dh.b(c.e) && (dh.c(c.e) == PluginCore.cg))
        {
            flag = false;
        }
        else if (c.e == 0)
        {
            flag = false;
        }
        else if (c.e == -1)
        {
            flag = true;
        }
        else
        {
            flag = true;
        }
        eDamageElement b = c.b;
        if (c.b == eDamageElement.Auto)
        {
            flag2 = true;
            quad.c = ePrismaticDamageBehavior.Any;
        }
        else if (c.b == eDamageElement.Prismatic)
        {
            flag2 = true;
            quad.c = ePrismaticDamageBehavior.ForcePrismatic;
        }
        else if (c.b == eDamageElement.Fists)
        {
            flag2 = false;
            quad.c = ePrismaticDamageBehavior.Any;
            b = eDamageElement.Bludgeon;
        }
        else
        {
            flag2 = false;
            quad.c = ePrismaticDamageBehavior.NoPrismatic;
        }
        an an = new an();
        if (flag && flag2)
        {
            an = PluginCore.cq.x.c(str);
        }
        else if (flag)
        {
            an = new an {
                b
            };
        }
        if (flag)
        {
            quad.a = this.a((int) c.d, an, PluginCore.cq.x.f(A_0.g()), false);
        }
        else
        {
            quad.a = c.e;
        }
        quad.d = this.a(quad.a, an, c, PluginCore.cq.x.f(A_0.g()));
        if (!flag2)
        {
            quad.b = b;
            return quad;
        }
        quad.b = eDamageElement.Bludgeon;
        bool flag3 = true;
        fn.a a = this.d(quad.a);
        quad.b = this.a(a.b, a.c, a.j);
        if (((eDamageElement) quad.b) != eDamageElement.None)
        {
            flag3 = false;
        }
        if (((PluginCore.cq.n.c(quad.a) == a1.b) && !dh.b(eGameSkillID.WarMagic)) && dh.b(eGameSkillID.VoidMagic))
        {
            flag3 = false;
            quad.b = eDamageElement.Void;
        }
        if (((PluginCore.cq.n.c(quad.a) == a1.b) && !dh.b(eGameSkillID.WarMagic)) && (!dh.b(eGameSkillID.VoidMagic) && dh.b(eGameSkillID.LifeMagic)))
        {
            ai.a("Warning: autoselecting drain as damage type. If you are not a martyr mage, you probably need to add your weapons to the items tab.");
            flag3 = false;
            quad.b = eDamageElement.DrainAuto;
        }
        if (flag3)
        {
            an an2 = PluginCore.cq.x.c(str);
            bool flag4 = false;
            foreach (eDamageElement element2 in an2)
            {
                if ((element2 != eDamageElement.None) && this.a(PluginCore.cq.n.c(quad.a), element2))
                {
                    quad.b = element2;
                    flag4 = true;
                    break;
                }
            }
            if (flag4)
            {
                return quad;
            }
            for (int i = 0; i < 7; i++)
            {
                eDamageElement item = (eDamageElement) i;
                if (!an2.Contains(item) && this.a(PluginCore.cq.n.c(quad.a), item))
                {
                    quad.b = item;
                    flag4 = true;
                    break;
                }
            }
            if (flag4)
            {
                ai.a("Warning: no ammunition available for any of target's possible damage types! Using unlisted damage type: " + quad.b.ToString());
                return quad;
            }
            ai.a("Warning: no ammunition available!!!");
        }
        return quad;
    }

    public static bool d(WorldObject A_0)
    {
        if (A_0 == null)
        {
            return false;
        }
        if (A_0.get_ObjectClass() != 9)
        {
            return false;
        }
        if (A_0.Values(0xd000011, 0) != 0)
        {
            return false;
        }
        if (!A_0.get_Name().Contains("Phial"))
        {
            return false;
        }
        return true;
    }

    public fn.a d(int A_0)
    {
        if (this.s.ContainsKey(A_0))
        {
            return this.s[A_0];
        }
        this.b(A_0);
        if (this.s.ContainsKey(A_0))
        {
            return this.s[A_0];
        }
        return new fn.a { a = 0, b = eImbueType.None, e = 0, d = false, f = false, j = eProtocolDamageType.None, n = eDamageElement.None };
    }

    public int e()
    {
        if (!PluginCore.cq.n.n.b(ActionLockType.ManaStoneUse))
        {
            int num = PluginCore.cq.ab.i();
            if (num != 0)
            {
                return num;
            }
            foreach (KeyValuePair<string, fz> pair in PluginCore.cq.l.h)
            {
                if (((fz) pair.Value) == fz.g)
                {
                    foreach (cv cv in PluginCore.cq.p.a(pair.Key))
                    {
                        if (PluginCore.cq.p.b(cv.k, PluginCore.cq.ax))
                        {
                            return cv.k;
                        }
                    }
                }
            }
            ai.a("Warning: No mana charges/stones available, but equipped items need mana.");
        }
        return 0;
    }

    public bool e(cv A_0)
    {
        fn.a a = this.d(A_0.k);
        if (a.n == eDamageElement.None)
        {
            return false;
        }
        if (a.l > PluginCore.cq.aw.get_CharacterFilter().get_Level())
        {
            return false;
        }
        if (a.m > dh.a(eGameSkillID.Summoning, true))
        {
            return false;
        }
        if (A_0.a(dt.aa, 0x270f) == 0)
        {
            return false;
        }
        return true;
    }

    public static bool e(WorldObject A_0)
    {
        cv cv = PluginCore.cq.p.d(A_0.get_Id());
        if (cv == null)
        {
            return false;
        }
        if (!cv.a.ContainsKey(280))
        {
            return false;
        }
        return (cv.a[280] == 0xd5);
    }

    internal eItemUseSpecifier e(int A_0)
    {
        v v = PluginCore.cq.l.c["ItemUseSpecifiers"].a(0, k.a(A_0));
        if (v == null)
        {
            return eItemUseSpecifier.WEAP_BothHands;
        }
        return (eItemUseSpecifier) k.e(v[1]);
    }

    public void f()
    {
        if (!this.x)
        {
            this.x = true;
            GC.SuppressFinalize(this);
            PluginCore.cq.p.b(new cj.c(this.c));
            PluginCore.cq.p.e(new cj.c(this.a));
            PluginCore.cq.p.a(new cj.c(this.b));
            this.v = null;
            this.w.remove_ChangeVital(new EventHandler<ChangeVitalEventArgs>(this.a));
            this.w = null;
        }
    }

    protected override void g()
    {
        try
        {
            this.f();
        }
        finally
        {
            base.Finalize();
        }
    }

    public class a
    {
        public int a;
        public eImbueType b;
        public eCleaveType c;
        public bool d;
        public int e;
        public bool f;
        public MySpell g;
        public int h;
        public int i;
        public eProtocolDamageType j;
        public int k;
        public int l;
        public int m;
        public eDamageElement n;
    }
}

