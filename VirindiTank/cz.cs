using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using uTank2;
using uTank2.LootPlugins;

internal class cz : IDisposable
{
    private WorldFilter a;
    private bool b;
    private MyDictionary<int, cz.a> c = new MyDictionary<int, cz.a>(0x31);
    private MyDictionary<int, cz.a> d = new MyDictionary<int, cz.a>(50);
    private MyDictionary<string, int> e = new MyDictionary<string, int>(0x3e7);
    private int f;
    private int g;
    private int h;
    private DateTimeOffset i;

    public cz(PluginCore A_0, CoreManager A_1, PluginHost A_2, cj A_3)
    {
        this.a = A_1.get_WorldFilter();
        this.a.add_ChangeObject(new EventHandler<ChangeObjectEventArgs>(this.a));
        this.a.add_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
        A_3.f(new cj.c(this.a));
        A_3.l(new cj.c(this.b));
    }

    public void a()
    {
        if (!this.b)
        {
            this.b = true;
            GC.SuppressFinalize(this);
            this.a.remove_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
            this.a.remove_ChangeObject(new EventHandler<ChangeObjectEventArgs>(this.a));
            this.a = null;
        }
    }

    private void a(cv A_0)
    {
        try
        {
            int k = A_0.k;
            if (((PluginCore.cq.aw.get_WorldFilter().get_Item(k) != null) && ((PluginCore.cq.q.j != 0) && (PluginCore.cq.aw.get_WorldFilter().get_Item(k).get_Container() == PluginCore.cq.q.j))) && !this.c.ContainsKey(k))
            {
                this.h--;
                cz.a a = new cz.a {
                    c = this.b(k)
                };
                if (a.c)
                {
                    PluginCore.cq.u.a(k, b0.a.b);
                }
                else
                {
                    this.a(k, a);
                }
                this.c.Add(k, a);
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void a(int A_0)
    {
        PluginCore.cq.n.a("LootList Clear (NewCorpse)", e8.k);
        this.i = DateTimeOffset.Now;
        this.h = A_0;
        this.c.Clear();
        this.d.Clear();
        this.e.Clear();
        this.f = 0;
        this.g = 0;
        foreach (WorldObject obj2 in PluginCore.cq.aw.get_WorldFilter().GetByContainer(PluginCore.cq.q.j))
        {
            this.h--;
            cz.a a = new cz.a {
                c = this.b(obj2.get_Id())
            };
            if (a.c)
            {
                PluginCore.cq.u.a(obj2.get_Id(), b0.a.b);
            }
            else
            {
                this.a(obj2.get_Id(), a);
            }
            this.c.Add(obj2.get_Id(), a);
        }
    }

    private void a(int A_0, cz.a A_1)
    {
        LootAction action = PluginCore.cq.ag.a(A_0);
        WorldObject obj2 = CoreManager.get_Current().get_WorldFilter().get_Item(A_0);
        if (obj2 != null)
        {
            switch (action.a)
            {
                case eLootAction.NoLoot:
                    goto Label_00BF;

                case eLootAction.KeepUpTo:
                {
                    string str = obj2.get_Name();
                    int num = dh.a(str);
                    if (this.e.ContainsKey(str))
                    {
                        num += this.e[str];
                    }
                    if (num >= action.b)
                    {
                        goto Label_00BF;
                    }
                    if (this.e.ContainsKey(str))
                    {
                        Dictionary<string, int> dictionary;
                        string str2;
                        (dictionary = this.e)[str2 = str] = dictionary[str2] + 1;
                    }
                    else
                    {
                        this.e[str] = 1;
                    }
                    break;
                }
            }
            A_1.f = action;
            this.d.Add(A_0, A_1);
        }
        return;
    Label_00BF:
        if (this.a(A_0, true))
        {
            A_1.f = LootAction.a();
            this.d.Add(A_0, A_1);
        }
        else
        {
            if (PluginCore.cq.ab.a(obj2))
            {
                int num2 = PluginCore.cq.ab.f() - this.f;
                if (num2 > 0)
                {
                    this.f++;
                    A_1.f = new LootAction(eLootAction.ManaStone);
                    this.d.Add(A_0, A_1);
                    return;
                }
            }
            if (PluginCore.cq.ab.b(obj2))
            {
                int num3 = PluginCore.cq.ab.h() - this.g;
                if (num3 > 0)
                {
                    this.g++;
                    A_1.f = new LootAction(eLootAction.ManaTank);
                    this.d.Add(A_0, A_1);
                }
            }
        }
    }

    public bool a(int A_0, bool A_1)
    {
        if ((PluginCore.cq.aw.get_WorldFilter().get_Item(A_0).get_ObjectClass() == 0x2a) && er.j("ReadUnknownScrolls"))
        {
            int num = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0).Values(0xd000008, 0);
            if (!PluginCore.cq.aw.get_CharacterFilter().IsSpellKnown(num))
            {
                int num2 = PluginCore.cq.e.b(num).Difficulty - 15;
                int skillWithSchool = PluginCore.cq.e.b(num).SkillWithSchool;
                if (num2 <= skillWithSchool)
                {
                    if (A_1)
                    {
                        if (!PluginCore.cq.n.h.ContainsKey(num))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void a(object A_0, ChangeObjectEventArgs A_1)
    {
        try
        {
            int num;
            if (PluginCore.cq.aw.get_WorldFilter().get_Item(A_1.get_Changed().get_Id()) == null)
            {
                PluginCore.cq.n.a("RETURN NULL ITEM", e8.k);
                return;
            }
            if (A_1.get_Change() != 1)
            {
                return;
            }
            if (PluginCore.cq.q.m != PluginCore.cq.q.j)
            {
                PluginCore.cq.n.a("RETURN WRONG CORPSE (" + A_1.get_Changed().get_Name() + ")", e8.k);
                return;
            }
            if (dh.c(A_1.get_Changed().get_Id()) != PluginCore.cq.aw.get_CharacterFilter().get_Id())
            {
                goto Label_045B;
            }
            if (!this.d.ContainsKey(A_1.get_Changed().get_Id()) || !this.d[A_1.get_Changed().get_Id()].a)
            {
                goto Label_042B;
            }
            PluginCore.cq.n.a("Got item in lootlist (" + A_1.get_Changed().get_Name() + "," + this.d[A_1.get_Changed().get_Id()].f.a.ToString() + ")", e8.k);
            if (!PluginCore.cq.n.b)
            {
                goto Label_048B;
            }
            LootAction f = this.d[A_1.get_Changed().get_Id()].f;
            switch (f.a)
            {
                case eLootAction.Salvage:
                    if ((A_1.get_Changed().Values(0xab, 0) == 0) && string.IsNullOrEmpty(A_1.get_Changed().Values(8, "")))
                    {
                        if (A_1.get_Changed().Values(0x83, 0) != 0)
                        {
                            break;
                        }
                        ai.a("Warning: Lootplugin attempted to classify item " + A_1.get_Changed().get_Name() + " for salvaging, but that item does not have a salvage material. Ignoring it.");
                    }
                    goto Label_03E7;

                case eLootAction.Read:
                    num = PluginCore.cq.aw.get_WorldFilter().get_Item(A_1.get_Changed().get_Id()).Values(0xd000008, 0);
                    if (num != 0)
                    {
                        if (A_1.get_Changed().get_ObjectClass() == 0x2a)
                        {
                            goto Label_02EF;
                        }
                        ai.a("Warning: Lootplugin attempted to classify item " + A_1.get_Changed().get_Name() + " for reading, but that item does not appear to be a scroll. Ignoring it.");
                    }
                    goto Label_03E7;

                case eLootAction.ManaStone:
                    if (this.f > 0)
                    {
                        this.f--;
                    }
                    PluginCore.cq.ab.b(A_1.get_Changed().get_Id());
                    goto Label_03E7;

                case eLootAction.ManaTank:
                    if ((A_1.get_Changed().Values(0xab, 0) == 0) && string.IsNullOrEmpty(A_1.get_Changed().Values(8, "")))
                    {
                        if (this.g > 0)
                        {
                            this.g--;
                        }
                        PluginCore.cq.ab.c(A_1.get_Changed().get_Id());
                    }
                    goto Label_03E7;

                default:
                    PluginCore.cq.n.g.Add(A_1.get_Changed().get_Id(), f.a);
                    goto Label_03E7;
            }
            PluginCore.cq.t.c(A_1.get_Changed().get_Id());
            PluginCore.cq.n.a("S: Object \"" + A_1.get_Changed().get_Name() + "\" added.", e8.c);
            goto Label_03E7;
        Label_02EF:
            if (!PluginCore.cq.n.h.ContainsKey(num))
            {
                PluginCore.cq.n.h.Add(num, A_1.get_Changed().get_Id());
            }
        Label_03E7:
            if (this.e.ContainsKey(A_1.get_Changed().get_Name()))
            {
                Dictionary<string, int> dictionary;
                string str;
                (dictionary = this.e)[str = A_1.get_Changed().get_Name()] = dictionary[str] - 1;
            }
            goto Label_048B;
        Label_042B:
            PluginCore.cq.n.a("ITEM NOT IN LOOTLIST (" + A_1.get_Changed().get_Name() + ")", e8.k);
            goto Label_048B;
        Label_045B:
            PluginCore.cq.n.a("STORAGECHANGE NONINVENTORY (" + A_1.get_Changed().get_Name() + ")", e8.k);
            return;
        Label_048B:
            if (this.d.ContainsKey(A_1.get_Changed().get_Id()))
            {
                this.d.Remove(A_1.get_Changed().get_Id());
            }
            if (this.c.ContainsKey(A_1.get_Changed().get_Id()))
            {
                this.c.Remove(A_1.get_Changed().get_Id());
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, ReleaseObjectEventArgs A_1)
    {
        try
        {
            if (this.d.ContainsKey(A_1.get_Released().get_Id()))
            {
                this.d.Remove(A_1.get_Released().get_Id());
            }
            if (this.c.ContainsKey(A_1.get_Released().get_Id()))
            {
                this.c.Remove(A_1.get_Released().get_Id());
            }
            if (PluginCore.cq.n.g.ContainsKey(A_1.get_Released().get_Id()))
            {
                PluginCore.cq.n.g.Remove(A_1.get_Released().get_Id());
            }
            if (PluginCore.cq.n.h.ContainsValue(A_1.get_Released().get_Id()))
            {
                for (int i = 0; i < PluginCore.cq.n.h.Keys.Count; i++)
                {
                    if (PluginCore.cq.n.h[PluginCore.cq.n.h.Keys[i]] == A_1.get_Released().get_Id())
                    {
                        PluginCore.cq.n.h.Remove(PluginCore.cq.n.h.Keys[i]);
                        return;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void b()
    {
        PluginCore.cq.n.a("LootList Clear (ClosedCorpse)", e8.k);
        PluginCore.cq.u.a(b0.a.b);
        this.h = 0;
        this.c.Clear();
        this.d.Clear();
        this.e.Clear();
        this.f = 0;
        this.g = 0;
    }

    private void b(cv A_0)
    {
        int k = A_0.k;
        if ((this.c.ContainsKey(k) && this.c[k].c) && !this.c[k].d)
        {
            this.c[k].d = true;
            this.a(k, this.c[k]);
        }
    }

    public bool b(int A_0)
    {
        return ((PluginCore.cq.q.e.ContainsKey(PluginCore.cq.q.j) && PluginCore.cq.q.e[PluginCore.cq.q.j].h) || (PluginCore.cq.ag.b(A_0) || ((((PluginCore.cq.ab.h() - this.g) > 0) && PluginCore.cq.p.i.ContainsKey(A_0)) && PluginCore.cq.p.i[A_0].b())));
    }

    public bool c()
    {
        return (this.d.Count > 0);
    }

    public bool d()
    {
        TimeSpan span = (TimeSpan) (DateTimeOffset.Now - this.i);
        if ((span > TimeSpan.FromSeconds(er.h("CorpseItemAppearanceTimeoutSeconds"))) && (this.h > 0))
        {
            PluginCore.e("Abandoned attempting to loot corpse. Item appearance timeout occurred. (Empty corpse bug)");
            this.h = 0;
        }
        if (this.h > 0)
        {
            return false;
        }
        bool flag = false;
        foreach (int num in this.c.Keys)
        {
            if (this.c[num].c && !this.c[num].d)
            {
                flag = true;
                break;
            }
        }
        if (flag && (span > TimeSpan.FromSeconds(er.h("CorpseItemIDTimeoutSeconds"))))
        {
            PluginCore.e("Abandoned attempting to loot corpse. Unable to recieve ID for all items.");
            flag = false;
        }
        if (flag)
        {
            return false;
        }
        if (this.d.Count > 0)
        {
            return false;
        }
        return true;
    }

    protected override void e()
    {
        try
        {
            this.a();
        }
        finally
        {
            base.Finalize();
        }
    }

    public void f()
    {
        if (this.c())
        {
            int key = 0;
            int e = -2147483648;
            foreach (int num3 in this.d.Keys)
            {
                if (this.d[num3].e > e)
                {
                    key = num3;
                    e = this.d[num3].e;
                }
            }
            this.d[key].a = true;
            cz.a local1 = this.d[key];
            local1.g++;
            if (this.d[key].g > 20)
            {
                this.d.Remove(key);
            }
            else
            {
                PluginCore.cq.ax.get_Actions().UseItem(key, 0);
            }
        }
    }

    private class a
    {
        public bool a = false;
        public DateTimeOffset b = DateTimeOffset.Now;
        public bool c;
        public bool d = false;
        public int e;
        public LootAction f = LootAction.NoLoot;
        public int g;
    }
}

