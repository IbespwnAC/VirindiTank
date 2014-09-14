using Decal.Adapter.Wrappers;
using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;

internal class cv
{
    public Dictionary<int, int> a = new Dictionary<int, int>();
    public Dictionary<int, string> b = new Dictionary<int, string>();
    public Dictionary<int, bool> c = new Dictionary<int, bool>();
    public Dictionary<int, double> d = new Dictionary<int, double>();
    public Dictionary<int, long> e = new Dictionary<int, long>();
    public Dictionary<int, int> f = new Dictionary<int, int>();
    public Dictionary<int, int> g = new Dictionary<int, int>();
    public List<int> h = new List<int>();
    public int i = -1;
    public bool j;
    public int k;
    public bool l;
    public bool m = true;
    public int n = 1;
    public DateTimeOffset o = DateTimeOffset.Now;
    public DateTimeOffset p = DateTimeOffset.MinValue;
    public bool q;
    public bool r;
    public int s;
    public List<bo> t = new List<bo>();
    public int u;
    public bool v;
    public dz w = new dz();
    private ObjectClass x;
    private bool y;

    private ObjectClass a()
    {
        ObjectClass unknown = ObjectClass.Unknown;
        int num = 0;
        if (this.a.ContainsKey(0xd00001a))
        {
            num = this.a[0xd00001a];
        }
        int num2 = 0;
        if (this.a.ContainsKey(0xd00001b))
        {
            num2 = this.a[0xd00001b];
        }
        int num3 = 0;
        if (this.a.ContainsKey(0xd000018))
        {
            num3 = this.a[0xd000018];
        }
        if ((num & 1) > 0)
        {
            unknown = ObjectClass.MeleeWeapon;
        }
        else if ((num & 2) > 0)
        {
            unknown = ObjectClass.Armor;
        }
        else if ((num & 4) > 0)
        {
            unknown = ObjectClass.Clothing;
        }
        else if ((num & 8) > 0)
        {
            unknown = ObjectClass.Jewelry;
        }
        else if ((num & 0x10) > 0)
        {
            unknown = ObjectClass.Monster;
        }
        else if ((num & 0x20) > 0)
        {
            unknown = ObjectClass.Food;
        }
        else if ((num & 0x40) > 0)
        {
            unknown = ObjectClass.Money;
        }
        else if ((num & 0x80) > 0)
        {
            unknown = ObjectClass.Misc;
        }
        else if ((num & 0x100) > 0)
        {
            unknown = ObjectClass.MissileWeapon;
        }
        else if ((num & 0x200) > 0)
        {
            unknown = ObjectClass.Container;
        }
        else if ((num & 0x400) > 0)
        {
            unknown = ObjectClass.Bundle;
        }
        else if ((num & 0x800) > 0)
        {
            unknown = ObjectClass.Gem;
        }
        else if ((num & 0x1000) > 0)
        {
            unknown = ObjectClass.SpellComponent;
        }
        else if ((num & 0x4000) > 0)
        {
            unknown = ObjectClass.Key;
        }
        else if ((num & 0x8000) > 0)
        {
            unknown = ObjectClass.WandStaffOrb;
        }
        else if ((num & 0x10000) > 0)
        {
            unknown = ObjectClass.Portal;
        }
        else if ((num & 0x40000) > 0)
        {
            unknown = ObjectClass.TradeNote;
        }
        else if ((num & 0x80000) > 0)
        {
            unknown = ObjectClass.ManaStone;
        }
        else if ((num & 0x100000) > 0)
        {
            unknown = ObjectClass.Services;
        }
        else if ((num & 0x200000) > 0)
        {
            unknown = ObjectClass.Plant;
        }
        else if ((num & 0x400000) > 0)
        {
            unknown = ObjectClass.BaseCooking;
        }
        else if ((num & 0x800000) > 0)
        {
            unknown = ObjectClass.BaseAlchemy;
        }
        else if ((num & 0x1000000) > 0)
        {
            unknown = ObjectClass.BaseFletching;
        }
        else if ((num & 0x2000000) > 0)
        {
            unknown = ObjectClass.CraftedCooking;
        }
        else if ((num & 0x4000000) > 0)
        {
            unknown = ObjectClass.CraftedAlchemy;
        }
        else if ((num & 0x8000000) > 0)
        {
            unknown = ObjectClass.CraftedFletching;
        }
        else if ((num & 0x20000000) > 0)
        {
            unknown = ObjectClass.Ust;
        }
        else if ((num & 0x40000000) > 0)
        {
            unknown = ObjectClass.Salvage;
        }
        if ((num2 & 8) > 0)
        {
            unknown = ObjectClass.Player;
        }
        else if ((num2 & 0x200) > 0)
        {
            unknown = ObjectClass.Vendor;
        }
        else if ((num2 & 0x1000) > 0)
        {
            unknown = ObjectClass.Door;
        }
        else if ((num2 & 0x2000) > 0)
        {
            unknown = ObjectClass.Corpse;
        }
        else if ((num2 & 0x4000) > 0)
        {
            unknown = ObjectClass.Lifestone;
        }
        else if ((num2 & 0x8000) > 0)
        {
            unknown = ObjectClass.Food;
        }
        else if ((num2 & 0x10000) > 0)
        {
            unknown = ObjectClass.HealingKit;
        }
        else if ((num2 & 0x20000) > 0)
        {
            unknown = ObjectClass.Lockpick;
        }
        else if ((num2 & 0x40000) > 0)
        {
            unknown = ObjectClass.Portal;
        }
        else if ((num2 & 0x800000) > 0)
        {
            unknown = ObjectClass.Foci;
        }
        else if ((num2 & 1) > 0)
        {
            unknown = ObjectClass.Container;
        }
        if ((((num & 0x2000) > 0) && ((num2 & 0x100) > 0)) && (unknown == ObjectClass.Unknown))
        {
            if ((num2 & 2) > 0)
            {
                unknown = ObjectClass.Journal;
            }
            else if ((num2 & 4) > 0)
            {
                unknown = ObjectClass.Sign;
            }
            else if ((num2 & 15) > 0)
            {
                unknown = ObjectClass.Book;
            }
        }
        if (((num & 0x2000) > 0) && ((num3 & 0x400000) > 0))
        {
            unknown = ObjectClass.Scroll;
        }
        if ((unknown == ObjectClass.Monster) && ((num2 & 0x10) == 0))
        {
            unknown = ObjectClass.Npc;
        }
        if ((unknown == ObjectClass.Monster) && ((num2 & 0x4000000) != 0))
        {
            unknown = ObjectClass.CombatPet;
        }
        return unknown;
    }

