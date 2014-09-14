using Decal.Adapter;
using Decal.Filters;
using Decal.Interop.Filters;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using uTank2;

internal class dl : IDisposable
{
    private ev a;
    public int b = 300;
    public bool c;
    private MyDictionary<int, dl.a> d = new MyDictionary<int, dl.a>(0x16);
    private MyList<dl.c> e = new MyList<dl.c>(0x17);
    private bool f;
    private bool g;

    public dl(ev A_0)
    {
        this.a = A_0;
        this.a.a.c(new b2.a(this.a));
        this.a.a.b(new b2.a(this.b));
    }

    protected override void a()
    {
        try
        {
            this.j();
        }
        finally
        {
            base.Finalize();
        }
    }

    public void a(a0 A_0)
    {
        A_0.f();
        foreach (dl.c c in this.e)
        {
            if ((c.b != -1) && (c.b != PluginCore.cq.aw.get_CharacterFilter().get_Id()))
            {
                v v = new v(A_0);
                v[0] = k.a(c.b);
                v[1] = k.a(c.a);
                A_0.c(v);
            }
        }
    }

    public void a(dl.c A_0)
    {
        this.e.Add(A_0);
    }

    public bool a(int A_0)
    {
        bool flag;
        return this.a(A_0, true, out flag);
    }

    private MyList<eDamageElement> a(string A_0)
    {
        MyList<eDamageElement> list = new MyList<eDamageElement>(0x15);
        if (A_0 == "All")
        {
            list.Add(eDamageElement.Acid);
            list.Add(eDamageElement.Bludgeon);
            list.Add(eDamageElement.Cold);
            list.Add(eDamageElement.Fire);
            list.Add(eDamageElement.Lightning);
            list.Add(eDamageElement.Pierce);
            list.Add(eDamageElement.Slash);
            return list;
        }
        if (A_0 != "None")
        {
            foreach (char ch in A_0)
            {
                switch (ch)
                {
                    case 'P':
                    {
                        eDamageElement pierce = eDamageElement.Pierce;
                        if (!list.Contains(pierce))
                        {
                            list.Add(pierce);
                        }
                        break;
                    }
                    case 'S':
                    {
                        eDamageElement slash = eDamageElement.Slash;
                        if (!list.Contains(slash))
                        {
                            list.Add(slash);
                        }
                        break;
                    }
                    case 'A':
                    {
                        eDamageElement acid = eDamageElement.Acid;
                        if (!list.Contains(acid))
                        {
                            list.Add(acid);
                        }
                        break;
                    }
                    case 'B':
                    {
                        eDamageElement bludgeon = eDamageElement.Bludgeon;
                        if (!list.Contains(bludgeon))
                        {
                            list.Add(bludgeon);
                        }
                        break;
                    }
                    case 'C':
                    {
                        eDamageElement cold = eDamageElement.Cold;
                        if (!list.Contains(cold))
                        {
                            list.Add(cold);
                        }
                        break;
                    }
                    case 'F':
                    {
                        eDamageElement fire = eDamageElement.Fire;
                        if (!list.Contains(fire))
                        {
                            list.Add(fire);
                        }
                        break;
                    }
                    case 'L':
                    {
                        eDamageElement lightning = eDamageElement.Lightning;
                        if (!list.Contains(lightning))
                        {
                            list.Add(lightning);
                        }
                        break;
                    }
                }
            }
        }
        return list;
    }

    private void a(ActiveSpellInfo A_0)
    {
        if (!A_0.IsCoolDown)
        {
            MySpell spell = A_0.Spell;
            if (this.d.ContainsKey(spell.RealFamily))
            {
                dl.b b;
                b = new dl.b {
                    b = spell.Quality,
                    c = spell.Id,
                    d = A_0.ExpireTime,
                    a = b.d
                };
                this.d[spell.RealFamily].a.Add(b);
            }
            else
            {
                dl.a a = new dl.a();
                dl.b item = new dl.b();
                a.a = new MyList<dl.b>(0x18);
                item.b = spell.Quality;
                item.c = spell.Id;
                item.d = A_0.ExpireTime;
                item.a = item.d;
                a.a.Add(item);
                this.d.Add(spell.RealFamily, a);
            }
            PluginCore.PC.d(A_0.Id, PluginCore.cq.aw.get_CharacterFilter().get_Id(), (int) (A_0.Duration * 1000.0));
        }
    }