    public bool a(ce A_0)
    {
        return this.e.ContainsKey((int) A_0);
    }

    public unsafe void a(HooksWrapper A_0)
    {
        IntPtr ptr = A_0.PhysicsObject(this.k);
        if (ptr != IntPtr.Zero)
        {
            short num = *((short*) (ptr.ToPointer() + 0xa8));
            if ((num & 4) > 0)
            {
                this.l = true;
            }
            else
            {
                this.l = false;
            }
        }
    }

    public bool a(di A_0)
    {
        return this.b.ContainsKey((int) A_0);
    }

    public bool a(ds A_0)
    {
        return this.c.ContainsKey((int) A_0);
    }

    public bool a(dt A_0)
    {
        return this.a.ContainsKey((int) A_0);
    }

    public bool a(fx A_0)
    {
        return this.d.ContainsKey((int) A_0);
    }

    public long a(ce A_0, long A_1)
    {
        if (this.e.ContainsKey((int) A_0))
        {
            return this.e[(int) A_0];
        }
        return A_1;
    }

    public string a(di A_0, string A_1)
    {
        if (this.b.ContainsKey((int) A_0))
        {
            return this.b[(int) A_0];
        }
        return A_1;
    }

    public bool a(ds A_0, bool A_1)
    {
        if (this.c.ContainsKey((int) A_0))
        {
            return this.c[(int) A_0];
        }
        return A_1;
    }

    public int a(dt A_0, int A_1)
    {
        if (this.a.ContainsKey((int) A_0))
        {
            return this.a[(int) A_0];
        }
        return A_1;
    }

    public double a(fx A_0, double A_1)
    {
        if (this.d.ContainsKey((int) A_0))
        {
            return this.d[(int) A_0];
        }
        return A_1;
    }

    public bool b()
    {
        if (!this.a.ContainsKey(0xd000010))
        {
            return false;
        }
        return ((this.a[0xd000010] & 1) > 0);
    }

    public dz b(HooksWrapper A_0)
    {
        float num;
        float num2;
        float num3;
        int num4;
        if (!A_0.IsValidObject(this.k))
        {
            return new dz();
        }
        try
        {
            int num5 = A_0.PhysicsObject(this.k).ToInt32();
            if (num5 == 0)
            {
                return new dz();
            }
            num = num5[0x84];
            num2 = num5[0x88];
            num3 = num5[140];
            num4 = num5[0x4c];
        }
        catch
        {
            return new dz();
        }
        return dz.a(num, num2, num3 / 240f, num4);
    }

    public ObjectClass c()
    {
        if (!this.y)
        {
            this.x = this.a();
            this.y = true;
        }
        return this.x;
    }

    public override string d()
    {
        return string.Format("{0:X}: {1}, {2}", this.k, this.g(), this.c());
    }

    public string e()
    {
        string str = c0.a(this.a(dt.aq, 0));
        if (str == null)
        {
            return this.g();
        }
        return (str + " " + this.g());
    }

    public int f()
    {
        int num = 0;
        int num2 = 0;
        if (this.a.ContainsKey(0xd000002))
        {
            num = this.a[0xd000002];
        }
        if (this.a.ContainsKey(0xd00002b))
        {
            num2 = this.a[0xd00002b];
        }
        if (num != 0)
        {
            return num;
        }
        if (num2 != 0)
        {
            return num2;
        }
        return 0;
    }

    public string g()
    {
        if (this.b.ContainsKey(1))
        {
            return this.b[1];
        }
        return "???";
    }
}