    private MySpell a(out int A_0, out int A_1)
    {
        this.g = false;
        MySpell spell = null;
        foreach (int num in this.i())
        {
            int quality;
            MySpell spell2 = this.a.h.a(num, false);
            if (spell2 == null)
            {
                quality = -1;
            }
            else
            {
                quality = spell2.Quality;
            }
            bool flag = false;
            if (this.d.ContainsKey(this.a.e.b(num).RealFamily))
            {
                foreach (dl.b b in this.d[this.a.e.b(num).RealFamily].a)
                {
                    if (b.b >= quality)
                    {
                        TimeSpan span = (TimeSpan) (b.a - DateTimeOffset.Now);
                        if (span.TotalSeconds >= this.b)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }
            if (!flag && (spell2 != null))
            {
                spell = spell2;
                A_0 = PluginCore.cq.aw.get_CharacterFilter().get_Id();
                A_1 = 0;
                return spell;
            }
            if ((!flag && (spell2 == null)) && !PluginCore.cq.n.i.Contains(num))
            {
                PluginCore.cq.n.i.Add(num);
                ai.a("No spell known for class including: " + this.a.e.b(num).Name + ", buff SKIPPED.");
            }
        }
        foreach (dl.c c in this.c())
        {
            if (!dh.b(this.b(c.b)))
            {
                ai.a("Warning: item " + c.b + " is in profile but not found in inventory. Skipping buffs for item.");
            }
            else if (c.a != -1)
            {
                MySpell spell3 = this.a.h.a(c.a, false);
                if ((spell3 != null) && (this.a.i.a(this.b(c.b), spell3).TotalSeconds < this.b))
                {
                    spell = spell3;
                    A_0 = this.b(c.b);
                    A_1 = 0;
                    return spell;
                }
            }
        }
        if (this.c && !this.a.n.n.b(ActionLockType.ItemUse))
        {
            foreach (string str in this.a.l.g.Keys)
            {
                MySpell spell4 = this.a.l.g[str];
                bool flag2 = false;
                if (this.d.ContainsKey(spell4.RealFamily))
                {
                    foreach (dl.b b2 in this.d[spell4.RealFamily].a)
                    {
                        if (b2.b >= spell4.Quality)
                        {
                            TimeSpan span3 = (TimeSpan) (b2.a - DateTimeOffset.Now);
                            if (span3.TotalSeconds >= this.b)
                            {
                                flag2 = true;
                                break;
                            }
                        }
                    }
                }
                if (spell4.isFellowship && !PluginCore.cq.ai.c())
                {
                    ai.a(string.Format("Skipping consumable buff spell \"{0}\" on {1} because it is a fellowship spell and you are not in a fellowship.", spell4.Name, str));
                }
                else
                {
                    int num3 = dh.e(str);
                    cv cv = PluginCore.cq.p.d(num3);
                    if (((cv != null) && !flag2) && ((num3 != 0) && !cx.b(cv)))
                    {
                        this.g = true;
                        spell = spell4;
                        A_0 = PluginCore.cq.aw.get_CharacterFilter().get_Id();
                        A_1 = num3;
                        return spell;
                    }
                }
            }
        }
        A_0 = 0;
        A_1 = 0;
        return spell;
    }

    public bool a(int A_0, bool A_1, out bool A_2)
    {
        int num;
        int num2;
        this.c = A_1;
        this.b = A_0;
        bool flag = this.a(out num, out num2) != null;
        A_2 = this.g;
        return flag;
    }

    private void a(int A_0, string A_1, ref MyList<int> A_2)
    {
        if ((A_0 == 3) || (A_0 == 2))
        {
            MySpell spell = this.a.h.a(A_1);
            if ((spell != null) && spell.isValid)
            {
                A_2.Add(spell.Id);
            }
            else
            {
                ai.a("Unknown skill detected! Unable to buff this. (" + A_1 + ")");
            }
        }
    }

    public void b()
    {
        this.a.i.c(PluginCore.cq.aw.get_CharacterFilter().get_Id());
    }

    public void b(a0 A_0)
    {
        this.e.Clear();
        foreach (v v in A_0.d())
        {
            this.e.Add(new dl.c(k.e(v[0]), k.e(v[1])));
            PluginCore.cq.n.b(k.e(v[0]));
        }
    }

    public int b(int A_0)
    {
        if (A_0 == -1)
        {
            return this.a.av.d();
        }
        return A_0;
    }

    private void b(ActiveSpellInfo A_0)
    {
        if (!A_0.IsCoolDown)
        {
            if (this.d.ContainsKey(A_0.Spell.RealFamily))
            {
                for (int i = this.d[A_0.Spell.RealFamily].a.Count - 1; i >= 0; i--)
                {
                    if (this.d[A_0.Spell.RealFamily].a[i].c == A_0.Id)
                    {
                        this.d[A_0.Spell.RealFamily].a.RemoveAt(i);
                    }
                }
            }
            PluginCore.PC.b(A_0.Id, PluginCore.cq.aw.get_CharacterFilter().get_Id());
        }
    }

    public MyList<dl.c> c()
    {
        MyList<eDamageElement> list2;
        MyList<dl.c> list = new MyList<dl.c>(20) {
            new dl.c(PluginCore.cq.aw.get_CharacterFilter().get_Id(), this.a.h.a(0x63).Id)
        };
        int num = er.e("BuffProfile_Banes");
        if (num == 1)
        {
            list2 = this.a(er.f("BuffProfile-Banes"));
        }
        else
        {
            list2 = this.a(er.b("BuffProfile_Banes", num));
        }
        foreach (eDamageElement element in list2)
        {
            list.Add(new dl.c(PluginCore.cq.aw.get_CharacterFilter().get_Id(), this.a.h.a(element).Id));
        }
        foreach (dl.c c in this.e)
        {
            if (this.a.e.c(c.a) && !this.a.e.b(c.a).isUntargetted)
            {
                list.Add(c);
            }
        }
        return list;
    }

    public void c(int A_0)
    {
        for (int i = this.e.Count - 1; i >= 0; i--)
        {
            if (this.e[i].b == A_0)
            {
                this.e.RemoveAt(i);
            }
        }
    }

    public void d()
    {
        foreach (KeyValuePair<int, dl.a> pair in this.d)
        {
            for (int i = 0; i < pair.Value.a.Count; i++)
            {
                pair.Value.a[i].a = DateTimeOffset.Now;
            }
        }
        this.a.i.g();
    }

    public MyList<int> e()
    {
        MyList<int> list = new MyList<int>(0x12);
        foreach (dl.c c in this.e)
        {
            if ((!list.Contains(c.b) && (c.b != -1)) && (c.b != PluginCore.cq.aw.get_CharacterFilter().get_Id()))
            {
                list.Add(c.b);
            }
        }
        return list;
    }

    public void f()
    {
        int num = 0;
        int num2 = 0;
        MySpell spell = this.a(out num, out num2);
        if ((spell != null) && (num2 == 0))
        {
            this.a.g.a(spell, num);
        }
        else if (num2 != 0)
        {
            if (cx.a(PluginCore.cq.p.d(num2)))
            {
                if (!PluginCore.cq.ap.d())
                {
                    PluginCore.cq.n.a("Buffing: item selected with cooldown and not busy. " + PluginCore.cq.aw.get_WorldFilter().get_Item(num2).get_Name(), e8.e);
                    this.a.ax.get_Actions().UseItem(num2, 0);
                    this.a.n.n.a(ActionLockType.ItemUse, this.a.n.j);
                }
                else
                {
                    PluginCore.cq.n.a("Buffing: item selected with cooldown, waiting for idle. " + PluginCore.cq.aw.get_WorldFilter().get_Item(num2).get_Name(), e8.e);
                }
            }
            else
            {
                PluginCore.cq.n.a("Buffing: regular item selected. " + PluginCore.cq.aw.get_WorldFilter().get_Item(num2).get_Name(), e8.e);
                this.a.ax.get_Actions().UseItem(num2, 0);
                this.a.n.n.a(ActionLockType.ItemUse, this.a.n.j);
            }
        }
    }

    public MyDictionary<int, int> g()
    {
        MyDictionary<int, int> dictionary = new MyDictionary<int, int>(0x12);
        foreach (dl.c c in this.e)
        {
            if ((!dictionary.ContainsKey(c.b) && (c.b != -1)) && (c.b != PluginCore.cq.aw.get_CharacterFilter().get_Id()))
            {
                dictionary.Add(c.b, c.a);
            }
        }
        return dictionary;
    }

    public void h()
    {
        foreach (KeyValuePair<int, dl.a> pair in this.d)
        {
            for (int i = 0; i < pair.Value.a.Count; i++)
            {
                pair.Value.a[i].a = pair.Value.a[i].d;
            }
        }
        this.a.i.f();
    }

    public MyList<int> i()
    {
        MyList<eDamageElement> list2;
        MyList<int> list = new MyList<int>(0x13) {
            this.a.e.a("Creature Enchantment Mastery Self I").Id,
            this.a.e.a("Focus Self I").Id,
            this.a.e.a("Willpower Self I").Id,
            this.a.e.a("Mana Conversion Mastery Self I").Id,
            this.a.e.a("Life Magic Mastery Self I").Id
        };
        FileService service = CoreManager.get_Current().get_FileService() as FileService;
        SkillInfo o = null;
        for (int i = 0; i < service.get_SkillTable().get_Length(); i++)
        {
            try
            {
                o = PluginCore.cq.aw.get_CharacterFilter().get_Underlying().get_Skill((eSkillID) service.get_SkillTable().get_Item(i).get_Id());
                this.a(o.get_Training(), o.get_Name(), ref list);
            }
            finally
            {
                if (o != null)
                {
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
            }
        }
        list.Add(this.a.e.a("Strength Self I").Id);
        list.Add(this.a.e.a("Endurance Self I").Id);
        list.Add(this.a.e.a("Coordination Self I").Id);
        list.Add(this.a.e.a("Quickness Self I").Id);
        list.Add(this.a.e.a("Regeneration Self I").Id);
        list.Add(this.a.e.a("Rejuvenation Self I").Id);
        list.Add(this.a.e.a("Mana Renewal Self I").Id);
        list.Add(this.a.h.b(eDamageElement.Physical).Id);
        int num2 = er.e("BuffProfile_Prots");
        if (num2 == 1)
        {
            list2 = this.a(er.f("BuffProfile-Prots"));
        }
        else
        {
            list2 = this.a(er.b("BuffProfile_Prots", num2));
        }
        foreach (eDamageElement element in list2)
        {
            list.Add(this.a.h.b(element).Id);
        }
        foreach (int num3 in PluginCore.cq.l.i)
        {
            list.Add(num3);
        }
        Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
        foreach (dl.c c in this.e)
        {
            if (this.a.e.c(c.a) && this.a.e.b(c.a).isUntargetted)
            {
                dictionary[c.a] = true;
            }
        }
        foreach (KeyValuePair<int, bool> pair in dictionary)
        {
            list.Add(pair.Key);
        }
        Dictionary<int, bool> dictionary2 = new Dictionary<int, bool>();
        foreach (int num4 in PluginCore.cq.l.j)
        {
            if (this.a.e.c(num4))
            {
                dictionary2[this.a.e.b(num4).RealFamily] = true;
            }
        }
        for (int j = list.Count - 1; j >= 0; j--)
        {
            int num6 = list[j];
            if (this.a.e.c(num6) && dictionary2.ContainsKey(this.a.e.b(num6).RealFamily))
            {
                list.RemoveAt(j);
            }
        }
        return list;
    }

    public void j()
    {
        if (!this.f)
        {
            this.f = true;
            GC.SuppressFinalize(this);
            this.a.a.a(new b2.a(this.a));
            this.a.a.d(new b2.a(this.b));
            this.a = null;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct a
    {
        public MyList<dl.b> a;
    }

    private class b
    {
        public DateTimeOffset a;
        public int b;
        public int c;
        public DateTimeOffset d;
    }

    public class c
    {
        public int a;
        public int b;

        public c(int A_0, int A_1)
        {
            this.a = A_1;
            this.b = A_0;
        }
    }
}

